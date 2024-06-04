//Leetcode 2967. Minimum Cost to Make Array Equalindromic hard
//题意：你需要将一个长度为 n 的整数数组 nums 转换为等价回文数组（equalindromic）。
//等价回文数组是指数组的所有元素都等于某个回文数 y，并且 y 小于 10^9。你可以执行以下特定操作任意次（包括零次）：
//选择一个索引 i（在范围[0, n - 1] 内）和一个正整数 x。    
//将 |nums[i] - x| 添加到总成本中。
//将 nums[i] 的值更改为 x。
//你的目标是通过上述操作使数组 nums 的所有元素都变为回文数，并使总成本最小化。
//思路：根据中位数定理，Make Array Equal的最小代价就是将所有元素变成数组里的中位数（median）。
//本题中，我们的目标就是找到最接近中位数的回文数。
//可以借鉴564. Find the Closest Palindrome的算法，求得中位数M的next greater palindrome和next smaller palinedrome，
//然后选取两者较小的代价即可。
//注意，单纯找nearest palinedrome是不对的。
//next greater palindrome和next smaller palinedrome相比，并不是更接近M就更好，
//而是与array里元素的分布有关。
//时间复杂度: n
//空间复杂度：n;
        public long MinimumCost(int[] nums)
        {
            int n = nums.Length;
            Array.Sort(nums);
            int midNum;
            if (n % 2 == 1)
                midNum = nums[n / 2];
            else
                midNum = (nums[n / 2] + nums[n / 2 - 1]) / 2;

            string a = NextSmallerOrEqual_MinimumCost(midNum.ToString());
            string b = NextGreaterOrEqual_MinimumCost(midNum.ToString());

            long ret = long.MaxValue;
            ret = Math.Min(ret, Check_MinimumCost(nums, long.Parse(a)));
            ret = Math.Min(ret, Check_MinimumCost(nums, long.Parse(b)));
            return ret;
        }

        private long Check_MinimumCost(int[] nums, long p)
        {
            long sum = 0;
            foreach (int num in nums)
            {
                sum += Math.Abs(num - p);
            }
            return sum;
        }

        private string NextSmallerOrEqual_MinimumCost(string n)
        {
            int m = n.Length;
            char[] s = n.ToCharArray();
            for (int i = 0, j = m - 1; i <= j;)
            {
                s[j--] = s[i++];
            }
            if (new string(s).CompareTo(n) <= 0) 
                return new string(s);
            //从中间开始减一
            int carry = 1;
            for (int i = (m - 1) / 2; i >= 0; i--)
            {
                int d = s[i] - '0' - carry;
                //如果减1之和发生变位的变化 比如10001,我们对前三位100减１之后得到的99
                if (d >= 0)
                {
                    s[i] = (char)('0' + d);
                    carry = 0;
                }
                else
                {
                    s[i] = '9';
                    carry = 1;
                }
                //并且反转；
                s[m - 1 - i] = s[i];
            }
            //那么如果减一会导致位数变化的情况，那么我们就直接返回n-1位数的99...99
            if (s[0] == '0' && m > 1)
                return new string('9', m - 1);
            else
                return new string(s);
        }

        private string NextGreaterOrEqual_MinimumCost(string n)
        {
            int m = n.Length;
            char[] s = n.ToCharArray();
            for (int i = 0, j = m - 1; i <= j;)
            {
                s[j--] = s[i++];
            }
            if (new string(s).CompareTo(n) >= 0) return new string(s);

            //从中间开始加一
            int carry = 1;
            for (int i = (m - 1) / 2; i >= 0; i--)
            {
                int d = s[i] - '0' + carry;
                //如果加1之和发生变位的变化， 999，我们如果对于前两位99加一变成100
                if (d <= 9)
                {
                    s[i] = (char)('0' + d);
                    carry = 0;
                }
                else
                {
                    s[i] = '0';
                    carry = 1;
                }
                s[m - 1 - i] = s[i];
            }
            //那么如果加一会导致位数变化的情况，直接返回n+1位数的100...0001
            if (carry == 1)
            {
                s = new char[m + 1];
                Array.Fill(s, '0');
                s[0] = s[m] = '1';
                return new string(s);
            }
            else
                return new string(s);
        }