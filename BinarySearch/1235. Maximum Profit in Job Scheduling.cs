//Leetcode 1235. Maximum Profit in Job Scheduling hard
//题意：给定一组工作，每个工作都有一个开始时间 startTime，结束时间 endTime，和该工作的收益 profit。如果你选择了某个工作，你就必须完成它，且不能同时进行其他工作。要求设计一个算法，找到最大的总收益，满足不同时进行的工作的结束时间不冲突。
//思路：使用二分搜索将工作按照结束时间排序。
//创建一个数组 dp，其中 dp[i] 表示截止到第 i 个工作结束时的最大总收益。
//对于每个工作 i，我们需要找到在它之前结束的工作 j 中能获得最大收益的那个工作，同时满足不冲突。因此，我们可以使用二分搜索在[0, i) 范围内找到满足 endTime[j] <= startTime[i] 的最大的 j，然后更新 dp[i]。
//最终，dp 数组中的最大值即为所求的最大总收益。
//时间复杂度: 对工作按结束时间排序的时间复杂度为 O(nlogn)。动态规划的时间复杂度为 O(nlogn)，其中包含了二分搜索的时间。总时间复杂度为 O(nlogn)。
//空间复杂度：动态规划数组 dp 的空间复杂度为 O(n)。
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            int n = startTime.Length;

            // 将工作按结束时间排序
            List<int[]> jobs = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                jobs.Add(new int[] { startTime[i], endTime[i], profit[i] });
            }
            jobs.Sort((a, b) => a[1] - b[1]);

            // 动态规划数组，dp[i] 表示截止到第 i 个工作结束时的最大总收益
            int[] dp = new int[n];
            dp[0] = jobs[0][2];

            for (int i = 1; i < n; i++)
            {
                // 在 [0, i) 范围内找到满足 endTime[j] <= startTime[i] 的最大的 j
                int prevIdx = BinarySearch(jobs, i);

                // 更新 dp[i]
                dp[i] = Math.Max(dp[i - 1], prevIdx == -1 ? jobs[i][2] : dp[prevIdx] + jobs[i][2]);
            }

            return dp[n - 1];
        }

        // 二分搜索找到满足 endTime[j] <= startTime[i] 的最大的 j
        private int BinarySearch(List<int[]> jobs, int i)
        {
            int left = 0, right = i - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (jobs[mid][1] <= jobs[i][0])
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }