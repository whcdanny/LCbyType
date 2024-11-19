//Leetcode 378. Kth Smallest Element in a Sorted Matrix med
//题意：给定一个 n x n 矩阵，其中每行每列元素均按升序排序，找到矩阵中第 k 小的元素。
//思路：我们创建了一个最小堆 minHeap，用于存储元素。堆中的比较方式是根据元素值的大小。接着，我们将矩阵的第一列中的元素（包括元素值、所在行、所在列）放入堆中。然后，我们开始循环，每次从堆中取出最小的元素
//时间复杂度：将矩阵的第一列元素放入堆中的操作时间复杂度是 O(n * log n)。进行 k 次出队入队操作的时间复杂度是 O(k* log n)。总的时间复杂度是 O((n+k) * log n)，其中 n 是矩阵的边长。
//空间复杂度：使用了一个自定义的最小堆来存储元素，堆的大小是 n，所以空间复杂度是 O(n)。综上所述，使用 PriorityQueue 的方法的时间复杂度为 O((n+k) * log n)，空间复杂度为 O(n)。
        public int KthSmallest(int[][] matrix, int k)
        {
            int n = matrix.Length;
            int m = matrix[0].Length;
            PriorityQueue<int> minHeap = new PriorityQueue<int>((a, b) => a - b);
            for (int i = 0; i < n; i++)
            {
                for(int j=0; j < m; j++)
                {
                    minHeap.Enqueue(matrix[i][j]);
                }
            }
            
            while (minHeap.Count > m*n-k+1)
            {
                minHeap.Dequeue();
            }
            return minHeap.Dequeue();

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

        //378. Kth Smallest Element in a Sorted Matrix
        //给定一个 n x n 的有序矩阵 matrix，其中每行和每列元素按升序排序，找到矩阵中第 k 小的元素
        //思路：二分查找，左边界 left 和右边界 right，因为是升序排序，所以先比较每一个行的最右边的数，根据大小，来决定是换行，还是同一行往前找；然后再更换边界；
        public int KthSmallest1(int[][] matrix, int k)
        {
            int n = matrix.Length;
            int left = matrix[0][0]; // 左边界
            int right = matrix[n - 1][n - 1]; // 右边界

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int count = CountElements(matrix, mid); // 统计小于等于 mid 的元素个数

                if (count < k)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }

        private int CountElements(int[][] matrix, int target)
        {
            int count = 0;
            int n = matrix.Length;
            int row = 0;
            int col = n - 1;

            while (row < n && col >= 0)
            {
                if (matrix[row][col] <= target)
                {
                    count += col + 1; // 当前列及之前的元素都小于等于 target
                    row++;
                }
                else
                {
                    col--;
                }
            }

            return count;
        }