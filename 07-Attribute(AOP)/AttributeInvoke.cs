using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _07_Attribute_AOP_
{
  public  class AttributeInvoke
    {
        public static void Show<T>(T t) where T : Student
        {
            Type type = t.GetType();
            {
                object[] oAttributeArray = type.GetCustomAttributes(typeof(CustomAttribute), true);
                if (oAttributeArray != null && oAttributeArray.Length > 0)
                {
                    CustomAttribute attribute = (CustomAttribute)oAttributeArray[0];
                    attribute.ShowVersion();
                    Console.WriteLine(attribute.Remark); 

                    //额外 提供其他功能
                    //校验、异常处理 统计 安全认证等
                }
            }

            //{
            //    PropertyInfo prop = type.GetProperty("Id");
            //    IEnumerable<Attribute> oAttributeArray = prop.GetCustomAttributes(typeof(PrimaryKeyAttribute));
            //    if (oAttributeArray != null && oAttributeArray.Count() > 0)
            //    {
            //        PrimaryKeyAttribute attribute = (PrimaryKeyAttribute)oAttributeArray.First();
            //        attribute.ShowKey();
            //    }
            //}
            


            Console.WriteLine("这个学员id={0} name={1}",t.Id,t.Name);
        }

    }
}
