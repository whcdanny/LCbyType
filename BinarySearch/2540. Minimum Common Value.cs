//Leetcode 2540. Minimum Common Value ez
//题意：给定两个非递减排序的整数数组 nums1 和 nums2。要求返回两个数组中的最小公共整数。如果 nums1 和 nums2 中没有公共整数，则返回 -1。
//思路：二分搜索, 只要在第二个nums2中找到num1的当前value，输出；      
//时间复杂度:  O(nlogm) O(min(N, M))，其中 N 和 M 分别是 nums1 和 nums2 的长度
//空间复杂度： O(1)
        public int GetCommon(int[] nums1, int[] nums2)
        {
            foreach (var n in nums1)
            {
                if (Array.BinarySearch(nums2, n) >= 0)
                {
                    return n;
                }
            }
            return -1;
        }
        //思路：由于两个数组是非递减排序的，可以使用两个指针 i 和 j 分别指向 nums1 和 nums2 的开头。
        //遍历两个数组，比较当前指针位置的元素，如果相等，则返回该元素为最小公共整数。
        //时间复杂度: O(min(N, M))，其中 N 和 M 分别是 nums1 和 nums2 的长度
        //空间复杂度： O(1)
        public int GetCommon1(int[] nums1, int[] nums2)
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