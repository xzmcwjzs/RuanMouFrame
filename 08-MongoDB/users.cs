using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_MongoDB
{
   public class users
    {
        public string id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public int age { get; set; }
        public DateTime createtime { get; set; }
    }
}
