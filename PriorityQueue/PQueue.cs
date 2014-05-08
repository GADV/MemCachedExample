using System.Collections.Generic;

namespace PriorityQueue
{
    /**
     *  Cormen, Leiserson, Rivest, Stein
     * "Introduction to Algorithms", 3rd edition
     * Chapter 6, "Heapsort"
     */

    public class PQueue : IPQueue
    {
        private int _currentMaxPriority = 0;
        private readonly List<PQNode> _heap = new List<PQNode>();

        public PQNode Insert(string key)
        {
            var node = new PQNode(key);
            ++_currentMaxPriority;
            node.Priority = _currentMaxPriority;
            MinHeapInsert(node);

            return node;
        }

        public PQNode Extract()
        {
            return HeapExtractMin();
        }

        public void Remove(PQNode node)
        {
            if (_heap.Count == 1)
            {
                Reset();
                return;
            }

            var idx = node.Index; // _heap.IndexOf(node) would be O(n)
            _heap[idx] = _heap[_heap.Count - 1];
            _heap.RemoveAt(_heap.Count - 1);
            _heap[idx].Index = idx;
            MinHeapify(idx);
        }

        public void IncreasePriority(PQNode node)
        {
            ++_currentMaxPriority;
            node.Priority = _currentMaxPriority;
            MinHeapify(node.Index);
        }

        public bool IsEmpty()
        {
            return _heap.Count == 0;
        }

        #region Heap operations

        private PQNode HeapExtractMin()
        {
            var min = _heap[0];
            _heap[0] = _heap[_heap.Count - 1];
            _heap[0].Index = 0;
            _heap.RemoveAt(_heap.Count - 1);
            MinHeapify(0);

            return min;
        }

        private void MinHeapInsert(PQNode node)
        {
            // A newly inserted node always has the largest priority
            node.Index = _heap.Count;
            _heap.Add(node);
        }

        private void MinHeapify(int i)
        {
            var smallest = i;
            var l = Left(i);
            if ((l < _heap.Count) && (_heap[l].Priority < _heap[i].Priority))
            {
                smallest = l;
            }
            var r = Right(i);
            if ((r < _heap.Count) && (_heap[r].Priority < _heap[smallest].Priority))
            {
                smallest = r;
            }
            if (smallest == i)
            {
                return;
            }
            Exchange(i, smallest);

            // Recursive call: change it to a while loop to improve performances
            MinHeapify(smallest);
        }

        #endregion

        #region Helper methods

        private void Exchange(int i, int j)
        {
            var tmp = _heap[i];
            _heap[i] = _heap[j];
            _heap[j] = tmp;

            var tmpIdx = _heap[i].Index;
            _heap[i].Index = _heap[j].Index;
            _heap[j].Index = tmpIdx;
        }

        /**
         * Not used, indeed. 
         **/
        //private int Parent(int i)
        //{
        //    return (i + 1) / 2 - 1;
        //}

        private static int Left(int i)
        {
            return (i + 1) * 2 - 1;
        }

        private static int Right(int i)
        {
            return (i + 1) * 2; // (+ 1 - 1)
        }

        private void Reset()
        {
            _currentMaxPriority = 0;
            _heap.Clear();
        }

        #endregion
    }
}
