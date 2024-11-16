//Leetcode 1438. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit med
//题意：给定一个整数数组 nums，和一个整数限制 limit，返回最长连续子数组的长度，满足以下条件：子数组中的最大值与最小值的绝对差值不超过 limit。
//思路：我们使用两个优先队列 maxHeap 和 minHeap 分别来维护滑动窗口内的最大值和最小值。使用双指针技巧维护一个滑动窗口，滑动窗口的左边界为 left，右边界为 right。在每一步中，我们将 nums[right] 放入 maxHeap 和 minHeap 中，并分别从两个堆中取出堆顶元素 max 和 min。如果 max - min > limit，说明当前窗口不符合条件，我们需要移动左边界 left，将 nums[left] 从堆中删除，并更新 max 和 min。计算当前窗口的长度 right - left + 1，并更新最大长度。
//时间复杂度：每个元素最多被操作两次（放入堆和取出堆），所以时间复杂度是 O(n*log(k))，其中 n 是数组的长度，k 是滑动窗口的大小。
//空间复杂度：O(k)
        public int LongestSubarray(int[] nums, int limit)
        {
            PriorityQueue<int> maxHeap = new PriorityQueue<int>((a, b) => b - a);
            PriorityQueue<int> minHeap = new PriorityQueue<int>((a, b) => a - b);

            int left = 0, right = 0;
            int maxLength = 0;

            while (right < nums.Length)
            {
                maxHeap.Enqueue(nums[right]);
                minHeap.Enqueue(nums[right]);

                int max = maxHeap.Peek();
                int min = minHeap.Peek();

                if (max - min > limit)
                {
                    maxHeap.Remove(nums[left]);
                    minHeap.Remove(nums[left]);
                    left++;
                }

                maxLength = Math.Max(maxLength, right - left + 1);
                right++;
            }

            return maxLength;
        }
		public class PriorityQueue<T>
        {
            //在最小堆（Min-Heap）中，每个节点的父节点和子节点的索引有一个特定的关系。
            //假设一个节点的索引是 i，那么它的父节点的索引是(i-1)/2，它的左子节点的索引是 2*i + 1，右子节点的索引是 2*i + 2。
            public List<T> heap;
            private Comparison<T> comparison;

            public int Count
            {
                get { return heap.Count; }
            }
            //public PriorityQueue()
            //{
            //    this.heap = new List<T>();
            //    this.comparison = 
            //}

            public PriorityQueue(Comparison<T> comparison)
            {
                this.heap = new List<T>();
                this.comparison = comparison;
            }

            public void Enqueue(T item)
            {
                heap.Add(item);
                int childIndex = heap.Count - 1;
                while (childIndex > 0)
                {
                    //计算当前子节点的父节点索引
                    int parentIndex = (childIndex - 1) / 2;
                    if (comparison(heap[parentIndex], heap[childIndex]) <= 0)
                        break;

                    Swap(parentIndex, childIndex);
                    childIndex = parentIndex;
                }
            }

            public T Dequeue()
            {
                int lastIndex = heap.Count - 1;
                T frontItem = heap[0];
                heap[0] = heap[lastIndex];
                heap.RemoveAt(lastIndex);

                lastIndex--;
                int parentIndex = 0;

                while (true)
                {
                    int leftChildIndex = parentIndex * 2 + 1;
                    if (leftChildIndex > lastIndex)
                        break;

                    int rightChildIndex = leftChildIndex + 1;
                    int minIndex = leftChildIndex;

                    if (rightChildIndex <= lastIndex && comparison(heap[rightChildIndex], heap[leftChildIndex]) < 0)
                        minIndex = rightChildIndex;

                    if (comparison(heap[parentIndex], heap[minIndex]) <= 0)
                        break;

                    Swap(parentIndex, minIndex);
                    parentIndex = minIndex;
                }

                return frontItem;
            }

            public T Peek()
            {
                return heap[0];
            }

            private void Swap(int i, int j)
            {
                T temp = heap[i];
                heap[i] = heap[j];
                heap[j] = temp;
            }
            public void Remove(T item)
            {
                int index = heap.IndexOf(item);
                if (index == -1) return;
                heap[index] = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                int parent = (index - 1) / 2;
                if(index < heap.Count)
                {
                    if (index > 0 && comparison(heap[parent], heap[index]) > 0)
                    {
                        while (index > 0 && comparison(heap[parent], heap[index]) > 0)
                        {
                            Swap(parent, index);
                            index = parent;
                            parent = (index - 1) / 2;
                        }
                    }
                    else
                    {
                        while (true)
                        {
                            int left = 2 * index + 1;
                            int right = 2 * index + 2;
                            int smallest = index;
                            if (left < heap.Count && comparison(heap[left], heap[smallest]) < 0)
                            {
                                smallest = left;
                            }
                            if (right < heap.Count && comparison(heap[right], heap[smallest]) < 0)
                            {
                                smallest = right;
                            }
                            if (smallest == index) break;
                            Swap(index, smallest);
                            index = smallest;
                        }
                    }
                }                
            }
        }
        //1438. Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit 
        //是一个求解满足条件的最长连续子数组长度的
        //思路：双指针和双端队列（Deque）来解决这个问题。双指针维护了子数组的左右边界，双端队列用来维护当前子数组的最大值和最小值；
        public int LongestSubarray1(int[] nums, int limit)
        {
            int n = nums.Length;
            int left = 0, right = 0;
            int maxLength = 0;
            var maxQueue = new LinkedList<int>();
            var minQueue = new LinkedList<int>();

            while (right < n)
            {
                // 维护最大值队列（从大到小）
                while (maxQueue.Count > 0 && nums[right] > maxQueue.Last.Value)
                    maxQueue.RemoveLast();
                maxQueue.AddLast(nums[right]);

                // 维护最小值队列（从小到大）
                while (minQueue.Count > 0 && nums[right] < minQueue.Last.Value)
                    minQueue.RemoveLast();
                minQueue.AddLast(nums[right]);

                // 判断当前子数组的最大值和最小值的差是否满足条件
                while (maxQueue.First.Value - minQueue.First.Value > limit)
                {
                    if (maxQueue.First.Value == nums[left])
                        maxQueue.RemoveFirst();
                    if (minQueue.First.Value == nums[left])
                        minQueue.RemoveFirst();
                    left++;
                }

                // 更新最长子数组的长度
                maxLength = Math.Max(maxLength, right - left + 1);

                right++;
            }

            return maxLength;
        }