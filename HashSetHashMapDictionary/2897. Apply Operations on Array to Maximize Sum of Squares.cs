//Leetcode 2897. Apply Operations on Array to Maximize Sum of Squares hard
//题意：给定一个整数数组 nums 和一个正整数 k，你可以对数组执行一种特殊操作，
//即选择任意两个不同的索引 i 和 j，同时更新 nums[i] 为 (nums[i] AND nums[j])，nums[j] 为 (nums[i] OR nums[j])。
//这里的 AND 表示按位与操作，OR 表示按位或操作。你需要从最终数组中选择 k 个元素，并计算它们平方和的最大值。
//思路：hashtable，看code
//X Y     AND OR
//1, 1 =>   1  1
//1, 0 =>   0  1
//0, 1 =>   0  1
//0, 0 =>   0  0
//我们发现OR的效果其实是在每个bit位上“收集”1，而AND的效果其实就是“送出”1. 一进一出，不难发现X+Y= AND+OR。
//当和固定的时候，数越大的平方越好；
//也就是说每次操作X和Y的一对数，我们在“零和”你死我活的前提下，拉大了“贫富差距”。是的，因为这能增大平方和。简单的证明，当x>=y且d>0时
//(x+d)^2 + (y-d)^2 = x^2 + y^2 + 2d*(x-y) + 2d^2 > x^2 + y^2 
//注：32个比特位，在每个数拆分成比特位，然后将最高位置放入1，尽可能构造最大的数；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaxSum(IList<int> nums, int k)
        {
            long M = 1000000007;
            long[] count = new long[32];

            foreach (int x in nums)
            {
                for (int i = 0; i < 32; i++)
                {
                    //x在第i为1，用于尽可能大的数字；
                    if (((x >> i) & 1) == 1)
                        count[i] += 1;
                }
            }

            long ret = 0;

            for (int t = 0; t < k; t++)
            {
                long x = 0;
                for (int i = 31; i >= 0; i--)
                {
                    //如果当前比特位有1，
                    if (count[i] > 0)
                    {
                        //在这个位置上填充1；
                        x += (1L << i);
                        count[i] -= 1;
                        x %= M;
                    }
                }
                ret = ret + x * x % M;
                ret %= M;
            }

            return (int)ret;
        }