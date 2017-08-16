using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _00_反射
{
    class Program
    {
        static void Main(string[] args)
        {
            //var strDllPath = Path.Combine(@"C:\Users\wangjie\Source\Repos\MedicalInformation\ReflectorModel\bin\Debug", "ReflectorModel.dll");
            
            var strDllPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ReflectorModel.dll");
            var oAssembly = Assembly.LoadFile(strDllPath);
            var lstTypes = oAssembly.GetTypes();
            foreach (var oType in lstTypes)
            {
                if (oType.Name == "Person")
                {
                    var lstMembers = oType.GetMembers();//默认得到类下面的所有public成员
                    foreach (var oMem in lstMembers)
                    {
                        Console.WriteLine("GetMembers()方法得到的成员名称：" + oMem.Name);
                    }
                    Console.WriteLine("");

                    var lstProperty = oType.GetProperties();//默认得到类下面所有public属性
                    foreach (var oProp in lstProperty)
                    {
                        Console.WriteLine("GetProperties()方法得到的成员名称：" + oProp.Name);
                    }
                    Console.WriteLine("");

                    var lstField = oType.GetFields();//得到类下面所有public字段
                    foreach (var oField in lstField)
                    {
                        Console.WriteLine("GetFields()方法得到的成员名称：" + oField.Name);
                    }
                    Console.WriteLine("");

                    Console.WriteLine("-----------------------反射对象的私有成员--------------------");

                    var lstField2 = oType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
                    foreach (var ofield in lstField2)
                    {
                        Console.WriteLine("GetField()方法得到的成员名称：" + ofield.Name);
                    }
                    Console.WriteLine("");

                    Console.WriteLine("-----------------------反射对象的静态成员--------------------");
                    var lstMembers2 = oType.GetMembers(BindingFlags.Public | BindingFlags.Static);
                    foreach (var omem in lstMembers2)
                    {
                        Console.WriteLine("GetMembers()方法得到的成员名称：" + omem.Name);
                    }
                    Console.WriteLine("");

                    Console.WriteLine("***************反射得到对象以及对象的操作****************");
                    Type type = typeof(Person);
                    Person people = (Person)Activator.CreateInstance(type);

                    foreach (var field in type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))
                    {
                        Console.WriteLine(field.Name);
                        Console.WriteLine("{0}={1}", field.Name, field.GetValue(people));

                    }
                }
            }

            Console.ReadKey();
        }

        public class Person
        {
            private string address;
            private string email;

            public string Name { set; get; }

            public int Age { set; get; }

            public void SayHello()
            {
                Console.WriteLine("你好");
            }

            public static string MystaticPro { set; get; }
            public static void MyStatic()
            {
                Console.WriteLine("我是static方法");
            }
        }
    }
}
