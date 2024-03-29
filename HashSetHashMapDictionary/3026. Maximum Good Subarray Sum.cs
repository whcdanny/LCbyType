//Leetcode 3026. Maximum Good Subarray Sum med
//题意：给定一个长度为n的数组nums和一个正整数k。
//如果一个数组的子数组的第一个元素和最后一个元素的绝对差恰好为k，则称该子数组为好子数组，即|nums[i] - nums[j]| == k。
//要求返回nums中好子数组的最大和。如果没有好子数组，则返回0。
//思路：hashtable, Dictionary找出所有的数字对应的位置；
//然后再算一个每个位置的前缀和；
//然后找出nums[i]-nums[j]==k 或者 nums[j]-nums[i] = k 然后找出最大的值；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public long MaximumSubarraySum(int[] nums, int k)
        {
            Dictionary<int, long> map = new Dictionary<int, long>();
            int n = nums.Length;
            long[] sum = new long[n];
            map.Add(nums[0], (long)0);
            sum[0] = nums[0];
            long ans = Int64.MinValue;
            for (int i = 1; i < nums.Length; i++)
            {
                sum[i] = sum[i - 1] + (long)(nums[i]);
                if (map.ContainsKey(nums[i])) 
                    map[nums[i]] = Math.Min(sum[i - 1], map[nums[i]]);
                else 
                    map.Add(nums[i], sum[i - 1]);
                int num1 = nums[i] + k;
                int num2 = nums[i] - k;

                if (map.ContainsKey(num1)) 
                    ans = Math.Max(sum[i] - map[num1], ans);
                if (map.ContainsKey(num2)) 
                    ans = Math.Max(sum[i] - map[num2], ans);
            }

            if (ans == Int64.MinValue) 
                return 0;
            return ans;
        }
        public long MaximumSubarraySum超时(int[] nums, int k)
        {
            long res = Int64.MinValue;
            Dictionary<long, List<long>> map = new Dictionary<long, List<long>>();
            long[] sum = new long[nums.Length];

            long currSum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum[i] = currSum;
                currSum += nums[i];

                if (map.ContainsKey(nums[i]))
                    map[nums[i]].Add(i);
                else
                    map[nums[i]] = new List<long>() { i };
            }

            for (int i = 0; i < nums.Length; i++)
            {
                long diff = nums[i] - k;
                if (map.ContainsKey(diff))
                {
                    foreach (int j in map[diff])
                    {
                        if (j < i)
                        {
                            res = Math.Max(res, sum[i] - sum[j] + nums[i]);
                        }
                    }
                }
                diff = nums[i] + k;
                if (map.ContainsKey(diff))
                {
                    foreach (int j in map[diff])
                    {
                        if (j < i)
                        {
                            res = Math.Max(res, sum[i] - sum[j] + nums[i]);
                        }
                    }
                }
            }

            if (res == Int64.MinValue)
                res = 0;

            return res;
        }