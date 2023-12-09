//Leetcode 783. Minimum Distance Between BST Nodes ez
//题意：给定一个二叉搜索树（BST）的根节点 root，返回树中任意两个不同节点值之间的最小差值。
//思路：（DFS）进行中序遍历，同时维护一个变量 prev 用于记录上一个访问的节点值。在遍历过程中，计算当前节点值与 prev 的差值，更新最小差值。最后返回最小差值即可。
//时间复杂度:  O(N)，其中 N 是二叉搜索树的节点数
//空间复杂度： O(N)
        private int minDiff_MinDiffInBST = int.MaxValue;
        private TreeNode prev_MinDiffInBST = null;
        public int MinDiffInBST(TreeNode root)
        {
            InOrderTraversal(root);
            return minDiff_MinDiffInBST;
        }

        private void InOrderTraversal(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.left);

            if (prev_MinDiffInBST != null)
            {
                minDiff_MinDiffInBST = Math.Min(minDiff_MinDiffInBST, node.val - prev_MinDiffInBST.val);
            }
            prev_MinDiffInBST = node;

            InOrderTraversal(node.right);
        }