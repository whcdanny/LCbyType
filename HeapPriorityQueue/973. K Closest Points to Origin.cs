//973. K Closest Points to Origin med 
//给一串点，找出离原点最近的k个点；
//思路：利用orberby就很好解决；
        public int[][] KClosest(int[][] points, int k)
        {
            return points.OrderBy(p => p[0] * p[0] + p[1] * p[1])
                         .Take(k)
                         .ToArray();
        }
//思路：创建一个MaxHeap
        public int[][] KClosest2(int[][] points, int k)
        {
            // 创建一个最大堆
            var heap = new MaxHeap<Point>(k, Comparer<Point>.Create((a, b) => a.Distance.CompareTo(b.Distance)));

            // 遍历给定的点集
            foreach (var point in points)
            {
                int distance = point[0] * point[0] + point[1] * point[1];
                var p = new Point(point, distance);

                // 将点及其距离添加到最大堆中
                heap.Push(p);

                // 如果堆的大小超过K，移除堆顶的元素
                if (heap.Count > k)
                {
                    heap.Pop();
                }
            }

            // 将堆中的点转化为数组并返回
            var result = new int[k][];
            for (int i = k - 1; i >= 0; i--)
            {
                var p = heap.Pop();
                result[i] = p.Coordinates;
            }

            return result;
        }

        // 定义一个辅助类表示点及其距离
        public class Point
        {
            public int[] Coordinates { get; }
            public int Distance { get; }

            public Point(int[] coordinates, int distance)
            {
                Coordinates = coordinates;
                Distance = distance;
            }
        }

        // 定义一个最大堆
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