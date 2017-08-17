using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _00_多线程与线程池
{
   public class ParallelLoopState
    {
        public void Parallel_LoopState()
        {
            List<Product> productList = GetProcuctList_500();
            Thread.Sleep(3000);
            Parallel.For(0, productList.Count, (i, loopState) =>
            {
                if (i < 100)
                {
                    Console.WriteLine("采用Stop index:{0}", i);
                }
                else
                {
                    /* 满足条件后 尽快停止执行，无法保证小于100的索引数据全部输出*/
                    loopState.Stop();
                    return;
                }
            });

            Thread.Sleep(3000);
            Parallel.For(0, productList.Count, (i, loopState) =>
            {
                if (i < 100)
                {
                    Console.WriteLine("采用Break index:{0}", i);
                }
                else
                {
                    /* 满足条件后 尽快停止执行，保证小于100的索引数据全部输出*/
                    loopState.Break();
                    return;
                }
            });

            Thread.Sleep(3000);
            Parallel.ForEach(productList, (model, loopState) =>
            {
                if (model.SellPrice < 10)
                {
                    Console.WriteLine("采用Stop index:{0}", model.SellPrice);
                }
                else
                {
                    /* 满足条件后 尽快停止执行，无法保证满足条件的数据全部输出*/
                    loopState.Stop();
                    return;
                }
            });
            Thread.Sleep(3000);
            Parallel.ForEach(productList, (model, loopState) =>
            {
                if (model.SellPrice < 10)
                {
                    Console.WriteLine("采用Break index:{0}", model.SellPrice);
                }
                else
                {
                    /* 满足条件后 尽快停止执行，保证满足条件的数据全部输出*/
                    loopState.Break();
                    return;
                }
            });
        }
        private static List<Product> GetProcuctList_500()
        {
            List<Product> result = new List<Product>();
            for (int index = 1; index < 500; index++)
            {
                Product model = new Product();
                model.Category = "Category" + index;
                model.Name = "Name" + index;
                model.SellPrice = index;
                result.Add(model);
            }
            return result;
        }
    }
}
