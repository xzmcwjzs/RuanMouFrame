using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程同步
{
    //一、线程同步概述

    //二、线程同步的使用

    //三 、总结
    //前面的文章都是讲创建多线程来实现让我们能够更好的响应应用程序，然而当我们创建了多个线程时，就存在多个线程同时访问一个共享的资源的情况，在这种情况下，就需要我们用到线程同步，线程同步可以防止数据（共享资源）的损坏。
    //然而我们在设计应用程序还是要尽量避免使用线程同步， 因为线程同步会产生一些问题：

//1. 它的使用比较繁琐。因为我们要用额外的代码把多个线程同时访问的数据包围起来，并获取和释放一个线程同步锁，如果我们在一个代码块忘记获取锁，就有可能造成数据损坏。

//2. 使用线程同步会影响性能，获取和释放一个锁肯定是需要时间的吧，因为我们在决定哪个线程先获取锁时候， CPU必须进行协调，进行这些额外的工作就会对性能造成影响

//3. 因为线程同步一次只允许一个线程访问资源，这样就会阻塞线程，阻塞线程会造成更多的线程被创建，这样CPU就有可能要调度更多的线程，同样也对性能造成了影响。

//所以在实际的设计中还是要尽量避免使用线程同步，因此我们要避免使用一些共享数据，例如静态字段。
    class Program
    {
        public static List<int> lists = new List<int>();

        // 创建一个对象
        public static ReaderWriterLock readerwritelock = new ReaderWriterLock();
        // 比较使用锁和不使用锁锁消耗的时间
        // 通过时间来说明使用锁性能的影响
        static void Main(string[] args)
        {
            //int x = 0;
            //// 迭代次数为500万
            //const int iterationNumber = 5000000;
            //// 不采用锁的情况
            //// StartNew方法 对新的 Stopwatch 实例进行初始化，将运行时间属性设置为零，然后开始测量运行时间。
            //Stopwatch sw = Stopwatch.StartNew();
            //for (int i = 0; i < iterationNumber; i++)
            //{
            //    x++;
            //}

            //Console.WriteLine("Use the all time is :{0} ms", sw.ElapsedMilliseconds);

            //sw.Restart();
            ////使用锁的情况
            //for (int i = 0; i < iterationNumber; i++)
            //{
            //    Interlocked.Increment(ref x);
            //}

            //Console.WriteLine("Use the all time is :{0} ms", sw.ElapsedMilliseconds);
            //Console.Read();

            //for (int i = 0; i < 50; i++)
            //{
            //    Thread testthread = new Thread(Add);
            //    testthread.Start();
            //}

            //Console.Read();


            //如果我们需要对一个共享资源执行多次读取时，然而用前面所讲的类实现的同步锁都只允许一个线程允许，所有线程将阻塞，但是这种情况下肯本没必要堵塞其他线程， 应该让它们并发的执行，因为我们此时只是进行读取操作，此时通过ReaderWriterLock类可以很好的实现读取并行。
            //创建一个线程读取数据
            Thread t1 = new Thread(Write);
            t1.Start();
            // 创建10个线程读取数据
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(Read);
                t.Start();
            }

            Console.Read();

        }
        public static void Write()
        {
            // 获取写入锁，以10毫秒为超时。
            readerwritelock.AcquireWriterLock(10);
            Random ran = new Random();
            int count = ran.Next(1, 10);
            lists.Add(count);
            Console.WriteLine("Write the data is:" + count);
            // 释放写入锁
            readerwritelock.ReleaseWriterLock();
        }

        // 读取方法
        public static void Read()
        {
            // 获取读取锁
            readerwritelock.AcquireReaderLock(10);

            foreach (int li in lists)
            {
                // 输出读取的数据
                Console.WriteLine(li);
            }

            // 释放读取锁
            readerwritelock.ReleaseReaderLock();
        }

        // 共享资源
        public static int number = 1;
        private static object lockobj = new object();//锁的对象应该是引用类型
        public static void Add()
        {
            //Thread.Sleep(1000);
            ////Console.WriteLine("the current value of number is:{0}", ++number);
            //Console.WriteLine("the current value of number is:{0}", Interlocked.Increment(ref number));

            Thread.Sleep(1000);
            //获得排他锁
            Monitor.Enter(lockobj);

            Console.WriteLine("the current value of number is:{0}", number++);

            // 释放指定对象上的排他锁。
            Monitor.Exit(lockobj);
        }
    }
}
