using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _00_多线程与线程池
{
   public class ParallelFor
    {
        public void Parallel_For()
        {
            //Thread.Sleep(3000);
            //ForSetProcuct_100();

            //Thread.Sleep(3000);
            //ParallelForSetProcuct_100();
            List<Product> ProductList = GetProcuctList();
            Parallel.ForEach(ProductList, (model) => {
                Console.WriteLine(model.Name);
            });
        }
        private static List<Product> GetProcuctList()
        {
            List<Product> result = new List<Product>();
            for (int index = 1; index < 100; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                result.Add(model);
            }
            return result;
        }
        private static void ForSetProcuct_100()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<Product> ProductList = new List<Product>();
            for (int index = 1; index < 100; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                ProductList.Add(model);
                //Console.WriteLine("for SetProcuct index: {0}", index);
            }
            sw.Stop();
            Console.WriteLine("for SetProcuct 10 执行完成 耗时：{0}，数目：{1}", sw.ElapsedMilliseconds,ProductList.Count());
        }
        private static void ParallelForSetProcuct_100()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            List<Product> ProductList = new List<Product>();
            Parallel.For(1, 100, index =>
            {

                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                ProductList.Add(model);
                //Console.WriteLine("ForSetProcuct SetProcuct index: {0}", index);
            });
            sw.Stop();
            Console.WriteLine("ForSetProcuct SetProcuct 20000 执行完成 耗时：{0}，数目：{1}", sw.ElapsedMilliseconds,ProductList.Count());
        }
    }

    class Product
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public int SellPrice { get; set; }
    }
}
