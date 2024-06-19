using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak3
{
    class Program
    {
        public static void Main(string[] args)
        {
       
            List<int> num100 = RandomNumbers.GenerateRandomNumber(100);
          /*  for (int i = 0; i < num100.Count; i++)
                Console.WriteLine(num100[i]);*/
            List<int> num1k = RandomNumbers.GenerateRandomNumber(1000);
            List<int> num10k = RandomNumbers.GenerateRandomNumber(10000);
            List<int> num100k = RandomNumbers.GenerateRandomNumber(100000);
            List<int> num1m = RandomNumbers.GenerateRandomNumber(1000000);
            List<int> num10m = RandomNumbers.GenerateRandomNumber(10000000);
            long kbAtExecution = GC.GetTotalMemory(false) / 1024;
            Console.WriteLine("Start memory used: " + kbAtExecution);
            Console.WriteLine("__________________________________");


            Console.WriteLine("100 elements: ");
            List<int> sel100 = SelectionSort.Sort(num100);
          /*  for (int i = 0; i < sel100.Count; i++)
                Console.WriteLine(sel100[i]);*/
            List<int> maxHeap100 = MaxHeapSort.Sort(num100);
          /*  for (int i = 0; i < maxHeap100.Count; i++)
                Console.WriteLine(maxHeap100[i]);*/
            List<int> bucket100 = BucketSort.Sort(num100);
           /* for (int i = 0; i < bucket100.Count; i++)
                Console.WriteLine(bucket100[i]);*/
            Console.WriteLine("__________________________________");

            Console.WriteLine("1000 elements: ");
            List<int> sel1k = SelectionSort.Sort(num1k);
            List<int> maxHeap1k = MaxHeapSort.Sort(num1k);
            List<int> bucket1k = BucketSort.Sort(num1k);
            Console.WriteLine("__________________________________");

            Console.WriteLine("10000 elements: ");
            List<int> sel10k = SelectionSort.Sort(num10k);
            List<int> maxHeap10k = MaxHeapSort.Sort(num10k);
            List<int> bucket10k = BucketSort.Sort(num10k);
            Console.WriteLine("__________________________________");

            Console.WriteLine("100000 elements: ");
            List<int> sel100k = SelectionSort.Sort(num100k);
            List<int> maxHeap100k = MaxHeapSort.Sort(num100k);
            List<int> bucket100k = BucketSort.Sort(num100k);
            Console.WriteLine("__________________________________");

            Console.WriteLine("1000000 elements: ");
            List<int> sel1m = SelectionSort.Sort(num1m);
            List<int> maxHeap1m=MaxHeapSort.Sort(num1m);
            List<int> bucket1m = BucketSort.Sort(num1m);
            Console.WriteLine("__________________________________");

            Console.WriteLine("10000000 elements: ");
            List<int> bucket10m = BucketSort.Sort(num10m);
            List<int> maxHeap10m = MaxHeapSort.Sort(num10m);
            List<int> sel10m = SelectionSort.Sort(num10m);
            Console.WriteLine("__________________________________");


        }
    }
}