//Leetcode 78 Subsets  med
//题意：给定一个整数数组，要求返回该数组所有可能的子集，包括空集和本身。
//思路：深度优先搜索（DFS）: 对于给定的整数数组 nums，我们可以将其看作一个有向无环图（DAG），其中每个节点代表一个数字，从根节点（空集）开始，不断地向下延伸，将当前数字加入当前集合中，形成新的子集。从根节点开始，依次向下延伸，将当前数字加入当前集合中，然后递归调用寻找下一个节点。
//时间复杂度: 整数数组的长度为 n, O(n * 2^n)
//空间复杂度： 深度可能达到 n, O(n)
        public IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Subsets__DFS(nums, 0, new List<int>(), result);
            return result;
        }

        private void Subsets__DFS(int[] nums, int start, List<int> subset, List<IList<int>> result)
        {
            result.Add(new List<int>(subset));

            for (int i = start; i < nums.Length; i++)
            {
                subset.Add(nums[i]);
                Subsets__DFS(nums, i + 1, subset, result);
                subset.RemoveAt(subset.Count - 1);
            }
        }