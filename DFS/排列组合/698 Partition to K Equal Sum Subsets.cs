//Leetcode 698 Partition to K Equal Sum Subsets   med
//题意：给定一个正整数数组 nums 和一个正整数 k，要求判断能否将数组分割成 k 个相等的子集。
//思路：深度优先搜索（DFS）: 计算出目标子集的和 target，即 target = sum(nums) / k。将数组从大到小排序，以便在搜索过程中优先选择大的数字。使用递归DFS的方式，在每一步中，将当前数字尝试放入 k 个子集中的一个。在递归的过程中，进行剪枝。例如，如果当前子集的和已经大于 target，就无需继续尝试。当成功找到一个子集时，递归调用寻找下一个子集
//时间复杂度: 数组长度为 n，目标子集数量为 k, O(n * n!)
//空间复杂度： 深度可能达到 n, O(n)
        public bool CanPartitionKSubsets(int[] nums, int k)
        {
            int sum = nums.Sum();
            if (sum % k != 0) return false;
            int target = sum / k;
            Array.Sort(nums, (a, b) => b - a); // 从大到小排序
            bool[] visited = new bool[nums.Length];
            return CanPartitionKSubsets_DFS(nums, k, 0, 0, target, visited);
        }

        private bool CanPartitionKSubsets_DFS(int[] nums, int k, int startIndex, int currentSum, int target, bool[] visited)
        {
            if (k == 1) return true; // 找到了 k-1 个子集，最后一个子集自动满足条件
            if (currentSum == target) return CanPartitionKSubsets_DFS(nums, k - 1, 0, 0, target, visited);
            for (int i = startIndex; i < nums.Length; i++)
            {
                if (!visited[i] && currentSum + nums[i] <= target)
                {
                    visited[i] = true;
                    if (CanPartitionKSubsets_DFS(nums, k, i + 1, currentSum + nums[i], target, visited)) return true;
                    visited[i] = false;
                }
            }
            return false;
        }