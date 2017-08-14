using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xzmcwjzs.ntu.Bussiness.Interface;

namespace xzmcwjzs.ntu.Bussiness.Service
{
  public  class BaseService<T>: IBaseService<T> where T :class
    {
        //通过 构造函数 注入
        private DbContext Context { get; set; }
         
        public BaseService(DbContext context)
        {
            this.Context = context;

        }
        public void Insert(T t)
        {
            Context.Set<T>().Add(t);
            Context.SaveChanges();
        }

        public T Find(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> FindAll()
        {
            throw new Exception();
        }

        public void Update(T t)
        {
            throw new Exception();
        }

        public void Delete(T t)
        {
            throw new Exception();
        }
    }
}
