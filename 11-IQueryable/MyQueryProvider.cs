using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _11_IQueryable
{
    public class MyQueryProvider : IQueryProvider
    {
        public IQueryable CreateQuery(Expression expression)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new MyQueryable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return new List<object>();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            List<LambdaExpression> lambda = null;
            AnalysisExpression.VisitExpression2(expression, ref lambda);//解析取得表达式数中的表达式
            IEnumerable<Student> enumerable = null;
            for (int i = 0; i < lambda.Count; i++)
            {
                //把LambdaExpression转成Expression<Func<Student, bool>>类型
                //通过方法Compile()转成委托方法
                Func<Student, bool> func = (lambda[i] as Expression<Func<Student, bool>>).Compile();
                if (enumerable == null)
                    enumerable = Program.StudentArrary.Where(func);//取得IEnumerable
                else
                    enumerable = enumerable.Where(func);
            }
            dynamic obj = enumerable.ToList();//（注意：这个方法的整个处理过程，你可以换成解析sql执行数据库查询，或者生成url然后请求获取数据。）
            return (TResult)obj;
        }
    }
}
