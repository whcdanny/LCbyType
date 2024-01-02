//Leetcode 1964. Find the Longest Valid Obstacle Course at Each Position hard
//题意：你想建造一些障碍课程。给定一个长度为 n 的整数数组 obstacles，其中 obstacles[i] 表示第 i 个障碍的高度。对于每个索引 i，其中 0 <= i <= n - 1（包括边界），找到 obstacles 中最长的障碍课程的长度，条件如下：
//选择从 0 到 i 之间的任意数量的障碍。
//必须包括第 i 个障碍在内。
//必须按照障碍在 obstacles 中的出现顺序放置。
//每个障碍（除了第一个）的高度都要高于或等于其前面的障碍。
//返回一个长度为 n 的数组 ans，其中 ans[i] 表示索引 i 对应的最长障碍课程的长度。
//思路：用二分法+greedy+LIS(Longest Increasing Subsequence)，建立一个递增的array来根据obstacles输入的更改这个递增array的内容，顺便找到在array中的index，然后用dp存入；
//注：用upperBound，因为要找到当前obstacles中大于递增array中的第一个数；
//时间复杂度: O(n log n)，其中 n 是 obstacles 数组的长度。这是因为在每个位置上，我们使用二分查找来找到最长障碍课程的长度。
//空间复杂度： O(n)，其中 n 是 obstacles 数组的长度。这是因为我们使用了一个辅助数组 dp 和一个动态维护的列表 result。
        public int[] LongestObstacleCourseAtEachPosition(int[] obstacles)
        {
            int n = obstacles.Length;
            int[] dp = new int[n];
            List<int> result = new List<int>();
           
            for (int i = 0; i < n; i++)
            {
                int index = upperBound_BinarySearch_LongestObstacleCourseAtEachPosition(result, obstacles[i]);
                if (index == result.Count)
                {
                    result.Add(obstacles[i]);
                }
                else
                {
                    result[index] = obstacles[i];
                }
                dp[i] = index + 1;
            }

            return dp;
        }
        // 二分查找
        public int upperBound_BinarySearch_LongestObstacleCourseAtEachPosition(List<int> list, int target)
        {
            int left = 0, right = list.Count;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (list[mid] <= target)
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
