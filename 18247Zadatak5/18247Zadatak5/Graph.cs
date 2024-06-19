using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _18247Zadatak5
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
            s.Edges.Add(new Edge(s, d, w));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
         
            foreach (Edge edge in Edges)
            {
                sb.Append(edge.ToString());
                sb.Append(" | ");
            }
            return sb.ToString();
          
        }

        public void generateGraphCase1(int N, int k)
        {

            Random r = new Random();

            List<Node> nodesList = new List<Node>();
            Edges.RemoveAll(e => e != null); //kad prodje za jedan slucaj,ako ne uradim removeAll dodace se novi cvorovi na vec postojece

            // generisanje N cvorova
            for (int i = 0; i < N; i++)
            {
                Node node = new Node(i);
                AddNode(node);
                nodesList.Add(node);
            }

            // slucajno izabrani cvor spojiti sa svim ostalim cvorovima
            int startIndex = r.Next(N);
            Node start = nodesList[startIndex];
            for (int i = 0; i < N; i++)
            {
                if (i == startIndex)
                {
                    continue;
                }
                Node d = nodesList[i];
              
                int weight = r.Next(1, k*N);
                AddEdge(start, d, weight);
                Edges.Add(new Edge(start, d, weight));
            }

            // dodati jo k*N potega izmedju dva slucajno izabrana cvora
            for (int i = 0; i < k * N; i++)
            {
                int sIndex = r.Next(N);
                int dIndex = r.Next(N);

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
                    Edges.Add(new Edge(s, d, weight));
                }
            }

        }



        public void generateGraphCase2(int N, int k)
        {
            Random r = new Random();
            List<Node> nodesList = new List<Node>();

            Edges.RemoveAll(e => e != null); 
            // generisanje n cvorova
            for (int i = 0; i < N; i++)
            {
                Node node = new Node(i);
                AddNode(node);
                nodesList.Add(node);
            }

            Node s, d;
            int w;
            //spojimo cvorove u daisy chain
            for (int i = 0; i < N - 1; i++)
            {
                w = r.Next(1, k * N);
                s = nodesList[i];
                d = nodesList[i + 1];
                AddEdge(s, d, w);
                Edges.Add(new Edge(s, d,w));
            }

            w = r.Next(1, k * N);
            s = nodesList[N - 1];
            d = nodesList[0];
            AddEdge(s, d, w);
            Edges.Add(new Edge(s, d, w));


            // dodavanje jos k*N potega izmedju dva slucajno izabrana cvora
            for (int i = 0; i < k * N; i++)
            {
                int sIndex = r.Next(N);
                int dIndex = r.Next(N);

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
                    Edges.Add(new Edge(s, d, weight));
                }
            }

        }
    

        public List<Edge> KruskalAlgorithm()
        {
            DisjoinSet disjoinSet = new DisjoinSet();
            foreach (Node node in Nodes)
                disjoinSet.makeSet(node);

            Edges.Sort((x, y) => x.Weight.CompareTo(y.Weight));

            List<Edge> mst = new List<Edge>();
            
            foreach (Edge edge in Edges)
            {
                Node set1 = disjoinSet.findSet(edge.Source);
                Node set2 = disjoinSet.findSet(edge.Destination);
                int w = edge.Weight;

                if (set1 != set2)
                {
                    Edge e = new Edge(set1, set2, w);
                    mst.Add(e);
                    disjoinSet.union(set1, set2);

                }

            }
            return mst;

        }
    }
}

