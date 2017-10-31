using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _11_IQueryable
{
    //我们看到其中有个接口属性 IQueryProvider ，这个接口的作用大着呢，主要作用是在执行查询操作符的时候重新创建 IQueryable<T> 并且最后遍历的时候执行sql远程取值。我们还看见了 Expression  属性。现在我们明白了 IQueryable<T> 和 Expression （表达式树）的关系了吧：IQueryable<T> 最主要的作用就是用来存储 Expression（表达式树）

    public class MyQueryable<T> : IQueryable<T>
    {
        public MyQueryable()
        {
            _provider = new MyQueryProvider();
            _expression = Expression.Constant(this);
        }

        public MyQueryable(Expression expression)
        {
            _provider = new MyQueryProvider();
            _expression = expression;
        }
        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }
        private Expression _expression;
        public Expression Expression
        {
            get
            {
                return _expression;
            }
        }
        private IQueryProvider _provider;
        public IQueryProvider Provider
        {
            get
            {
                return _provider;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return (Provider.Execute(Expression) as IEnumerable).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            var result = _provider.Execute<List<T>>(_expression);
            if (result == null)
                yield break;
            foreach (var item in result)
            {
                yield return item;
            }
        }
    }
}
