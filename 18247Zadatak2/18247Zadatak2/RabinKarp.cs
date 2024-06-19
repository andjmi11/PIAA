using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak2
{
    public class RabinKarp
    {
        public static void RabinKarpMatcher(string text, string pattern, int d, string fileName)
        {
            Stopwatch st = new Stopwatch();
            Console.WriteLine("Rabin Karp \n" + "Pattern: " + pattern.Length + " d:" + d);
            st.Start();
            List<int> patterns = new List<int>();

            int q = 13;
            int n = text.Length;
            int m= pattern.Length;
            int h=(int)(Math.Pow(d,m-1)%q);
            int p = 0;
            int t = 0;

            
            for(int i=0;i<m-1;i++)
            {
                p = (d * p + pattern[i]) % q;
                t = (d * t + text[i]) % q;
            }

            for(int i = 0; i < n - m;i++)
            {
                if(p==t) 
                {
                    string s = text.Substring(i, m);
                    if(s.Equals(pattern))
                    {
                        patterns.Add(i);   
                    }
                }
                else if(i<n-m)
                {
                    t = (d * (t - text[i] * h) + text[i + m]) % q;
                    if (t < 0)
                        t += q;
                }
                

               
            }

            TimeSpan time = st.Elapsed;
            Console.WriteLine("Stopwatch:" + time);
            Console.WriteLine();
            Console.WriteLine("______________________________________________");
            st.Stop();

            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Patterns:");
                foreach (int i in patterns)
                    sw.WriteLine(i);
                sw.WriteLine("RabinKarp starwatch: " + time);
            }

        }
        
    }

    
}
