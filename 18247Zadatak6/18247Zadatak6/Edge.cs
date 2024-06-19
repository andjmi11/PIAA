using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak6
{
    public class Edge
    {
        public Node Source { get; set; }
        public Node Destination { get; set; }
        public int Weight { get; set; }
        public bool Visited { get; set; }

        public Edge(Node src, Node dst, int w)
        {
           Source= src;
            Destination= dst;
            Weight= w;
        }

        public override string ToString()
        {
            return $"{Source.Value} -> {Destination.Value} ({Weight})";
        }
    }
}
