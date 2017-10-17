using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04快速排序
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
            QuickSort(arr,0,arr.Length-1);
            Console.WriteLine("\n排序后数组值为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
        }
        private static void QuickSort(int[] arr,int low,int high)
        {
            int i = low;
            int j = high;
            int temp = arr[low];
            while (low<high)
            {
                while (low<high&&arr[high]>=temp)
                {
                    high--;
                }
                arr[low] = arr[high];
                low++;
                while (low<high&&arr[low]<=temp)
                {
                    low++;
                }
                arr[high] = arr[low];
                high--;
            }
            arr[low] = temp;//此时low等于high
            if (i < low - 1)
            {
                QuickSort(arr, i, low - 1);
            }
            if (j > high + 1)
            {
                QuickSort(arr, high + 1, j);
            }
        }
    }
}
