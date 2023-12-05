//Leetcode 1302. Deepest Leaves Sum med
//题意：给定二叉树的根节点，返回其最深层叶子节点的值之和
//思路：DFS, 使用 GetMaxDepth 函数计算树的最大深度。 使用 GetSumAtDepth 函数递归计算在指定深度的节点值之和。
//时间复杂度: O(N^2)，其中 N 是二叉树的节点数，因为在每个深度上都要递归遍历子树
//空间复杂度：O(H)，其中 H 是二叉树的高度
        public int DeepestLeavesSum(TreeNode root)
        {
            int maxDepth = GetMaxDepth(root); // 获取树的最大深度
            return GetSumAtDepth(root, maxDepth);
        }

        private int GetMaxDepth(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftDepth = GetMaxDepth(node.left);
            int rightDepth = GetMaxDepth(node.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        private int GetSumAtDepth(TreeNode node, int depth)
        {
            if (node == null)
            {
                return 0;
            }

            if (depth == 1)
            {
                return node.val;
            }

            return GetSumAtDepth(node.left, depth - 1) + GetSumAtDepth(node.right, depth - 1);
        }