using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xzmcwjzs.ntu.Framework.Log;

namespace xzmcwjzs.ntu.Framework.AOP.Behavior
{
    public class MonitorBehavior : IInterceptionBehavior
    {
        private Logger logger = Logger.CreateLogger(typeof(MonitorBehavior));

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var result = getNext().Invoke(input, getNext);
            watch.Stop();
            Console.WriteLine("共耗时{0}ms", watch.ElapsedMilliseconds);
            logger.Info(string.Format("共耗时{0}ms", watch.ElapsedMilliseconds));
            return result;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
