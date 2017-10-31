using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _11_IQueryable
{
    //表达式解析
    public static class AnalysisExpression
    {
        public static void VisitExpression(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Call://执行方法
                    MethodCallExpression method = expression as MethodCallExpression;
                    Console.WriteLine("方法名:" + method.Method.Name);
                    for (int i = 0; i < method.Arguments.Count; i++)
                        VisitExpression(method.Arguments[i]);
                    break;
                case ExpressionType.Lambda://lambda表达式
                    LambdaExpression lambda = expression as LambdaExpression;
                    VisitExpression(lambda.Body);
                    break;
                case ExpressionType.Equal://相等比较
                case ExpressionType.AndAlso://and条件运算
                    BinaryExpression binary = expression as BinaryExpression;
                    Console.WriteLine("运算符:" + expression.NodeType.ToString());
                    VisitExpression(binary.Left);
                    VisitExpression(binary.Right);
                    break;
                case ExpressionType.Constant://常量值
                    ConstantExpression constant = expression as ConstantExpression;
                    Console.WriteLine("常量值:" + constant.Value.ToString());
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression Member = expression as MemberExpression;
                    Console.WriteLine("字段名称:{0}，类型:{1}", Member.Member.Name, Member.Type.ToString());
                    break;
                default:
                    Console.Write("UnKnow");
                    break;
            }
        }
        public static void VisitExpression2(Expression expression, ref List<LambdaExpression> lambdaOut)
        {
            if (lambdaOut == null)
                lambdaOut = new List<LambdaExpression>();
            switch (expression.NodeType)
            {
                case ExpressionType.Call://执行方法
                    MethodCallExpression method = expression as MethodCallExpression;
                    Console.WriteLine("方法名:" + method.Method.Name);
                    for (int i = 0; i < method.Arguments.Count; i++)
                        VisitExpression2(method.Arguments[i], ref lambdaOut);
                    break;
                case ExpressionType.Lambda://lambda表达式
                    LambdaExpression lambda = expression as LambdaExpression;
                    lambdaOut.Add(lambda);
                    VisitExpression2(lambda.Body, ref lambdaOut);
                    break;
                case ExpressionType.Equal://相等比较
                case ExpressionType.AndAlso://and条件运算
                    BinaryExpression binary = expression as BinaryExpression;
                    Console.WriteLine("运算符:" + expression.NodeType.ToString());
                    VisitExpression2(binary.Left, ref lambdaOut);
                    VisitExpression2(binary.Right, ref lambdaOut);
                    break;
                case ExpressionType.Constant://常量值
                    ConstantExpression constant = expression as ConstantExpression;
                    Console.WriteLine("常量值:" + constant.Value.ToString());
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression Member = expression as MemberExpression;
                    Console.WriteLine("字段名称:{0}，类型:{1}", Member.Member.Name, Member.Type.ToString());
                    break;
                case ExpressionType.Quote:
                    UnaryExpression Unary = expression as UnaryExpression;
                    VisitExpression2(Unary.Operand, ref lambdaOut);
                    break;
                default:
                    Console.Write("UnKnow");
                    break;
            }
        }
    }
}
