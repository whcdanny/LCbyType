//Leetcode 2958. Length of Longest Subarray With at Most K Frequency med
//题意：给定一个整数数组 nums 和一个整数 k，要求找到数组中满足以下条件的最长子数组的长度：
//子数组中每个元素的出现次数不超过 k 次。
//思路：双指针，设置左右两个针，如果发现当前right针的数量>k，那么left针左移
//直到right针的数量不大于k，
//每次移动都要算一共当前长度，然后Math.Max(ans, right - left + 1)        
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaxSubarrayLength(int[] nums, int k)
        {
            int right = 0;
            int left = 0;
            int n = nums.Length;
            int ans = 1;
            Dictionary<int, int> map = new Dictionary<int, int>();

            while (right < n)
            {
                if (map.ContainsKey(nums[right]))
                    map[nums[right]]++;
                else
                    map[nums[right]] = 1;

                while (map[nums[right]] > k)
                {
                    map[nums[left]]--;
                    left++;
                }
                ans = Math.Max(ans, right - left + 1);
                right++;
            }
            return ans;
        }