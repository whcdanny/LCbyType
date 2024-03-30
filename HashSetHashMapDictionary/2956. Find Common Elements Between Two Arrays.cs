//Leetcode 2956. Find Common Elements Between Two Arrays ez
//题意：要求找到两个数组中共同出现的元素个数
//思路：hashtable，用两个hashset分别存入nums1和nums2的不重复的数，
//nums1 中在 nums2 中出现的元素个数，nums2 中在 nums1 中出现的元素个数          
//时间复杂度：O(n+m)
//空间复杂度：O(n+m)
        public int[] FindIntersectionValues(int[] nums1, int[] nums2)
        {
            HashSet<int> set1 = new HashSet<int>(nums1);
            HashSet<int> set2 = new HashSet<int>(nums2);
            int count1 = 0;
            int count2 = 0;

            // 统计 nums1 中在 nums2 中出现的元素个数
            foreach (int num in nums1)
            {
                if (set2.Contains(num))
                {
                    count1++;
                }
            }
            // 统计 nums2 中在 nums1 中出现的元素个数
            foreach (int num in nums2)
            {
                if (set1.Contains(num))
                {
                    count2++;
                }
            }

            return new int[] { count1, count2 };
        }