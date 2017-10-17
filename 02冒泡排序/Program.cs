using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02冒泡排序
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
            BubbleSort(arr);
            Console.WriteLine("\n排序后数组值为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
        }
        private static void BubbleSort(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException("arr");
            int temp;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length-i-1; j++)
                {
                    if (arr[j + 1] < arr[j]) {
                        temp = arr[j + 1];
                        arr[j+1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }

        }

    }
}
