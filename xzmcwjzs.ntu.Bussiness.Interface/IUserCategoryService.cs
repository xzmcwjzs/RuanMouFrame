using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xzmcwjzs.ntu.EF.Model.Entities;

namespace xzmcwjzs.ntu.Bussiness.Interface
{
   public interface IUserCategoryService:IBaseService<JD_Commodity_001>
    {
        void ComplexOperation();
    }
}
