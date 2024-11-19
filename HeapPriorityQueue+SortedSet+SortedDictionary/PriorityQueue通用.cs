public class PriorityQueue_T<T> where T : IComparable<T>
        {
            private List<T> heap;
            private Comparison<T> comparer;

            public int Count => heap.Count;

            public PriorityQueue_T(Comparison<T> comparer)
            {
                heap = new List<T>();
                this.comparer = comparer;
            }

            public void Enqueue(T item)
            {
                heap.Add(item);
                HeapifyUp(heap.Count - 1);
            }

            public T Dequeue()
            {
                var item = heap[0];
                var lastItem = heap[heap.Count - 1];
                heap[0] = lastItem;
                heap.RemoveAt(heap.Count - 1);
                HeapifyDown(0);
                return item;
            }

            private void HeapifyUp(int index)
            {
                var parentIndex = (index - 1) / 2;
                while (index > 0 && comparer(heap[index], heap[parentIndex]) < 0)
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                    parentIndex = (index - 1) / 2;
                }
            }

            private void HeapifyDown(int index)
            {
                var leftChildIndex = index * 2 + 1;
                var rightChildIndex = index * 2 + 2;
                var smallestIndex = index;

                if (leftChildIndex < heap.Count && comparer(heap[leftChildIndex], heap[smallestIndex]) < 0)
                {
                    smallestIndex = leftChildIndex;
                }

                if (rightChildIndex < heap.Count && comparer(heap[rightChildIndex], heap[smallestIndex]) < 0)
                {
                    smallestIndex = rightChildIndex;
                }

                if (smallestIndex != index)
                {
                    Swap(index, smallestIndex);
                    HeapifyDown(smallestIndex);
                }
            }

            private void Swap(int i, int j)
            {
                var temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }
        }