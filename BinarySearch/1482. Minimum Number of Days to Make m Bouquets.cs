//Leetcode 1482. Minimum Number of Days to Make m Bouquets med
//题意：给定一个整数数组 bloomDay 表示花朵的开放情况，数组中的第 i 个元素表示第 i 朵花将在 bloomDay[i] 天开放。还给定两个整数 m 和 k。
//我们需要制作 m 束花，每束花必须包含 连续 的 k 朵花。我们可以在开放花朵的这些天内制作花束，要求制作花束的总天数尽量少。
//如果无法制作 m 束花，则返回 -1。
//思路：使用二分搜索，为了降低制作花束的总天数，我们可以使用二分搜索来找到最小的制作花束的天数。具体而言，我们可以在最小值和最大值之间执行二分搜索，然后对于每个中间值，检查是否可以制作 m 束花。
//接下来，我们将新数组中从索引 left 到索引 right 的数字相加，最终结果对 10^9 + 7 取模。
//时间复杂度: O(log(maxBloomDay−minBloomDay))，其中         minBloomDayminBloomDay 分别是数组 bloomDay 中最大和最小的元素。
//空间复杂度：O(1)
        public int MinDays(int[] bloomDay, int m, int k)
        {
            int n = bloomDay.Length;
            if ((long)n < ((long)m * (long)k))
                return -1;
            int left = 0;
            int right = int.MaxValue;
            while (left < right)
            {
                int mid = left + (right - left) / 2;
                if (isOK_MinDays(bloomDay, m, k, mid))
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }

        private bool isOK_MinDays(int[] bloomDay, int m, int k, int day)
        {
            //有多少给k个花束；
            int count = 0;
            //连续的花，跟k来比较；
            int cur = 0;
            for(int i = 0; i < bloomDay.Length; i++)
            {
                if (bloomDay[i] > day)
                    cur = 0;
                else
                {
                    cur += 1;
                    if (cur == k)
                    {
                        cur = 0;
                        count += 1;
                    }
                }
                if (count >= m)
                    return true;
            }
            return false;
        }
