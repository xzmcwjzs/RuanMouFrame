using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_IEnumerable
{
    //继承接口 IEnumerator并实现
  public  class MyIEnumerator:IEnumerator
    {
        private string[] strList;
        private int position = -1;
        public MyIEnumerator(string[] _strList)
        {
            strList = _strList;
            position = -1;
        }
        public object Current
        {
            get
            {
                return strList[position];
            }
        }

        public bool MoveNext()
        {
            position++;
            if (position < strList.Length) return true;
            return false;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
