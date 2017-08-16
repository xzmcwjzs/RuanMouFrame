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
            Console.WriteLine("##############################################");
            #region 死锁2
            {
                Task[] tasks = new Task[2];
                tasks[0] = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Task 1 Start running...");
                    while (true)
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                    Console.WriteLine("Task 1 Finished!");
                });
                tasks[1] = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Task 2 Start running...");
                    System.Threading.Thread.Sleep(2000);
                    Console.WriteLine("Task 2 Finished!");
                });

                Task.WaitAll(tasks, 5000);
                for (int i = 0; i < tasks.Length; i++)
                {
                    if (tasks[i].Status != TaskStatus.RanToCompletion)
                    {
                        Console.WriteLine("Task {0} Error!", i + 1);
                    }
                }
            }
            #endregion

            Console.WriteLine("##############################################"); 
            #region 自旋锁
            //第一个想到的同步方法就是使用lock或者Monitor，然而在4.0 之后微软给我们提供了另一把利器——spinLock，它比重量级别的Monitor具有更小的性能开销，它的用法跟Monitor很相似
            SpinLock slock = new SpinLock(false);
            long sum1 = 0;
            long sum2 = 0;
            Parallel.For(0, 100000, i =>
            {
                sum1 += i;
            });

            Parallel.For(0, 100000, i =>
            {
                bool lockTaken = false;
                try
                {
                    slock.Enter(ref lockTaken);
                    sum2 += i;
                }
                finally
                {
                    if (lockTaken)
                        slock.Exit(false);
                }
            });

            Console.WriteLine("Num1的值为:{0}", sum1);
            Console.WriteLine("Num2的值为:{0}", sum2);

            #endregion

            #region 线程安全集合


            #endregion

            #region 线程池


            #endregion

            Console.ReadKey();
        }
    }
}
