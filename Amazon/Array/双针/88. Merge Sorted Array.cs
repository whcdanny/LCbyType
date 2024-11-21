//88. Merge Sorted Array ez
//题目要求将两个已排序的整数数组 nums1 和 nums2 合并为一个排序的数组，并将结果存储在 nums1 中
//思路：三个指针分别指向 nums1 的末尾、nums2 的末尾和合并后的数组的末尾
//然后从后往前比较nums1和nums2最后一个数nums1[p1] nums2[p2]，选取最大的放入nums1[p]
//然后如果p2有剩余全部加入nums1[p]
//时间复杂度：O(m + n)
//空间复杂度：O(m + n)
        public void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            int p1 = m - 1; // nums1 的末尾指针
            int p2 = n - 1; // nums2 的末尾指针
            int p = m + n - 1; // 合并后的数组的末尾指针

            while (p1 >= 0 && p2 >= 0)
            {
                if (nums1[p1] >= nums2[p2])
                {
                    nums1[p] = nums1[p1];
                    p1--;
                }
                else
                {
                    nums1[p] = nums2[p2];
                    p2--;
                }
                p--;
            }

            while (p2 >= 0)
            {
                nums1[p] = nums2[p2];
                p2--;
                p--;
            }
        }