using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _00_多线程与线程池
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 死锁1
            {
                //var t1 = Task.Factory.StartNew(() =>
                //{
                //    Console.WriteLine("Task 1 Start running...");
                //    while (true)
                //    {
                //        System.Threading.Thread.Sleep(1000);
                //    }
                //    Console.WriteLine("Task 1 Finished!");
                //});
                //var t2 = Task.Factory.StartNew(() =>
                //{
                //    Console.WriteLine("Task 2 Start running...");
                //    System.Threading.Thread.Sleep(2000);
                //    Console.WriteLine("Task 2 Finished!");
                //});
                //Task.WaitAll(t1, t2);
            }
            #endregion
            //Console.WriteLine("##############################################");
            #region 死锁2
            {
                //Task[] tasks = new Task[2];
                //tasks[0] = Task.Factory.StartNew(() =>
                //{
                //    Console.WriteLine("Task 1 Start running...");
                //    while (true)
                //    {
                //        System.Threading.Thread.Sleep(1000);
                //    }
                //    Console.WriteLine("Task 1 Finished!");
                //});
                //tasks[1] = Task.Factory.StartNew(() =>
                //{
                //    Console.WriteLine("Task 2 Start running...");
                //    System.Threading.Thread.Sleep(2000);
                //    Console.WriteLine("Task 2 Finished!");
                //});

                //Task.WaitAll(tasks, 5000);
                //for (int i = 0; i < tasks.Length; i++)
                //{
                //    if (tasks[i].Status != TaskStatus.RanToCompletion)
                //    {
                //        Console.WriteLine("Task {0} Error!", i + 1);
                //    }
                //}
            }
            #endregion

            //Console.WriteLine("##############################################"); 
            #region 自旋锁
            //第一个想到的同步方法就是使用lock或者Monitor，然而在4.0 之后微软给我们提供了另一把利器——spinLock，它比重量级别的Monitor具有更小的性能开销，它的用法跟Monitor很相似
            //SpinLock slock = new SpinLock(false);
            //long sum1 = 0;
            //long sum2 = 0;
            //Parallel.For(0, 100000, i =>
            //{
            //    sum1 += i;
            //});

            //Parallel.For(0, 100000, i =>
            //{
            //    bool lockTaken = false;
            //    try
            //    {
            //        slock.Enter(ref lockTaken);
            //        sum2 += i;
            //    }
            //    finally
            //    {
            //        if (lockTaken)
            //            slock.Exit(false);
            //    }
            //});

            //Console.WriteLine("Num1的值为:{0}", sum1);
            //Console.WriteLine("Num2的值为:{0}", sum2);

            #endregion
            //Console.WriteLine("##############################################");
            #region 并行编程PLinq
            //并发是有状态的，某一线程同时执行一个任务，完了才能进行到下一个，而并行是无状态的。

            //并发与并行是两个既相似而又不相同的概念：并发性，又称共行性，是指能处理多个同时性活动的能力；并行是指同时发生的两个并发事件，具有并发的含义，而并发则不一定并行，也亦是说并发事件之间不一定要同一时刻发生。

            //所有的并发处理都有排队等候，唤醒，执行至少三个这样的步骤.所以并发肯定是宏观概念，在微观上他们都是序列被处理的，只不过资源不会在某一个上被阻塞(一般是通过时间片轮转)，所以在宏观上看多个几乎同时到达的请求同时在被处理。如果是同一时刻到达的请求也会根据优先级的不同，而先后进入队列排队等候执行。

            //并发的实质是一个物理CPU(也可以多个物理CPU) 在若干道程序之间多路复用，并发性是对有限物理资源强制行使多用户共享以提高效率。

            //并行性指两个或两个以上事件或活动在同一时刻发生。在多道程序环境下，并行性使多个程序同一时刻可在不同CPU上同时执行。

            //并行编程：并行编程是指软件开发的代码，它能在同一时间执行多个计算任务，提高执行效率和性能一种编程方式，属于多线程编程范畴。所以我们在设计过程中一般会将很多任务划分成若干个互相独立子任务，这些任务不考虑互相的依赖和顺序。这样我们就可以使用很好的使用并行编程。但是我们都知道多核处理器的并行设计使用共享内存，如果没有考虑并发问题，就会有很多异常和达不到我们预期的效果。不过还好NET Framework4.0引入了Task Parallel Library（TPL）实现了基于任务设计而不用处理重复复杂的线程的并行开发框架。它支持数据并行，任务并行与流水线。核心主要是Task，但是一般简单的并行我们可以利用Parallel提供的静态类如下三个方法。

            //Parallel.Invoke 对给定任务实现并行开发

            //Parallel.For 对固定数目的任务提供循环迭代并行开发

            //parallel.Foreach 对固定数目的任务提供循环迭代并行开发

            //注意：所有的并行开发不是简单的以为只要将For或者Foreach换成Parallel.For与Parallel.Foreach这样简单。
            //ParallelInvoke parallelInvoke = new ParallelInvoke();
            //parallelInvoke.Client1();

            //ParallelFor parallelFor = new ParallelFor();
            //parallelFor.Parallel_For();
            //ParallelLoopState parallelLoopState = new ParallelLoopState();
            //parallelLoopState.Parallel_LoopState();
            //线程安全的并行集合有
            //ConcurrentQueue
            //ConcurrentStack
            //ConcurrentBag ： 一个无序的数据结构集，当不需要考虑顺序时非常有用。
            //BlockingCollection ： 与经典的阻塞队列数据结构类似
            //ConcurrentDictionary
            #endregion

            #region 线程池
            // 新建ManualResetEvent对象并且初始化为无信号状态
            ManualResetEvent eventX = new ManualResetEvent(false);
            ThreadPool.SetMaxThreads(3, 3);
            thr t = new thr(15, eventX);
            for (int i = 0; i < 15; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(t.ThreadProc), i);
            }
            //等待事件的完成，即线程调用ManualResetEvent.Set()方法
            //eventX.WaitOne  阻止当前线程，直到当前 WaitHandle 收到信号为止。 
            eventX.WaitOne(Timeout.Infinite, true);
            Console.WriteLine("断点测试");
            Thread.Sleep(10000);
            Console.WriteLine("运行结束");
             
            #endregion

            Console.ReadKey();
        }

        public class thr
        {
            public thr(int count, ManualResetEvent mre)
            {
                iMaxCount = count;
                eventX = mre;
            }

            public static int iCount = 0;
            public static int iMaxCount = 0;
            public ManualResetEvent eventX;
            public void ThreadProc(object i)
            {
                Console.WriteLine("Thread[" + i.ToString() + "]");
                Thread.Sleep(2000);
                //Interlocked.Increment()操作是一个原子操作，作用是:iCount++ 具体请看下面说明 
                //原子操作，就是不能被更高等级中断抢夺优先的操作。你既然提这个问题，我就说深一点。
                //由于操作系统大部分时间处于开中断状态，
                //所以，一个程序在执行的时候可能被优先级更高的线程中断。
                //而有些操作是不能被中断的，不然会出现无法还原的后果，这时候，这些操作就需要原子操作。
                //就是不能被中断的操作。
                Interlocked.Increment(ref iCount);
                if (iCount == iMaxCount)
                {
                    Console.WriteLine("发出结束信号!");
                    //将事件状态设置为终止状态，允许一个或多个等待线程继续。
                    eventX.Set();
                }
            }
        }


    }
}
