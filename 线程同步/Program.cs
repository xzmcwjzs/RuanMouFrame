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




        }
    }
}
