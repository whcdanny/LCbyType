//Leetcode 1351. Count Negative Numbers in a Sorted Matrix ez
//题意：题目要求统计矩阵中的负数的数量。给定一个按非递减顺序排列的二维矩阵，要求计算其中的负数的个数
//思路：使用二分搜索对于每一行，找到第一个负数的位置，然后该位置及其右侧的元素都是负数。统计负数的个数，并加到结果中。
//对所有行得到的负数个数求和，得到最终结果。
//时间复杂度:  O(m log n)，其中 m 是行数，n 是列数
//空间复杂度： O(1)
        public int CountNegatives(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int count = 0;

            for (int i = 0; i < m; i++)
            {
                int left = 0, right = n - 1;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    if (grid[i][mid] < 0)
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }

                count += n - left;
            }

            return count;
        }