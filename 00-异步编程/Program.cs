using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_异步编程
{
    
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate del = new MyDelegate();
            del.Caculate();

            Console.ReadKey();
        }
        
    } 
}
