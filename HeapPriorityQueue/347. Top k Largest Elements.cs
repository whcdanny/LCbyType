//Leetcode 347. Top k Largest Elements med
//题意：给定一个整数数组 nums，找出其中最大的 k 个元素。
//思路：一种常用的解决方法是使用最小堆（Min-Heap）。首先，我们将前 k 个元素插入最小堆中。然后，对于剩下的元素，如果比堆顶元素大，就将堆顶元素出堆，将新元素插入堆中。最终，堆中的元素就是前 k 大的元素。
//时间复杂度：建堆的时间复杂度是 O(k)，每次插入和删除元素的时间复杂度是 O(logk)，总共有 n-k 次操作，因此总时间复杂度是 O(k + (n-k)logk)，约化为 O(nlogk)
//空间复杂度：O(k) 
        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> frequency = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (frequency.ContainsKey(num))
                    frequency[num]++;
                else
                    frequency[num] = 1;
            }

            PriorityQueue<int> minHeap = new PriorityQueue<int>((a, b) => frequency[a] - frequency[b]);

            foreach (var num in frequency.Keys)
            {
                minHeap.Enqueue(num);
                if (minHeap.Count > k)
                    minHeap.Dequeue();
            }

            int[] result = new int[k];
            for (int i = k - 1; i >= 0; i--)
            {
                result[i] = minHeap.Dequeue();
            }

            return result;
        }
		public class PriorityQueue<T>
        {
            //在最小堆（Min-Heap）中，每个节点的父节点和子节点的索引有一个特定的关系。
            //假设一个节点的索引是 i，那么它的父节点的索引是(i-1)/2，它的左子节点的索引是 2*i + 1，右子节点的索引是 2*i + 2。
            private List<T> heap;
            private Comparison<T> comparison;

            public int Count
            {
                get { return heap.Count; }
            }

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