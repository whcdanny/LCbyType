//Leetcode 3007. Maximum Number That Sum of the Prices Is Less Than or Equal to K med
//题意：给定整数 k 和整数 x。一个数 num 的价格是根据其二进制表示中从最低有效位开始的 x、2x、3x 等位置的「set bits」的数量计算得到的。
//下表包含了价格计算的示例。
//思路：二分搜索法 首先我们很容易看出此题的答案具有单调性。答案越大，就有越多的bit 1能够被计入；
//反之，被计入的bit 1会越少。所以整体的框架就是一个二分，核心就是制定一个上限A，想问从1到A的所有自然数的二进制表达里，总共有多少个bit 1出现在第x位、第2x位、...
//这个问题和LC 233.Number-of-Digit-One非常相似。
//我们不会固定一个数，再数里面有多少个bit 1；
//而是相反的策略，对于某位bit，我们计算有多少个数会在该bit的值是1.
//我们令上限A表达为XXX i YYY，考虑从1到A总共多少个自然数在第i位bit上的值是1呢？
//如果A[i]==0，那么高位部分可以是任意000 ~ (XXX-1)，低位部分可以是任意 000 ~ 111。
//两处的任意组合，都可以保证整体的数值不超过上限A。
//这样的数有XXX* 2^i种，其中i表示YYY的位数。此外没有任何数可以满足要求。
//如果A[i]==1，那么高位部分可以是任意000 ~ (XXX-1)，低位部分可以是任意 000 ~ 111。两处的任意组合，都可以保证整体的数值不超过上限A。同样，这样的数有XXX* 2^t种，其中t表示YYY的位数。。此外，当高位恰好是XXX时，低位可以是从000 ~YYY，这样就额外有YYY+1种。
//以上就统计了从1-A的所有自然数有多少个在第i位bit是1。我们再循环处理下一个的bit（隔x位）即可。
//时间复杂度：O(NLognLogn)
//空间复杂度：O(m+n)
        public long FindMaximumNumber(long k, int x)
        {
            long left = 1;
            long right = (long)1e15;
            while (left < right)
            {
                long mide = left + (right - left) / 2;
                if (isOk_FindMaximumNumber(mide, k, x))
                    left = mide;
                else
                    right = mide - 1;
            }
            return left;
        }

        private bool isOk_FindMaximumNumber(long topValue, long k, int x)
        {
            long res = 0;

            for (int i = x - 1; (1L << i) <= topValue; i += x)
            {
                long value = topValue;
                List<int> arr = new List<int>();
                while (value > 0)
                {
                    arr.Add((int)(value % 2));
                    value /= 2;
                }
                if (arr[i] == 1)
                {
                    long preValue = 0;
                    for (int j = arr.Count - 1; j > i; j--)
                        preValue = preValue * 2 + arr[j];
                    res += preValue * (long)Math.Pow(2, i);
                    //前几位刚好是xxx，后面必须小于YYY
                    preValue = 0;
                    for (int j = i - 1; j >= 0; j--)
                        preValue = preValue * 2 + arr[j];
                    res += preValue + 1;
                }
                else
                {
                    long preValue = 0;
                    for (int j = arr.Count - 1; j > i; j--)
                        preValue = preValue * 2 + arr[j];
                    res += preValue * (long)Math.Pow(2, i);
                }

                if (res > k) return false;
            }
            return true;
        }