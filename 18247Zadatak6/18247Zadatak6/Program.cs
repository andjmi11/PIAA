using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Graph graph = new Graph();

            List<int> nlist = new List<int> { 100, 1000, 10000, 100000 };

            foreach (int N in nlist)
            {
                List<int> kList = new List<int> { 2, 5, 10, 20, 33, 50 };
                foreach (int k in kList)
                {
                    Console.WriteLine();
                    Console.WriteLine("Graf od " + N + " grana za k=" + k + ".");
                    Console.WriteLine();

                    Console.WriteLine("Slucaj 1:");
                    graph.generateGraphCase1(N, k);
                    // Console.WriteLine(graph);
                    graph.testDijkstra();



                    Console.WriteLine("Slucaj 2:");
                    graph.generateGraphCase2(N, k);
                    //Console.WriteLine(graph);
                    graph.testDijkstra(); 

                    Console.WriteLine("------------------------------------------------------");
                }
            }


        }
    }
}
