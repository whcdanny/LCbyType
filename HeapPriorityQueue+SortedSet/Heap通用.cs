 public class MaxHeap<T>
        {
            private List<T> heap;
            private Comparer<T> comparer;

            public int Count { get; private set; }

            public MaxHeap(int capacity, Comparer<T> comparer)
            {
                heap = new List<T>(capacity);
                this.comparer = comparer;
                Count = 0;
            }

            public void Push(T item)
            {
                heap.Add(item);
                Count++;
                HeapifyUp(Count - 1);
            }

            public T Pop()
            {
                T root = heap[0];
                heap[0] = heap[Count - 1];
                heap.RemoveAt(Count - 1);
                Count--;
                HeapifyDown(0);
                return root;
            }

            private void HeapifyUp(int index)
            {
                while (index > 0)
                {
                    int parent = (index - 1) / 2;
                    if (comparer.Compare(heap[index], heap[parent]) > 0)
                    {
                        Swap(index, parent);
                        index = parent;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void HeapifyDown(int index)
            {
                while (index < Count)
                {
                    int left = 2 * index + 1;
                    int right = 2 * index + 2;
                    int largest = index;

                    if (left < Count && comparer.Compare(heap[left], heap[largest]) > 0)
                    {
                        largest = left;
                    }
                    if (right < Count && comparer.Compare(heap[right], heap[largest]) > 0)
                    {
                        largest = right;
                    }

                    if (largest != index)
                    {
                        Swap(largest, index);
                        index = largest;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            private void Swap(int i, int j)
            {
                T temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }
        }