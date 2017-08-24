using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _08_MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("主线程id为：" + Thread.CurrentThread.ManagedThreadId.ToString());
            Insert();
            //Delete();
            Count();
            Console.ReadKey();
        }
        private static object objectLock = new object();
        public static void Insert()
        {
            var db = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = db.GetCollection<users>("users");
            int n = 10000;
            //const int threadNum = 2;

            Stopwatch sw = new Stopwatch();
            sw.Start();
            //并行
            var po = new ParallelOptions
            {
                MaxDegreeOfParallelism = 5 // 设置最大的线程数3，仔细观察线程ID变化
            };
            Parallel.For(0, n, po, (i) =>
            {
                Console.WriteLine("线程id为：" + Thread.CurrentThread.ManagedThreadId.ToString());
               users user = new users()
                {
                    id =Guid.NewGuid().ToString(),
                    name = "MongoDB分片集群实战",
                    password = "123456",
                    age = i + 2,
                    createtime = DateTime.Now
                };
                collection.InsertOne(user);

            });

            //并发
            //List<Task> taskList = new List<Task>();
            //TaskFactory taskFactory = new TaskFactory();
            //for (int j = 0; j < threadNum; j++)
            //{
            //    int i;
            //    taskList.Add(taskFactory.StartNew(() =>
            //    {
            //        Console.WriteLine("线程id为：" + Thread.CurrentThread.ManagedThreadId.ToString());
            //        for (i = 0; i < n; i++)
            //        {
            //            users user = new users()
            //            {
            //                id = Guid.NewGuid().ToString(),
            //                name = "MongoDB分片集群实战",
            //                password = "123456",
            //                age = i + 2,
            //                createtime = DateTime.Now
            //            };
            //            collection.InsertOne(user);
            //        }
            //    }));
            //}


            //Task[] tasks = new Task[threadNum];
            //for (int j = 0; j < threadNum; j++)
            //{
            //    Console.WriteLine("第" + (j + 1) + "个线程");
            //    int i;
            //    tasks[j] = Task.Factory.StartNew(() =>
            //    {
            //        Console.WriteLine("线程id为：" + Thread.CurrentThread.ManagedThreadId.ToString());

            //        for (i = 1; i < n; i++)
            //        {
            //            lock (objectLock)
            //            {
            //                users user = new users()
            //                {
            //                    id = Guid.NewGuid().ToString(),
            //                    name = "MongoDB分片集群实战",
            //                    password = "123456",
            //                    age = i + 2,
            //                    createtime = DateTime.Now
            //                };
            //                collection.InsertOne(user);
            //            } 
            //        }

            //    });
            //}

            //try
            //{
            //    // Wait for all the tasks to finish.
            //    Task.WaitAll(taskList.ToArray());

            //    // We should never get to this point
            //    Console.WriteLine("WaitAll() has not thrown exceptions. THIS WAS NOT EXPECTED.");
            //}
            //catch (AggregateException e)
            //{
            //    Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
            //    for (int j = 0; j < e.InnerExceptions.Count; j++)
            //    {
            //        Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
            //    }
            //}

            sw.Stop();
            long totalTime = sw.Elapsed.Seconds;
            Console.WriteLine("总耗时为：" + totalTime.ToString());
            Console.WriteLine(n + "条数据插入成功");
        }
        public static void Count()
        {
            var db = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = db.GetCollection<users>("users");
            var result = collection.Find<users>(t => true).Count();
            Console.WriteLine("总记录数为：" + result);
        }

        public static void Delete()
        {
            var db = new GetMongoDB().GetDB();
            IMongoCollection<users> collection = db.GetCollection<users>("users");
            DeleteResult result = collection.DeleteMany(t => true);
            if (result.DeletedCount > 0)
            {
                Console.WriteLine("数据删除成功");
            }
            else
            {
                Console.WriteLine("数据删除失败");
            }
        }

    }
}
