using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xzmcwjzs.ntu.Bussiness.Interface
{
  public  interface IBaseService<T> where T :class
    {
        void Insert(T t);

        T Find(int id);

        List<T> FindAll();

        void Update(T t);

        void Delete(T t);
    }
}
