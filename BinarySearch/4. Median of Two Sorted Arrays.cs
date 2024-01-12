//Leetcode 4. Median of Two Sorted Arrays hard
//题意：给定两个已排序的数组 nums1 和 nums2，长度分别为 m 和 n。请找出这两个已排序数组的中位数。
//思路：二分搜索法:组分为两个长度相等的部分，且左侧部分的元素都小于右侧部分的元素。为了找到中位数，可以通过二分搜索的方式来确定分割线。
//确定两个数组中较短的那个数组，作为 nums1。
//使用二分搜索在 nums1 中找到一个分割线 i，使得满足以下两个条件：
//i 的左侧部分的元素个数等于 nums1 和 nums2 中元素的总个数的一半（即 i + j = (m + n + 1) / 2，其中 j = (m + n + 1) / 2 - i）。
//nums1[i - 1] <= nums2[j] 且 nums2[j - 1] <= nums1[i]。
//根据分割线 i，计算中位数。
//时间复杂度：O(log(min(m, n))) - 二分搜索的时间复杂度。
//空间复杂度：O(1)
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                // 保证 nums1 是较短的数组
                int[] temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }

            int m = nums1.Length;
            int n = nums2.Length;

            int left = 0, right = m;
            int halfLen = (m + n + 1) / 2;

            while (left <= right)
            {
                int i = left + (right - left) / 2;
                int j = halfLen - i;

                if (i < m && nums2[j - 1] > nums1[i])
                {
                    // i 太小，增加 i
                    left = i + 1;
                }
                else if (i > 0 && nums1[i - 1] > nums2[j])
                {
                    // i 太大，减小 i
                    right = i - 1;
                }
                else
                {
                    // i 符合条件
                    int maxLeft;
                    if (i == 0)
                    {
                        maxLeft = nums2[j - 1];
                    }
                    else if (j == 0)
                    {
                        maxLeft = nums1[i - 1];
                    }
                    else
                    {
                        maxLeft = Math.Max(nums1[i - 1], nums2[j - 1]);
                    }

                    if ((m + n) % 2 == 1)
                    {
                        // 如果总长度为奇数
                        return maxLeft;
                    }

                    int minRight;
                    if (i == m)
                    {
                        minRight = nums2[j];
                    }
                    else if (j == n)
                    {
                        minRight = nums1[i];
                    }
                    else
                    {
                        minRight = Math.Min(nums1[i], nums2[j]);
                    }

                    // 如果总长度为偶数
                    return (maxLeft + minRight) / 2.0;
                }
            }

            return 0.0;
        }