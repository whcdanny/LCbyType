//Leetcode 2462. Total Cost to Hire K Workers med
//题意：给定一个整数数组costs，表示雇佣每个工人的成本。
//同时给定两个整数k和candidates。我们想要按照以下规则雇佣确切k名工人：
//你将运行k个会话，并在每个会话中雇佣一名工人。 
//在每个雇佣会话中，从前candidates名工人或后candidates名工人中选择成本最低的工人。如果成本相同，则按最小索引来决定。
//例如，如果costs = [3,2,7,7,1,2] 且candidates = 2，则在第一个雇佣会话中，我们将选择第4名工人，因为他们的成本最低[3, 2, 7, 7, 1, 2]。
//在第二个雇佣会话中，我们将选择第1名工人，因为他们与第4名工人的成本相同，但索引更小[3, 2, 7, 7, 2]。请注意，索引在这个过程中可能会发生变化。
//如果剩余的工人数量少于candidates，从中选择成本最低的工人。如果成本相同，则按最小索引来决定。
//每名工人只能被选择一次。
//返回雇佣确切k名工人的总成本。
//思路：PriorityQueue;
//建立两个priorityqueue，一个从前，一个从后，然后用i和j表示前后的添加位置；因为有可能当前的costs被移除后size小于candidate的数；
//然后每次当两个priorityqueue的size满足candidate，找出两个中最小的添加到result，然后dequeue；直到算到最后；        
//时间复杂度：遍历工人数组并维护最小堆的时间复杂度为O(n* log(candidates))。总体时间复杂度为O(n* log(n) + n* log(candidates))。
//空间复杂度：O(candidates)
        public long TotalCost(int[] costs, int k, int candidates)
        {
            var queue1 = new PriorityQueue<int, int>();
            var queue2 = new PriorityQueue<int, int>();
            int i = 0, j = costs.Length - 1;
            long totalCost = 0;

            while (k > 0)
            {
                while (queue1.Count < candidates && i <= j)
                {
                    queue1.Enqueue(costs[i], costs[i]);
                    i++;
                }

                while (queue2.Count < candidates && j >= i)
                {
                    queue2.Enqueue(costs[j], costs[j]);
                    j--;
                }

                int p1 = queue1.Count > 0 ? queue1.Peek() : int.MaxValue;
                int p2 = queue2.Count > 0 ? queue2.Peek() : int.MaxValue;

                if (p1 <= p2)
                {
                    totalCost += p1;
                    //queue1.TryDequeue(out int e, out int p);
                    queue1.Dequeue();
                }
                else
                {
                    totalCost += p2;
                    //queue2.TryDequeue(out int e, out int p);
                    queue2.Dequeue();
                }

                k--;
            }

            return totalCost;
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
