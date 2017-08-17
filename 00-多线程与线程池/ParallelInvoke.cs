using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _00_多线程与线程池
{
    public class ParallelInvoke
    {
        //public void Client1() {
        //    Stopwatch stopwatch = new Stopwatch();
        //    Console.WriteLine("主线程：{0}线程ID ： {1}；开始", "Client1", Thread.CurrentThread.ManagedThreadId);
        //    stopwatch.Start();
        //    Parallel.Invoke(() => Task1("task1"), () => Task2("task2"), () => Task3("task3"));
        //    stopwatch.Stop();
        //    Console.WriteLine("主线程：{0}线程ID ： {1}；结束,共用时{2}ms", "Client1", Thread.CurrentThread.ManagedThreadId, stopwatch.ElapsedMilliseconds);
        //}
        private void Task1(string data)
        {
            Thread.Sleep(5000);
            Console.WriteLine("任务名：{0}线程ID ： {1}", data, Thread.CurrentThread.ManagedThreadId);
        }

        private void Task2(string data)
        {
            Console.WriteLine("任务名：{0}线程ID ： {1}", data, Thread.CurrentThread.ManagedThreadId);
        }

        private void Task3(string data)
        {
            Console.WriteLine("任务名：{0}线程ID ： {1}", data, Thread.CurrentThread.ManagedThreadId);
        }

        //我们看到Invoke 执行Task三个方法主要有以下几个特点：

        // 1、没有固定的顺序，每个Task可能是不同的线程去执行，也可能是相同的；

        //2、主线程必须等Invoke中的所有方法执行完成后返回才继续向下执行；这样对我们以后设计并行的时候，要考虑每个Task任务尽可能差不多，如果相差很大，比如一个时间非常长，其他都比较短，这样一个线程可能会影响整个任务的性能。这点非常重要

        //3、这个非常简单就实现了并行，不用我们考虑线程问题。主要Framework已经为我们控制好线程池的问题。

        //ps：如果其中有一个异常怎么办？ 带做这个问题修改了增加了一个Task4.

        //public void Client1()
        //{
        //    Stopwatch stopWatch = new Stopwatch();

        //    Console.WriteLine("主线程：{0}线程ID ： {1}；开始", "Client1", Thread.CurrentThread.ManagedThreadId);
        //    stopWatch.Start();

        //    try
        //    {
        //        Parallel.Invoke(() => Task1("task1"), () => Task2("task2"), () => Task3("task3"),delegate() { throw new Exception("定义了一个异常"); });

        //    }
        //    catch (AggregateException ae)
        //    {
        //        foreach (var ex in ae.InnerExceptions)
        //        {
        //            Console.WriteLine(ex.Message);
        //        } 
        //    }
        //    stopWatch.Stop();
        //    Console.WriteLine("主线程：{0}线程ID ： {1}；结束,共用时{2}ms", "Client1", Thread.CurrentThread.ManagedThreadId, stopWatch.ElapsedMilliseconds);
        //}

        /// <summary>
        /// 重载方法ParallelOptions 的使用
        /// </summary>
        readonly CancellationTokenSource cts = new CancellationTokenSource();
        public void Client1() {
            // 定义CancellationTokenSource 控制取消
            Console.WriteLine("主线程：{0}线程ID ： {1}；开始{2}", "Client1", Thread.CurrentThread.ManagedThreadId, DateTime.Now);

            var po = new ParallelOptions {
                CancellationToken=cts.Token,//控制线程取消
                MaxDegreeOfParallelism= 3 // 设置最大的线程数3，仔细观察线程ID变化
            };
            Parallel.Invoke(po, () => Task1("task4"), () => Task5(po), Task6);

        }

        private void Task4(string data)
        {
            Thread.Sleep(5000);
            Console.WriteLine("任务名：{0}线程ID ： {1}", data, Thread.CurrentThread.ManagedThreadId);
        }
        // 打印数字
        private void Task5(ParallelOptions po) {
            Console.WriteLine("进入Task5线程ID ： {0}", Thread.CurrentThread.ManagedThreadId);
            int i = 0;
            while (i<500)
            {
                // 判断是否已经取消
                if (po.CancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("已经被取消。");
                    return;
                }
                Thread.Sleep(100);
                Console.Write(i + " ");
                Interlocked.Increment(ref i);
            }
        }
        private void Task6()
        {
            Console.WriteLine("进入取消任务，Task6线程ID ： {0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000 * 10);
            cts.Cancel();
            Console.WriteLine("发起取消请求...........");
        }
        //从程序结果我们看到以下特点：

        //    1、程序在执行过程中线程数码不超过3个。

        //    2、CancellationTokenSource/CancellationToken控制任务的取消。

      //  Parallel.Invoke 的使用过程中我们要注意以下特点：

      //1、没有特定的顺序，Invoke中的方法全部执行完才返回，但是即使有异常在执行过程中也同样会完成，他只是一个很简单的并行处理方法，特点就是简单，不需要我们考虑线程的问题。

      //2、如果在设计Invoke中有个需要很长时间，这样会影响整个Invoke的效率和性能，这个我们在设计每个task时候必须去考虑的。

      //3、Invoke 参数是委托方法。

      //4、当然Invoke在每次调用都有开销的，不一定并行一定比串行好，要根据实际情况，内核环境多次测试调优才可以。

      //5、异常处理比较复杂。
    }
}
