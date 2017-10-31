using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_IEnumerable
{
    //接口的定义就只有get没有set。所以我们在foreach中不能修改item的值
    //我们自己写的MyIEnumerable删掉后面的IEnumerable接口一样可以foreach
    //所以要可以foreach只需要对象定义了GetEnumerator无参方法，并且返回值是IEnumerator或其对应的泛型
    class Program
    {
        static void Main(string[] args)
        {
            string[] strList = { "aaaa","bbbb","cccc","dddd","eeee"};
            MyIEnumerable my = new MyIEnumerable(strList);
            var str = my.GetEnumerator();//第一步：获取IEnumerator接口实例
            while (str.MoveNext())//第二步：判断是否可继续循环
            {
                Console.WriteLine(str.Current);
            }

            //foreach (var item in my)
            //{
            //    Console.WriteLine(item);
            //}


            Console.ReadKey();
        }
    }
}
