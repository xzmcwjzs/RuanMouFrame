using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00_递归
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.  斐波那契数列问题
            //提到递归，我们可能会想到的一个实例便是斐波那契数列。斐波那契数列就是如下的数列：
            //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, …，总之，就是第N(N > 2)个数等于第(N - 1)个数和(N - 2)个数的和
            Console.WriteLine("输入第n个你想得到的斐波那契数");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine("第n个斐波那契数为：" + Fibonacci(num));

            //2.  阶乘
            //0!=1 1!=1 2!=1*2=2 3!=1*2*3=2!*3=6 n!=(n-1)!*n
            Console.WriteLine("输入n的阶乘");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("{0}的阶乘为：{1}", num1, Factorial(num1));

            //3.  汉诺塔问题
            //有三根杆子A，B，C。A杆上有N个(N > 1)穿孔圆盘，盘的尺寸由下到上依次变小。要求按下列规则将所有圆盘移至C杆：
            //1、每次只能移动一个圆盘；
            //2、大盘不能叠在小盘上面。
            //提示：可将圆盘临时置于B杆，也可将从A杆移出的圆盘重新移回A杆，但都必须遵循上述两条规则。
            //问：如何移？最少要移动多少次？
            Console.WriteLine("输入圆盘数n");
            int num2 = int.Parse(Console.ReadLine());
            hannoi(num2, "A", "B", "C");
            //4.  全排列问题
            string[] Nums = new string[] { "a", "b", "c" };
            Console.WriteLine("数组abc的全排列为：");
            Permutation(Nums, 0, Nums.Length);
            Console.ReadKey();
        }
        public static int Fibonacci(int n)
        {
            if (n < 1) return -1;
            if (n == 1) return 0;
            if (n == 2) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
        public static int Factorial(int n)
        {
            int sum = 0;
            if (n == 0) return 1;
            else
                sum = Factorial(n - 1) * n;
            return sum;
        }
        public static void hannoi(int n, string from, string buffer, string to)
        {
            if (n == 1)
            {
                Console.WriteLine("Move disk " + n + " from " + from + " to " + to);
            }
            else
            {
                hannoi(n - 1, from, to, buffer);
                Console.WriteLine("Move disk " + n + " from " + from + " to " + to);
                hannoi(n - 1, buffer, from, to);
            }
        }
        public static void Permutation(string[] nums, int m, int n)
        {
            string t;
            if (m < n - 1)
            {
                Permutation(nums, m + 1, n);
                for (int i = m + 1; i < n; i++)
                {
                    //可抽取Swap方法
                    t = nums[m];
                    nums[m] = nums[i];
                    nums[i] = t;

                    Permutation(nums, m + 1, n);

                    //可抽取Swap方法
                    t = nums[m];
                    nums[m] = nums[i];
                    nums[i] = t;
                }
            }
            else
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    Console.Write(nums[j]);
                }
                Console.WriteLine();
            }
        }
    }
}
