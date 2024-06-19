using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _18247Zadatak4
{
    public class FibonacciHeap
    {
        private Node min;
        private int numOfNodes = 0;
        private int numOfTrees = 0;
        private Node lastNodeInserted;

        public void fibHeapInsert(int key)
        {
            Node toAdd = new Node();
            toAdd.Key = key;
            fibHeapInsert(toAdd);
            numOfTrees++;
            numOfNodes++;
        }

        private void fibHeapInsert(Node node)
        {

            lastNodeInserted = node;

            if (min == null)
            {
                node.Left = node;
                node.Right = node;
                min = node;
            }

            else
            {
                node.Left = min.Left;
                min.Left.Right = node;
                min.Left = node;
                node.Right = min;
                if (node.Key < min.Key)
                    min = node;

            }

        }

        public Node fibHeapExtractMin()
        {
            
            Node z = min;
            if (z != null)
            {

                
                Node child = z.Child;
                if (z.Degree > 0)
                {
                    Node childLast = child.Left;
                    Node thisLast = this.min.Left;

                    thisLast.Right = child;
                    childLast.Right = this.min;

                    this.min.Left = childLast;
                    child.Left = thisLast;
                }
                numOfTrees += z.Degree;

                
                z.Left.Right = z.Right;
                z.Right.Left = z.Left;
                numOfTrees--;
                numOfNodes--;

                if (z == z.Right)
                    min = null;
                else
                {
                    min = z.Right;
                    Consolidate();
                }
            }
          

            return z;
        }

        public void Consolidate()
        {
            Dictionary<int, Node> A = new Dictionary<int, Node>();
            Node current = min;
            for (int i = 0; i < numOfTrees; i++)
            {
                Node x = current;
                int d = x.Degree;
                current = current.Right;
                while (A.ContainsKey(d))
                {
                    Node y = A[d];
                    if (x.Key > y.Key)
                    {
                        fibHeapLink(y, x);
                        x = y;
                    }
                    else fibHeapLink(x, y);

                    A.Remove(d);
                    d++;
                    numOfTrees--;
                    i--;
                }
                A.Add(d, x);
            }

            min = null;
            numOfTrees = 0;
            foreach (Node node in A.Values)
            {
                fibHeapInsert(node);
                numOfTrees++;
            }
        }

        private void fibHeapLink(Node parent, Node child)
        {
            child.Left.Right = child.Right;
            child.Right.Left = child.Left;
            child.Parent = parent;
            child.Mark = false;

            if (parent.Degree == 0)
            {
                child.Left = child;
                child.Right = child;
                parent.Child = child;
            }
            else
            {
                parent.Child.Left.Right = child;
                child.Left = parent.Child.Left;
                child.Right = parent.Child;
                parent.Child.Left = child;
            }
            parent.Degree++;
        }

        public Node fibHeapDeleteLastNodeInserted()
        {
            Node deleted;


            if (lastNodeInserted.Key == min.Key)
            {
                deleted = fibHeapExtractMin();
            }
            else
            {

                min.Left = lastNodeInserted.Left;
                lastNodeInserted.Left.Right = min;

                numOfTrees--;
                numOfNodes--;

                deleted = lastNodeInserted;
            }

            return deleted;
        }


        public override string ToString()
        {
            StringBuilder s = new StringBuilder();

            Node current = min;
            if (current == null)
                return "Empty";

            for (int i = 0; i < numOfTrees - 1; i++)
            {
                s.Append(current.Key);
                if (current.Degree > 0)
                {
                    s.Append("(");
                    s.Append(Siblings(current.Child, current.Degree));
                    s.Append(")");
                }
                s.Append("<-->");
                current = current.Right;
            }

            s.Append(current.Key);
            if (current.Degree > 0)
            {
                s.Append("(");
                s.Append(Siblings(current.Child, current.Degree));
                s.Append(")");
            }

            return s.ToString();
        }

         private StringBuilder Siblings(Node node, int siblingCount)
         {
             StringBuilder s = new StringBuilder();
             for (int i = 0; i < siblingCount - 1; i++)
             {
                 s.Append(node.Key);
                 if (node.Degree > 0)
                 {
                     s.Append("(");
                     s.Append(Siblings(node.Child, node.Degree));
                     s.Append(")");
                 }
                 s.Append(", ");
                 node = node.Right;
             }

             s.Append(node.Key);
             if (node.Degree > 0)
             {
                 s.Append("(");
                 s.Append(Siblings(node.Child, node.Degree));
                 s.Append(")");
             }
             return s;
           
        }
    }
}
