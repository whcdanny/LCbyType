//Leetcode 1201. Ugly Number III med
//题意：给定四个正整数 a, b, c 和 n，找到第 n 个丑数。丑数是指只包含因子 a、b、c 的正整数。
//思路：使用二分搜索在二分搜索的过程中，对于每个猜测的丑数 mid，计算它是第几个丑数，即 countUgly。
//如果 countUgly<n，说明 mid 太小，需要增大 mid，否则减小 mid。
//在计算 countUgly 的过程中，使用容斥原理（Inclusion-Exclusion Principle）来计算不重复的丑数个数。
//最终得到的 mid 即为所求的第 n 个丑数。
//时间复杂度: 二分搜索的时间复杂度为 O(log(maxVal))，其中 maxVal 是 n 个 a、b、c 的最大值。在二分搜索的每一步中，计算 countUgly 的时间复杂度为 O(1)。总时间复杂度为 O(log(maxVal))。
//空间复杂度：O(1)。
        public int NthUglyNumber(int n, int a, int b, int c)
        {
            long low = 1, high = int.MaxValue, result = 0;

            while (low <= high)
            {
                long mid = low + (high - low) / 2;

                // 计算当前猜测的丑数 mid 是第几个丑数
                long countUgly = CountUglyNumbers_NthUglyNumber(mid, a, b, c);

                if (countUgly < n)
                {
                    low = mid + 1;
                }
                else
                {
                    result = mid;
                    high = mid - 1;
                }
            }

            return (int)result;
        }

        // 计算不重复的丑数个数
        private long CountUglyNumbers_NthUglyNumber(long num, long a, long b, long c)
        {
            long ab = LCM_NthUglyNumber(a, b);
            long bc = LCM_NthUglyNumber(b, c);
            long ca = LCM_NthUglyNumber(c, a);
            long abc = LCM_NthUglyNumber(a, bc);

            // 使用容斥原理计算不重复的丑数个数
            return num / a + num / b + num / c - num / ab - num / bc - num / ca + num / abc;
        }

        // 计算最小公倍数
        private long LCM_NthUglyNumber(long x, long y)
        {
            return x * y / GCD__NthUglyNumber(x, y);
        }

        // 计算最大公约数
        private long GCD__NthUglyNumber(long x, long y)
        {
            while (y != 0)
            {
                long temp = y;
                y = x % y;
                x = temp;
            }
            return x;
        }