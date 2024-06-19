using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak6
{
    public class Node : IComparer<Node>
    {
        public int Value { get; set; }
        public Node Predecessor { get; set; }
        public int Distance { get; set; }

        public List<Edge> Neighbors { get; set; } 


        public Node(int value)
        {
            this.Value = value;
            this.Distance = int.MaxValue; //beskonacno
            Neighbors = new List<Edge>();
        }
        public int Compare(Node x, Node y)
        {
            if (x.Distance < y.Distance) return -1;
            if (x.Distance > y.Distance) return 1;
            return 0;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
