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
    public class UserService : BaseService<User>, IUserService
    {
        #region Identity
        private DbSet<User> UserSet;
        public UserService(DbContext jdContext)
            : base(jdContext)
        {
            this.UserSet = base.Context.Set<User>();
        }
        #endregion Identity

        #region Query
        public User UserLogin(string account)
        {
            return this.UserSet.FirstOrDefault(u => u.Mobile.Equals(account) || u.Account.Equals(account) || u.Email.Equals(account));
        }

        public void LastLogin(User user)
        {
            user.LastLoginTime = DateTime.Now;
            base.Update(user);
        }
        #endregion Query


    }
}
