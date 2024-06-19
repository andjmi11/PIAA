using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18247Zadatak5
{
    public class DisjoinSet
    {
        private Dictionary<Node, Node> parent;
        private Dictionary<Node, int> rank;

        public DisjoinSet()
        {
           parent = new Dictionary<Node, Node>();
            rank = new Dictionary<Node, int>();

        }

        public void makeSet(Node node)
        {
            parent[node] = node;
            rank[node] = 0;
        }

        public void union(Node x, Node y)
        {
            link(findSet(x), findSet(y));
        }

        public void link(Node x, Node y)
        {
            if (rank[x] < rank[y])
                parent[x] = x;
            else
            {
                parent[x] = y;
                if (rank[x] == rank[y])
                    rank[y]++;
            }
        }

        public Node findSet(Node node)
        {
            if (node != parent[node])
                parent[node] = findSet(parent[node]);
            return parent[node];
        }
    }
}
