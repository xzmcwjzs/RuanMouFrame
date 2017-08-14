using _02_Crawler_爬虫_.DataService;
using _02_Crawler_爬虫_.Model;
using _02_Crawler_爬虫_.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Crawler_爬虫_
{
    class Program
    {
        private static Logger logger = new Logger(typeof(Program));
        static void Main(string[] args)
        {
            try
            {
                //http://search.jd.com/Search?keyword=%E5%85%85%E6%B0%94%E5%A8%83%E5%A8%83&enc=utf-8&suggest=3.his.0.0&wq=&pvid=60124febe81f4f4288a1d482b687f994

                // string html = HttpHelper.DownloadHtml(@"http://search.jd.com/Search?keyword=%E5%85%85%E6%B0%94%E5%A8%83%E5%A8%83&enc=utf-8&suggest=3.his.0.0&wq=&pvid=60124febe81f4f4288a1d482b687f994", Encoding.UTF8);

                //测试抓取商品列表
                // string testCategory = "{\"Id\":73,\"Code\":\"02f01s01T\",\"ParentCode\":\"02f01s\",\"Name\":\"烟机/灶具\",\"Url\":\"http://list.jd.com/737-794-1300.html\",\"Level\":3}";
                // new CommoditySearch(JsonConvert.DeserializeObject<Category>(testCategory)).Crawler();

                DBInit dbInit = new DBInit();
                CategoryRepository categoryRepository = new CategoryRepository();

                Console.WriteLine("请输入Y/N进行类别表初始化确认！ Y 删除Category表然后重新创建，然后抓取类型数据，N（或者其他）跳过");
                string input = Console.ReadLine();
                if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    dbInit.InitCategoryTable();
                    List<Category> categoryList = CategorySearch.Crawler("http://www.jd.com/allSort.aspx");

                    categoryRepository.Save(categoryList);
                    Console.WriteLine("类型数据初始化完成，共抓取类别{0}个", categoryList.Count);
                }
                else
                {
                    Console.WriteLine("你选择不初始化类别数据");
                }
                Console.WriteLine("*****************^_^**********************");

                Console.WriteLine("请输入Y/N进行商品数据初始化确认！ Y 删除全部商品表表然后重新创建，然后抓取商品数据，N（或者其他）跳过");
                input = Console.ReadLine();
                if (input.Equals("Y", StringComparison.OrdinalIgnoreCase))
                {
                    dbInit.InitCommodityTable();
                    CrawlerCommodity();
                }
                Console.WriteLine("*****************^_^**********************");
                //CleanAll();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                logger.Error("异常啦，", ex);
                Console.WriteLine("异常啦，{ 0} ",ex);
                Console.WriteLine("*****************木有成功**********************");
                Console.ReadLine(); 
            }
            
        }

        private static void CrawlerCommodity()
        {
            Console.WriteLine("{0} jd商品开始抓取 - -", DateTime.Now);
            CategoryRepository categoryRepository = new CategoryRepository();
            List<Category> categoryList = categoryRepository.QueryListByLevel(3);

            List<Task> taskList = new List<Task>();
            TaskFactory taskFactory = new TaskFactory();

            foreach (Category category in categoryList)
            {
                CommoditySearch searcher = new CommoditySearch(category);
                //searcher.Crawler();
                taskList.Add(taskFactory.StartNew(searcher.Crawler));

                taskList = taskList.Where(t => !t.IsCompleted && !t.IsCanceled && !t.IsFaulted).ToList();//把已完成的过滤掉
                if (taskList.Count > 9)//如果正在运行的任务数>9
                {
                    Task.WaitAny(taskList.ToArray());//主线程等着某个任务完成
                }
            }
            Task.WaitAll(taskList.ToArray());

            //ParallelOptions options = new ParallelOptions()
            //{
            //    MaxDegreeOfParallelism = 10,
            //};
            //Parallel.ForEach(categoryList, options, c =>
            //{
            //    CommoditySearch searcher = new CommoditySearch(c);
            //    searcher.Crawler();
            //});

             
            Console.WriteLine("{0} jd商品抓取全部完成 - -", DateTime.Now);
            CleanAll();
        }

        private static void CleanAll()
        {
            try
            {
                Console.WriteLine("{0} 开始清理重复数据 - -", DateTime.Now);
                StringBuilder sb = new StringBuilder();
                for (int i = 1; i < 31; i++)
                {
                    sb.AppendFormat(@"DELETE FROM [dbo].[JD_Commodity_{0}] where productid IN(select productid from [dbo].[JD_Commodity_{0}] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_{0}] group by productid,CategoryId having count(0)>1);", i.ToString("000"));
                }
                #region
                /*
                 DELETE FROM [dbo].[JD_Commodity_001] where productid IN(select productid from [dbo].[JD_Commodity_001] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_001] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_002] where productid IN(select productid from [dbo].[JD_Commodity_002] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_002] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_003] where productid IN(select productid from [dbo].[JD_Commodity_003] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_003] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_004] where productid IN(select productid from [dbo].[JD_Commodity_004] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_004] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_005] where productid IN(select productid from [dbo].[JD_Commodity_005] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_005] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_006] where productid IN(select productid from [dbo].[JD_Commodity_006] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_006] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_007] where productid IN(select productid from [dbo].[JD_Commodity_007] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as IDv from [dbo].[JD_Commodity_007] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_008] where productid IN(select productid from [dbo].[JD_Commodity_008] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_008] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_009] where productid IN(select productid from [dbo].[JD_Commodity_009] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_009] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_010] where productid IN(select productid from [dbo].[JD_Commodity_010] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_010] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_011] where productid IN(select productid from [dbo].[JD_Commodity_011] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_011] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_012] where productid IN(select productid from [dbo].[JD_Commodity_012] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_012] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_013] where productid IN(select productid from [dbo].[JD_Commodity_013] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_013] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_014] where productid IN(select productid from [dbo].[JD_Commodity_014] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_014] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_015] where productid IN(select productid from [dbo].[JD_Commodity_015] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_015] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_016] where productid IN(select productid from [dbo].[JD_Commodity_016] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_016] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_017] where productid IN(select productid from [dbo].[JD_Commodity_017] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_017] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_018] where productid IN(select productid from [dbo].[JD_Commodity_018] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_018] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_019] where productid IN(select productid from [dbo].[JD_Commodity_019] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_019] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_020] where productid IN(select productid from [dbo].[JD_Commodity_020] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_020] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_021] where productid IN(select productid from [dbo].[JD_Commodity_021] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_021] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_022] where productid IN(select productid from [dbo].[JD_Commodity_022] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_022] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_023] where productid IN(select productid from [dbo].[JD_Commodity_023] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_023] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_024] where productid IN(select productid from [dbo].[JD_Commodity_024] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_024] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_025] where productid IN(select productid from [dbo].[JD_Commodity_025] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_025] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_026] where productid IN(select productid from [dbo].[JD_Commodity_026] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_026] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_027] where productid IN(select productid from [dbo].[JD_Commodity_027] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_027] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_028] where productid IN(select productid from [dbo].[JD_Commodity_028] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_028] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_029] where productid IN(select productid from [dbo].[JD_Commodity_029] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_029] group by productid,CategoryId having count(0)>1);DELETE FROM [dbo].[JD_Commodity_030] where productid IN(select productid from [dbo].[JD_Commodity_030] group by productid,CategoryId having count(0)>1)
                                AND ID NOT IN(select max(ID) as ID from [dbo].[JD_Commodity_030] group by productid,CategoryId having count(0)>1);
                 */
                #endregion
                Console.WriteLine("执行清理sql:{0}", sb.ToString());
                SqlHelper.ExecuteNonQuery(sb.ToString());
                Console.WriteLine("{0} 完成清理重复数据 - -", DateTime.Now);
            }
            catch (Exception ex)
            { 
                Console.WriteLine("CleanAll出现异常，{0}",ex);
            }
            finally
            {
                Console.WriteLine("{0} 结束清理重复数据 - -", DateTime.Now);
            }
        }
    }
}
