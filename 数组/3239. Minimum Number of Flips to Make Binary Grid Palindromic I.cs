//Leetcode 3239. Minimum Number of Flips to Make Binary Grid Palindromic I med
//题目：给定一个 m x n 的二进制矩阵 grid，要求最少翻转的次数以使矩阵的所有行或所有列都成为回文。
//回文定义：一个数组如果从左往右与从右往左读相同，则它是回文。
//翻转定义：可以翻转任意单元格的值，即将 0 变为 1 或将 1 变为 0。我们要返回最小的翻转次数，使得矩阵的所有行或所有列都是回文。
//思路: 检查行和列的回文性质：
//对每行和每列分别检查其回文性质。
//统计每行或每列中每对非回文单元格的数量，记录需要翻转的次数。
//翻转次数统计：
//对每行或每列，找到使其成为回文所需的最小翻转次数。
//对于每个非回文单元格对，可以选择翻转其中一个单元格。
//选择最小的翻转结果：
//计算出使所有行回文和所有列回文分别所需的最小翻转次数，返回两者的最小值
//时间复杂度：O(m * n)
//空间复杂度：O(m + n)
        public int MinFlips(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            // 计算所有行变成回文所需的最小翻转次数
            int rowFlips = 0;
            for (int i = 0; i < m; i++)
            {
                rowFlips += CalculateFlips(grid[i]);
            }

            // 计算所有列变成回文所需的最小翻转次数
            int colFlips = 0;
            for (int j = 0; j < n; j++)
            {
                int[] column = new int[m];
                for (int i = 0; i < m; i++)
                {
                    column[i] = grid[i][j];
                }
                colFlips += CalculateFlips(column);
            }

            // 返回最小的翻转次数
            return Math.Min(rowFlips, colFlips);
        }
        private int CalculateFlips(int[] arr)
        {
            int flips = 0;
            int left = 0;
            int right = arr.Length - 1;

            // 比较回文对并统计需要翻转的次数
            while (left < right)
            {
                if (arr[left] != arr[right])
                {
                    flips++;
                }
                left++;
                right--;
            }

            return flips;
        }