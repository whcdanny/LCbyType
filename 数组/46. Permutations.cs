//46. Permutations med
//给一个无重复的数组，给出不重复的排列组合
//回溯算法： 记录「路径」，添加不存在的数字，直到最后，然后再把刚添加的移除，去寻找新的分支；
		List<IList<int>> resPermute = new List<IList<int>>();
        public IList<IList<int>> Permute(int[] nums)
        {
            // 记录「路径」
            List<int> track = new List<int>();
            // 「路径」中的元素会被标记为 true，避免重复使用
            bool[] used = new bool[nums.Length + 1];           
            backtrack(nums, track, used);
            return resPermute;
        }
        // 路径：记录在 track 中
        // 选择列表：nums 中不存在于 track 的那些元素（used[i] 为 false）
        // 结束条件：nums 中的元素全都在 track 中出现
        private void backtrack(int[] nums, List<int> track, bool[] used)
        {
            // 排除不合法的选择
            if (track.Count == nums.Length)
            {
                // nums[i] 已经在 track 中，跳过
                resPermute.Add(new List<int>(track));
                return;
            }

            for(int i = 0; i < nums.Length; i++)
            {
                if (used[i])
                    continue;
                // 做选择
                track.Add(nums[i]);
                used[i] = true;
                // 进入下一层决策树
                backtrack(nums, track, used);
                // 取消选择
                track.Remove(nums[i]);
                used[i] = false;
            }
        }