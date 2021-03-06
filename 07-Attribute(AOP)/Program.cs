﻿using _07_Attribute_AOP_.AOP;
using _07_Attribute_AOP_.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Attribute_AOP_
{
    
    class Program
    {
        private static Logger logger = Logger.CreateLogger(typeof(Program));
        static void Main(string[] args)
        {
            Student student = new Student()
            {
                Id = 8,
                Name = "王杰"
            };
            VipStudent vip = new VipStudent()
            {
                Id = 2,
                Name = "ks"
            };
            FreeStudent free = new FreeStudent()
            {
                Id = 22,
                Name = "免费的福哥"
            };

            AttributeInvoke.Show<Student>(student);
            Console.WriteLine("=========================");
            AttributeInvoke.Show<VipStudent>(vip);
            Console.WriteLine("=========================");
            AttributeInvoke.Show<FreeStudent>(free);
            Console.WriteLine("=========================");
            UnityAOP.Show();

           //logger.Error("测试异常", null);
              
            Console.ReadKey();
        }
    }
}
