//Leetcode 1080. Insufficient Nodes in Root to Leaf Paths med
//题意：给定一棵二叉树的根节点 root 和整数 limit，请你删除所有从根节点到叶子节点的路径，使得路径上所有节点的值相加小于 limit。在删除之后，返回树的根节点。若没有这样的路径，则返回 null。
//思路：DFS, 从根节点开始，递归地处理左子树和右子树。在递归过程中，计算当前路径的节点值之和，并判断是否小于 limit。若小于 limit，则删除当前路径（即将当前节点置为 null）。最终返回修改后的二叉树的根节点。
//时间复杂度: O(N)，其中 N 是二叉树中的节点数
//空间复杂度：O(H)，其中 H 是二叉树的高度
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            return DFS_SufficientSubset(root, 0, limit);
        }

        private TreeNode DFS_SufficientSubset(TreeNode node, int currentSum, int limit)
        {
            if (node == null)
                return null;

            currentSum += node.val;

            // 若当前节点为叶子节点，判断路径上的节点值之和是否小于 limit
            if (node.left == null && node.right == null)
            {
                return currentSum < limit ? null : node;
            }

            // 递归处理左子树和右子树
            node.left = DFS_SufficientSubset(node.left, currentSum, limit);
            node.right = DFS_SufficientSubset(node.right, currentSum, limit);

            // 若左右子树均删除，则当前节点也应删除
            if (node.left == null && node.right == null)
            {
                return null;
            }

            return node;
        }