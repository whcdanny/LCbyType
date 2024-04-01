//Leetcode 2670. Find the Distinct Difference Array ez
//题意：给定一个长度为 n 的数组 nums，定义其不同差分数组 diff 为一个长度为 n 的数组，
//其中 diff[i] 表示 nums 的前缀子数组 nums[0, ..., i] 中不同元素的数量与后缀子数组 nums[i + 1, ..., n - 1] 中不同元素的数量之差。
//思路：hashtable, 一个hashset解决，先从后往前 算一遍每个位置的后置位不同数子的个数；
//然后再从前往后加上每一个位置的前置位不同数字的个数；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] DistinctDifferenceArray(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[n];
            HashSet<int> distinctElements = new HashSet<int>();

            distinctElements.Add(nums[n - 1]);
            for (int i = n - 2; i >= 0; i--)
            {
                result[i] = -distinctElements.Count;
                distinctElements.Add(nums[i]);
            }

            distinctElements.Clear();

            for (int i = 0; i <= n - 1; i++)
            {
                distinctElements.Add(nums[i]);
                result[i] += distinctElements.Count;
            }

            return result;
        }