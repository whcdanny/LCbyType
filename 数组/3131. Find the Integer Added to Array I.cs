//Leetcode 3131. Find the Integer Added to Array I ez
//题目：给定两个等长的数组 nums1 和 nums2，已知 nums1 中的每个元素都通过加上一个整数 x（或者在负数的情况下减去 x）来使得 nums1 变成 nums2。
//两个数组在包含相同元素并且这些元素的频率相同的情况下才视为相等。
//请返回整数 x。
//思路: 因为相当于找出总和差，然后除以nums1的长度
//因为整数x，result / nums1.Length;
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int AddedInteger(int[] nums1, int[] nums2)
        {
            var result = 0;
            for (var i = 0; i < nums2.Length; i++)
                result += nums2[i] - nums1[i];
            return result / nums1.Length;
        }