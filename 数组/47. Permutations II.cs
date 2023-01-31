//47. Permutations II med
//给你输入一个可包含重复数字的序列 nums，请你写一个算法，返回所有可能的全排列长度和nums一样
//回溯算法：先排序，然后建立一个boollist去检查是否用过，因为这个nums数组为重复，也就是有可能会出现重复subres；
//所以要用一个prevNum来存储上一次回溯时添加的数；
		public IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();           
            Array.Sort(nums);
            List<int> subRes = new List<int>();
            bool[] used = new bool[nums.Length + 1];
            SPermuteUniqueRecruion(res, nums, subRes, used);
            return res;
        }
        private void SPermuteUniqueRecruion(List<IList<int>> res, int[] nums, List<int> subRes, bool[] used)
        {
            if (subRes.Count == nums.Length)
            {
                res.Add(new List<int>(subRes));
                return;
            }
            // 题目说 -10 <= nums[i] <= 10，所以初始化为特殊值
            int prevNum = -666;
            for (int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                {
                    continue;
                }
                if (nums[i] == prevNum)
                {
                    continue;
                }
                // 做选择
                subRes.Add(nums[i]);
                used[i] = true;
                // 记录这条树枝上的值
                prevNum = nums[i];
                // 通过 start 参数控制树枝的遍历，避免产生重复的子集
                SPermuteUniqueRecruion(res, nums, subRes, used);
                // 撤销选择
                subRes.RemoveAt(subRes.Count - 1);
                used[i] = false;
            }
        }        