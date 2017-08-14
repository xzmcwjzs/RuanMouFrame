using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _04_SOA.WCF.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ServiceHost> hostList = new List<ServiceHost>()
            {
                new ServiceHost(typeof(Service)),
            };
            foreach (ServiceHost host in hostList)
            {
                host.Opened += delegate
                {
                    System.Console.WriteLine("{0}已经启动！", host.Description);
                };

                host.Open();
            }
            System.Console.WriteLine("输入任何字符串停止服务");
            System.Console.ReadKey();

            foreach (ServiceHost host in hostList)
            {
                host.Abort();
            }
        }
    }
}
