//Leetcode 295. Find Median from Data Stream hard
//题意：设计一个数据结构，支持以下两种操作：addNum(int num) - 将整数 num 添加到数据结构中。findMedian() - 返回当前所有元素的中位数。
//思路：为了实现在数据流中查找中位数，我们可以使用两个优先队列（PriorityQueue）来解决：创建一个最大堆 maxHeap 来存储数据流中的较小一半的元素。创建一个最小堆 minHeap 来存储数据流中的较大一半的元素。当插入一个新元素时，我们将其与 maxHeap 的堆顶元素（最大值）比较，如果小于等于堆顶元素，则插入 maxHeap 中，否则插入 minHeap 中。为了保持两个堆的平衡，我们需要做一些调整：如果 maxHeap 的大小大于 minHeap 的大小超过 1，将 maxHeap 的堆顶元素弹出并插入到 minHeap 中。如果 minHeap 的大小大于 maxHeap 的大小，将 minHeap 的堆顶元素弹出并插入到 maxHeap 中。
//时间复杂度：插入一个新元素的时间复杂度是 O(log n)。查询中位数的时间复杂度是 O(1)。
//空间复杂度：O(n)
        public class MedianFinder
        {
            private PriorityQueue<int> maxHeap; // 存储较小一半的元素
            private PriorityQueue<int> minHeap; // 存储较大一半的元素

            public MedianFinder()
            {
                maxHeap = new PriorityQueue<int>((a, b) => b - a); // 最大堆
                minHeap = new PriorityQueue<int>((a, b) => a - b); // 最小堆
            }

            public void AddNum(int num)
            {
                if (maxHeap.Count == 0 || num <= maxHeap.Peek())
                {
                    maxHeap.Enqueue(num);
                }
                else
                {
                    minHeap.Enqueue(num);
                }

                if (maxHeap.Count > minHeap.Count + 1)
                {
                    minHeap.Enqueue(maxHeap.Dequeue());
                }
                else if (maxHeap.Count < minHeap.Count)
                {
                    maxHeap.Enqueue(minHeap.Dequeue());
                }
            }

            public double FindMedian()
            {
                if (maxHeap.Count == minHeap.Count)
                {
                    return (double)(maxHeap.Peek() + minHeap.Peek()) / 2;
                }
                else
                {
                    return maxHeap.Peek();
                }
            }
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
        }
        public class MedianFinder1
        {
            private SortedDictionary<int, int> dict;
            private int count;

            public MedianFinder1()
            {
                dict = new SortedDictionary<int, int>();
                count = 0;
            }

            public void AddNum(int num)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict.Add(num, 1);
                }
                count++;
            }

            public double FindMedian()
            {
                int mid = count / 2;
                bool isOdd = count % 2 != 0;

                int currCount = 0;
                int prevNum = 0;
                foreach (var kvp in dict)
                {
                    currCount += kvp.Value;
                    if (isOdd && currCount > mid)
                    {
                        return kvp.Key;
                    }
                    else if (!isOdd && currCount == mid)
                    {
                        prevNum = kvp.Key;
                        return (prevNum + kvp.Key) / 2.0;
                    }
                    else if (!isOdd && currCount > mid)
                    {
                        return (prevNum + kvp.Key) / 2.0;
                    }
                }

                return 0.0; // 数据流为空
            }
        }