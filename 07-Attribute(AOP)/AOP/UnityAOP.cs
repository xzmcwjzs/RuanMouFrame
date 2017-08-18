using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Attribute_AOP_.AOP
{
   public class UnityAOP
    {
        public static void Show()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IUserProcessor, UserProcessor>();//声明UnityContainer并注册IUserProcessor
            container.AddNewExtension<Interception>().Configure<Interception>().SetInterceptorFor<IUserProcessor>(new InterfaceInterceptor());
            User user = new User() {Id=12, Name = "wangjie", Password = "123432423456" };
            IUserProcessor userprocessor = container.Resolve<IUserProcessor>();
            userprocessor.RegUser(user);//调用
            //userprocessor.GetUser(user);
        }

        #region 特性对应的行为
        public class UserHandler : ICallHandler
        {
            public int Order { get; set; }
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                User user = input.Inputs[0] as User;
                if (user.Password.Length < 10)
                {
                    return input.CreateExceptionMethodReturn(new Exception("密码长度不能小于10位"));
                }
                Console.WriteLine("参数检测无误");

                //InvokeHandlerDelegate delegateMethod = getNext();
                //IMethodReturn methodReturn = delegateMethod(input, getNext);
                return getNext()(input, getNext);
            }
        }

        public class LogHandler : ICallHandler
        {
            public int Order { get; set; }
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                User user = input.Inputs[0] as User;
                string message = string.Format("RegUser:Username:{0},Password:{1}", user.Name, user.Password);
                Console.WriteLine("日志已记录，Message:{0},Ctime:{1}", message, DateTime.Now);
                return getNext()(input, getNext);
            }
        }


        public class ExceptionHandler : ICallHandler
        {
            public int Order { get; set; }
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                IMethodReturn methodReturn = getNext()(input, getNext);
                if (methodReturn.Exception == null)
                {
                    Console.WriteLine("无异常");
                }
                else
                {
                    Console.WriteLine("异常:{0}", methodReturn.Exception.Message);
                }
                return methodReturn;
            }
        }

        public class AfterLogHandler : ICallHandler
        {
            public int Order { get; set; }
            public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
            {
                IMethodReturn methodReturn = getNext()(input, getNext);
                User user = input.Inputs[0] as User;
                string message = string.Format("RegUser:Username:{0},Password:{1}", user.Name, user.Password);
                Console.WriteLine("完成日志，Message:{0},Ctime:{1},计算结果{2}", message, DateTime.Now, methodReturn.ReturnValue);
                return methodReturn;
            }
        }
        #endregion 特性对应的行为

        #region 特性
        public class UserHandlerAttribute : HandlerAttribute
        {
            public new int Order { get; set; }
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                ICallHandler handler = new UserHandler() { Order = this.Order };
                return handler;
            }
        }

        public class LogHandlerAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                return new LogHandler() { Order = this.Order };
            }
        }

        public class ExceptionHandlerAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                return new ExceptionHandler() { Order = this.Order };
            }
        }

        public class AfterLogHandlerAttribute : HandlerAttribute
        {
            public override ICallHandler CreateHandler(IUnityContainer container)
            {
                return new AfterLogHandler() { Order = this.Order };
            }
        }
        #endregion 特性

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
        }

        [UserHandlerAttribute(Order = 1)]
        [LogHandlerAttribute(Order = 2)]
        [ExceptionHandlerAttribute(Order = 3)]
        [AfterLogHandlerAttribute(Order = 5)]
        public interface IUserProcessor
        {
            void RegUser(User user);
            User GetUser(User user);
        }
        public class UserProcessor :  IUserProcessor
        {
            public void RegUser(User user)
            {
                Console.WriteLine("用户已注册。");
                //throw new Exception("11");
            } 
            public User GetUser(User user)
            {
                return user;
            }
        }

    }
}
