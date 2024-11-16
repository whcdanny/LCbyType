//Leetcode 2503. Maximum Number of Points From Grid Queries hard
//题意：给定一个m x n的整数矩阵grid和一个大小为k的数组queries。
//对于每个整数queries[i]，你从矩阵的左上角开始，并重复以下过程：
//如果queries[i] 严格大于当前所在单元格的值，那么如果这是你第一次访问此单元格，你获得一个点，并且可以移动到所有4个方向的相邻单元格：上、下、左、右。
//否则，你不获得任何点，并结束此过程。
//过程结束后，answer[i] 表示你能获得的最大点数。注意，对于每个查询，你可以多次访问同一个单元格。
//返回结果数组answer。
//思路：BFS+PriorityQueue;
//先将queries排序，这样我们可以从最小的开始 这样比这个大的就可以根据之前的往上添加，
//用PriorityQueue 存入 row，colum 和 当前位置的值grid[row][colum]
//然后每一次算的时候 找到比当前query小的值，然后count++；
//最后根据queries的顺序，输出答案；
//时间复杂度：整个矩阵的时间复杂度为O(m * n)。对于每个查询，使用最小堆维护可访问单元格的时间复杂度为O(m* n * log(m* n))。整体时间复杂度为O(k* m * n* log(m* n))，其中k是查询数量
//空间复杂度：O(m * n)

        public int[] MaxPoints(int[][] grid, int[] queries)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[][] direction = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };


            int[] sortedQueries = queries.OrderBy(q => q).ToArray();
            //int[] => row & column   - int => Value 
            PriorityQueue<int[], int> pq = new PriorityQueue<int[], int>();
            pq.Enqueue(new int[] { 0, 0, grid[0][0] }, grid[0][0]);
            grid[0][0] = 0;

            //queryValue - Maximum
            Dictionary<int, int> qMax = new Dictionary<int, int>();
            int counter = 0;
            for (int i = 0; i < sortedQueries.Length; i++)
            {
                if (qMax.ContainsKey(sortedQueries[i]))
                    continue;

                while (pq.Count > 0 && pq.Peek()[2] < sortedQueries[i])
                {
                    counter++;
                    int[] cur = pq.Dequeue();
                    int row = cur[0];
                    int column = cur[1];


                    foreach (int[] dir in direction)
                    {
                        int newRow = row + dir[0];
                        int newColum = column + dir[1];
                        if (IsValid(newRow, newColum, m, n, grid))
                        {
                            pq.Enqueue(new int[] { newRow, newColum, grid[newRow][newColum] }, grid[newRow][newColum]);
                            grid[newRow][newColum] = 0;
                        }
                    }
                }
                qMax.Add(sortedQueries[i], counter);
            }

            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = qMax[queries[i]];
            }
            return result;
        }

        private bool IsValid(int newR, int newC, int m, int n, int[][] grid)
        {
            if (newR >= 0 && newC >= 0 && newR < m && newC < n && grid[newR][newC] != 0)
                return true;
            return false;
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

            public T Peek()
            {
                if (heap.Count == 0)
                {
                    throw new InvalidOperationException("PriorityQueue is empty");
                }

                return heap[0];
            }
        }