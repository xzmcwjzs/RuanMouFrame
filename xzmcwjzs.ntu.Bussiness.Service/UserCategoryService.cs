using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xzmcwjzs.ntu.Bussiness.Interface;
using xzmcwjzs.ntu.EF.Model.Entities;

namespace xzmcwjzs.ntu.Bussiness.Service
{

    public class UserCategoryService:BaseService<JD_Commodity_001>, IUserCategoryService
    {
        //子类默认 具有无参构造函数
        private DbContext Context = null;
        public UserCategoryService(DbContext dbcontext) : base(dbcontext)
        {
            this.Context = dbcontext;
        }

        public void ComplexOperation()
        {
            //using (JDContext context = new JDContext())
            //{
            //    var user = context.User.Find(2); 
            //    var category = context.Category.Find(2);

            //}
            var user = Context.Set<User>().Find(2);
            var category = Context.Set<Category>().Find(2);
        }

        //public void Delete(JD_Commodity_001 t)
        //{
        //    throw new NotImplementedException();
        //}

        //public JD_Commodity_001 Find(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public List<JD_Commodity_001> FindAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Insert(JD_Commodity_001 t)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(JD_Commodity_001 t)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
