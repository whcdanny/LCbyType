//88. Merge Sorted Array ez
//题目要求将两个已排序的整数数组 nums1 和 nums2 合并为一个排序的数组，并将结果存储在 nums1 中
//思路：三个指针分别指向 nums1 的末尾、nums2 的末尾和合并后的数组的末尾；
        public void Merge(int[] nums1, int m, int[] nums2, int n)
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
        public void Merge1(int[] nums1, int m, int[] nums2, int n)
        {
            int i = m - 1, j = n - 1, k = m + n - 1;
            while (j >= 0)
            {
                if (i >= 0)
                {
                    nums1[k--] = nums1[i] > nums2[j] ? nums1[i--] : nums2[j--];
                }
                else
                {
                    nums1[k--] = nums2[j--];
                }
            }
        }