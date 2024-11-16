//Leetcode 2406. Divide Intervals Into Minimum Number of Groups med
//题意：给定一个二维整数数组 intervals，其中 intervals[i] = [lefti, righti] 表示闭区间 [lefti, righti]。
//你需要将这些区间划分成一个或多个组，使得每个区间恰好属于一个组，并且同一组中的任意两个区间不相交。
//返回你需要划分的最小组数。
//两个区间相交的定义是它们之间至少有一个公共数。例如，区间[1, 5] 和[5, 8] 相交。
//思路：PriorityQueue;先给intervals进行排序根据左区域，然后priorityqueue存入的是右区域+1；
//如果新加入的左区域小于当前最小的priorityqueue右区域+1时，就证明有一个新的group，
//如果新加入的左区域大于等于当前最小的priorityqueue右区域+1时，就可以弹出当前最小的在PriorityQueue，因为我们排序了所以后面的肯定都大或等于这个值，所以不需要了；
//时间复杂度：排序的时间复杂度为O(NlogN)，其中N是区间的数量。遍历排序后的区间的时间复杂度为O(N)。因此，总体时间复杂度为O(NlogN + N) = O(NlogN)。
//空间复杂度：O(n)
        public int MinGroups(int[][] intervals)
        {
            var min_groups = 0;
            var pq = new PriorityQueue<int, int>();

            Array.Sort(intervals, (a, b) =>
            {
                return a[0].CompareTo(b[0]);
            });

            foreach (var interval in intervals)
            {
                if (pq.Count > 0 && interval[0] >= pq.Peek())
                    pq.Dequeue();
                else
                    min_groups++;

                pq.Enqueue(interval[1] + 1, interval[1] + 1);
            }

            return min_groups;
        }
		
		public class PriorityQueue<T, TKey> where TKey : IComparable<TKey>
        {
            private List<T> heap;
            private readonly Func<T, TKey> keySelector;

            public int Count
            {
                get { return heap.Count; }
            }

            public PriorityQueue(Func<T, TKey> keySelector)
            {
                this.heap = new List<T>();
                this.keySelector = keySelector;
            }
            public PriorityQueue()
            {
                this.heap = new List<T>();
                //this.keySelector = keySelector;
            }

            public void Enqueue(T item, TKey key)
            {
                heap.Add(item);
                int currentIndex = heap.Count - 1;

                while (currentIndex > 0)
                {
                    int parentIndex = (currentIndex - 1) / 2;
                    if (keySelector(heap[currentIndex]).CompareTo(keySelector(heap[parentIndex])) >= 0)
                    {
                        break;
                    }

                    T temp = heap[currentIndex];
                    heap[currentIndex] = heap[parentIndex];
                    heap[parentIndex] = temp;

                    currentIndex = parentIndex;
                }
            }

            public T Dequeue()
            {
                if (heap.Count == 0)
                {
                    throw new InvalidOperationException("PriorityQueue is empty");
                }

                T result = heap[0];
                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                int currentIndex = 0;
                while (true)
                {
                    int leftChildIndex = 2 * currentIndex + 1;
                    int rightChildIndex = 2 * currentIndex + 2;
                    int smallestIndex = currentIndex;

                    if (leftChildIndex < heap.Count && keySelector(heap[leftChildIndex]).CompareTo(keySelector(heap[smallestIndex])) < 0)
                    {
                        smallestIndex = leftChildIndex;
                    }

                    if (rightChildIndex < heap.Count && keySelector(heap[rightChildIndex]).CompareTo(keySelector(heap[smallestIndex])) < 0)
                    {
                        smallestIndex = rightChildIndex;
                    }

                    if (smallestIndex == currentIndex)
                    {
                        break;
                    }

                    T temp = heap[currentIndex];
                    heap[currentIndex] = heap[smallestIndex];
                    heap[smallestIndex] = temp;

                    currentIndex = smallestIndex;
                }

                return result;
            }
            public bool TryDequeue(out T item, out TKey key)
            {
                item = default(T);
                key = default(TKey);

                if (heap.Count == 0)
                {
                    return false;
                }

                item = heap[0];
                key = keySelector(item);

                heap[0] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                int currentIndex = 0;
                while (true)
                {
                    int leftChildIndex = 2 * currentIndex + 1;
                    int rightChildIndex = 2 * currentIndex + 2;
                    int smallestIndex = currentIndex;

                    if (leftChildIndex < heap.Count && keySelector(heap[leftChildIndex]).CompareTo(keySelector(heap[smallestIndex])) < 0)
                    {
                        smallestIndex = leftChildIndex;
                    }

                    if (rightChildIndex < heap.Count && keySelector(heap[rightChildIndex]).CompareTo(keySelector(heap[smallestIndex])) < 0)
                    {
                        smallestIndex = rightChildIndex;
                    }

                    if (smallestIndex == currentIndex)
                    {
                        break;
                    }

                    T temp = heap[currentIndex];
                    heap[currentIndex] = heap[smallestIndex];
                    heap[smallestIndex] = temp;

                    currentIndex = smallestIndex;
                }

                return true;
            }


            public T Peek()
            {
                if (heap.Count == 0)
                {
                    throw new InvalidOperationException("PriorityQueue is empty");
                }

                return heap[0];
            }
        }