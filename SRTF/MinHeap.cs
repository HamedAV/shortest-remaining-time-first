using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRTF;
namespace SRTF
{
    public class MinHeap<T>
    {
        private List<T> items;
        private IComparer<T> comparer;

        public MinHeap(int capacity, IComparer<T> comparer)
        {
            items = new List<T>(capacity);
            this.comparer = comparer;
        }

        public int Count { get { return items.Count; } }

        public bool IsEmpty()
        {
            return Count == 0;
        }

        public void Insert(T item)
        {
            items.Add(item);
            HeapifyUp(Count - 1);
        }

        public T GetMin()
        {
            if (IsEmpty())
            {
                throw new Exception("Heap is empty");
            }
            return items[0];
        }

        public T RemoveMin()
        {
            if (IsEmpty())
            {
                throw new Exception("Heap is empty");
            }
            T minItem = items[0];
            items[0] = items[Count - 1];
            items.RemoveAt(Count - 1);
            HeapifyDown(0);
            return minItem;
        }

        public void Update(T item)
        {
            int index = items.IndexOf(item);
            if (index >= 0)
            {
                int parentIndex = (index - 1) / 2;
                if (parentIndex >= 0 && comparer.Compare(items[index], items[parentIndex]) < 0)
                {
                    HeapifyUp(index);
                }
                else
                {
                    HeapifyDown(index);
                }
            }
        }

        private void HeapifyUp(int index)
        {
            int parentIndex = (index - 1) / 2;

            while (index > 0 && comparer.Compare(items[index], items[parentIndex]) < 0)
            {
                Swap(index, parentIndex);
                index = parentIndex;
                parentIndex = (index - 1) / 2;
            }
        }

        private void HeapifyDown(int index)
        {
            int smallest = index;
            int leftChild = index * 2 + 1;
            int rightChild = index * 2 + 2;

            if (leftChild < Count && comparer.Compare(items[leftChild], items[smallest]) < 0)
            {
                smallest = leftChild;
            }

            if (rightChild < Count && comparer.Compare(items[rightChild], items[smallest]) < 0)
            {
                smallest = rightChild;
            }

            if (smallest != index)
            {
                Swap(index, smallest);
                HeapifyDown(smallest);
            }
        }

        private void Swap(int index1, int index2)
        {
            T temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }
    }

}


public class ProcessPriorityBurstTimeComparer : IComparer<Process>
{
    public int Compare(Process p1, Process p2)
    {
        if (p1.Priority != p2.Priority)
        {
            return p2.Priority.CompareTo(p1.Priority);
        }
        else
        {
            return p1.BurstTime.CompareTo(p2.BurstTime);
        }
    }
}
