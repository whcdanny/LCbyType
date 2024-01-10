//Leetcode 668. Kth Smallest Number in Multiplication Table hard
//题意：给定一个 m x n 的二维整数数组 table，其中 table[i][j] 表示乘法表中的第 i 行第 j 列的数字。请找出乘法表中第 k 小的数字。
//思路：二分搜索：首先，我们可以确定二分查找的范围，即最小值和最大值。最小值为乘法表中的最小元素，即1，最大值为乘法表中的最大元素，即 m * n。然后，在这个范围内进行二分查找。
//对于每一次二分查找，我们需要统计乘法表中小于等于 mid 的元素个数。具体步骤如下：
//对于每一行 i，找到 mid / i 的值，表示乘法表中小于等于 mid 的元素个数。
//对所有行的结果求和，即为小于等于 mid 的元素总数。
//根据比较结果调整二分查找范围。     
//时间复杂度: O(m * log(m * n))，其中 m 和 n 分别为乘法表的行数和列数
//空间复杂度：O(1)
        public int FindKthNumber(int m, int n, int k)
        {
            int left = 1;
            int right = m * n;

            while (left < right)
            {
                int mid = left + (right - left) / 2;

                int count = 0;
                for (int i = 1; i <= m; i++)
                {
                    count += Math.Min(mid / i, n);
                }

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