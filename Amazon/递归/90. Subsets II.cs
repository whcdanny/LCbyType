//Leetcode 90. Subsets II med
//题意：nums给定一个可能包含重复项的整数数组，返回所有可能的子集（幂集）。
//解决方案集不得包含重复的子集。以任意顺序返回解决方案。
//思路：递归，回溯算法核心函数，遍历子集问题的回溯树
// 前序位置，每个节点的值都是一个子集
// 回溯算法标准框架
// 做选择
// 剪枝逻辑，值相同的相邻树枝，只遍历第一条
// 通过 start 参数控制树枝的遍历，避免产生重复的子集
// 撤销选择
//时间复杂度:  n 是字符串的长, O(n*2^n)
//空间复杂度： O(26) = O(1)
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0)
            {
                return res;
            }

            List<int> subRes = new List<int>();

            SubsetsWithDupRecruion(res, nums, subRes, 0);

            return res;
        }
        // 回溯算法核心函数，遍历子集问题的回溯树
        private void SubsetsWithDupRecruion(List<IList<int>> res, int[] nums, List<int> subRes, int start)
        {
            // 前序位置，每个节点的值都是一个子集
            res.Add(new List<int>(subRes));
            // 回溯算法标准框架
            for (int i = start; i < nums.Length; i++)
            {
                // 剪枝逻辑，值相同的相邻树枝，只遍历第一条
                if (i > start && nums[i] == nums[i - 1])
                {
                    continue;
                }
                // 做选择
                subRes.Add(nums[i]);
                // 通过 start 参数控制树枝的遍历，避免产生重复的子集
                SubsetsWithDupRecruion(res, nums, subRes, i + 1);
                // 撤销选择
                subRes.RemoveAt(subRes.Count - 1);
            }
        }