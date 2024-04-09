//Leetcode 2461. Maximum Sum of Distinct Subarrays With Length K med
//题意：给定一个整数数组 nums 和一个整数 k，找到 nums 的所有满足以下条件的子数组的最大子数组和：
//子数组的长度为 k
//子数组中的所有元素都是不同的
//返回满足条件的所有子数组的最大子数组和。如果没有满足条件的子数组，则返回 0。
//思路：hashtable+滑动窗口, 一个k长度窗口，然后map统计当前每个数字出现的次数；
//如果map的大小==k，说明有不重复的num，找的最大的sum
//然后根据left的值，调整map
//时间复杂度：O(n)
//空间复杂度：O(n)
        public long MaximumSubarraySum_2475(int[] nums, int k)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            long sum = 0;
            long maxSum = 0;

            for (int right = 0, left = 0; right < nums.Length; right++)
            {
                //添加right
                if (map.TryGetValue(nums[right], out int value))
                    map[nums[right]] = ++value;
                else
                    map.Add(nums[right], 1);
               
                sum += nums[right];

                //window length == K
                if (right - left + 1 == k)
                {
                    //说明都是不同的数字；
                    if (map.Count == k)
                    {                        
                        maxSum = Math.Max(maxSum, sum);
                    }

                    //移除left的值从currentsum
                    sum -= nums[left];

                    //移除left从map中.
                    map[nums[left]]--;
                    if (map[nums[left]] == 0)
                        map.Remove(nums[left]);

                    left++;
                }
            }

            return maxSum;
        }