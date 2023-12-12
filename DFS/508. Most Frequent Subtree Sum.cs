//Leetcode 508. Most Frequent Subtree Sum med
//题意：给定一个二叉树，返回出现次数最多的子树和。如果有多个子树和出现次数相同，返回所有出现次数最多的子树和。子树和定义为该子树中所有节点的和。
//思路：（DFS）遍历二叉树，并计算每个子树的和。为了统计每个和的出现次数，我们可以使用一个哈希表。在遍历过程中，对于每个节点，我们计算以该节点为根的子树的和，然后更新哈希表。在遍历完成后，我们遍历哈希表，找到出现次数最多的和，然后收集所有具有最大出现次数的和。
//时间复杂度: O(n)，其中 n 为二叉树的节点数。
//空间复杂度：最坏情况下为 O(h)，其中 h 为二叉树的高度。哈希表用于存储每个子树和的出现次数，最坏情况下需要 O(n) 的额外空间。
        private Dictionary<int, int> sumCount_FindFrequentTreeSum = new Dictionary<int, int>();
        private int maxCount_FindFrequentTreeSum = 0;

        public int[] FindFrequentTreeSum(TreeNode root)
        {
            DFS_FindFrequentTreeSum(root);

            List<int> result = new List<int>();
            foreach (var entry in sumCount_FindFrequentTreeSum)
            {
                if (entry.Value == maxCount_FindFrequentTreeSum)
                {
                    result.Add(entry.Key);
                }
            }

            return result.ToArray();
        }

        private int DFS_FindFrequentTreeSum(TreeNode node)
        {
            if (node == null) return 0;

            int leftSum = DFS_FindFrequentTreeSum(node.left);
            int rightSum = DFS_FindFrequentTreeSum(node.right);

            int currentSum = leftSum + rightSum + node.val;
            sumCount_FindFrequentTreeSum[currentSum] = sumCount_FindFrequentTreeSum.GetValueOrDefault(currentSum) + 1;

            maxCount_FindFrequentTreeSum = Math.Max(maxCount_FindFrequentTreeSum, sumCount_FindFrequentTreeSum[currentSum]);

            return currentSum;
        }