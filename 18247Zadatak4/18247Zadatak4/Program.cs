using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak4
{
    public class Program
    {
 
        static void Main(string[] args)
        {
            Console.WriteLine("Prosecna vremena su izracunata u tikovima.");
            FibonacciHeap heap = new FibonacciHeap();
            int i = 0;

            long insertTime = 0;
            long deleteTime = 0;
            long extractTime = 0;

            
            while (i < 10)
            {

                function(heap, ref insertTime, ref deleteTime, ref extractTime);
                i++;
            }
            Console.WriteLine("Prosecno vreme izvrsenja insert operacije:" + insertTime/(double)i);
            Console.WriteLine("Prosecno vreme izvrsenja extract operacije: " + extractTime/(double)i);
            Console.WriteLine("Prosecno vreme izvresenja delete operacije: " + deleteTime / (double)i);

       
            i = 0;
            Console.WriteLine("Ciklus od 100 ponavljanja:");
            while (i < 100)
            {
                function(heap, ref insertTime,ref deleteTime, ref extractTime);

                i++;
            }
            Console.WriteLine("Prosecno vreme izvrsenja insert operacije:" + insertTime / (double)i);
            Console.WriteLine("Prosecno vreme izvrsenja extract operacije: " + extractTime / (double)i);
            Console.WriteLine("Prosecno vreme izvresenja delete operacije: " + deleteTime / (double)i);


            i = 0;
            Console.WriteLine("Ciklus od 1000 ponavljanja:");
            while (i < 1000)
            {
                function(heap, ref insertTime, ref deleteTime, ref extractTime);
                i++;
            }
            Console.WriteLine("Prosecno vreme izvrsenja insert operacije:" + insertTime / (double)i);
            Console.WriteLine("Prosecno vreme izvrsenja extract operacije: " + extractTime / (double)i);
            Console.WriteLine("Prosecno vreme izvresenja delete operacije: " + deleteTime / (double)i);


            i = 0;
            Console.WriteLine("Ciklus od 10 000 ponavljanja:");
            while (i < 10000)
            {
                function(heap, ref insertTime, ref deleteTime, ref extractTime);
                i++;
            }
            Console.WriteLine("Prosecno vreme izvrsenja insert operacije:" + insertTime / (double)i);
            Console.WriteLine("Prosecno vreme izvrsenja extract operacije: " + extractTime / (double)i);
            Console.WriteLine("Prosecno vreme izvresenja delete operacije: " + deleteTime / (double)i);

            i = 0;
            Console.WriteLine("Ciklus od 100 000 ponavljanja:");
            while (i < 100000)
            {
                function(heap, ref insertTime, ref deleteTime, ref extractTime);
                i++;
            }
            Console.WriteLine("Prosecno vreme izvrsenja insert operacije:" + insertTime / (double)i);
            Console.WriteLine("Prosecno vreme izvrsenja extract operacije: " + extractTime / (double)i);
            Console.WriteLine("Prosecno vreme izvresenja delete operacije: " + deleteTime / (double)i);

        }

        public static void function(FibonacciHeap heap,ref long insertTime,ref long deleteTime,ref long extractTime)
        {
            Random r = new Random();
         
           
           
            Stopwatch sw = new Stopwatch();
            sw.Start();
            heap.fibHeapInsert(r.Next(100000));
            heap.fibHeapInsert(r.Next(100000));
            heap.fibHeapInsert(r.Next(100000));
            insertTime += sw.ElapsedTicks;
            sw.Restart();

            //Console.WriteLine("Dodata su 3 nova elementa:");
            //Console.WriteLine(heap);

           
            heap.fibHeapDeleteLastNodeInserted();
            deleteTime += sw.ElapsedTicks;
            sw.Restart();

            //Console.WriteLine("Nakon brisanja:");
            //Console.WriteLine(heap);

           
            heap.fibHeapExtractMin();
            extractTime += sw.ElapsedTicks;
            sw.Restart();

            //Console.WriteLine("ExtractMin:");
             //Console.WriteLine(heap);

           
            heap.fibHeapInsert(r.Next(100000));
            heap.fibHeapInsert(r.Next(100000));
            insertTime += sw.ElapsedTicks;
            sw.Restart();

            //Console.WriteLine("Dodata su 2 nova elementa: ");
            //Console.WriteLine(heap);

           
            heap.fibHeapDeleteLastNodeInserted();
            deleteTime += sw.ElapsedTicks;
            sw.Restart();

           // Console.WriteLine("Nakon brisanja: ");
           // Console.WriteLine(heap);

           
            heap.fibHeapExtractMin();
            extractTime += sw.ElapsedTicks;
            sw.Restart();

             //Console.WriteLine("ExtractMin:");
           // Console.WriteLine(heap);

            
            heap.fibHeapInsert(r.Next(100000));
            insertTime += sw.ElapsedTicks;
            sw.Stop();

             //Console.WriteLine("Dodat je 1 novi element:");
             //Console.WriteLine(heap);

            // Console.WriteLine("----------------------------------------------");
 
        }
    }
}
