//Leetcode 333 Largest BST Subtree mid
//题意：在一个二叉树中找到最大的二叉搜索子树
//思路：深度优先搜索（DFS） BST 的特性，辅助函数 IsValidBST，用于判断一个以某个节点为根的子树是否是二叉搜索树。
//时间复杂度:    n 是 BST 中的节点数, O(n)
//空间复杂度： h 是树的高度 O(h)
        public int LargestBSTSubtree(TreeNode root)
        {
            if (root == null) return 0;

            if (IsValidBST(root, int.MinValue, int.MaxValue))
            {
                return CountNodes(root);
            }

            int left = LargestBSTSubtree(root.left);
            int right = LargestBSTSubtree(root.right);

            return Math.Max(left, right);
        }

        private bool IsValidBST(TreeNode node, int min, int max)
        {
            if (node == null) return true;

            if (node.val <= min || node.val >= max) return false;

            return IsValidBST(node.left, min, node.val) && IsValidBST(node.right, node.val, max);
        }

        private int CountNodes(TreeNode node)
        {
            if (node == null) return 0;

            return 1 + CountNodes(node.left) + CountNodes(node.right);
        }