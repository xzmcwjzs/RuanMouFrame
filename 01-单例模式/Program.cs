using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_单例模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleThread_Singleton a = new SingleThread_Singleton();
            
        }

        //单线程Singleton
        public class SingleThread_Singleton
        {
            private static SingleThread_Singleton instance = null;
            private SingleThread_Singleton() { }
            public static SingleThread_Singleton Instance
            {
                get
                {
                    if (instance == null)//在多线程情况下不安全
                    {
                        instance = new SingleThread_Singleton();
                    }
                    return instance;
                }
            }
        }

        //多线程Singleton
        /*为何要使用双重检查锁定呢？上文已经大概说了一下。
        考虑这样一种情况，就是有两个线程同时到达，即同时调用 getInstance() 方法，
        此时由于 singleTon == null ，所以很明显，两个线程都可以通过第一重的 singleTon == null ，
        进入第一重 if 语句后，由于存在锁机制，所以会有一个线程进入 lock 语句并进入第二重 singleTon == null ，
        而另外的一个线程则会在 lock 语句的外面等待。
        而当第一个线程执行完 new SingleTon（）语句后，便会退出锁定区域，此时，第二个线程便可以进入 lock 语句块，
        此时，如果没有第二重 singleTon == null 的话，那么第二个线程还是可以调用 new SingleTon （）语句，
        这样第二个线程也会创建一个 SingleTon实例，这样也还是违背了单例模式的初衷的，
        所以这里必须要使用双重检查锁定。
        细心的朋友一定会发现，如果我去掉第一重 singleton == null ，程序还是可以在多线程下完好的运行的，
        考虑在没有第一重 singleton == null 的情况下，
        当有两个线程同时到达，此时，由于 lock 机制的存在，第一个线程会进入 lock 语句块，并且可以顺利执行 new SingleTon（），
        当第一个线程退出 lock 语句块时， singleTon 这个静态变量已不为 null 了，所以当第二个线程进入 lock 时，
        还是会被第二重 singleton == null 挡在外面，而无法执行 new Singleton（），
        所以在没有第一重 singleton == null 的情况下，也是可以实现单例模式的？那么为什么需要第一重 singleton == null 呢？
        这里就涉及一个性能问题了，因为对于单例模式的话，new SingleTon（）只需要执行一次就 OK 了，
        而如果没有第一重 singleTon == null 的话，每一次有线程进入 getInstance（）时，均会执行锁定操作来实现线程同步，
        这是非常耗费性能的，而如果我加上第一重 singleTon == null 的话，
        那么就只有在第一次，也就是 singleTton ==null 成立时的情况下执行一次锁定以实现线程同步，
        而以后的话，便只要直接返回 Singleton 实例就 OK 了而根本无需再进入 lock 语句块了，这样就可以解决由线程同步带来的性能问题了。*/
        public class MultiThread_Singleton
        {
            //volatile多用于多线程的环境，当一个变量定义为volatile时，读取这个变量的值时候每次都是从momery里面读取而不是从cache读
            private static volatile MultiThread_Singleton instance = null;
            private static object lockHelper = new object();
            public MultiThread_Singleton() { }
            public static MultiThread_Singleton Instance
            {
                get
                {
                    if (instance == null)
                    {
                        lock (lockHelper)
                        {
                            if (instance == null)
                            {
                                instance = new MultiThread_Singleton();
                            }
                        }
                    }
                    return instance;
                }
            }

            public string test()
            {
                return "单例模式开启";
            }
        }

        //静态Singelton

        /*1、静态构造函数既没有访问修饰符，也没有参数。因为是.NET调用的，所以像public和private等修饰符就没有意义了。
    　　
    　　2、是在创建第一个类实例或任何静态成员被引用时，.NET将自动调用静态构造函数来初始化类，也就是说我们无法直接调用静态构造函数，也就无法控制什么时候执行静态构造函数了。

    　　3、一个类只能有一个静态构造函数。

    　　4、无参数的构造函数可以与静态构造函数共存。尽管参数列表相同，但一个属于类，一个属于实例，所以不会冲突。

    　　5、最多只运行一次。

    　　6、静态构造函数不可以被继承。

    　　7、如果没有写静态构造函数，而类中包含带有初始值设定的静态成员，那么编译器会自动生成默认的静态构造函数。
      */
        public class Static_Singleton
        {
            //public static readonly Static_Singleton instance = new Static_Singleton();
            public static readonly Static_Singleton instance;
            static Static_Singleton()
            {
                instance = new Static_Singleton();
            }
            private Static_Singleton() { }
        }
    }
}
