//Leetcode 3240. Minimum Number of Flips to Make Binary Grid Palindromic II med
//题目：给定一个 m x n 的二进制矩阵 grid，需要最少的翻转次数使矩阵的所有行和所有列都成为回文，并使矩阵中 1 的数量是 4 的倍数。
//翻转定义：可以将 0 翻转为 1 或将 1 翻转为 0。
//目标：
//所有行和列都是回文。
//矩阵中 1 的总数是 4 的倍数。
//思路: 分块处理：
//由于行和列都要满足回文性质，我们可以将矩阵划分为四个对称区域（象限），比较各象限中的对应元素是否满足对称性。
//对于每个 grid[i][j]，其对称的三个元素为：grid[m - i - 1][j]，grid[i][n - j - 1] 和 grid[m - i - 1][n - j - 1]。
//统计每一组对称元素中 1 的数量 countOne，如果 countOne > 2，说明需要翻转（取 4 - countOne）使得该组对称元素符合回文条件。
//处理奇数行或奇数列：
//如果 m 或 n 为奇数，则矩阵中心存在无法与其他部分对称的行或列。
//针对奇数列和奇数行分别处理，将其值调整为对称回文。
//处理中心单元格：
//如果矩阵的行和列都是奇数，中心点没有对称单元格，因此需要单独检查，并根据是否为 1 决定是否翻转。
//调整 1 的数量为 4 的倍数：
//最后检查矩阵中 1 的数量是否是 4 的倍数，如果不是，可能需要额外的翻转来满足要求。
//时间复杂度：O(m * n)
//空间复杂度：O(1)
        public int MinFlips1(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int ans = 0;

            // Step 1: Calculate each quarter part
            int halfRow = m / 2;
            int halfColum = n / 2;
            for (int i = 0; i < halfRow; ++i)
            {
                for (int j = 0; j < halfColum; ++j)
                {
                    int countOne = grid[i][j] + grid[m - i - 1][j] + grid[i][n - j - 1] + grid[m - i - 1][n - j - 1];
                    if (countOne > 2)
                        countOne = 4 - countOne;
                    ans += countOne;
                }
            }

            // Step 2: In case n or m is odd, calculate in center row, col.
            int numOfPalinOnes = 0;
            int numOfChanges = 0;
            if (n % 2 == 1)
            {
                for (int i = 0; i < halfRow; ++i)
                {
                    if (grid[i][halfColum] != grid[m - i - 1][halfColum])
                    {
                        ans++;
                        numOfChanges++;
                        continue;
                    }

                    numOfPalinOnes += grid[i][halfColum];
                }
            }

            if (m % 2 == 1)
            {
                for (int j = 0; j < halfColum; ++j)
                {
                    if (grid[halfRow][j] != grid[halfRow][n - j - 1])
                    {
                        ans++;
                        numOfChanges++;
                        continue;
                    }

                    numOfPalinOnes += grid[halfRow][j];
                }
            }
            //numOfPalinOnes 统计了在中间行或列中处于回文位置的 1 的数量。
            //如果这个数量为奇数(numOfPalinOnes % 2 != 0) 且没有发生不符合对称条件的变化(numOfChanges == 0)，则需要额外翻转两次来保证矩阵中的 1 数量成为偶数
            //如果 1 的数量是奇数，则无法保证翻转后仍然对称，所以通过额外的 2 次翻转使其满足偶数的条件。
            if (numOfPalinOnes % 2 != 0 && numOfChanges == 0)
                ans += 2;
            // 如果矩阵的行数 m 和列数 n 均为奇数，那么矩阵会有一个唯一的中心单元格 grid[halfM][halfN]。
            //如果该中心单元格的值为 1，则需将其翻转为 0 以保持整个矩阵的对称性
            if ((m % 2 == 1) && (n % 2 == 1) && grid[halfRow][halfColum] != 0) // handle center
                ans++;

            return ans;
        }