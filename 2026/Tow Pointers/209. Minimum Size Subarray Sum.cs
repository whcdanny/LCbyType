//Leetcode 209. Minimum Size Subarray Sum med
//题意：有一个int[] nums找出和>=target中最小的个数
//思路：双针法，right针历遍，然后当前tempsun>=target，然后移动left，直到不满足条件。
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public int MinSubArrayLen(int target, int[] nums)
        {
            int left = 0;
            int res = Int32.MaxValue;
            int tempSum = 0;
            for(int right = 0; right < nums.Length; right++)
            {
                tempSum += nums[right];
                while (tempSum >= target)
                {                   
                    res = Math.Min(res, right - left + 1);
                    tempSum -= nums[left];
                    left++;
                }                
            }
            return res == Int32.MaxValue ? 0 : res;
        }