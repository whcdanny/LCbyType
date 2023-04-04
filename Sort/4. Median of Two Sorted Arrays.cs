//4. Median of Two Sorted Arrays hard 
        //给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。请找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))
        //思路：归并排序,先将两个合并，然后新的有序数组长度为偶数，则中位数为新数组中第 (n+m)/2 和 (n+m)/2-1 个元素的平均值，新的有序数组长度为奇数，则中位数为新数组中第 (n+m)/2 个元素；
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int m = nums1.Length, n = nums2.Length;
            int[] merged = new int[m + n];
            int i = 0, j = 0, k = 0;
            while (i < m && j < n)
            {
                if (nums1[i] < nums2[j])
                {
                    merged[k++] = nums1[i++];
                }
                else
                {
                    merged[k++] = nums2[j++];
                }
            }
            while (i < m)
            {
                merged[k++] = nums1[i++];
            }
            while (j < n)
            {
                merged[k++] = nums2[j++];
            }
            int mid = (m + n) / 2;
            if ((m + n) % 2 == 0)
            {
                return (merged[mid] + merged[mid - 1]) / 2.0;
            }
            else
            {
                return merged[mid];
            }
        }
		
	
		//二分法 不过有点难理解
		public double FindMedianSortedArrays1(int[] nums1, int[] nums2)
        {
            if (nums1.Length > nums2.Length)
            {
                int[] temp = nums1;
                nums1 = nums2;
                nums2 = temp;
            }
            int m = nums1.Length, n = nums2.Length;
            int left = 0, right = m, mid = (m + n + 1) / 2;
            while (left <= right)
            {
                int i = (left + right) / 2;
                int j = mid - i;
                if (i < right && nums2[j - 1] > nums1[i]) left = i + 1;
                else if (i > left && nums1[i - 1] > nums2[j]) right = i - 1;
                else
                {
                    int maxLeft = 0, minRight = 0;
                    if (i == 0) maxLeft = nums2[j - 1];
                    else if (j == 0) maxLeft = nums1[i - 1];
                    else maxLeft = Math.Max(nums1[i - 1], nums2[j - 1]);
                    if ((m + n) % 2 == 1) return maxLeft;
                    if (i == m) minRight = nums2[j];
                    else if (j == n) minRight = nums1[i];
                    else minRight = Math.Min(nums1[i], nums2[j]);
                    return (maxLeft + minRight) / 2.0;
                }
            }
            return 0.0;
        }