using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak3
{
    public class BucketSort
    {
        public static List<int> Sort(List<int> numbers)
        {
          
            Stopwatch st = Stopwatch.StartNew();
            st.Start();
        
            List<int> result = new List<int>();
          
            int minValue = numbers[0];
            int maxValue = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i] > maxValue)
                    maxValue = numbers[i];
                if (numbers[i] < minValue)
                    minValue = numbers[i];
            }

            int numOfBuckets = (int)Math.Sqrt(maxValue - minValue + 1)  + 2;
            List<int>[] buckets = new List<int>[numOfBuckets];

            for (int i = 0; i < numOfBuckets; i++)
            {
                buckets[i] = new List<int>();
            }

            for (int i=0;i<numbers.Count;i++)
            {
                int bucketSpace=numbers[i]/numbers.Count;
                buckets[bucketSpace].Add(numbers[i]);
            }

            for(int i=0;i<buckets.Length ;i++)
            {
                if (buckets[i].Count > 1)
                    buckets[i].Sort();
                result.AddRange(buckets[i]);
            }
            Console.WriteLine("BucketSort stopwatch: " + st.Elapsed);
            st.Stop();

            long kbAtExecution = GC.GetTotalMemory(false) / 1024;
            Console.WriteLine("BucketSort memory used: " + kbAtExecution);

            return result;
        }
    }
}


