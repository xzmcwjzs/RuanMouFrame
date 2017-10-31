using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_IEnumerable
{
    //继承接口 IEnumerable并实现
    public class MyIEnumerable : IEnumerable
    {
        private string[] strList;
        public MyIEnumerable(string[] _strList)
        {
            strList = _strList;
        }
        public IEnumerator GetEnumerator()
        {
            //return new MyIEnumerator(strList);
            for (int i = 0; i < strList.Length; i++)
            {
                yield return strList[i];
            }
        }
    }
}
