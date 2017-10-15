using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程池中的工作者线程
{
//    一、上节补充

//二、CLR线程池基础

//三、通过线程池的工作者线程实现异步

//四、使用委托实现异步

//五、任务
    class Program
    {
        // 使用委托的实现的方式是使用了异步变成模型APM（Asynchronous Programming Model）
        // 自定义委托
        private delegate string MyTestdelegate();

        static void Main(string[] args)
        {
            //// 创建一个线程来测试
            //Thread thread1 = new Thread(TestMethod);
            //thread1.Name = "Thread1";
            //thread1.Start();
            ////Thread.Sleep(2000);
            //Console.WriteLine("Main Thread is running");
            ////int b = 0;
            ////int a = 3 / b;
            ////Console.WriteLine(a);
            //thread1.Resume();
            //Console.Read();

            //Thread abortThread = new Thread(AbortMethod);
            //abortThread.Name = "Abort Thread";
            //abortThread.Start();
            //Thread.Sleep(1000);
            //try
            //{
            //    abortThread.Abort();
            //}
            //catch
            //{
            //    Console.WriteLine("{0} Exception happen in Main Thread", Thread.CurrentThread.Name);
            //    Console.WriteLine("{0} Status is:{1} In Main Thread ", Thread.CurrentThread.Name, Thread.CurrentThread.ThreadState);
            //}
            //finally
            //{
            //    Console.WriteLine("{0} Status is:{1} In Main Thread ", abortThread.Name, abortThread.ThreadState);
            //}

            //abortThread.Join();
            //Console.WriteLine("{0} Status is:{1} ", abortThread.Name, abortThread.ThreadState);
            //Console.Read();

            //Thread interruptThread = new Thread(InterruptMethod);
            //interruptThread.Name = "Interrupt Thread";
            //interruptThread.Start();
            //interruptThread.Interrupt();

            //interruptThread.Join();//阻塞当前线程   直到interruptThread线程完成  线程因为了Join,Sleep方法而唤醒了线程
            //Console.WriteLine("{0} Status is:{1} ", interruptThread.Name, interruptThread.ThreadState);
            //Console.Read();

            //Thread thread1 = new Thread(TestMethod);
            //thread1.Start();
            //Thread.Sleep(100);

            ////thread1.Interrupt();
            //thread1.Abort();
            //Thread.Sleep(3000);           //sleep唤醒被Interrupt终止的线程，而无法唤醒被abort终止的线程
            //Console.WriteLine("after finnally block, the Thread1 status is:{0}", thread1.ThreadState);
            //Console.Read();


            //// 设置线程池中处于活动的线程的最大数目
            //// 设置线程池中工作者线程数量为1000，I/O线程数量为1000
            //ThreadPool.SetMaxThreads(1000, 1000);
            //Console.WriteLine("Main Thread: queue an asynchronous method");
            //PrintMessage("Main Thread Start");

            //// 把工作项添加到队列中，此时线程池会用工作者线程去执行回调方法
            //ThreadPool.QueueUserWorkItem(asyncMethod);
            //Console.Read();


            //协作式取消 
            //.net Framework提供了取消操作的模式， 这个模式是协作式的。为了取消一个操作，首先必须创建一个System.Threading.CancellationTokenSource对象。 
            //ThreadPool.SetMaxThreads(1000, 1000);
            //Console.WriteLine("Main thread run");
            //PrintMessage("Start");
            //Run();
            //Console.ReadKey();


            //ThreadPool.SetMaxThreads(1000, 1000);
            //PrintMessage("Main Thread Start");

            ////实例化委托
            //MyTestdelegate testdelegate = new MyTestdelegate(asyncMethod);

            //// 异步调用委托
            //IAsyncResult result = testdelegate.BeginInvoke(null, null);

            //// 获取结果并打印出来
            //string returndata = testdelegate.EndInvoke(result);
            //Console.WriteLine(returndata);

            //Console.ReadLine();

            //ThreadPool.SetMaxThreads(1000, 1000);
            //PrintMessage("Main Thread Start");
            //// 调用构造函数创建Task对象,
            //Task<int> task = new Task<int>(n => asyncMethod((int)n), 10);

            //// 启动任务 
            //task.Start();
            //// 等待任务完成
            //task.Wait();
            //Console.WriteLine("The Method result is: " + task.Result); 
            //Console.ReadLine();


            ThreadPool.SetMaxThreads(1000, 1000);
            PrintMessage("Main Thread Start");
            CancellationTokenSource cts = new CancellationTokenSource();

            // 调用构造函数创建Task对象,将一个CancellationToken传给Task构造器从而使Task和CancellationToken关联起来
            Task<int> task = new Task<int>(n => asyncMethod(cts.Token, (int)n), 10);

            // 启动任务 
            task.Start();

            // 延迟取消任务
            Thread.Sleep(3000);

            // 取消任务
            cts.Cancel();
            Console.WriteLine("The Method result is: " + task.Result);
            Console.ReadLine();
             
            //ThreadPool.SetMaxThreads(1000, 1000);
            //Task.Factory.StartNew(() => PrintMessage("Main Thread"));
            //Console.Read();

        }
        private static int asyncMethod(CancellationToken ct, int n)
        {
            Thread.Sleep(1000);
            PrintMessage("Asynchoronous Method");

            int sum = 0;
            try
            {
                for (int i = 1; i < n; i++)
                {
                    // 当CancellationTokenSource对象调用Cancel方法时，
                    // 就会引起OperationCanceledException异常
                    // 通过调用CancellationToken的ThrowIfCancellationRequested方法来定时检查操作是否已经取消，
                    // 这个方法和CancellationToken的IsCancellationRequested属性类似
                    ct.ThrowIfCancellationRequested();
                    Thread.Sleep(500);
                    // 如果n太大，使用checked使下面代码抛出异常
                    checked
                    {
                        sum += i;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception is:" + e.GetType().Name);
                Console.WriteLine("Operation is Canceled");
            }

            return sum;
        }
        private static int asyncMethod(int n)
        {
            Thread.Sleep(1000);
            PrintMessage("Asynchoronous Method");

            int sum = 0;
            for (int i = 1; i < n; i++)
            {
                // 如果n太大，使用checked使下面代码抛出异常
                checked
                {
                    sum += i;
                }
            }

            return sum;
        } 
        private static string asyncMethod()
        {
            Thread.Sleep(1000);
            PrintMessage("Asynchoronous Method");
            return "Method has completed";
        } 
        private static void Run()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            // 这里用Lambda表达式的方式和使用委托的效果一样的，只是用了Lambda后可以少定义一个方法。
            // 这在这里就是让大家明白怎么lambda表达式如何由委托转变的
            ////ThreadPool.QueueUserWorkItem(o => Count(cts.Token, 1000));

            ThreadPool.QueueUserWorkItem(callback, cts.Token);

            Console.WriteLine("Press Enter key to cancel the operation\n");
            Console.ReadLine();

            // 传达取消请求
            cts.Cancel();
        }

        private static void callback(object state)
        {
            Thread.Sleep(1000);
            PrintMessage("Asynchoronous Method Start");
            CancellationToken token = (CancellationToken)state;
            Count(token, 1000);
        }

        // 执行的操作，当受到取消请求时停止数数
        private static void Count(CancellationToken token, int countto)
        {
            for (int i = 0; i < countto; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Count is canceled");
                    break;
                }

                Console.WriteLine(i);
                Thread.Sleep(300);
            }

            Console.WriteLine("Count has done");
        }



        // 方法必须匹配WaitCallback委托
        private static void asyncMethod(object state)
        {
            Thread.Sleep(1000);
            PrintMessage("Asynchoronous Method");
            Console.WriteLine("Asynchoronous thread has worked ");
        } 
        // 打印线程池信息
        private static void PrintMessage(String data)
        {
            int workthreadnumber;
            int iothreadnumber;

            // 获得线程池中可用的线程，把获得的可用工作者线程数量赋给workthreadnumber变量
            // 获得的可用I/O线程数量给iothreadnumber变量
            ThreadPool.GetAvailableThreads(out workthreadnumber, out iothreadnumber);

            Console.WriteLine("{0}\n CurrentThreadId is {1}\n CurrentThread is background :{2}\n WorkerThreadNumber is:{3}\n IOThreadNumbers is: {4}\n",
                data,
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.IsBackground.ToString(),
                workthreadnumber.ToString(),
                iothreadnumber.ToString());
        } 
        //private static void TestMethod()
        //{
        //    Console.WriteLine("Thread: {0} has been suspended!", Thread.CurrentThread.Name);
        //    Thread.Sleep(2000);
        //    //将当前线程挂起
        //    Thread.CurrentThread.Suspend();
        //    Console.WriteLine("Thread: {0} has been resumed!", Thread.CurrentThread.Name);
        //}
        private static void AbortMethod()
        {
            try
            {
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine("{0} Exception happen In Abort Thread", Thread.CurrentThread.Name);
                Console.WriteLine("{0} Status is:{1} In Abort Thread ", Thread.CurrentThread.Name, Thread.CurrentThread.ThreadState);
            }
            finally
            {
                Console.WriteLine("{0} Status is:{1} In Abort Thread", Thread.CurrentThread.Name, Thread.CurrentThread.ThreadState);
            }
        }
        private static void InterruptMethod()
        {
            try
            {
                Thread.Sleep(5000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
                Console.WriteLine("{0} Exception happen In Interrupt Thread", Thread.CurrentThread.Name);
                Console.WriteLine("{0} Status is:{1} In Interrupt Thread ", Thread.CurrentThread.Name, Thread.CurrentThread.ThreadState);
            }
            finally
            {
                Console.WriteLine("{0} Status is:{1} In Interrupt Thread", Thread.CurrentThread.Name, Thread.CurrentThread.ThreadState);
            } 
        }
        private static void TestMethod()
        {

            for (int i = 0; i < 4; i++)
            {
                try
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("Thread is Running");
                }
                catch (Exception e)
                {
                    if (e != null)
                    {
                        Console.WriteLine("Exception {0} throw ", e.GetType().Name);
                    }
                }
                finally
                {
                    Console.WriteLine("Current Thread status is:{0} ", Thread.CurrentThread.ThreadState);
                }
            }
        }


    }
}
