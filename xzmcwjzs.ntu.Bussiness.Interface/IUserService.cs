using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xzmcwjzs.ntu.EF.Model.Entities;

namespace xzmcwjzs.ntu.Bussiness.Interface
{
    public interface IUserService : IBaseService<User>
    {
        /// <summary>
        /// 根据用户账户/email/手机号查找User
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        User UserLogin(string account);

        /// <summary>
        /// 用户最后登陆
        /// </summary>
        /// <param name="user"></param>
        void LastLogin(User user);
    }
}
