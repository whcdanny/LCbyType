//Leetcode 2454. Next Greater Element IV hard
//题意：给定一个非负整数数组nums。对于nums中的每个整数，你必须找到其相应的第二大整数。
//nums[i] 的第二大整数是nums[j]，满足：    
//j > i
//nums[j] > nums[i]
//存在唯一的索引k，使得nums[k] > nums[i]，且i<k<j
//如果没有这样的nums[j]，则将第二大整数视为-1。
//例如，在数组[1, 2, 4, 3]中，1的第二大整数是4，2的是3，3和4的是-1。
//返回一个整数数组answer，其中answer[i]是nums[i]的第二大整数。
//思路：PriorityQueue;
//建立两个priorityqueue，一个是最大的，一个是第二大的，       
//然后如果当前的值大于最大的，那么就将这个小于值放入第二大的queue里，如果当前值大于第二大的queue里，就说明queue里的index的第二大的值找到了；
//时间复杂度：O(n * log(n))
//空间复杂度：O(n)
        public int[] SecondGreaterElement(int[] nums)
        {
            int n = nums.Length;
            int[] ans = new int[n];
            for (int i = 0; i < n; i++) ans[i] = -1;

            // Min heap to track the elements to be treated for the first time
            PriorityQueue<(int, int)> firstGreater = new PriorityQueue<(int, int)>((a, b) => a.Item1.CompareTo(b.Item1));

            // Min heap to track the elements needing the second greater element
            PriorityQueue<(int, int)> secondGreater = new PriorityQueue<(int, int)>((a, b) => a.Item1.CompareTo(b.Item1));

            firstGreater.Enqueue((nums[0], 0));

            for (int i = 1; i < n; i++)
            {
                //如果nums[i] 大于secondGreater里的值，就说明当前secondGreater的值位置上第二大的数找到了就是nums[i]；
                while (secondGreater.Count > 0 && secondGreater.Peek().Item1 < nums[i])
                {
                    (int value, int index) = secondGreater.Dequeue();
                    ans[index] = nums[i];
                }

                //如果nums[i] 大于firstGreater里的值，就说明当前firstGreater的值可以添加到secondGreater中，并更新firstGreater；
                while (firstGreater.Count > 0 && firstGreater.Peek().Item1 < nums[i])
                {
                    secondGreater.Enqueue(firstGreater.Dequeue());
                }

                firstGreater.Enqueue((nums[i], i));
            }

            return ans;
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