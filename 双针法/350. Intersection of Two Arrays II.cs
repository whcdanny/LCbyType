//Leetcode 350. Intersection of Two Arrays II ez
//题意：求两个数组的交集的问题。给定两个数组 nums1 和 nums2，返回它们的交集。
//思路：双指针，两个数组进行排序。
//使用两个指针 i 和 j 分别指向数组 nums1 和 nums2。
//在循环中，比较 nums1[i] 和 nums2[j] 的值：
//如果相等，说明找到一个相同元素，将其加入结果集，并将 i 和 j 分别移动到下一个位置。
//如果 nums1[i] < nums2[j]，说明 nums1[i] 小，将 i 移动到下一个位置。
//如果 nums1[i] > nums2[j]，说明 nums2[j] 小，将 j 移动到下一个位置。
//循环直到其中一个数组遍历完。
//时间复杂度：两个数组进行排序的时间复杂度为 O(nlogn)，其中 n 是数组的长度.然后在排序后的数组上进行双指针操作，时间复杂度为 O(n)，所以总的时间复杂度是 O(nlogn)。
//空间复杂度：O(min(n, m))，其中 n 和 m 分别是两个数组的长度
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            List<int> result = new List<int>();
            int i = 0;
            int j = 0;

            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    result.Add(nums1[i]);
                    i++;
                    j++;
                }
                else if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }

            return result.ToArray();
        }