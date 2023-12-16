//Leetcode 2945. Find Maximum Non-decreasing Array Length hard
//题意：给定一个从0开始的整数数组nums，你可以执行任意次操作，每次操作涉及选择数组的一个子数组并用其元素的和替换它。例如，如果给定数组是[1,3,5,6]，你选择子数组[3,5]，数组将变为[1,8,6]。返回在应用操作后可以得到的最大非递减数组的长度。
//思路：二分查找.维护一个前缀和数组和一个 dp 数组，使用二分查找寻找下一个可能的位置，从而实现在线性时间内求解最大非递减数组的长度。
//注：这里BinarySearch如果找到了匹配项，则返回该项的索引；如果未找到匹配项，则返回一个负数，该负数是对应于按位求补的插入点的索引。
//时间复杂度:  O(nlogn) - 两个嵌套的循环，其中每个循环的主要操作是二分查找，所以总体时间复杂度为 O(nlogn)。
//空间复杂度： O(n) - 使用了额外的数组来存储前缀和、位置信息等，空间复杂度为  
        public int FindMaximumLength(int[] nums)
        {
            int n = nums.Length;
            //用于存储累积和、动态规划结果和优化索引的数组
            int[] pre = new int[n + 2], dp = new int[n + 1];
            long[] acc = new long[n + 1];
            //存储输入数组的累积和的数组
            for (int i = 1; i <= n; i++)
            {
                acc[i] = acc[i - 1] + nums[i - 1];
            }
            //迭代输入数组的元素
            for (int i = 0, j = 1; j <= n; j++)
            {
                //如果之前优化过起始索引 i，则优化它
                i = Math.Max(i, pre[j]); 
                dp[j] = dp[i] + 1;
                //说白了就是我需要找到下一个比前一组或者前一个数大的位置；
                //he sum of last group of elements is acc[j] - acc[i] = nums[i] + ... + nums[j - 1].
                //We will find the next shortest group starting from nums[j] to nums[k - 1]
                //to make it bigger than current group.
                //acc[j] - acc[i] <= acc[k] - acc[j]
                //so that acc[j] * 2 - acc[i] <= acc[k].
                int k = Array.BinarySearch(acc, 2 * acc[j] - acc[i]);
                //如果没有找到值，则用-k-1来得到应在数组中的位置，更新pre数组
                if (k < 0)
                {
                    k = -k - 1;
                }
                //使用当前索引 j 更新 pre 数组
                pre[k] = j;
            }
            return dp[n];
        }