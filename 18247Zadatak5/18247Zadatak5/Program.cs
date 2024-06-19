using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _18247Zadatak5
{
    public class Program
    {
        public static void execute(Graph graph, int N, int k, string filename)
        {
            Stopwatch s=new Stopwatch();
            s.Start();
            
            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine("Slucaj 1:");
                Console.WriteLine("Slucaj 1:");
                sw.WriteLine("Generisan je graf od " + N + " cvorova za k=" + k + ":");
                graph.generateGraphCase1(N, k);
                sw.WriteLine(graph);
                sw.WriteLine("Kruskalov algoritam:");
                graph.KruskalAlgorithm();
                sw.WriteLine(graph);
                sw.WriteLine("----------------------------------");
                Console.WriteLine("Vremensko izvrsenje za N=" + N + " i k=" + k);
                Console.WriteLine(s.Elapsed);
                s.Restart();

                sw.WriteLine("Slucaj 2:");
                Console.WriteLine("Slucaj 2: ");
                sw.WriteLine("Generisan je graf od " + N + " cvorova za k=" + k + ":");
                graph.generateGraphCase2(N, k);
                sw.WriteLine(graph);
                sw.WriteLine("Kruskalov algoritam:");
                graph.KruskalAlgorithm();
                sw.WriteLine(graph);
                Console.WriteLine("Vremensko izvrsenje za N=" + N + "i k=" + k);
                Console.WriteLine(s.Elapsed);
                Console.WriteLine();
                s.Stop();

            }

        }
        public static void Main(string[] args)
        {
            
            Graph graph = new Graph();

            List<int> nlist = new List<int> { 100, 1000, 10000, 100000 };
            List<string> files = new List<string> { "kruskal100.txt", "kruskal1000.txt", "kruskal10k.txt", "kruskal100k.txt" };
            int i = 0;
             foreach (int N in nlist)
            {
                string f = files[i++];
                List<int> kList = new List<int> { 2, 5, 10, 20, 33, 50};
                foreach (int k in kList)
                { 
                        execute(graph, N, k, f);
                }

            }
        }
    }
}
