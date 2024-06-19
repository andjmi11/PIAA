using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak3
{
    public class SelectionSort
    {
        public static List<int> Sort(List<int> numbers)
        {
            Stopwatch s = new Stopwatch();

            for(int i=0; i < numbers.Count; i++)
            {
                int minIndex = i;
                for(int j=i+1;j<numbers.Count; j++)
                    if (numbers[j] < numbers[minIndex])
                        minIndex = j;

                int tmp = numbers[minIndex];
                numbers[minIndex] = numbers[i];
                numbers[i] = tmp;
            }

            Console.WriteLine("SelectionSort stopwatch: " + s.Elapsed);
            s.Stop();

            long kbAtExecution = GC.GetTotalMemory(false) / 1024;
            Console.WriteLine("SelectionSort memory used: " + kbAtExecution);
            return numbers;
        }
    }
}
