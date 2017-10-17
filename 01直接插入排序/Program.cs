using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01直接插入排序
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { -1,-2,3,45,75,12,-4,90,21};
            Console.WriteLine("排序前数组值为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            InsertSort(arr);
            Console.WriteLine("\n排序后数组值为：");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadKey();
        }

        private static void InsertSort(int[] arr)
        {
            if (arr == null) throw new ArgumentNullException("arr");
            for (int i =1; i < arr.Length; i++)
            {
                if (arr[i] < arr[i-1]) {//从数组i位 开始向前比较 如果比i大 则通过下面的for循环继续向前比较
                    int temp = arr[i];
                    int j = 0;
                    for (j = i-1; j >=0 && temp<arr[j]; --j)
                    {
                        arr[j + 1] = arr[j];  //如果已排序的元素大于新元素，将该元素移到下一位置
                    }
                    arr[j + 1] = temp;//将arr[i]放到合适位置
                } 
            } 
        }

    }
}
