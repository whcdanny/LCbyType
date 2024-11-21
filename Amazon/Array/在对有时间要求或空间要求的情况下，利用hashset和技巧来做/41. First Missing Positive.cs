//Leetcode 41. First Missing Positive hard
//题意：给定一个未排序的整数数组 nums，返回数组中没有出现的最小正整数。
//要求：你必须实现时间复杂度为 O(n) 且只使用 O(1) 辅助空间的算法
//思路：用hashset来存不重复的nums，减少计算，然后找出没出现最小整数，
//那么最小整数是1，startValue=1，
//然后如果nums里出现1，然后从hashset中找startValue++，直到没有startValue
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int FirstMissingPositive(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            int startValue = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
                if (startValue == nums[i])
                {
                    while (set.Contains(startValue))
                    {
                        startValue++;
                    }
                }
            }
            return startValue;
        }