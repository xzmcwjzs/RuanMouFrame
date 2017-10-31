using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _11_IQueryable
{
    //lambda表达式和表达式树的区别：
    //Lambda表达式：
    //Func<Student, bool> func = t => t.Name == "王杰";

    //表达式树： 
    //Expression<Func<Student, bool>> expression = t => t.Name == "王杰";

    // 咋一看，没啥区别啊。表达式只是用Expression包了一下而已。那你错了。
    // 第一个lambda表达式编译成了匿名函数，第二个表达式树编译成一了一堆我们不认识的东西，远比我们原来写的lambda复杂得多。

    //表达式树转成Lambda表达式：Expression<Func<Student, bool>> expression = t => t.Name == "王杰";Func<Student, bool> func = expression.Compile();


    class Program
    {
        public static List<Student> StudentArrary = new List<Student>()
        {
            new Student(){Name="王杰", Age=26, Sex="男", Address="长沙"},
            new Student(){Name="小明", Age=23, Sex="男", Address="岳阳"},
            new Student(){Name="嗨-妹子", Age=25, Sex="女", Address="四川"}
        };
        static void Main(string[] args)
        {
            //Expression<Func<Student, bool>> expression = t => t.Name == "王杰" && t.Sex == "男";
            //AnalysisExpression.VisitExpression(expression);

            var aa = new MyQueryable<Student>();
            var bb = aa.Where(t => t.Name == "农码一生");
            var cc = bb.Where(t => t.Sex == "男");
            var dd = cc.AsEnumerable();
            var ee = cc.ToList();

            Console.ReadKey();
        }
    }
}
