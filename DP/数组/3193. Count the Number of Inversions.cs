//Leetcode 3193. Count the Number of Inversions hard
//题目：给定一个整数 n 和一个二维数组 requirements，其中 requirements[i] = [endi, cnti] 表示每个要求的终点索引和倒置数。
//在一个整数数组 nums 中，如果存在一对索引(i, j) 满足 i<j 且 nums[i] > nums[j]，则称该对为一个 倒置 (inversion)。
//任务是找到满足以下条件的[0, 1, 2, ..., n - 1] 所有排列 perm 的数量：对于所有 requirements[i]，在 perm[0..endi] 子数组中，必须恰好有 cnti 个倒置。
//由于答案可能非常大，返回结果对取模后的值。
//思路: 动态规划，dp[i, j] 表示长度为 i 的子数组中恰好有 j 个倒置的排列数量
//req[i] 是一个数组，用来存储 requirements 中的条件，如果 requirements 中有关于终点 endi 的倒置数 cnti 的条件，那么 req[i] = cnti；如果没有要求，则 req[i] = -1。
//对于长度为 1 的情况，没有倒置，因此 dp[1, 0] = 1，表示长度为 1 的子数组中仅有 1 种排列，且倒置数为 0。
//先确定当前个数从i-n，然后再确认插入位置，然后再找出已知的倒置数
//时间复杂度：O(n^2*m)
//空间复杂度：O(n*401)
        public int NumberOfPermutations(int n, int[][] requirements)
        {
            //dp[i, j] 表示长度为 i 的子数组中恰好有 j 个倒置的排列数量
            int[,] dp = new int[n + 1, 401];
            //req[i] 是一个数组，用来存储 requirements 中的条件，如果 requirements 中有关于终点 endi 的倒置数 cnti 的条件，那么 req[i] = cnti；如果没有要求，则 req[i] = -1。
            int[] req = new int[n + 1];
            Array.Fill(req, -1);

            foreach (var requirement in requirements)
            {
                int a = requirement[0];
                int b = requirement[1];
                req[a + 1] = b;
            }
            //对于长度为 1 的情况，没有倒置，因此 dp[1, 0] = 1，表示长度为 1 的子数组中仅有 1 种排列，且倒置数为 0。
            if (req[1] <= 0)
            {
                dp[1, 0] = 1;
            }

            for (int i = 2; i <= n; i++)
            {
                //可能的插入位置
                for (int incertIndex = 0; incertIndex < i; incertIndex++)
                {
                    //遍历当前已知的倒置数;i-1 的子数组中已有的倒置数
                    for (int inversionCount = 0; inversionCount + incertIndex <= 400; inversionCount++)
                    {
                        if (req[i] != -1 && inversionCount + incertIndex != req[i]) continue;
                        dp[i, inversionCount + incertIndex] += dp[i - 1, inversionCount];
                        dp[i, inversionCount + incertIndex] %= 1000000007;
                    }
                }
            }

            return dp[n, req[n]];
        }