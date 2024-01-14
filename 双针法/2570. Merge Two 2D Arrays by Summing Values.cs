//Leetcode 2570. Merge Two 2D Arrays by Summing Values ez
//题意：给定两个 2D 整数数组 nums1 和 nums2。
//nums1[i] = [idi, vali] 表示具有 id idi 的数字的值等于 vali。
//nums2[i] = [idi, vali] 表示具有 id idi 的数字的值等于 vali。
//每个数组都包含唯一的 id，并按 id 升序排序。
//将两个数组合并成一个数组，按 id 升序排序，满足以下条件：   
//结果数组中只包含出现在两个数组中至少一个数组中的 id。
//每个 id 应该只包含一次，并且其值应为两个数组中该 id 的值的和。如果 id 在其中一个数组中不存在，则在该数组中其值被认为是 0。
//返回结果数组。返回的数组必须按 id 升序排序。
//思路：左右针，指针 i 和 j，分别指向 nums1 和 nums2 的开头。
//遍历过程中，比较 nums1[i][0] 和 nums2[j][0] 的大小：
//如果 nums1[i][0] 小于 nums2[j][0]，则将 nums1[i] 添加到结果数组，并将 i 右移。
//如果 nums1[i][0] 大于 nums2[j][0]，则将 nums2[j] 添加到结果数组，并将 j 右移。
//如果 nums1[i][0] 等于 nums2[j][0]，则将两个数组中相同 id 的值相加，添加到结果数组，并将 i 和 j 都右移。
//时间复杂度: O(m + n)，其中 m 和 n 分别为数组 nums1 和 nums2 的长度
//空间复杂度：O(m + n)
        public int[][] MergeArrays(int[][] nums1, int[][] nums2)
        {
            int m = nums1.Length, n = nums2.Length;
            List<int[]> result = new List<int[]>();

            int i = 0, j = 0;

            while (i < m || j < n)
            {
                if (i < m && (j >= n || nums1[i][0] < nums2[j][0]))
                {
                    result.Add(nums1[i]);
                    i++;
                }
                else if (j < n && (i >= m || nums1[i][0] > nums2[j][0]))
                {
                    result.Add(nums2[j]);
                    j++;
                }
                else
                {
                    // 合并具有相同 id 的元素
                    result.Add(new int[] { nums1[i][0], nums1[i][1] + nums2[j][1] });
                    i++;
                    j++;
                }
            }

            return result.ToArray();
        }
