//Leetcode 407. Trapping Rain Water II hard
//题意：给定一个m x n的整数矩阵heightMap，表示二维高程图中每个单元格的高度，返回下雨后它能够蓄水的体积。
//思路：PriorityQueue将矩阵四周的边界加入最小堆，并标记这些位置为已访问。
//从最小堆中弹出最小高度的位置，然后遍历其四个相邻位置，如果相邻位置没有访问过，将其加入最小堆，并将相邻位置的高度和当前位置的高度差作为蓄水的高度。
//重复上述步骤，直到最小堆为空。
//最终累加得到的蓄水高度即为答案。
//时间复杂度：O((E + V) * logV)，其中E是边的数量，V是节点的数量。
//空间复杂度：O(V)
        public int TrapRainWater(int[][] heightMap)
        {
            if (heightMap == null || heightMap.Length == 0 || heightMap[0].Length == 0)
            {
                return 0;
            }

            int m = heightMap.Length;
            int n = heightMap[0].Length;

            PriorityQueue<Cell> minHeap = new PriorityQueue<Cell>((a, b) => a.Height.CompareTo(b.Height));

            bool[,] visited = new bool[m, n];

            // Add the border cells into the min heap and mark them as visited
            for (int i = 0; i < m; i++)
            {
                minHeap.Enqueue(new Cell(i, 0, heightMap[i][0]));
                minHeap.Enqueue(new Cell(i, n - 1, heightMap[i][n - 1]));
                visited[i, 0] = true;
                visited[i, n - 1] = true;
            }

            for (int j = 0; j < n; j++)
            {
                minHeap.Enqueue(new Cell(0, j, heightMap[0][j]));
                minHeap.Enqueue(new Cell(m - 1, j, heightMap[m - 1][j]));
                visited[0, j] = true;
                visited[m - 1, j] = true;
            }

            int[,] directions = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

            int result = 0;

            while (minHeap.Count > 0)
            {
                Cell current = minHeap.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int newRow = current.Row + directions[i, 0];
                    int newCol = current.Col + directions[i, 1];

                    if (IsValid(newRow, newCol, m, n) && !visited[newRow, newCol])
                    {
                        int minHeight = Math.Max(current.Height, heightMap[newRow][newCol]);
                        result += Math.Max(0, minHeight - heightMap[newRow][newCol]);
                        minHeap.Enqueue(new Cell(newRow, newCol, minHeight));
                        visited[newRow, newCol] = true;
                    }
                }
            }

            return result;
        }

        private bool IsValid(int row, int col, int m, int n)
        {
            return row >= 0 && row < m && col >= 0 && col < n;
        }

        public class Cell
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Height { get; set; }

            public Cell(int row, int col, int height)
            {
                Row = row;
                Col = col;
                Height = height;
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