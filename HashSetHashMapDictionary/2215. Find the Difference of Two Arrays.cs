//Leetcode 2215. Find the Difference of Two Arrays ez
//题意：给定两个整数数组 nums1 和 nums2，返回一个大小为2的列表 answer，其中：
//answer[0] 是 nums1 中与 nums2 不同的所有整数列表。
//answer[1] 是 nums2 中与 nums1 不同的所有整数列表。
//注意：返回的列表中的整数可以以任意顺序返回。
//思路：hashtable 用两个list来存nums1 中与 nums2 不同的所有整数列表，nums2 中与 nums1 不同的所有整数列表
//时间复杂度：O(n*m)
//空间复杂度：O(n+m)
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            IList<int> distinctNums1 = new List<int>();
            IList<int> distinctNums2 = new List<int>();
            foreach (int i in nums1)
            {
                if (Array.IndexOf(nums2, i) == -1 && !distinctNums1.Contains(i))
                {
                    distinctNums1.Add(i);
                }
            }
            foreach (int i in nums2)
            {
                if (Array.IndexOf(nums1, i) == -1 && !distinctNums2.Contains(i))
                {
                    distinctNums2.Add(i);
                }
            }
            IList<IList<int>> result = new List<IList<int>>();
            result.Add(distinctNums1);
            result.Add(distinctNums2);
            return result;
        }