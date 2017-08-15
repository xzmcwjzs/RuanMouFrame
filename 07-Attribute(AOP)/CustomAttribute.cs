using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Attribute_AOP_
{
    /// <summary>
    /// 必须是Attribute子类
    /// 一般以Attribute结尾
    /// </summary>
  public  class CustomAttribute:Attribute
    {
        public CustomAttribute() { }
        public CustomAttribute(int version)
        {
            this.Version = version;
        }

        private int Version = 1;
        public string Remark { get; set; }

        public void ShowVersion()
        {
            Console.WriteLine("当前version是{0}", this.Version);
        }
    }

    public class ExceptionAttribute : Attribute
    {

    }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class InheritAttribute : Attribute
    {

    }
    public class PrimaryKeyAttribute : Attribute
    {
        private string Key = "";
        public PrimaryKeyAttribute(string name)
        {
            this.Key = name;
        }
        public void ShowKey()
        {
            Console.WriteLine(this.Key);
        }
    }

}
