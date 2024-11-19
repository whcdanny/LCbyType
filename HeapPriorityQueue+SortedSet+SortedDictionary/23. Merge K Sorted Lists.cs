//Leetcode 23. Merge K Sorted Lists hard
//题意：给定 k 个已排序的链表，将它们合并成一个新的已排序链表
//思路：优先队列（Min-Heap）。我们可以将每个链表的头节点放入优先队列中，根据节点的值进行比较。然后，我们从队列中取出最小节点，并将其加入结果链表。
//时间复杂度：假设每个链表的平均长度为 n，一共有 k 个链表。那么总共有 k*n 个节点。建堆的时间复杂度是 O(k* logk)，每次插入和删除元素的时间复杂度是 O(logk)，总共有 k*n 次操作，因此总时间复杂度是 O(k* n*logk)
//空间复杂度：O(k) 
        public ListNode MergeKLists(ListNode[] lists)
        {
            // 创建一个最小堆，并根据节点的值进行比较
            var minHeap = new PriorityQueue<ListNode>((a, b) => a.val.CompareTo(b.val));

            // 将所有链表的头节点加入最小堆
            foreach (var list in lists)
            {
                if (list != null)
                {
                    minHeap.Enqueue(list);
                }
            }

            // 创建一个哑节点作为结果链表的头节点
            var dummy = new ListNode(0);
            var current = dummy;

            // 不断从最小堆中取出最小节点，并将该节点的下一个节点加入最小堆
            while (minHeap.Count > 0)
            {
                var node = minHeap.Dequeue();
                current.next = node;
                current = current.next;

                if (node.next != null)
                {
                    minHeap.Enqueue(node.next);
                }
            }

            return dummy.next;
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