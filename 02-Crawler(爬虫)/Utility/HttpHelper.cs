using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _02_Crawler_爬虫_.Utility
{
   public class HttpHelper
    {
        public static string DownloadCategory(string url)
        {
            return DownloadHtml(url, Encoding.UTF8);
        }
        public static string DownloadCommodity(string url)
        {
            return DownloadHtml(url, Encoding.UTF8);
        }
        /// <summary>
        /// 下载html
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string DownloadHtml(string url,Encoding encode)
        {
            string html = string.Empty;
            try
            {
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;//模拟请求
                request.Timeout = 30 * 1000;//设置30s的超时
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
                request.ContentType = "text/html;charset=utf-8";

                using (HttpWebResponse response=request.GetResponse() as HttpWebResponse)//发起请求
                {
                    if (response.StatusCode != HttpStatusCode.OK) {
                        Console.WriteLine("抓取{0}地址返回失败，response.StatusCode为{1}",url,response.StatusCode);
                    }
                    else
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(response.GetResponseStream(), encode);
                            html = sr.ReadToEnd();//读取数据
                            sr.Close();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("DownloadHtml抓取{0}保存失败", url);
                            html = null;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                if(ex.Message.Equals("远程服务器返回错误: (306)。"))
                {
                    Console.WriteLine("远程服务器返回错误: (306)。");
                    return null;
                } 
            }
            catch(Exception)
            {
                Console.WriteLine("DownloadHtml抓取{0}保存失败", url);
                html = null;
            }
            return html;
        }
    }
}
