using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_异步编程
{
   public class MyDelegate
    {
        //【1】定义委托（参数1：操作数  参数2：延长的秒数）
        public delegate int MyCalculator(int num, int ms);

        //【2】根据委托定义方法（返回一个数据的平方）
        private int ExcuteTask(int num, int ms)
        {
            System.Threading.Thread.Sleep(ms);
            return num * num;
        }
        //【3】创建委托变量（以为后面回调函数要使用，所以委托变量要定义成成员变量的范围）
        private MyCalculator objMyCal = null;
         
        public void Caculate()
        {
            // 初始化委托变量（也就是将委托变量和具体方法关联）
            objMyCal = new MyCalculator(ExcuteTask);
            //模拟10个任务（如果是同步执行需要55秒，而异步执行只需要10秒）
            for (int i = 1; i < 11; i++)
            {
                //开始异步执行，并封装回调函数
                objMyCal.BeginInvoke(10 * i, 1000 * i, MyCallBack, i);
                //最后一个参数i给回调函数字段AsyncState赋值，表示第几个，这个字段是object类型
            }
        }
        //【5】回调函数（同步执行的任务中，谁完成，谁就会主动的调用回调函数）
        private void MyCallBack(IAsyncResult result)
        {
            int res = objMyCal.EndInvoke(result);
            //异步显示执行的结果：
            Console.WriteLine("第{0}个计算结果为：{1}", result.AsyncState.ToString(), res);
        }

        //异步编程总结：
        //1. 异步编程是建立在委托基础之上的编程方法。
        //2. 异步调用的每个方法都是在独立的线程中执行的。因此，本质上就是一种多线程程序，也就是“简化的多线程技术”。
        //3. 比较适合在后台运行较为耗时的“简单任务”，并且任务之间是独立，任务中不要有直接访问可视化控件的内容。
        //4. 如果后台任务要求必须按照特定顺序执行，或者访问特定资源，异步编程不太合适，而应该选择多线程开发技术。
        //5. 学习异步编程就是为多线程学习做铺垫的。

        //Ajax（异步访问：自己编写js内容实现异步调用     $.post()  $.Ajax()）

    }
}
