 //Leetcode 675. Cut Off Trees for Golf Event hard
//题意：题目要求在一个二维网格中模拟一个高尔夫球场，球场上有多棵树，每棵树都有一个高度。现在，要求从一个起始位置出发，按照树的高度从低到高的顺序，依次砍倒所有的树，求解最短的路径。
//思路：对于给定的树的位置，按照树的高度进行排序。从起始位置出发，依次按照排序后的顺序前往每棵树的位置，记录每一步的最短路径。使用 BFS 进行搜索，找到从起始位置到达目标位置的最短路径。
//时间复杂度: 设球场上有 m 行和 n 列，总共有 k 棵树，排序的时间复杂度为 O(k * log(k))，每次 BFS 的时间复杂度为 O(m * n)。总体时间复杂度为 O(k * log(k) + m * n)。
//空间复杂度：O(m * n)
        public int CutOffTree(IList<IList<int>> forest)
        {
            int m = forest.Count;
            int n = forest[0].Count;

            // 使用列表保存所有树的位置及其高度
            List<int[]> trees = new List<int[]>();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int height = forest[i][j];
                    if (height > 1)
                    {
                        trees.Add(new int[] { i, j, height });
                    }
                }
            }

            // 按照树的高度进行排序
            trees.Sort((a, b) => a[2] - b[2]);

            int totalSteps = 0;
            int[] start = new int[] { 0, 0 };

            foreach (var tree in trees)
            {
                int steps = BFS_CutOffTree(forest, start, tree);

                // 如果某棵树无法到达，返回 -1
                if (steps == -1)
                {
                    return -1;
                }

                totalSteps += steps;
                start = new int[] { tree[0], tree[1] };
            }

            return totalSteps;
        }

        private int BFS_CutOffTree(IList<IList<int>> forest, int[] start, int[] target)
        {
            int m = forest.Count;
            int n = forest[0].Count;

            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(start);

            int steps = 0;
            bool[,] visited = new bool[m, n];
            visited[start[0], start[1]] = true;

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    int[] current = queue.Dequeue();

                    if (current[0] == target[0] && current[1] == target[1])
                    {
                        return steps;
                    }

                    for (int j = 0; j < 4; j++)
                    {
                        int x = current[0] + dx[j];
                        int y = current[1] + dy[j];

                        if (x >= 0 && x < m && y >= 0 && y < n && !visited[x, y] && forest[x][y] > 0)
                        {
                            queue.Enqueue(new int[] { x, y });
                            visited[x, y] = true;
                        }
                    }
                }

                steps++;
            }

            // 如果目标位置不可达，返回 -1
            return -1;
        }