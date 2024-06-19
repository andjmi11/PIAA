using System.Runtime.CompilerServices;

namespace _18247Zadatak6
{
    public class PriorityQueue<T> where T : IComparer<T>
    {
        private List<T> data;
        public int Count { get { return data.Count; } }
        public PriorityQueue()
        {
            this.data = new List<T>();
        }

        public void enqueue(T item)
        {
            data.Add(item);
            int ci = data.Count - 1;
            while(ci > 0)
            {
                int pi = (ci - 1)/2;
                if (data[ci].Compare(item, data[pi]) >= 0) break;
                T tmp = data[ci];
                data[ci] = data[pi];
                data[pi] = tmp;
                ci = pi;
            }
        }

        public T dequeue()
        {
            int li = data.Count - 1;
            T frontItem = data[0];
            data[0] = data[li];
            data.RemoveAt(li);

            return frontItem;
        }
    }
}