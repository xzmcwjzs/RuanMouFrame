using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Attribute_AOP_
{
    //[Obsolete("user other",false)]
    [Serializable]
    [CustomAttribute(Remark ="你好")]
   public class Student
    {
        [PrimaryKey("StudentId")]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    [Custom(34, Remark = "vip的公开课学员")]
    public class VipStudent:Student
    { 
         public int Price { get; set; }
    }
    [Custom(3,Remark ="免费的公开课学员")]
    public class FreeStudent : Student
    {

    }
}
