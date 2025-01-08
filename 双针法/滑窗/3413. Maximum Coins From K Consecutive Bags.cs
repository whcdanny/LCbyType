//Leetcode 3413. Maximum Coins From K Consecutive Bags med
//题意：你面前有一个无限长的数轴，每个坐标点上有一个袋子，其中一些袋子包含硬币。
//给定一个二维数组 coins，其中 coins[i] = [li, ri, ci] 表示从坐标 li 到 ri 范围内的每个袋子都包含 ci 个硬币。
//数组中的所有区间 互不重叠。
//还给定一个整数 k，你需要在数轴上找到 连续的 k 个袋子，以获得最多的硬币总数。
//返回你能获得的最大硬币总数。
//要求：你必须实现时间复杂度为 O(n) 且只使用 O(1) 辅助空间的算法
//思路：滑窗
// 处理单个区间的特殊情况
// 按起始位置排序
// 如果整个 `right` 区间都能装入窗口，则直接加入总和
//cur += (rightEnd - rightStart + 1) * rightPart[2];
// 如果 `right` 区间部分重叠窗口，则计算最大值
//max = Math.Max(max, rightStart <= end ? (end - rightStart + 1) * rightPart[2] + cur : cur);
// 如果窗口起始点的新位置部分重叠在 `left` 区间上
//cur += (rightEnd - rightStart + 1) * rightPart[2] - (newStart - start) * leftPart[2];
// 窗口完全移动到 `left` 区间之外
//cur -= (leftEnd - start + 1) * leftPart[2];
//时间复杂度：O(n)
//空间复杂度：O(1)

        public long MaximumCoins(int[][] coins, int k)
        {
            int n = coins.Length;

            // 处理单个区间的特殊情况
            if (n == 1)
            {
                return (long)Math.Min(coins[0][1] - coins[0][0] + 1, k) * coins[0][2];
            }

            // 按起始位置排序
            Array.Sort(coins, (a, b) => a[0].CompareTo(b[0]));

            long max = 0, cur = 0;
            long start = coins[0][0], end = start + k - 1;

            int left = 0, right = 0;

            while (right < n)
            {
                int[] rightPart = coins[right];
                long rightStart = rightPart[0], rightEnd = rightPart[1];

                if (end >= rightEnd)
                {
                    // 如果整个 `right` 区间都能装入窗口，则直接加入总和
                    cur += (rightEnd - rightStart + 1) * rightPart[2];
                    right++;
                    continue;
                }

                // 如果 `right` 区间部分重叠窗口，则计算最大值
                max = Math.Max(max, rightStart <= end ? (end - rightStart + 1) * rightPart[2] + cur : cur);

                int[] leftPart = coins[left];
                long leftEnd = leftPart[1], newStart = rightEnd - k + 1;

                if (newStart <= leftEnd)
                {
                    // 如果窗口起始点的新位置部分重叠在 `left` 区间上
                    cur += (rightEnd - rightStart + 1) * rightPart[2] - (newStart - start) * leftPart[2];
                    end = rightEnd;
                    start = newStart;
                    right++;
                }
                else
                {
                    // 窗口完全移动到 `left` 区间之外
                    cur -= (leftEnd - start + 1) * leftPart[2];
                    left++;
                    if (left < n)
                    {
                        start = coins[left][0];
                        end = start + k - 1;
                    }
                }
            }

            return Math.Max(max, cur);
        }
        public long MaximumCoins_1(int[][] coins, int k)
        {
            Array.Sort(coins, (a, b) => a[0].CompareTo(b[0]));
            long res = 0;
            long total = 0;
            int i = 0;
            int n = coins.Length;

            for(int j = 0; j < n; j++)
            {
                int winLength = coins[j][1] - coins[i][0] + 1;
                int jthCoins = coins[j][1] - coins[j][0] + 1;
                total += (long)coins[j][2] * jthCoins;

                while(i<=j && winLength > k)
                {
                    int extra = winLength - k;
                    if (jthCoins >= extra)
                    {
                        res = Math.Max(res, total - (long)extra * coins[j][2]);
                    }
                    int ithCoins = coins[i][1] - coins[i][0] + 1;
                    if (ithCoins >= extra)
                    {
                        res = Math.Max(res, total - (long)extra * coins[i][2]);
                    }
                    total -= (long)coins[i][2] * ithCoins;
                    i++;
                    if (i < n)
                    {
                        winLength = coins[j][1] - coins[i][0] + 1;
                    }
                }
                res = Math.Max(res, total);

                if (i > 0)
                {
                    i--;
                    total += (long)coins[i][2] * (coins[i][1] - coins[i][0] + 1);
                }
            }
            return res;
        }