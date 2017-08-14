using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace _04_SOA.WCF.Application
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string HelloWorld(int num);

        [OperationContract]
        Student GetUser();

        List<Student> GetUserList();

        // TODO: 在此添加您的服务操作
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class Student
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class Service : IService1
    {

        public string HelloWorld(int num)
        {
            return "Hello World " + num;
        }

        public Student GetUser()
        {
            return new Student()
            {
                Id = 11,
                Name = "憨豆",
                Password="12345"
            };
        }

        public List<Student> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
