//90. Subsets II
//给你一个整数数组 nums，其中可能包含重复元素，请你返回该数组所有可能的子集。
//思路：回溯算法： 类似78subset，只不过如果相邻的两个值相同跳过，
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
                if (i>start && nums[i] == nums[i - 1])
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