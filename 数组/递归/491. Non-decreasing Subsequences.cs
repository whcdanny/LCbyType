//Leetcode 491. Non-decreasing Subsequences med
//题意：给定一个整数数组 nums，返回所有可能的非递减子序列，
//这些子序列的长度至少为 2。可以按任意顺序返回结果。
//思路：递归 + 回溯方法，
//从第一个开始，然后记录每一个path
//去重处理：每次递归时，使用一个集合used 跟踪在当前层级中已经使用过的数字，避免重复选择。
//对于每个数字，尝试加入路径，如果满足条件，继续递归。
//如果路径长度大于等于 2，将路径加入结果集合中。
//时间复杂度: O(n*2^n)最坏，每个数字被选择或不选择O(2^n),
//空间复杂度：O(2^n)
        public IList<IList<int>> FindSubsequences(int[] nums)
        {
            var res = new List<IList<int>>();
            backTrackFindSubsequences(0, nums, new List<int>(), res);
            return (res);
        }

        private void backTrackFindSubsequences(int index, int[] nums, List<int> list, List<IList<int>> res)
        {
            if (list.Count >= 2)
                res.Add(new List<int>(list));

            var used = new HashSet<int>();
            for(int i = index; i < nums.Length; i++)
            {
                if((list.Count > 0 && nums[i] < list.Last()) || used.Contains(nums[i]))
                {
                    continue;
                }
                used.Add(nums[i]);
                list.Add(nums[i]);
                backTrackFindSubsequences(i + 1, nums, list, res);
                list.RemoveAt(list.Count - 1);
            }
        }