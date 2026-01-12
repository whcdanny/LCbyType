//Leetcode 560. Subarray Sum Equals K med
//题意：给一个int[],注意这是无序的，然后找出满足subSum==K
//思路：前缀和（preSum），子数组 [left, right] 的和可以表示为：sum(i, j) = preSum[j] - preSum[i-1]
//要找的是 sum(i, j) = k，即：preSum[j] - preSum[i-1] = k, 
//遍历到当前位置 j 时，只要知道之前出现了多少个前缀和等于 preSum[j] - k，就能找到有多少个符合条件的Subarray。
//注意的是 初始化：前缀和为 0 默认出现 1 次（处理子数组刚好从索引 0 开始的情况）
//时间复杂度:  O(n)
//空间复杂度： O(n)
        public int SubarraySum(int[] nums, int k)//fix
        {
            int res = 0;
            int preSum = 0;
            // key: 前缀和的值, value: 该前缀和出现的次数
            Dictionary<int, int> map = new Dictionary<int, int>();

            // 初始化：前缀和为 0 默认出现 1 次（处理子数组刚好从索引 0 开始的情况）
            map.Add(0, 1);

            foreach (int num in nums)
            {
                preSum += num; // 更新当前前缀和

                // 如果存在一个之前的前缀和 等于 (当前前缀和 - k)
                if (map.ContainsKey(preSum - k))
                {
                    res += map[preSum - k];
                }

                // 将当前前缀和存入哈希表
                if (map.ContainsKey(preSum))
                {
                    map[preSum]++;
                }
                else
                {
                    map[preSum] = 1;
                }
            }

            return res;
        }
//思路：暴力手段历遍所有
//时间复杂度:  O(n^2)
//空间复杂度： O(1)
        public int SubarraySum1(int[] nums, int k)
        {            
            int res = 0;
            for(int left = 0; left < nums.Length; left++)
            {
                int subSum = 0;
                for(int right = left; right < nums.Length; right++)
                {
                    while (subSum + nums[right] == k)
                    {
                        res++;
                    }
                }
            }

            return res;
        }        