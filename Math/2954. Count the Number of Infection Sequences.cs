//Leetcode 2954. Count the Number of Infection Sequences hard
//题意：描述了一个场景：有n个孩子排成一队，位置从0到n - 1编号。
//数组"sick"包含了一开始就感染了传染病的孩子的位置。
//传染病会从一个感染了的孩子传播给它的相邻孩子（如果它们存在并且尚未感染），每秒最多感染一个尚未感染的孩子。
//目标是找出所有可能的感染顺序的总数，其中感染顺序是非感染孩子感染的顺序。
//思路：对于两个相邻sick点之间的区间，他们被感染的次序看似很复杂，其实无非就是“感染左端点”和“感染右端点”两个选择里的随机选取。
//因此任意一个感染序列，都对应了一种LR的二值序列。假设区间内未被感染的点有m个，那么感染过程的序列种类（即排列）就是2^(m-1)。
//为什么是m-1？因为当只剩最后一个未感染点时，“感染左端点”和“感染右端点”这两个选择对应是同一个点。
//此外需要注意，如果只有单边存在sick的区间（比如第一个区间或者最后一个区间），它的序列种类只有1.
//以上是一个区间的种类数。那么如何计算所有点的总的序列种类呢？
//假设前述的区间m1,m2,...mk的总数是n，那么这n个点的随机排列是n!种。
//但是，对于属于某个特定区间的点而言（比如说属于第k个区间的mk个点），它的顺序不应该是完全随机的，随意我们要再除以mk的阶乘抵消这种随机性。
//但是属于第k区间的点肯定也不是只有一种排列，而是有2^(mk-1)种方法（如果是单边存在sick的区间，那就只是1种），故需要再乘以该区间内点的排列数。
//所以这道题的答案是
//ret = n!;
//for (int i=0; i<k; i++)
//      ret = ret / mi! * (2^mi);
//注意到其中涉及到除法，想要保持同余操作的正确性，我们必须将除以m!的操作，转化为乘以m!的（关于1e9+7取余的）逆元的操作。
//我们可以利用小费马定理：inv(a) ≡ a ^ (M-2)  (mod M) 通过快速幂实现。
//时间复杂度: n
//空间复杂度：n;
        long[] power_NumberOfSequence = new long[100005];
        long[] fact_NumberOfSequence = new long[10005];
        long mod_NumberOfSequence = 1000000007;
        public int NumberOfSequence(int n, int[] sick)
        {
            power_NumberOfSequence[0] = 1;
            for(int i = 1; i <= n; i++)
            {
                power_NumberOfSequence[i] = power_NumberOfSequence[i - 1] * 2 % mod_NumberOfSequence;
            }
            fact_NumberOfSequence[0] = 1;
            for(int i = 1; i <= n; i++)
            {
                fact_NumberOfSequence[i] = fact_NumberOfSequence[i - 1] * i % mod_NumberOfSequence;
            }
            List<int> groups = new List<int>();
            for(int i=0; i < sick.Length; i++)
            {
                if (i == 0)
                    groups.Add(sick[i]);
                else
                    groups.Add(sick[i] - sick[i - 1] - 1);
            }
            groups.Add(n - 1 - sick.Last());

            int total = groups.Sum();

            long res = fact_NumberOfSequence[total];
            foreach(int val in groups)
            {
                res = res * Inv(fact_NumberOfSequence[val]) % mod_NumberOfSequence;
            }
            for(int i = 1; i < sick.Length; i++)
            {
                int val = sick[i] - sick[i - 1] - 1;
                if (val > 0)
                {
                    res = res * power_NumberOfSequence[val - 1] % mod_NumberOfSequence;
                }
            }
            return (int)res;
        }
        long QuickPow(long x, long y)
        {
            long ret = 1;
            long cur = x;

            while (y > 0)
            {
                if ((y & 1) == 1)
                {
                    ret = (ret * cur) % mod_NumberOfSequence;
                }
                cur = (cur * cur) % mod_NumberOfSequence;
                y >>= 1;
            }
            return ret;
        }

        long Inv(long x)
        {
            return QuickPow(x, mod_NumberOfSequence - 2);
        }