//Leetcode 530. Minimum Absolute Difference in BST ez
//题意：给定一个二叉搜索树（BST），返回树中任意两个不同节点值之间的最小绝对差。
//思路：DFS, BST 的中序遍历是一个递增序列。我们可以中序遍历 BST，得到有序的节点值序列，然后计算相邻两个节点值之间的差，找出最小的绝对差。
//时间复杂度: O(n)，其中 n 为树的节点数
//空间复杂度：O(h)，其中 h 为树的高度。最坏情况下，当树为链状（单侧深度），空间复杂度为 O(n)。
        private int minDiff_GetMinimumDifference = int.MaxValue;
        private TreeNode prev_GetMinimumDifference = null;

        public int GetMinimumDifference(TreeNode root)
        {
            DFS_InorderTraversal(root);
            return minDiff_GetMinimumDifference;
        }

        private void DFS_InorderTraversal(TreeNode node)
        {
            if (node == null)
                return;

            DFS_InorderTraversal(node.left);

            if (prev_GetMinimumDifference != null)
            {
                minDiff_GetMinimumDifference = Math.Min(minDiff_GetMinimumDifference, Math.Abs(node.val - prev_GetMinimumDifference.val));
            }

            prev_GetMinimumDifference = node;

            DFS_InorderTraversal(node.right);
        }