//Leetcode 2040. Kth Smallest Product of Two Sorted Array hard
//题意：给定两个已排序的整数数组 nums1 和 nums2，以及一个整数 k，返回两数组中所有可能的乘积 nums1[i] * nums2[j] 中第 k 小的值（从 1 开始计数）。
//思路：二分搜索, 计算有多少对乘积小于或等于m。如果这个数目小于k，那么说明m肯定不是答案，并且易知k太小，所以应该尝试更大的数（即lower = m+1）。
//如果count大于等于k，说明m可能是答案（因为允许有若干对成绩都等于m）或者m可能猜大了，所以接下来尝试更小的数（即upper = m）。利用二分搜值的模板，直至收敛到left==right，就是最终的解。
//双指针的单调性来实现o(n)的countSmallerOrEqual(m)
//m>=0
//(i) nums1[i]>0： 我们有 nums2[j] <= m/nums1[i]。可以知道nums2[j] 有个上界，且随着nums1[i] 的增大，这个上界越来越小。所以我们从大到小单调地移动j，找到与i对应的临界位置j，那么[0:j] 都是合法的解。
//(ii) nums1[i]==0： 所有的nums2都是解。
//(iii) nums1[i]<0： 我们有 nums2[j] >= m/nums1[i]。可以知道nums2[j] 有个下界，且随着nums1[i] 的增大，这个下界越来越小。所以我们从大到小单调地移动j，找到与i对应的临界位置j，那么[j:n - 1] 都是合法的解。
//m<0
//(i) nums[i]>0： 我们有 nums2[j] <= m/nums1[i]。可以知道nums2[j] 有个上界，且随着nums1[i] 的增大，这个上界越来越大。所以我们从小到大单调地移动j，找到与i对应的临界位置j，那么[0:j] 都是合法的解。
//(ii) nums[i]==0： 所有的nums2都不会是解 （因为不可能 0*nums[j] < m）。
//(iii) nums[i]<0： 我们有 nums2[j] >= m/nums1[i]。可以知道nums2[j] 有个下界，且随着nums1[i] 的增大，这个下界越来越大。所以我们从小到大单调地移动j，找到与i对应的临界位置j，那么[j:n - 1] 都是合法的解。
//时间复杂度: O(n * log(n))
//空间复杂度：O(1)               
        public long KthSmallestProduct(int[] nums1, int[] nums2, long k)
        {
            if (nums1.Length > nums2.Length)
                return KthSmallestProduct(nums2, nums1, k);
            long left = -10000000000L;
            long right = 10000000000L;
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                if(checkNums_KthSmallestProduct(mid, nums1, nums2) >= k)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        private long checkNums_KthSmallestProduct(long mid, int[] nums1, int[] nums2)
        {
            long res = 0;
            if (mid >= 0)
            {
                int j0 = nums2.Length - 1;
                int j1 = nums2.Length - 1;
                for (int i = 0; i < nums1.Length; i++)
                {
                    if (nums1[i] > 0)
                    {
                        while (j0 >= 0 && (long)nums1[i] * (long)nums2[j0] > mid)
                        {
                            j0--;
                        }
                        res += j0 + 1;
                    }
                    else if (nums1[i] == 0)
                    {
                        res += nums2.Length;
                    }
                    else
                    {
                        while (j1 >= 0 && (long)nums1[i] * (long)nums2[j1] <= mid)
                        {
                            j1--;
                        }
                        res += nums2.Length - 1 - j1;
                    }
                }
            }
            else
            {
                int j0 = 0;
                int j1 = 0;
                for (int i = 0; i < nums1.Length; i++)
                {
                    if (nums1[i] > 0)
                    {
                        while (j0 < nums2.Length && (long)nums1[i] * (long)nums2[j0] <= mid)
                        {
                            j0++;
                        }
                        res += j0;
                    }
                    else if (nums1[i] == 0)
                    {
                        res += 0;
                    }
                    else
                    {
                        while (j1 < nums2.Length && (long)nums1[i] * (long)nums2[j1] > mid)
                        {
                            j1++;
                        }
                        res += nums2.Length - j1;
                    }
                }
            }            
            return res;
        }
		
		public long KthSmallestProduct1(int[] nums1, int[] nums2, long k)
        {
            if (nums1.Length > nums2.Length)
                return KthSmallestProduct1(nums2, nums1, k);
            long left = -10000000000L;
            long right = 10000000000L;
            while (left < right)
            {
                long mid = left + (right - left) / 2;
                if (checkNums_KthSmallestProduct1(mid, nums1, nums2) >= k)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        private long checkNums_KthSmallestProduct1(long mid, int[] nums1, int[] nums2)
        {
            long res = 0;
            for (int i = 0; i < nums1.Length; i++)
            {
                long x = nums1[i];
                if (x == 0)
                {
                    if (mid < 0)
                        res += 0;
                    else
                        res += nums2.Length;
                }
                else if (x > 0)
                {
                    long yy = (long)Math.Floor(mid * 1.0 / x);
                    int index = upperBound_KthSmallestProduct1(nums2, yy);
                    res += index;
                }
                else
                {
                    long yy = (long)Math.Ceiling(mid * 1.0 / x);
                    int index = lowerBound_KthSmallestProduct1(nums2, yy);
                    res += nums2.Length - index;
                }
            }
            return res;
        }
        private int upperBound_KthSmallestProduct1(int[] list, long val)
        {
            int l = 0, r = list.Length;
            while (l < r)
            {
                int m = (l + r) / 2;
                if ((long)list[m] <= val)
                    l = m + 1;
                else
                    r = m;
            }
            return l;
        }
        //lower_bound函数用于查找在有序容器中第一个大于或等于给定值的元素的位置。
        private int lowerBound_KthSmallestProduct1(int[] list, long val)
        {
            int l = 0, r = list.Length;
            while (l < r)
            {
                int m = (l + r) / 2;
                if ((long)list[m] < val)
                    l = m + 1;
                else
                    r = m;
            }
            return l;
        }