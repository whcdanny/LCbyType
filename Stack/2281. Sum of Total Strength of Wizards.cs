//Leetcode 2281. Sum of Total Strength of Wizards hard
//题意：作为王国的统治者，你指挥着一支由法师组成的军队。
//给定一个长度为 n 的整数数组 strength，其中 strength[i] 表示第 i 个法师的力量值。对于一个连续的法师组（即法师的力量值构成 strength 的一个子数组），其总力量被定义为以下两个值的乘积：
//组中最弱法师的力量值。
//组中所有法师的力量值之和。
//求所有连续的法师组的总力量之和，结果需要对 10^9 + 7 取模。
//思路：Stack+Monotonic Stack
//假设位置在i的元素nums[i]，其prevSmaller在位置a，nextSmaller在位置b。那么以nums[i] 为weakest的subarray
//a X X X X i X X X b
//那么，左边界x = i-a种可能；右边界y = b-i种可能。所以总共的subarray的可能性是x*y；
//左边界为例子：这里的*1，2，3，4是在算subarray的总和是，每一次被+的次数；
//S = nums[a + 1]*1 + nums[a + 2]*2 + nums[a + 3]*3 + nums[a + 4]*4 ...nums[i-1]*(i-1)
//技巧：presum2[i] = sum{nums[k]*k} for k=0,1,2,..i
//presum2[i - 1]-presum2[a] = nums[a + 1]*(a+1) + nums[a + 2]*(a+2) + nums[a + 3]*(a+3) + nums[a + 4]*(a+4) ...nums[a + i - 1]*(a + i - 1)
//=s + (nums[a + 1] + nums[a + 2] + nums[a + 3] + nums[a + 4] ...nums[a + i - 1])*(a)   
//(nums[a + 1] + nums[a + 2] + nums[a + 3] + nums[a + 4] ...nums[a + i - 1])这部分就是前缀和的(presum[i - 1] - presum[a])
//所以最后S =           (presum2[i - 1] - presum2[a]) - (presum[i - 1] - presum[a]) * a
//右部分就是逆向思维，  (presum[b - 1] - presum[i]) * (b - 1 + 1) - (presum2[b - 1] - presum2[i])
//那么用单调栈来算prevSmaller和nextSmaller；
//然后总和三部分
//左部分+i本身+有部分
//时间复杂度: O(n)，其中 n 是字符串的长度
//空间复杂度：O(n)
        public int TotalStrength(int[] strength)
        {
            const long M = 1000000007;
            int n = strength.Length;
            List<int> numsList = new List<int>(strength);
            numsList.Insert(0, 0);

            //普通前缀和；
            List<long> presum = new List<long>(new long[n + 2]);
            for (int i = 1; i <= n; i++)
                presum[i] = (presum[i - 1] + (long)numsList[i]) % M;

            //特别前缀和：每次加入多个系数；
            List<long> presum2 = new List<long>(new long[n + 2]);
            for (int i = 1; i <= n; i++)
                presum2[i] = (presum2[i - 1] + (long)numsList[i] * i) % M;

            Stack<int> stack = new Stack<int>();
            List<int> nextSmaller = Enumerable.Repeat(n + 1, n + 2).ToList();
            List<int> prevSmaller = Enumerable.Repeat(0, n + 2).ToList();
            for (int i = 1; i <= n; i++)
            {
                while (stack.Count > 0 && numsList[stack.Peek()] > numsList[i])
                {
                    nextSmaller[stack.Peek()] = i;
                    stack.Pop();
                }
                if (stack.Count > 0)
                    prevSmaller[i] = stack.Peek();
                stack.Push(i);
            }

            long ret = 0;
            for (int i = 1; i <= n; i++)
            {
                long a = prevSmaller[i], b = nextSmaller[i];
                long x = i - a, y = b - i;
                long first = ((presum2[i - 1] - presum2[(int)a]) - (presum[i - 1] - presum[(int)a]) * a % M + M) % M;
                first = first * y % M;
                long second = ((presum[(int)b - 1] - presum[i]) * (b - 1 + 1) - (presum2[(int)b - 1] - presum2[i]) + M) % M;
                second = second * x % M;
                long mid = (long)numsList[i] * x * y % M;

                ret = (ret + (first + second + mid) * numsList[i]) % M;
            }

            return (int)ret;
        }