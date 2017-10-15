using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程同步_信号量和互斥体
{
    class Program
    {
        // 初始信号量计数为0，最大计数为10
        public static Semaphore semaphore = new Semaphore(0, 10);
        public static int time = 0;
        //public static Mutex mutex = new Mutex();
        //public static int count;
        static void Main(string[] args)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread test = new Thread(new ParameterizedThreadStart(TestMethod));
                // 开始线程，并传递参数
                test.Start(i);
            }

            // 等待1秒让所有线程开始并阻塞在信号量上
            Thread.Sleep(500);
            // 信号量计数加4
            // 最后可以看到输出结果次数为4次
            semaphore.Release(4);
            Console.Read();
            //for (int i = 0; i < 10; i++)
            //{
            //    Thread test = new Thread(TestMethod);

            //    // 开始线程，并传递参数
            //    test.Start();
            //}

            //Console.Read();

        }
        //public static void TestMethod()
        //{
        //    mutex.WaitOne();
        //    Thread.Sleep(500);
        //    count++;
        //    Console.WriteLine("Current Cout Number is {0}", count);
        //    mutex.ReleaseMutex();
        //}
        public static void TestMethod(object number)
        {
            // 设置一个时间间隔让输出有顺序
            int span = Interlocked.Add(ref time, 100);
            Thread.Sleep(1000 + span);

            //信号量计数减1
            semaphore.WaitOne();

            Console.WriteLine("Thread {0} run ", number);
        }


    }
}
