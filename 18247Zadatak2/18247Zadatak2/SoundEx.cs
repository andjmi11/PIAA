using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _18247Zadatak2
{
    public class SoundEx
    {
        private string pattern;
        private string patternCode;
        public SoundEx(string pattern)
        {
            this.pattern = pattern;
            this.patternCode = SoundExCode(pattern);
        }

        private string SoundExCode(string word)
        {
            word = word.ToLower();
            word = word[0] +
                Regex.Replace(
                    Regex.Replace(
                    Regex.Replace(
                    Regex.Replace(
                    Regex.Replace(
                    Regex.Replace(
                    Regex.Replace(word.Substring(1), "[bfpv]+", "1"),
                     "[cgjkqsxz]+", "2"),
                     "[dt]+", "3"),
                     "[l]+", "4"),
                     "[mn]+", "5"),
                     "[r]+", "6"),
                     "[aeiouywh]", "");

            return word.PadRight(4, '0').Substring(0, 4);
        }

        public void SearchAllEqualCodes(string[] words, string writeToFile)
        {
            Stopwatch st = new Stopwatch();
            Console.WriteLine("SoundEx pattern: " + pattern);

            st.Start();
            using (StreamWriter sw=new StreamWriter(writeToFile))
            {
                foreach(string word in words)
                {
                    if (SoundExEquals(word))
                        sw.WriteLine("Pattern: " + pattern + " Word: " +  word + " Code: " + patternCode);
                }
                sw.WriteLine("Stopwatch: " + st.Elapsed);
            }
            Console.WriteLine("Stopwatch ended: " + st.Elapsed);
            Console.WriteLine("______________________________________________");
            st.Stop();
        }

        private bool SoundExEquals(string word)
        {
            return patternCode.Equals(SoundExCode(word));
        }
    }
}
