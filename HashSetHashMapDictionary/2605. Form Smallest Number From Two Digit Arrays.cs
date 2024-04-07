//Leetcode 2605. Form Smallest Number From Two Digit Arrays ez
//题意：给定两个唯一数字数组 nums1 和 nums2，返回至少包含来自每个数组的一个数字的最小数字。
//思路：hashtable, 用hashset存nums1的不同出现数字，先找出nums1的最小；
//然后再从nums2中找出最小，如果有相同最小，找出相同最小；
//最后有相同最小就输出相同最小数，如果不是就比较哪个小作为十位数然后剩下个位数；
//时间复杂度：O(max(n1,n2))
//空间复杂度：O(n1)
        public int MinNumber(int[] nums1, int[] nums2)
        {
            var set = new HashSet<int>(nums1);

            int min1 = int.MaxValue;
            int min2 = int.MaxValue;
            int singleMin = int.MaxValue;

            foreach (var num in nums1) 
            { 
                min1 = Math.Min(min1, num); 
            }
            foreach (var num in nums2)
            {
                if (set.Contains(num)) 
                    singleMin = Math.Min(singleMin, num);
                min2 = Math.Min(min2, num);
            }

            return singleMin != int.MaxValue ? singleMin : min2 > min1 ? min1 * 10 + min2 : min2 * 10 + min1;
        }