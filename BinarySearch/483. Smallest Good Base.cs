//Leetcode 483. Smallest Good Base hard
//题意：给定一个字符串 "n" 表示一个非负整数，找到一个以 2 为底的 k 的最小整数，使得 k 的幂等于 n。换句话说，找到最小的 k 使得 k^x = n，其中 k 和 x 都是正整数。
//思路：二分搜索要找的是一个最小的 k，因此可以考虑从最小的 k 开始进行二分搜索。对于给定的 n，k 的取值范围是 [2, n]。
//在范围内使用二分查找，对每个可能的 k 进行验证，看是否能找到一个 x，使得 k^x = n。
//在验证时，可以通过二分查找 x 的范围，以减小时间复杂度。
//时间复杂度: O(log^2 n)，其中 n 是给定的字符串表示的整数。
//空间复杂度：O(1)
        public string SmallestGoodBase(string n)
        {
            long num = long.Parse(n);

            // 对于给定的 n，k 的取值范围是 [2, n]
            //对于一个 m 位的二进制数，其最大值为 2^m - 1。所以，我们从 m = log2(n+1) 开始尝试。
            for (int m = (int)Math.Floor(Math.Log(num + 1) / Math.Log(2)); m >= 2; m--)
            {
                //k^m <= num，所以 k <= num^(1/(m-1))。我们使用二分查找在这个范围内寻找合适的 k。
                long l = 2, r = (long)Math.Pow(num, 1.0 / (m - 1)) + 1;

                // 在范围内使用二分查找
                while (l < r)
                {
                    long mid = l + (r - l) / 2;
                    long sum = 0;

                    // 计算 k^x 的和
                    for (int i = 0; i < m; i++)
                    {
                        sum = sum * mid + 1;
                    }

                    // 验证是否能找到 x，使得 k^x = n
                    if (sum == num)
                    {
                        return mid.ToString();
                    }
                    else if (sum < num)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid;
                    }
                }
            }

            return (num - 1).ToString();
        }