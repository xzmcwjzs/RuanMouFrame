using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xzmcwjzs.ntu.Bussiness.Interface;

namespace xzmcwjzs.ntu.Bussiness.Service
{
  public  class BaseService<T>: IBaseService<T> where T :class
    {
        //通过 构造函数 注入
        public DbContext Context { get; set; }
        private DbSet<T> TDbSet;
        public BaseService(DbContext context)
        {
            this.Context = context;
            this.TDbSet = this.Context.Set<T>();
        }
        public T Insert(T t)
        {
            this.TDbSet.Add(t);
            this.Commit();
            return t;
        }

        public T Find(int id)
        {
            return this.TDbSet.Find(id);
        }

        public List<T> FindAll()
        {
            return this.TDbSet == null ? null : TDbSet.ToList();
        }

        public IQueryable<T> Set()
        {
            return this.TDbSet;
        }

        public void Update(T t)
        {
            if (t == null) throw new Exception("t is null");
            this.Commit();
        }

        public void Delete(T t)
        {
            if (t == null) throw new Exception("t is null");
            this.TDbSet.Remove(t);
            this.Commit();
        }

        public void Delete(int Id)
        {
            T t = this.Find(Id);
            if (t == null) throw new Exception("t is null");
            this.TDbSet.Remove(t);
            this.Commit();
        }

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public IQueryable<T> ExcuteQuery(string sql, SqlParameter[] parameters)
        {
            return this.Context.Database.SqlQuery<T>(sql, parameters).AsQueryable();
        }

        public void Excute(string sql, SqlParameter[] parameters)
        {
            DbContextTransaction trans = null;
            try
            {
                trans = this.Context.Database.BeginTransaction();
                Context.Database.ExecuteSqlCommand(sql, parameters);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                    trans.Rollback();
                throw ex;
            }
        }
    }
}
