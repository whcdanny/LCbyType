//Leetcode 1751. Maximum Number of Events That Can Be Attended II hard
//题意：这道题要求在给定的事件数组中选择最多 k 个事件参加，每个事件都有一个开始日期 startDayi、结束日期 endDayi 和一个价值 valuei。目标是最大化参加的事件的总价值。
//思路：用二分法：
//将事件按照结束日期排序： 首先，将事件数组按照结束日期进行排序，以便后续的处理。
//定义状态和动态规划数组： 定义一个二维数组 dp，其中 dp[i, j] 表示在考虑前 i 个事件，并且已经选择了 j 个事件时的最大总价值。
//对于每个事件，考虑两种情况：
//选择参加当前事件：如果选择参加当前事件，那么最大总价值就等于上一个不重叠事件的最大总价值加上当前事件的价值。通过二分搜索找到上一个不重叠事件的位置。
//不选择参加当前事件：最大总价值保持不变，即等于上一个事件的最大总价值。
//初始化 dp[0, j] 为第一个事件的价值（如果选择参加）或者 0（如果不选择参加），然后进行动态规划遍历。
//时间复杂度: O(nk + n log n)
//空间复杂度：O(nk)
        public int MaxValue(int[][] events, int k)
        {
            //根据endDayi排序；
            Array.Sort(events, (a, b) => a[1].CompareTo(b[1]));

            int n = events.Length;
            int[,] dp = new int[n + 1, k + 1];

            for (int i = 1; i <= n; i++)
            {
                int index = BinarySearch(events, i);
                for (int j = 1; j <= k; j++)
                {
                    //对于每个事件，考虑两种情况：
                    //选择参加当前事件：如果选择参加当前事件，那么最大总价值就等于上一个不重叠事件的最大总价值加上当前事件的价值。通过二分搜索找到上一个不重叠事件的位置。
                    //不选择参加当前事件：最大总价值保持不变，即等于上一个事件的最大总价值。
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[index, j - 1] + events[i - 1][2]);
                }
            }

            int result = 0;
            for (int j = 0; j <= k; j++)
            {
                result = Math.Max(result, dp[n, j]);
            }

            return result;
        }

        private int BinarySearch(int[][] events, int i)
        {
            int left = 0, right = i - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (events[mid][1] >= events[i - 1][0])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }