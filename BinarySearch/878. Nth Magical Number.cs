//Leetcode 878. Nth Magical Number hard
//题意：题目描述为：给定四个整数 A、B、N 和 X，找到从 1 10^9 + 7 中第 N 个按位或操作结果为 X 的正整数。
//思路：二分搜索找到最小公倍数：由于要找的是按位或操作的结果，可以将问题转化为找到在 A 和 B 中任选的数列中，第 N 个数是多少。首先找到 A 和 B 的最小公倍数 LCM。LCM 是一个周期，在这个周期内，所有的数都会按位或操作得到相同的结果。
//使用二分搜索：使用二分搜索来确定 N 在 LCM 周期内的位置。在每个二分搜索的步骤中，假设当前位置为 mid，计算在这个位置之前有多少个满足条件的数。如果满足条件的数小于 N，说明 mid 太小，需要在右侧搜索；否则，在左侧搜索。
//计算结果：在找到 N 的位置后，计算 N 在 LCM 周期内的具体位置，即LCM×倍数+在周期内的位置。最终结果即为A×倍数+在周期内的位置。
//时间复杂度: O(log(LCM))
//空间复杂度：O(1)。
        public int NthMagicalNumber(int N, int A, int B)
        {
            long lcm = LCM(A, B);
            long left = 2, right = (long)1e18;

            while (left < right)
            {
                long mid = left + (right - left) / 2;
                long count = mid / A + mid / B - mid / lcm;

                if (count < N)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return (int)(left % (long)(1e9 + 7));
        }

        private long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }

        private long GCD(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }