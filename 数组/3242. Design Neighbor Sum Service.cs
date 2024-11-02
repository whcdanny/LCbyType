//Leetcode 3242. Design Neighbor Sum Service ez
//题目：题目要求我们设计一个 NeighborSum 类，用于计算二维矩阵中某个元素的相邻元素的和。我们有两种类型的邻居：
//相邻邻居：包括上下左右位置的元素。
//对角邻居：包括左上、右上、左下和右下位置的元素。
//具体功能
//NeighborSum(int[][] grid)：初始化对象，使用一个 n x n 的二维数组 grid。
//int adjacentSum(int value)：返回 value 的相邻邻居的和。
//int diagonalSum(int value)：返回 value 的对角邻居的和。
//思路: 先遍历整个 grid 并将 value 的位置存储到字典 positionMap 中，这样可以快速找到每个 value 的坐标。
//接下来，计算邻居和对角邻居的和时，便可以通过字典查找位置并检查相应的邻居是否存在于矩阵中。
//时间复杂度：初始化：O(n^2)，因为需要遍历整个 n x n 的矩阵。邻居求和：O(1)
//空间复杂度：O(n^2)
        public class NeighborSum
        {
            private int[][] grid_NeighborSum;
            private Dictionary<int, (int, int)> positionMap_NeighborSum;
            private int n_NeighborSum;
            public NeighborSum(int[][] grid)
            {
                this.grid_NeighborSum = grid;
                this.n_NeighborSum = grid.Length;
                this.positionMap_NeighborSum = new Dictionary<int, (int, int)>();

                // 将 grid 中的元素位置存入字典
                for (int i = 0; i < n_NeighborSum; i++)
                {
                    for (int j = 0; j < n_NeighborSum; j++)
                    {
                        positionMap_NeighborSum[grid[i][j]] = (i, j);
                    }
                }
            }

            public int AdjacentSum(int value)
            {
                if (!positionMap_NeighborSum.ContainsKey(value)) return 0;

                var (i, j) = positionMap_NeighborSum[value];
                int sum = 0;

                // 定义四个相邻位置的方向数组
                int[][] directions = new int[][]
                {
                    new int[] { -1, 0 }, // 上
                    new int[] { 1, 0 },  // 下
                    new int[] { 0, -1 }, // 左
                    new int[] { 0, 1 }   // 右
                };

                foreach (var dir in directions)
                {
                    int ni = i + dir[0];
                    int nj = j + dir[1];

                    if (ni >= 0 && ni < n_NeighborSum && nj >= 0 && nj < n_NeighborSum)
                    {
                        sum += grid_NeighborSum[ni][nj];
                    }
                }

                return sum;
            }

            public int DiagonalSum(int value)
            {
                if (!positionMap_NeighborSum.ContainsKey(value)) return 0;

                var (i, j) = positionMap_NeighborSum[value];
                int sum = 0;

                // 定义四个对角位置的方向数组
                int[][] directions = new int[][]
                {
                    new int[] { -1, -1 }, // 左上
                    new int[] { -1, 1 },  // 右上
                    new int[] { 1, -1 },  // 左下
                    new int[] { 1, 1 }    // 右下
                };

                foreach (var dir in directions)
                {
                    int ni = i + dir[0];
                    int nj = j + dir[1];

                    if (ni >= 0 && ni < n_NeighborSum && nj >= 0 && nj < n_NeighborSum)
                    {
                        sum += grid_NeighborSum[ni][nj];
                    }
                }

                return sum;
            }
        }