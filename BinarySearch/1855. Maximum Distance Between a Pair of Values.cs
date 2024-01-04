//Leetcode 1855. Maximum Distance Between a Pair of Values med
//题意：题目要求在两个非递增的数组 nums1 和 nums2 中找到满足条件 nums1[i] <= nums2[j] 的最大距离 j - i。如果没有满足条件的情况，则返回0。
//思路：用二分法定义，初始化最大距离为0： 首先，将最大距离 maxDistance 初始化为0。
//遍历 nums1 中的每个元素： 对于 nums1 中的每个元素 num1，我们需要在 nums2 中找到满足条件的最大下标 j，即 num1 <= nums2[j]。为此，我们可以使用二分搜索。
//二分搜索查找最大下标： 对于 num1，在 nums2 中使用二分搜索找到最大的下标 j，使得 num1 <= nums2[j]。如果找到了满足条件的 j，计算距离 j - i 并更新最大距离。        
//时间复杂度: O(m log n)，其中 m 是 nums1 的长度，n 是 nums2 的长度
//空间复杂度：O(1)
        public int MaxDistance(int[] nums1, int[] nums2)
        {
            var maxDistance = 0;

            for (int i = 0; i < nums1.Length; ++i)
            {
                maxDistance = Math.Max(maxDistance, FindInsertPosition(nums2, i, nums1[i]));
            }

            return maxDistance;
        }

        int FindInsertPosition(int[] nums, int index, int value)
        {
            var left = index;
            var right = nums.Length - 1;

            while (left < right)
            {
                var mid = left + (right - left + 1) / 2;
                if (nums[mid] < value)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid;
                }
            }

            return left - index;
        }