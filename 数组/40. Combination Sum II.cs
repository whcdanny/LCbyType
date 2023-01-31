//40. Combination Sum II med
//给你输入 candidates 和一个目标和 target，从 candidates 中找出中所有和为 target 的组合。
//回溯算法/DFS： 先将数组排序，然后根据target==0来觉得是否存入这个子集；
//然后不能有重复类似90，然后添加数字，target-数字 然后直到回溯完成；
		public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            var result = new List<IList<int>>();
            if (candidates.Length == 0) return result;
            Array.Sort(candidates);
            CombinationSum2Recruion(candidates, target, 0, new List<int>(), result);
            return result;
        }

        private void CombinationSum2Recruion(int[] candidates, int target, int start, IList<int> oneResult, IList<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(oneResult));
            }
            else if (target > 0)
            {
                for (int i = start; i < candidates.Length; i++)
                {
                    if (i > start && candidates[i - 1] == candidates[i]) continue;
                    oneResult.Add(candidates[i]);
                    CombinationSum2Recruion(candidates, target - candidates[i], i + 1, oneResult, result);
                    oneResult.RemoveAt(oneResult.Count - 1);
                }
            }
        }