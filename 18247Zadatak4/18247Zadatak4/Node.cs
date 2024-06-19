using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _18247Zadatak4
{
    public class Node
    {
        public int Key { get; set; }
        public Node Parent { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node Child { get; set; }
        public int Degree { get; set; }
        public bool Mark { get; set; }
    }
}