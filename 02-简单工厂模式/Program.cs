using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_简单工厂模式
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        //操作 父类
        public class Operation
        {
            public double NumberA { get; set; }
            public double NumberB { get; set; }
            public virtual double GetResult()
            {
                double result = 0;
                return result;
            }
        }
        //加减乘除
        class OperationAdd : Operation
        {
            public override double GetResult()
            {
                double result = 0;
                result = NumberA + NumberB;
                return result;
            }
        }
        class OperationSub : Operation
        {
            public override double GetResult()
            {
                double result = 0;
                result = NumberA - NumberB;
                return result;
            }
        }
        class OperationMulti : Operation
        {
            public override double GetResult()
            {
                double result = 0;
                result = NumberA * NumberB;
                return result;
            }
        }
        class OperationDiv : Operation
        {
            public override double GetResult()
            {
                if (NumberB == 0)
                {
                    throw new Exception("除数不能为0!");
                }
                else
                {
                    double result = 0;
                    result = NumberA / NumberB;
                    return result;
                }
            }
        }

        //简单工厂类 负责
        public class OperationFactory
        {
            public static Operation CreateOperate(string operate)
            {
                Operation oper = null;
                switch (operate)
                {
                    case "+":
                        oper = new OperationAdd();
                        break;
                    case "-":
                        oper = new OperationSub();
                        break;
                    case "*":
                        oper = new OperationMulti();
                        break;
                    case "/":
                        oper = new OperationDiv();
                        break;
                    default:
                        break;
                }
                return oper;
            }
        }
    }
}
