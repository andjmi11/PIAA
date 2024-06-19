using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _18247Zadatak6
{
    public class Graph
    {
        public List<Node> Nodes { get; set; }
        public List<Edge> Edges { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
            Edges = new List<Edge>();
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public void AddEdge(Node s, Node d, int w)
        {
            Edge edge = new Edge(s, d, w);
            Edges.Add(edge);
            s.Neighbors.Add(edge);
            d.Neighbors.Add(edge);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Edge edge in Edges)
            {
                sb.AppendLine(edge.ToString());
            }
            return sb.ToString();

        }
        public void generateGraphCase1(int n, int k)
        {

            Random r = new Random();

            List<Node> nodesList = new List<Node>();
            Edges.RemoveAll(e => e != null); //kad prodje za jedan slucaj,ako ne uradim removeAll dodace se novi cvorovi na vec postojece

            // generisanje n cvorova
            for (int i = 0; i < n; i++)
            {
                Node node = new Node(i);
                AddNode(node);
                nodesList.Add(node);
            }

            // slucajno izabrani cvor spojiti sa svim ostalim cvorovima
            int startIndex = r.Next(n);
            Node start = nodesList[startIndex];
            for (int i = 0; i < n; i++)
            {
                if (i == startIndex)
                {
                    continue;
                }
                Node d = nodesList[i];

                int weight = r.Next(1, k * n);
                AddEdge(start, d, weight);

                // Edges.Add(new Edge(start, d, weight));
            }

            // dodati jo k*n potega izmedju dva slucajno izabrana cvora
            for (int i = 0; i < k * n; i++)
            {
                int sIndex = r.Next(n);
                int dIndex = r.Next(n);

                Node s = nodesList[sIndex];
                Node d = nodesList[dIndex];

                if (s == d)
                    continue;

                bool alreadyConnected = false;
                foreach (Edge edge in Edges)
                {
                    if ((edge.Source == s && edge.Destination == d) || (edge.Source == d && edge.Destination == s)) // da ne bi dodavao npr 1->0 i 0->1
                    {
                        alreadyConnected = true;
                        break;
                    }
                }

                if (!alreadyConnected)
                {

                    int weight = r.Next(1, k + 1);
                    AddEdge(s, d, weight);
                    //Edges.Add(new Edge(s, d, weight));
                }
            }
        }
        public void generateGraphCase2(int n, int k)
        {
            Random r = new Random();
            List<Node> nodesList = new List<Node>();

            Edges.RemoveAll(e => e != null);
            // generisanje n cvorova
            for (int i = 0; i < n; i++)
            {
                Node node = new Node(i);
                AddNode(node);
                nodesList.Add(node);
            }

            Node s, d;
            int w;
            //spojimo cvorove u daisy chain
            for (int i = 0; i < n - 1; i++)
            {
                w = r.Next(1, k * n);
                s = nodesList[i];
                d = nodesList[i + 1];
                AddEdge(s, d, w);
                //Edges.Add(new Edge(s, d, w));
            }

            w = r.Next(1, k * n);
            s = nodesList[n - 1];
            d = nodesList[0];
            AddEdge(s, d, w);
            // Edges.Add(new Edge(s, d, w));


            // dodavanje jos k*n potega izmedju dva slucajno izabrana cvora
            for (int i = 0; i < k * n; i++)
            {
                int sIndex = r.Next(n);
                int dIndex = r.Next(n);

                s = nodesList[sIndex];
                d = nodesList[dIndex];

                if (s == d) //nema ciklus duzine 0
                    continue;

                bool alreadyConnected = false;
                foreach (Edge edge in Edges)
                {
                    if ((edge.Source == s && edge.Destination == d) || (edge.Source == d && edge.Destination == s))
                    {
                        alreadyConnected = true;
                        break;
                    }
                }

                if (!alreadyConnected)
                {

                    int weight = r.Next(1, k + 1);
                    AddEdge(s, d, weight);
                    // Edges.Add(new Edge(s, d, weight));
                }
            }

        }

        public void DijkstrAlgorithm(Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();
            source.Distance = 0;
            queue.enqueue(source);

            while(queue.Count != 0)
            {
                Node currentNode = queue.dequeue();
                foreach (Edge edge in currentNode.Neighbors)
                {
                    
                    if(edge.Visited == true)
                        continue;

                    edge.Visited = true;

                    Node neighbor = edge.Destination;
                    if (neighbor == currentNode)
                        neighbor = edge.Source;

                    int newDistance = currentNode.Distance + edge.Weight;
                    if (newDistance < neighbor.Distance)
                    {
                        neighbor.Distance = newDistance;
                        neighbor.Predecessor = currentNode;
                        queue.enqueue(neighbor);
                    }
                }
            }

        }

        public List<Node> getShortestPath(Node destination)
        {
            List<Node> path = new List<Node>();
            for (Node current = destination; current != null; current = current.Predecessor)
                path.Add(current);
            
            path.Reverse();
            return path;
        }

        public void testDijkstra()
        {

            Random r = new Random();

            Stopwatch s = new Stopwatch();
            for (int i = 0; i < 10; i++)
            {
                s.Start();

                foreach (Edge edge in Edges)
                    edge.Visited = false;

                foreach (Node node in Nodes)
                {
                    node.Distance = int.MaxValue;
                    node.Predecessor = null;
                }
                Node src = Nodes[r.Next(Nodes.Count)];
                Node dst = Nodes[r.Next(Nodes.Count)];

                while (dst == src)
                    dst = Nodes[r.Next(Nodes.Count)];


                DijkstrAlgorithm(src);

                List<Node> path = getShortestPath(dst);

                /* Console.Write("Minimalni put izmedju " + src.Value + " i " + dst.Value + ": ");

                  if (path.Count > 1)
                  {
                      foreach (Node node in path)
                          Console.Write(node + " ");
                      Console.WriteLine();
                  }

                  else
                      Console.WriteLine(src.Value + " " + dst.Value);*/

            }
            Console.WriteLine("Vreme izvrsenja za 10 ponavljanja: " + s.Elapsed);
            s.Stop();
        }

    }
}
