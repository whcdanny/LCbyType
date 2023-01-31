//39. Combination Sum med
//给你一个无重复元素的整数数组 candidates 和一个目标和 target，找出 candidates 中可以使数字和为目标数 target 的所有组合。candidates 中的每个数字可以无限制重复被选取。
//回溯算法：唯一不同时数组里的数字可以重复使用，那么start就是数组的位置，可以一直是一个直到不满足target条件；
		public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            List<int> combination = new List<int>();
            Array.Sort(candidates);
            CombinationSumRecruion(result, candidates, combination, target, 0);
            return result;
        }

        private void CombinationSumRecruion(IList<IList<int>> result, int[] candidates, IList<int> combination, int target, int start)
        {
            if (target == 0)
            {
                result.Add(new List<int>(combination));
                return;
            }
            //更一步优化target
            for (int i = start; i != candidates.Length && target >= candidates[i]; ++i)
            {
                combination.Add(candidates[i]);
				// 同一元素可重复使用，注意参数
                CombinationSumRecruion(result, candidates, combination, target - candidates[i], i);//这里start不是i+1；
                combination.Remove(combination.Last());
            }
        }