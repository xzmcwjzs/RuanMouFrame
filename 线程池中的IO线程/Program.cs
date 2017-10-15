using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程池中的IO线程
{
//一、I/O线程实现对文件的异步

//二、I/O线程实现对请求的异步

//三、总结
    class Program
    {
        const int maxsize = 1024;
        static byte[] readbytes = new byte[maxsize];
        static void Main(string[] args)
        {
            //const int maxsize = 100000;
            //ThreadPool.SetMaxThreads(1000, 1000);
            //PrintMessage("Main Thread start");

            //// 初始化FileStream对象
            //FileStream filestream = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 100, true);

            ////打印文件流打开的方式
            //Console.WriteLine("filestream is {0} opened Asynchronously", filestream.IsAsync ? "" : "not");

            //byte[] writebytes = new byte[maxsize];
            //string writemessage = "An operation Use asynchronous method to write message.......................";
            //writebytes = Encoding.Unicode.GetBytes(writemessage);
            //Console.WriteLine("message size is： {0} byte\n", writebytes.Length);
            //// 调用异步写入方法把信息写入到文件中
            //filestream.BeginWrite(writebytes, 0, writebytes.Length, new AsyncCallback(EndWriteCallback), filestream);
            //filestream.Flush();
            //Console.Read();

            //ThreadPool.SetMaxThreads(1000, 1000);
            //PrintMessage("Main Thread start");

            //// 初始化FileStream对象
            //FileStream filestream = new FileStream("test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 100, false);

            //// 异步读取文件内容
            //filestream.BeginRead(readbytes, 0, readbytes.Length, new AsyncCallback(EndReadCallback), filestream);
            //Console.Read();


            ThreadPool.SetMaxThreads(1000, 1000);
            PrintMessage("Main Thread start"); 
            // 发出一个异步Web请求
            WebRequest webrequest = WebRequest.Create("http://www.cnblogs.com/");
            webrequest.BeginGetResponse(ProcessWebResponse, webrequest);

            Console.Read();

        }
        // 回调方法
        private static void ProcessWebResponse(IAsyncResult result)
        {
            Thread.Sleep(500);
            PrintMessage("Asynchronous Method start");

            WebRequest webrequest = (WebRequest)result.AsyncState;
            using (WebResponse webresponse = webrequest.EndGetResponse(result))
            {
                Console.WriteLine("Content Length is : " + webresponse.ContentLength);
            }
        }
        private static void EndReadCallback(IAsyncResult asyncResult)
        {
            Thread.Sleep(1000);
            PrintMessage("Asynchronous Method start");

            // 把AsyncResult.AsyncState转换为State对象
            FileStream readstream = (FileStream)asyncResult.AsyncState;
            int readlength = readstream.EndRead(asyncResult);
            if (readlength <= 0)
            {
                Console.WriteLine("Read error");
                return;
            }

            string readmessage = Encoding.Unicode.GetString(readbytes, 0, readlength);
            Console.WriteLine("Read Message is :" + readmessage);
            readstream.Close();
        }
        // 当把数据写入文件完成后调用此方法来结束异步写操作
        private static void EndWriteCallback(IAsyncResult asyncResult)
        {
            Thread.Sleep(500);
            PrintMessage("Asynchronous Method start");

            FileStream filestream = asyncResult.AsyncState as FileStream;

            // 结束异步写入数据
            filestream.EndWrite(asyncResult);
            filestream.Close();
        }

        // 打印线程池信息
        private static void PrintMessage(String data)
        {
            int workthreadnumber;
            int iothreadnumber;

            // 获得线程池中可用的线程，把获得的可用工作者线程数量赋给workthreadnumber变量
            // 获得的可用I/O线程数量给iothreadnumber变量
            ThreadPool.GetAvailableThreads(out workthreadnumber, out iothreadnumber);

            Console.WriteLine("{0}\n CurrentThreadId is {1}\n CurrentThread is background :{2}\n WorkerThreadNumber is:{3}\n IOThreadNumbers is: {4}\n",
                data,
                Thread.CurrentThread.ManagedThreadId,
                Thread.CurrentThread.IsBackground.ToString(),
                workthreadnumber.ToString(),
                iothreadnumber.ToString());
        }


    }
}
