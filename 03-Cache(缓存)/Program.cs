using _03_Cache_缓存_.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Cache_缓存_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //{
                //    long i1 = Plus();

                //    long i2 = Plus();

                //    long i3 = Plus();

                //    long i4 = Plus();
                //}
                //{
                //    //缓存
                //    long i1 = Plus();//木云得  5s
                //    CacheManager.Add("Plus", i1, 30);

                //    long i2 = CacheManager.GetData<long>("Plus");//Hejunping  1ms

                //    long i3 = CacheManager.GetData<long>("Plus");//1ms

                //    long i4 = CacheManager.GetData<long>("Plus");//1ms
                //}














                //CacheManager.Add("123", 3232432);
                long result1 = CacheManager.Get<long>("123", () => Plus(), 600);//会执行plus

                long result2 = CacheManager.Get<long>("123", () => Plus(), 600);//读缓存
                CacheManager.Remove("123");
                bool result = CacheManager.Contains("123");

                Student student = CacheManager.Get<Student>("冰川", () => new Student() { Id = 11, Name = "冰川" });

                Student student1 = CacheManager.Get<Student>("冰川", () => new Student() { Id = 11, Name = "冰川" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }


        /// <summary>
        /// 耗时很长的数据库查询
        /// 接口调用
        /// 文件读取
        /// </summary>
        /// <returns></returns>
        private static long Plus()
        {
            long lResult = 0;
            for (int i = 0; i < 1000000000; i++)
            {
                lResult += i;
            }
            Console.WriteLine("计算完成");
            return lResult;
        }




    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
