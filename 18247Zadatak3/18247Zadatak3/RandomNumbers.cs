using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak3
{
    public class RandomNumbers
    {
        public static List<int> GenerateRandomNumber(int numOfElements)
        {
            Random r = new Random();
            List<int> numbers = new List<int>();
                for (int i = 0; i < numOfElements; i++)
                    numbers.Add(r.Next(10000));
            return numbers;
        }
    }
}