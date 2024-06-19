using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak1
{
    public class Program
    {

        static void Main(string[] args)
        {
               
                LZW lorem100 = new LZW("lorem100.txt", "lzw100.bin");
                lorem100.Decode();           
                var c = lorem100.CompressionRatio("lzw100.bin", "lorem100.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");
             

                LZW lorem1k = new LZW("lorem1k.txt", "lzw1k.bin");
                lorem1k.Decode();  
                c = lorem1k.CompressionRatio("lzw1k.bin", "lorem1k.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");
         

                LZW lorem10k = new LZW("lorem10k.txt", "lzw10k.bin");
                lorem10k.Decode();
                c = lorem10k.CompressionRatio("lzw10k.bin", "lorem10k.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");


                LZW lorem100k = new LZW("lorem100k.txt", "lzw100k.bin");
                lorem100k.Decode();            
                c = lorem100k.CompressionRatio("lzw100k.bin", "lorem100k.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");

         
                LZW lorem1m = new LZW("lorem1m.txt", "lzw1m.bin");
                lorem1m.Decode();
                c = lorem1m.CompressionRatio("lzw1m.bin", "lorem1m.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");
              

                LZW lorem10m = new LZW("lorem10m.txt", "lzw10m.bin");
                lorem1m.Decode();
                c = lorem10m.CompressionRatio("lzw10m.bin", "lorem10m.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");
     

                //____________________________________________________________________

              
                LZW r100 = new LZW("100random.txt", "r100.bin");
                lorem1m.Decode();
                c = r100.CompressionRatio("r100.bin", "100random.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");
             

                LZW r1k = new LZW("1Krandom.txt", "r1k.bin");
                lorem1m.Decode();
                c = r1k.CompressionRatio("r1k.bin", "1Krandom.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");
               
                LZW r10k = new LZW("10Krandom.txt", "r10k.bin");
                lorem1m.Decode();
                c = r10k.CompressionRatio("r10k.bin", "10krandom.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");
              

                LZW r100k = new LZW("100Krandom.txt", "r100k.bin");
                lorem1m.Decode();
                c = r100k.CompressionRatio("r100k.bin", "100Krandom.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");

                LZW r1m = new LZW("1Mrandom.txt", "r1m.bin");
                lorem1m.Decode();
                c = r1m.CompressionRatio("r1m.bin", "1Mrandom.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");


                LZW r10m = new LZW("10Mrandom.txt", "r10m.bin");
                lorem1m.Decode();
                c = r10m.CompressionRatio("r10m.bin", "10Mrandom.txt");
                Console.WriteLine("Stepen kompresije: " + c.ToString() + "%");
                Console.WriteLine("_____________________________________________");
                
            }

        }
    }


