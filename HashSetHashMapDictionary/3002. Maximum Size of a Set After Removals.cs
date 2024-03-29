//Leetcode 3002. Maximum Size of a Set After Removals med
//题意：给定两个长度为偶数的整数数组nums1和nums2。
//需要从nums1和nums2中各删除n / 2个元素。删除元素后，将nums1和nums2中剩余的元素插入到一个集合s中。
//思路：hashtable, 用hashset存nums1和nums2每个不同元素，然后算出个数，
//再找到相同有的数，
//Math.Min(nums1Count + nums2Count - intersectionCount, Math.Min(n / 2, nums1Count) + Math.Min(n / 2, nums2Count))
//找的是留下的不同字母个数
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaximumSetSize(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;

            HashSet<int> hashsetNums1 = new HashSet<int>(nums1);
            HashSet<int> hashsetNums2 = new HashSet<int>(nums2);

            int nums1Count = hashsetNums1.Count, nums2Count = hashsetNums2.Count;

            hashsetNums1.IntersectWith(hashsetNums2);
            int intersectionCount = hashsetNums1.Count;

            return Math.Min(nums1Count + nums2Count - intersectionCount, Math.Min(n / 2, nums1Count) + Math.Min(n / 2, nums2Count));
        }