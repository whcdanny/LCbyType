//Leetcode 39 Combination Sumr  med
//题意：给定一个候选数字的集合 candidates 和一个目标值 target，找出所有候选数字的组合，使得它们的和等于目标值。每个候选数字可以重复使用。
//思路：深度优先搜索（DFS）: 将候选数字排序，以便在搜索过程中剪枝。然后，从第一个候选数字开始，依次尝试将它添加到当前组合中，然后递归调用寻找下一个候选数字。在递归的过程中，需要传递当前的目标值减去已选数字之和 target - candidates[i]。
//时间复杂度:  候选数字的个数为 n, O(n^target)
//空间复杂度： O(target)
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(candidates);
            CombinationSum_DFS(candidates, target, 0, new List<int>(), result);
            return result;
        }

        private void CombinationSum_DFS(int[] candidates, int target, int start, List<int> combination, List<IList<int>> result)
        {
            if (target == 0)
            {
                result.Add(new List<int>(combination));
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (candidates[i] > target)
                {
                    break;
                }
                combination.Add(candidates[i]);
                CombinationSum_DFS(candidates, target - candidates[i], i, combination, result);
                combination.RemoveAt(combination.Count - 1);
            }
        }