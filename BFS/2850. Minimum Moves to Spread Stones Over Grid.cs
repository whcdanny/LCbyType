//Leetcode 2850. Minimum Moves to Spread Stones Over Grid  mid
//题意：题目给出一个大小为n x n的二维矩阵grid，其中矩阵中的每个单元格可以是以下两种情况之一：包含一个小偷（1表示）为空的单元格（0表示）你最初位于单元格(0, 0)，在一次移动中，你可以移动到网格中任何相邻的单元格，包括包含小偷的单元格。路径的安全系数定义为路径上任何单元格到最近的小偷的曼哈顿距离的最小值。要求返回所有通往单元格(n - 1, n - 1)的路径中，最大的安全系数。
//思路：广度优先搜索（BFS）和优先级队列的结合。首先，创建一个二维数组 safety，用来记录每个位置到最近的小偷的曼哈顿距离。初始化所有位置为最大值，然后将含有小偷的位置设为0，表示小偷本身的位置。使用BFS遍历所有的小偷位置，将它们添加到队列中，并将相应的safety值设为0。对于每个小偷，从其位置开始向四周扩展，更新safety值，同时将新的位置添加到队列中。接着，将起点(0, 0) 加入优先级队列 path，并设置其优先级为 safety[0][0]，表示到达起点的最大安全系数为起点的安全值。使用优先级队列进行广度优先搜索，每次从队列中取出一个位置，如果它是终点(n-1, n-1)，则返回当前的最大安全系数。
//时间复杂度: O(n^2 * log(n^2))，其中 n 为网格的大小
//空间复杂度：O(n^2)
        public int MaximumSafenessFactor(IList<IList<int>> grid)
        {
            int n = grid.Count;
            int[][] directions = new int[][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
            if(grid[0][0]==1 || grid[n-1][n-1]==1)
                return 0;
            int maxSafetyFactor = int.MinValue;
            int[][] safety = new int[n][];
            Queue<int[]> queue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                safety[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        queue.Enqueue(new int[] { i, j, 0 });
                        // since node has thief himself
                        safety[i][j] = 0;
                    }
                    else
                        safety[i][j] = int.MaxValue;
                }
            }
            
            while (queue.Count > 0)
            {
                int[] current = queue.Dequeue();
                int x = current[0];
                int y = current[1];
                int minDistance = current[2];
                
                foreach (int[] direction in directions)
                {
                    int nx = x + direction[0];
                    int ny = y + direction[1];

                    if (nx >= 0 && nx < n && ny >= 0 && ny < n && minDistance+1<safety[nx][ny])
                    {
                        queue.Enqueue(new int[] { nx, ny, minDistance + 1 });
                        safety[nx][ny] = minDistance + 1;
                    }
                }
            }
            Heap_Priority_Queue_xiti.PriorityQueue<int[]> path = new Heap_Priority_Queue_xiti.PriorityQueue<int[]>((a, b) => b[2] - a[2]);
            path.Enqueue(new int[] { 0, 0, safety[0][0] });
            bool[][] visited = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                visited[i] = new bool[n];
            }
            visited[0][0] = true;
            while (path.Count > 0)
            {
                int[] current = path.Dequeue();
                int x = current[0];
                int y = current[1];
                int minDistance = current[2];
                if (x == n - 1 && y == n - 1)
                    return minDistance;
                foreach(int[] direction in directions)
                {
                    int nx = x + direction[0];
                    int ny = y + direction[1];
                    if (nx >= 0 && nx < n && ny >= 0 && ny < n && !visited[nx][ny])
                    {
                        path.Enqueue(new int[] { nx, ny, Math.Min(minDistance, safety[nx][ny]) });
                        visited[nx][ny] = true;
                    }
                }
            }

            return 0;
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