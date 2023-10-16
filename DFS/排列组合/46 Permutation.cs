//Leetcode 46 Permutation  med
//题意：给定一个不包含重复数字的数组，返回所有可能的全排
//思路：深度优先搜索（DFS）: 对于给定的不包含重复数字的数组，我们可以将其看作一个有向无环图（DAG），其中每个节点代表一个数字，从根节点开始，不断地向下延伸，将当前数字添加到当前排列中，形成新的排列。从根节点开始，依次向下延伸，将当前数字添加到当前排列中，然后递归调用寻找下一个节点。
//时间复杂度: 数组长度为 n, O(n * n!)
//空间复杂度： 深度可能达到 n, O(n)
        public IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> result = new List<IList<int>>();
            Permute_DFS(nums, new List<int>(), result);
            return result;
        }

        private void Permute_DFS(int[] nums, List<int> permutation, List<IList<int>> result)
        {
            if (permutation.Count == nums.Length)
            {
                result.Add(new List<int>(permutation));
                return;
            }

            foreach (int num in nums)
            {
                if (!permutation.Contains(num))
                {
                    permutation.Add(num);
                    Permute_DFS(nums, permutation, result);
                    permutation.RemoveAt(permutation.Count - 1);
                }
            }
        }