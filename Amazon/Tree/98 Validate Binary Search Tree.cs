//Leetcode 98 Validate Binary Search Tree med
//题意：判断给定的二叉树是否是一个有效的二叉搜索树（BST）
//思路：深度优先搜索（DFS） BST 的特性，左子树上的所有节点的值均小于它的根节点的值。右子树上的所有节点的值均大于它的根节点的值。
//时间复杂度:  n 是 BST 中的节点数, O(n)
//空间复杂度： h 是树的高度 O(h)
        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }
        private bool IsValidBST(TreeNode node, long lower, long upper)
        {
            if (node == null) return true;

            if (node.val <= lower || node.val >= upper) return false;

            return IsValidBST(node.left, lower, node.val) && IsValidBST(node.right, node.val, upper);
        }