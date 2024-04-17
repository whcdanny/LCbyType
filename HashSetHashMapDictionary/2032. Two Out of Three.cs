//Leetcode 2032. Two Out of Three ez
//题意：给定三个整数数组 nums1、nums2 和 nums3，返回一个包含至少在这三个数组中的两个数组中出现的所有值的不同数组。你可以以任意顺序返回这些值。
//思路：hashtable 三个哈希集（HashSet）分别存储 nums1、nums2 和 nums3 中的元素。
//然后遍历其中任意两个哈希集，将它们的交集加入一个结果集中。
//最后返回结果集作为答案。
//时间复杂度：O(n)，其中 n 分别是 nums1、nums2 和 nums3 的长度。 O(n1 + n2)，其中 n1 和 n2 分别是两个哈希集的大小。
//空间复杂度：O(m1 + m2 + m3)，其中 m1、m2 和 m3 分别是 nums1、nums2 和 nums3 中的不同元素数量
        public IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3)
        {
            HashSet<int> set1 = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>(nums2);
            HashSet<int> set3 = new HashSet<int>(nums3);
            HashSet<int> result = new HashSet<int>();

            AddIntersection(set1, set2, result);
            AddIntersection(set1, set3, result);
            AddIntersection(set2, set3, result);

            return result.ToList();
        }
        private void AddIntersection(HashSet<int> set1, HashSet<int> set2, HashSet<int> result)
        {
            foreach (var num in set1)
            {
                if (set2.Contains(num))
                {
                    result.Add(num);
                }
            }
        }