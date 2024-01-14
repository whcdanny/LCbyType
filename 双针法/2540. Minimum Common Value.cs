//Leetcode 2540. Minimum Common Value ez
//题意：给定两个非递减排序的整数数组 nums1 和 nums2，返回两个数组中的最小公共整数。如果 nums1 和 nums2 中没有公共整数，则返回 -1。
//注意：整数 x 被称为 nums1 和 nums2 的公共整数，如果两个数组中都至少有一个 x 的出现。
//思路：左右针，两个指针 i 和 j 分别指向数组 nums1 和 nums2 的开头。
//在循环中，比较 nums1[i] 和 nums2[j] 的值：
//如果二者相等，说明找到了最小公共整数，返回该值。
//如果 nums1[i] 小于 nums2[j]，则将 i 右移。
//如果 nums1[i] 大于 nums2[j]，则将 j 右移。
//时间复杂度: O(m + n)，其中 m 和 n 分别为数组 nums1 和 nums2 的长度
//空间复杂度：O(1)
        public int GetCommon(int[] nums1, int[] nums2)
        {
            int i = 0, j = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    return nums1[i];
                }
                else if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return -1;
        }