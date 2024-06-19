using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak5
{
    public class Node
    {
        public int Value { get; set; }
        public List<Edge> Edges { get; set; }

        public Node(int value)
        {
            this.Value = value;
            Edges= new List<Edge>();
        }
        public override string ToString()
        {
            return Value.ToString();
        }
    }


}
