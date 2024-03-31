//Leetcode 2799. Count Complete Subarrays in an Array med
//题意：给定一个由正整数组成的数组 nums，我们称数组的一个子数组为完整子数组，
//如果该子数组中不同元素的数量等于整个数组中不同元素的数量。现在要求计算完整子数组的数量。
//思路：hashtable + window 统计整个数组中不同元素的数量，可以使用 HashSet 来记录不同元素，这样可以快速判断一个元素是否已经存在于集合中。
//使用滑动窗口遍历数组，对于每个滑动窗口，统计其内部不同元素的数量，如果与整个数组中不同元素的数量相等，则该滑动窗口中的子数组是完整子数组。
//统计满足条件的滑动窗口的数量，并返回结果。
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public int CountCompleteSubarrays(int[] nums)
        {
            int n = nums.Length;
            HashSet<int> distinct = new HashSet<int>(nums);
            int distinctCount = distinct.Count;
            int result = 0;

            for (int i = 0; i < n; i++)
            {
                HashSet<int> window = new HashSet<int>();
                for (int j = i; j < n; j++)
                {
                    window.Add(nums[j]);
                    if (window.Count == distinctCount)
                    {
                        result++;
                    }
                }
            }

            return result;
        }