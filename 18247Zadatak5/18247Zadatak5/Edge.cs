using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak5
{
    public class Edge
    {
        public Node Source { get; set; }
        public Node Destination { get; set; }
        public int Weight { get; set; }

        public Edge(Node s, Node d, int w) 
        {
            Source = s;
            Destination = d;
            Weight = w;
        }

        public override string ToString()
        {
            return $"{Source.Value} -> {Destination.Value} ({Weight})";
        }
    }
}
