using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Crawler_爬虫_.DataService
{
    public class ObjectFactory
    {
        public static string DataPath = ConfigurationManager.AppSettings["DataPath"];
    }
}
