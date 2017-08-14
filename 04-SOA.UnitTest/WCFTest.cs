using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _04_SOA.UnitTest.xzmcwjzs.ntu.wcf;

namespace _04_SOA.UnitTest
{
    /// <summary>
    /// wcf调用时 不要using
    /// </summary>
    [TestClass]
    public class WCFTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //using (Service1Client client = new Service1Client())
            //{ }

            Service1Client client = null;
            try
            {
                client = new Service1Client();
                string result1 = client.HelloWorld(33);
                //client.GetUserList();
                Student result2 = client.GetUser();
                client.Close();//网络出问题的时候  会异常   而且断不掉
            }
            catch (Exception)
            {
                if (client != null)
                    client.Abort();//会强制关闭 而且不抛异常
            }
        }
    }
}
