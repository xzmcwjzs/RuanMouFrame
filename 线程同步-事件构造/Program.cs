using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程同步_事件构造
{
    //一、WaitHandle基类介绍

//二、事件(Event)类实现线程同步

//三、信号量(Semapyore)类实现线程同步

//四、互斥体(Mutex)实现线程同步

    //前面讲的线程同步主要是用户模式的(CLR Via C# 一书中是这么定义的，书中说到线程同步分两种：一、用户模式构造 二、内核模式构造，第一次看的时候不是很理解两个名词是什么意思的，我一般理解东西是采用把东西拆分来理解，理解拆分的各个部分后再合起来理解内容的，现在我对着两个的理解是——用户模式构造：对于内核模式构造（指的的是构造操作系内核对象），我们使用类（.net Framework中的类，如 AutoResetEvent, Semaphore类）的方法来实现线程同步，其实内部是调用操作系统的内核对象来实现的线程同步，此时就会导致线程从托管代码到为内核代码，然而用户模式构造，没有调用操作系统内核对象，线程只是在用户的托管代码上执行的)，对于用户模式构造和内核模式的构造只是我自己的理解的， 如果有更好的理解方式可以留言告诉下我， 这样我们可以一起讨论和学习了。
    class Program
    {
        // 初始化自动重置事件，并把状态设置为非终止状态
        // 如果这里把初始状态设置为True时，
        // 当调用WaitOne方法时就不会阻塞线程,看到的输出结果的时间就是一样的了
        // 因为设置为True时，表示此时已经为终止状态了。       
        //public static AutoResetEvent autoEvent = new AutoResetEvent(true);
        //public static ManualResetEvent autoEvent = new ManualResetEvent(true);
        public static EventWaitHandle autoEvent = new EventWaitHandle(true, EventResetMode.AutoReset, "My"); 
        static void Main(string[] args)
        {
            //Console.WriteLine("Main Thread Start run at: " + DateTime.Now.ToLongTimeString());
            //Thread t = new Thread(TestMethod);
            //t.Start();

            //// 阻塞主线程3秒后
            //// 调用 Set方法释放线程，使线程t可以运行
            ////Thread.Sleep(1000);

            //// Set 方法就是把事件状态设置为终止状态。
            ////autoEvent.Set();
            //Console.Read();

            Console.WriteLine("Main Thread Start run at: " + DateTime.Now.ToLongTimeString());
            Thread t = new Thread(TestMethod);

            // 为了有时间启动另外一个线程
            Thread.Sleep(2000);
            t.Start();
            Console.Read();
        }
        public static void TestMethod()
        {
            //autoEvent.WaitOne();

            //// 3秒后线程可以运行，所以此时显示的时间应该和主线程显示的时间相差3秒
            //Console.WriteLine("Method Restart run at: " + DateTime.Now.ToLongTimeString());

            //if (autoEvent.WaitOne(2000))
            //{
            //    Console.WriteLine("Get Singal to Work");
            //    // 3秒后线程可以运行，所以此时显示的时间应该和主线程显示的时间相差一秒
            //    Console.WriteLine("Method Restart run at: " + DateTime.Now.ToLongTimeString());
            //}
            //else
            //{
            //    Console.WriteLine("Time Out to work");
            //    Console.WriteLine("Method Restart run at: " + DateTime.Now.ToLongTimeString());
            //}

            // 初始状态为终止状态，则第一次调用WaitOne方法不会堵塞线程
            // 此时运行的时间间隔应该为0秒，但是因为是AutoResetEvent对象
            // 调用WaitOne方法后立即把状态返回为非终止状态。
            //autoEvent.WaitOne();
            //Console.WriteLine("Method start at : " + DateTime.Now.ToLongTimeString());

            //// 因为此时AutoRestEvent为非终止状态，所以调用WaitOne方法后将阻塞线程1秒，这里设置了超时时间
            //// 所以下面语句的和主线程中语句的时间间隔为1秒
            //// 当时 ManualResetEvent对象时，因为不会自动重置状态
            //// 所以调用完第一次WaitOne方法后状态仍然为非终止状态,所以再次调用不会阻塞线程，所以此时的时间间隔也为0
            //// 如果没有设置超时时间的话，下面这行语句将不会执行
            //autoEvent.WaitOne(1000);
            //Console.WriteLine("Method start at : " + DateTime.Now.ToLongTimeString());


            // 进程一：显示的时间间隔为2秒
            // 进程二中显示的时间间隔为3秒
            // 因为进程二中AutoResetEvent的初始状态为非终止的
            // 因为在进程一中通过WaitOne方法的调用已经把AutoResetEvent的初始状态返回为非终止状态了
            autoEvent.WaitOne(1000);
            Console.WriteLine("Method start at : " + DateTime.Now.ToLongTimeString());
        }

    }
}
