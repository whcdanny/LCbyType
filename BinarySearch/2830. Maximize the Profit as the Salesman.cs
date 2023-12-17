//Leetcode 2830. Maximize the Profit as the Salesman med
//题意：给定一个表示数轴上房屋数量的整数 n，编号从 0 到 n - 1。
//此外，给定一个二维整数数组 offers，其中 offers[i] = [starti, endi, goldi] 表示第 i 个买家想以 goldi 数量的金币购买从 starti 到 endi 的所有房屋。
//作为销售员，你的目标是通过巧妙地选择并出售房屋来最大化你的收益。
//返回你能够获得的最大金币数量。
//注意，不同的买家不能购买同一栋房屋，而且一些房屋可能会无人购买。
//思路：动态规划和二分查找, dp[i] 表示在处理到第 i 个买家时的最大金币数量, 我们需要在此之前找到不与当前购买请求冲突的最远的购买请求（即 endi 最小的、不与当前 offers[i] 重叠的请求）;
//注：二分法用于查找，跟当前买家不重复房子的购买者；     
//时间复杂度:  O(n log n)，动态规划的时间复杂度是 O(n log n)，因此总体时间复杂度是 O(n log n)。
//空间复杂度： dp 数组，因此空间复杂度是 O(n)
        public int MaximizeTheProfit(int n, IList<IList<int>> offers)
        {
            //将 offers 数组按照结束房屋的位置（endi）从小到大进行排序，这样方便后续处理。
            int[][] offersArray = new int[offers.Count][];
            for (int i = 0; i < offers.Count; i++)
            {
                offersArray[i] = offers[i].ToArray();
            }

            Array.Sort(offersArray, (a, b) => a[1] - b[1]); // Sort by endi
            //动态规划，创建一个数组 dp，其中 dp[i] 表示在处理到第 i 个买家时的最大金币数量。
            int[] dp = new int[offersArray.Length];
            for (int i = 0; i < offersArray.Length; i++)
            {
                int start = offersArray[i][0], end = offersArray[i][1], gold = offersArray[i][2];
                dp[i] = gold;

                //我们需要在此之前找到不与当前购买请求冲突的最远的购买请求（即 endi 最小的、不与当前 offers[i] 重叠的请求）
                int prev = SearchPreviousOffer(offersArray, i, start);
                if (prev != -1)
                {
                    dp[i] += dp[prev];
                }

                if (i > 0)
                {
                    dp[i] = Math.Max(dp[i], dp[i - 1]);
                }
            }
            //dp 数组中的最大值即为答案，表示在处理所有购买请求时的最大金币数量
            return dp[offersArray.Length - 1];
        }
        //找到与当前报价不重叠的前一个报价的索引
        private int SearchPreviousOffer(int[][] offers, int current, int start)
        {
            int left = 0, right = current - 1, result = -1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (offers[mid][1] < start)
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }