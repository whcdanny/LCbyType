//Leetcode 3077. Maximum Strength of K Disjoint Subarrays hard
//题意：题目要求在给定的数组nums中选择k个不相交的子数组，使得它们的强度（strength）之和最大。强度的计算方式是：
//strength = sum[1] * x - sum[2] * (x - 1) + sum[3] * (x - 2) - sum[4] * (x - 3) + ... + sum[x] * 1
//其中，sum[i] 是第i个子数组的元素和。形式上，强度是所有i的总和，满足1 <= i <= x，其中（-1）^i+1 * sum[i] * (x - i + 1)。
//思路：动态规划：我们令dp[i][j]表示前i个元素里找出j个subarray的最优解。
//注意，我们认为k是个常数，即dp[i][j] = sum[1]*k - sum[2]*(k-1) + ...，而不是dp[i][j] = sum[1]*j - sum[2]*(j-1) + ....
//考虑dp[i][j] 时，会思考对于nums[i] 的决策。
//如果nums[i] 不加入任何subarray，那么就有dp[i][j] = dp[i - 1][j]. 
//如果nums[i] 加入subarray，那么它就是属于sum[j]。但是此时有一个问题，它是加入已有的sum[j] 呢，还是自己独创一个sum[j]。
//前者的话就是dp[i - 1][j]+nums[i]，后者就是dp[i - 1][j - 1]+nums[i]. 但是注意到，前者要求dp[i - 1][j] 中的sum[j]必须结尾在第i-1个元素，才能将nums[i] 顺利接在sum[j]里，而我们的dp定义并没有这个约束。
//为了解决这个问题，我们重新定义dp，加入第三个维度表示“最后一个subarray是否以当前元素结尾”。
//即dp[i][j][0] 表示前i个元素分成j个subarray，且nums[i] 不参与最后一个subarray；
//类似dp[i][j][1] 表示前i个元素分成j个subarray，且nums[i] 参与了最后一个subarray。
//以j是偶数为例，对于dp[i][j][0]，由于nums[i] 不起作用，完全取决于dp[i - 1][j]，不用考虑它的第三个维度：
//dp[i][j][0] = max(dp[i - 1][j][0], dp[i - 1][j][1]);
//对于dp[i][j][1]，我们需要考虑nums[i] 是否是接在nums[i - 1]后面属于同一个subarray，还是自己新成立一个subarray。
//如果是前者，我们考虑的前驱状态是dp[i - 1][j][1]; 如果是后者，我们考虑的前驱状态是dp[i - 1][j - 1][x]
//dp[i][j] [1] = max(dp[i - 1][j][1], max(dp[i - 1][j - 1][0], dp[i - 1][j - 1][1])) - (LL) nums[i]*(k+1-j);   
//最终返回的答案是max(dp[n][k][0], dp[n][k][1]).
//初始状态是对于所有的dp[i][0][0] 赋值为零，其他都设为负无穷大。
//时间复杂度: n^3
//空间复杂度：n
        public long MaximumStrength(int[] nums, int k)
        {
            int n = nums.Length;            
            int[] newNums = new int[n + 1];
            newNums[0] = 0;
            int index = 1;           
            foreach (int num in nums)
                newNums[index++] = num;

            long[,,] dp = new long[n + 1, k + 1, 2];
            for(int i = 0; i <n+1; i++)
            {
                for(int j = 0; j <k+1; j++)
                {
                    dp[i, j, 0] = long.MinValue / 3;
                    dp[i, j, 1] = long.MinValue / 3;
                }
            }
            for (int i = 0; i <= n; i++)
            {
                dp[i,0,0] = 0;
            }
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= k; j++)
                {
                    if (j % 2 == 0)
                    {
                        dp[i, j, 0] = Math.Max(dp[i - 1,j,0], dp[i - 1,j,1]);
                        dp[i, j, 1] = Math.Max(dp[i - 1,j,1], Math.Max(dp[i - 1,j - 1,0], dp[i - 1,j - 1,1])) - (long)newNums[i] * (k + 1 - j);
                    }
                    else
                    {
                        dp[i, j, 0] = Math.Max(dp[i - 1,j,0], dp[i - 1,j,1]);
                        dp[i, j, 1] = Math.Max(dp[i - 1,j,1], Math.Max(dp[i - 1,j - 1,0], dp[i - 1,j - 1,1])) + (long)newNums[i] * (k + 1 - j);
                    }
                }
            }
            return Math.Max(dp[n, k, 0], dp[n, k, 1]);
        }