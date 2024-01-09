//Leetcode 793. Preimage Size of Factorial Zeroes Function hard
//题意：给定一个非负整数 K，计算 K!（K 的阶乘）的后缀零的数量。后缀零是指数字末尾的连续零的数量。
//思路：二分搜索要: 理解什么导致阶乘结果中末尾出现零。末尾零的数量取决于质因子 2 和 5 的个数，因为 2 和 5 相乘得到 10，而 10 贡献了一个末尾零。
//阶乘的结果可以表示为质因子的乘积，而质因子 2 的个数通常会比质因子 5 的个数多，因此我们只需关注质因子 5 的个数。我们的目标是找到最小的非负整数 x，使得 x! 后缀零的数量等于 K。
//二分搜索：我们可以使用二分搜索来找到满足条件的 x。我们知道，每个质因子 5 都会贡献一个末尾零。因此，我们可以通过统计 x! 中质因子 5 的个数来确定末尾零的数量。
//计算质因子 5 的个数：对于 x!，其中质因子 5 的个数等于 x/5 + x/25 + x/125 + ...，以此类推。我们可以使用循环来累加这些值，直到 x/5^k 不再大于 0。
//二分搜索区间：我们使用二分搜索来找到满足条件的 x，其中左边界是 0，右边界是 K * 5。
//时间复杂度: O(logK)
//空间复杂度：O(1)。
        public int PreimageSizeFZF(int K)
        {
            long left = 0, right = (long)K * 5;

            while (left <= right)
            {
                long mid = left + (right - left) / 2;
                long count = CountFactor5(mid);

                if (count == K)
                {
                    return 5;
                }
                else if (count < K)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return 0;
        }

        private long CountFactor5(long num)
        {
            long count = 0;
            long divisor = 5;

            while (num >= divisor)
            {
                count += num / divisor;
                divisor *= 5;
            }

            return count;
        }