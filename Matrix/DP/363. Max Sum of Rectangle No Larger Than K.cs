//Leetcode 363. Max Sum of Rectangle No Larger Than K hard
//题意：给定一个大小为 
//m×n 的矩阵 matrix 和一个整数 k，请返回矩阵中矩形的最大和，要求矩形的和不大于k
//可以保证至少存在一个矩形和满足不大于k。
//思路：动态规划+前缀和，每次更新 dp 数组，用于记录当前列区间内每一行的和
//外层循环 i 表示左列边界。
//内层循环 j 表示右列边界。
//这里dp相当于 我们一列一列，可以是[0,0]-[1,0]一直到[rows,0];
//也要算[1,0]-[2,0]一直到[rows,0]
//所以是在每一次算的时候建立新的dp
//MaxSubArray用前缀和找出合适的值满足,用sortedSet来存前缀和
//curSum - prefix<=k => curSum - k <= prefix 
//用FindCeil(set, currSum - k);在sortedSet中找到最接近这个值        
//时间复杂度：O(n^2⋅m⋅logm)
//空间复杂度：O(m) 
        public int MaxSumSubmatrix(int[][] matrix, int k)
        {
            int rows = matrix.Length; // 矩阵的行数
            int cols = matrix[0].Length; // 矩阵的列数
            int maxK = int.MinValue; // 初始化结果为最小值

            // 枚举每一对列边界 [i, j]
            for (int i = 0; i < cols; i++)
            {
                int[] dp = new int[rows]; // 存储当前列区间内各行的和
                for (int j = i; j < cols; j++)
                {
                    // 更新 dp，表示列区间 [i, j] 内每一行的和
                    for (int l = 0; l < rows; l++)
                    {
                        dp[l] += matrix[l][j];
                    }

                    // 在 dp 中找到不超过 k 的最大子数组和
                    int currSum = MaxSubArray(dp, k);
                    maxK = Math.Max(maxK, currSum);

                    // 提前返回最优解
                    if (maxK == k)
                    {
                        return k;
                    }
                }
            }

            return maxK;
        }

         private int MaxSubArray(int[] arr, int k)
        {
            int max = int.MinValue; // 当前最大值
            int currSum = 0; // 当前前缀和
            SortedSet<int> set = new SortedSet<int>(); // 有序集合存储前缀和
            set.Add(0); // 初始化前缀和为 0

            foreach (var num in arr)
            {
                currSum += num;

                // 找到 currSum - k 的最接近值               
                int tes = findValue(set, currSum - k);               
                if (tes != int.MinValue)
                {
                    max = Math.Max(max, currSum - tes);
                }

                // 将当前前缀和加入集合
                set.Add(currSum);
            }

            return max;
        }

        private int findValue(SortedSet<int> set, int target)
        {
            foreach (var val in set)
            {
                if (val >= target)
                {
                    return val;
                }
            }
            return int.MinValue;
        }