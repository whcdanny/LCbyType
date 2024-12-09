//Leetcode 396. Rotate Function med
//题意：给定一个nums长度为的整数数组n。
//假设是按位置顺时针旋转得到的数组，定义旋转函数如下：arrknumsk Fnums
//F(k) = 0 * arrk[0] + 1 * arrk[1] + ... + (n - 1) * arrk[n - 1].
//返回的最大值 F(0), F(1), ..., F(n-1)。
//生成测试用例时，答案必须适合32 位整数。
//思路：数学，找规律因为有方程式，所以有规律
//F(0) = 0 * arrk[0] + 1 * arrk[1] + ... + (n - 1) * arrk[n - 1].
//F(k) = 0 * arrk[n-k] + 1 * arrk[n-k+1] + ... + (n - 1) * arrk[n - k -1].
//F(k-1) = 0 * arrk[n-k+1] + 1 * arrk[n-k+2] + ... + (n - 1) * arrk[n - k].
//F(k)-F(k-1) = 1 * arrk[n-k] + 2 * arrk[n - k+ 1] ...+ (n - 2) * arrk[n - k - 2] + (n - 1) * arrk[n - k -1]
//                            - 1 * arrk[n - k + 1]...- (n - 3) * arrk[n - k - 2] - (n - 2) * arrk[n - k - 1] - (n - 1) * arrk[n - k]
//F(k) = F(k-1) + Sum(arrk) - n * arr[n-k]
//所以先算出sum 和 F（0）就可以类推了；
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public int MaxRotateFunction(int[] nums)
        {
            int n = nums.Length;
            int sum = 0; // nums 的总和
            int F = 0;   // F(0) 的初始值

            for (int i = 0; i < n; i++)
            {
                sum += nums[i];
                F += i * nums[i];
            }

            int max = F; // 最大值初始化为 F(0)
            for (int k = 1; k < n; k++)
            {
                // 根据递推公式计算 F(k)
                F = F + sum - n * nums[n - k];
                max = Math.Max(max, F);
            }

            return max;
            //int n = nums.Length;
            //int res = int.MinValue;
            //bool[] visted = new bool[n];
            //for (int i = 0; i < n; i++)
            //{
            //    int count = 0;
            //    int k = i;
            //    for (int j = 0; j < n; j++)
            //    {
            //        count += nums[j] * k;
            //        k++;
            //        if (k >= n)
            //            k = 0;
            //    }
            //    res = Math.Max(res, count);
            //}
           
            //return res;
        }