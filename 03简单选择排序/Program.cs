using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03简单选择排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -1, -2, 3, 45, 75, 12, -4, 90, 21 };
            Console.WriteLine("排序前数组值为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            SimpleSelectSort(arr);
            Console.WriteLine("\n排序后数组值为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
        }
        private static void SimpleSelectSort(int[] arr) {
            int temp=0;
            int t = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                t = i;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[t] > arr[j])
                    {
                        t = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[t];
                arr[t] = temp;
            }
        }

    }
}
