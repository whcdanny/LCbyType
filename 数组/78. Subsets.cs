//78. Subsets med		
//给一个数组，输出所有的子集 
//Input: nums = [1,2,3]
//Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]
//思路： 回溯算法，前序位置，每个节点的值都是一个子集，通过 start 参数控制树枝的遍历，避免产生重复的子集，
//每一次添加完成所有历遍后，将添加的数字删除掉
		//回溯
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (nums == null || nums.Length == 0)
            {
                return res;
            }

            List<int> subRes = new List<int>();

            Recruion(res, nums, subRes, 0);

            return res;
        }
        // 回溯算法核心函数，遍历子集问题的回溯树
        private void Recruion(List<IList<int>> res, int[] nums, List<int> subRes, int start)
        {
            // 前序位置，每个节点的值都是一个子集
            res.Add(new List<int>(subRes));
            // 回溯算法标准框架
            for (int i = start; i < nums.Length; i++)
            {
                // 做选择
                subRes.Add(nums[i]);
                // 通过 start 参数控制树枝的遍历，避免产生重复的子集
                Recruion(res, nums, subRes, i + 1);
                // 撤销选择
                subRes.RemoveAt(subRes.Count - 1);
            }
        }