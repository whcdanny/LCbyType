//23. Merge k Sorted Lists hard
//一道合并k个有序链表
//思路：最小堆（Min Heap）来维护当前k个链表的最小节点。将k个链表的头节点都加入最小堆中。从最小堆中取出堆顶节点，即当前k个链表的最小节点。将该最小节点添加到结果链表中，并将最小节点所在链表的下一个节点加入最小堆中，保持最小堆的大小为k。重复步骤2和步骤3，直到最小堆为空，即所有节点都已经遍历完毕
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

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class PriorityQueue<ListNode>
        {
            private List<ListNode> heap;
            private Comparison<ListNode> comparer;

            public int Count => heap.Count;

            public PriorityQueue(Comparison<ListNode> comparer)
            {
                heap = new List<ListNode>();
                this.comparer = comparer;
            }

            public void Enqueue(ListNode item)
            {
                heap.Add(item);
                HeapifyUp(heap.Count - 1);
            }

            public ListNode Dequeue()
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