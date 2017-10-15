using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程基础
{
     //一、线程的介绍 
    //二、线程调度和优先级 
    //三、前台线程和后台线程 
    //四、简单线程的使用
    class Program
    {
        static void Main(string[] args)
        {
            //// 创建一个新线程（默认为前台线程）
            //Thread backthread = new Thread(Worker);

            //// 使线程成为一个后台线程
            //backthread.IsBackground = true;

            //// 通过Start方法启动线程
            //backthread.Start();
            //backthread.Join();

            //// 模拟主线程的输出
            //Thread.Sleep(2000);


            //// 如果backthread是前台线程，则应用程序大约5秒后才终止
            //// 如果backthread是后台线程，则应用程序立即终止
            //Console.WriteLine("Return from Main Thread");

            //Console.Read();


            // 创建一个新线程（默认为前台线程）
            Thread backthread = new Thread(new ParameterizedThreadStart(Worker));

          
            // 通过Start方法启动线程
            backthread.Start("123");

            // 如果backthread是前台线程，则应用程序大约5秒后才终止
            // 如果backthread是后台线程，则应用程序立即终止
            Console.WriteLine("Return from Main Thread");
        }

        private static void Worker()
        {
            // 模拟做5秒
            Thread.Sleep(5000);

            // 下面语句，只有由一个前台线程执行时，才会显示出来
            Console.WriteLine("Return from Worker Thread");
        }

        private static void Worker(object data)
        {
            // 模拟做5秒
            Thread.Sleep(5000);

            // 下面语句，只有由一个前台线程执行时，才会显示出来
            Console.WriteLine(data + " Return from Worker Thread");
            Console.Read();
        }

    }
}
