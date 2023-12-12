//Leetcode 515. Find Largest Value in Each Tree Row med
//题意：给定一个二叉树，返回每一行中最大的值。
//思路：（DFS）进行递归。在遍历每一行时，维护一个变量 maxValue 来存储当前行的最大值。对于每个节点，比较节点的值和 maxValue，更新 maxValue。在递归调用的过程中，每次进入新的一层（即新的一行），需要将 maxValue 重置为 int.MinValue。
//时间复杂度: O(N)，其中 N 是二叉树的节点数
//空间复杂度：O(h)，其中 h 为树的高度
        public IList<int> LargestValues(TreeNode root)
        {
            List<int> result = new List<int>();
            DFS_LargestValues(root, 0, result);
            return result;
        }

        private void DFS_LargestValues(TreeNode node, int level, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            // 如果输入新层数，存入之前一层的最大值
            if (level >= result.Count)
            {
                result.Add(int.MinValue);
            }

            // Update the max value for the current level
            result[level] = Math.Max(result[level], node.val);

            // Recursive calls for left and right children
            DFS_LargestValues(node.left, level + 1, result);
            DFS_LargestValues(node.right, level + 1, result);
        }
