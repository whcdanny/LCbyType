//Leetcode 2528. Maximize the Minimum Powered City hard
//题意：给定一个长度为 n 的数组 stations，其中 stations[i] 表示第 i 个城市的发电站数量。
//每个发电站都可以为一定范围内的城市提供电力。如果范围用 r 表示，那么位于城市 i 的发电站可以为城市 j 提供电力，只要 |i - j| <= r 且 0 <= i, j <= n - 1。
//这里 |x| 表示绝对值。例如，|7 - 5| = 2 和 |3 - 10| = 7。
//一个城市的电力是其所获得电力站数量的总和。
//政府批准建设 k 个额外的发电站，每个发电站可以建在任何城市，具有与现有发电站相同的范围。
//给定两个整数 r 和 k，如果额外的发电站被最优地建设，返回城市的最大可能最小电力。
//思路：二分搜索, 注意“最大化最小值”，显然应该考虑在值域上进行二分搜索;使用滑动窗口来维持当前城市拥有的发电站数量
//注：检查时，遍历自0到n-1并计算每个城市缺少多少个发电站, 每次检查是否k足够了。
//时间复杂度:  O(n log(n))
//空间复杂度： O(n)
        public long MaxPower(int[] stations, int r, int k)
        {
            int n = stations.Length;
            long left = 0, right = k;
            //right是可能的最大值；
            foreach (int val in stations)
                right += val;
            //这是之后的滑块；
            long[] newStations = new long[n];
            while (left <= right)
            {
                long mid = (left + right) / 2;
                //先把暂时station添加进入滑块；
                for (int i = 0; i < n; ++i)
                    newStations[i] = stations[i];
                //start作为开始存储power根据r来计算；
                long start = 0, use = 0;
                for (int i = 0; i < r; ++i)
                    start += newStations[i];

                for (int i = 0; i < n; ++i)
                {
                    //防止超出边界；
                    int point = Math.Min(n - 1, i + r);
                    //找到应该被加的；
                    if (i + r < n) 
                        start += newStations[i + r];
                    //找到应该被减去的；
                    if (i - r > 0) 
                        start -= newStations[i - r - 1];

                    //找到期望mid和现有的差值；
                    long diff = Math.Max(0, mid - start);
                    newStations[point] += diff;
                    start += diff;
                    use += diff;
                }
                if (use <= k) 
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return right;
        }