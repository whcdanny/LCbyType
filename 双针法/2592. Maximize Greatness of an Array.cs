//Leetcode 2592. Maximize Greatness of an Array med
//题意：给定一个整数数组 nums（下标从 0 开始）。允许对 nums 进行重新排列得到一个新数组 perm。
//定义 nums 的“伟大程度（greatness）”为满足条件 perm[i] > nums[i] 的索引数量，其中 0 <= i<nums.length。
//要求返回在重新排列 nums 后，可能达到的最大伟大程度。
//思路：左右针，先排序，然后i和j从头开始，只要找到nums[j] > nums[i]，i++，无论结果怎么样j++，这样就可找到所有大于的，然后就是结果
//时间复杂度: O(nlogn)，其中 n 为数组长度
//空间复杂度：O(n)
        public int MaximizeGreatness(int[] nums)
        {
            var count = 0;
            Array.Sort(nums);
            for (int i = 0, j = 1; j < nums.Length; j++)
            {
                if (nums[j] > nums[i])
                {
                    count++;
                    i++;
                }
            }

            return count;
        }