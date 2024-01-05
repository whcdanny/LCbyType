//Leetcode  1818. Minimum Absolute Sum Difference med
//题意：题目要求在两个正整数数组 nums1 和 nums2 之间，最多替换一个元素，使得两个数组的绝对差之和最小。绝对差之和的计算方式是对于每个下标 i，计算 |nums1[i] - nums2[i]|，并求和。
//思路：用二分法：计算原始的绝对差之和，然后计算替换一个元素后的新的差值。如果新的差值大于之前的差值，就更新绝对差之和.
//排序数组，然后在每次迭代中计算替换一个元素后的绝对差之和，并记录最大的差值。这样可以保证每次替换都是在最大差值的位置进行的，从而最小化总的绝对差之和。
//时间复杂度: O(n log n)
//空间复杂度：O(n)
        public int MinAbsoluteSumDiff(int[] nums1, int[] nums2)
        {
            int n = nums1.Length, modulo = 1000000007;
            if (n == 1) 
                return Math.Abs(nums1[0] - nums2[0]);
            
            int[] nums = new int[n];
            Array.Copy(nums1, nums, n);
            Array.Sort(nums);
            int diff = 0, sum = 0;
            // Count the sum with update for max difference
            for (int i = 0; i < n; i++)
            {
                sum = AddSumInModulo(sum, Math.Abs(nums1[i] - nums2[i]), modulo);
                // Calculate the new difference and correct the sum if needed
                int new_diff = CalcDiff(nums1[i], nums2[i], nums, Math.Abs(nums1[i] - nums2[i]));
                if (new_diff > diff)
                {
                    sum = AddSumInModulo(sum, -new_diff + diff, modulo);
                    diff = new_diff;
                }
            }
            return sum;
        }
        //函数用于计算带有模的加法
        public int AddSumInModulo(int sum, int add, int modulo)
        {
            return (sum + add) % modulo;
        }
        //二分搜索在排序后的数组中找到最接近 target 的元素，然后计算差异。如果在替换一个元素后，原始数组中的元素没有变化，则返回零。
        public int CalcDiff(int key, int target, int[] nums, int basediff)
        {
            // Using binary search
            int left = 0, right = nums.Length - 1;
            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > target) right = mid;
                else left = mid;
            }
            // Final check for l&r, if we do not need to move element for minimum difference - we return zero as a result
            if (Math.Abs(nums[left] - target) > Math.Abs(nums[right] - target)) left = right;
            if (nums[left] == key) return 0;

            return basediff - Math.Abs(nums[left] - target);
        }