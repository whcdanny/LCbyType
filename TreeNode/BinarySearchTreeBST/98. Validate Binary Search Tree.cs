//98. Validate Binary Search Tree med
//检查所给的treenode是否为二叉搜索树；
//思路：要保证左子树所有的值小于root，同理右子树的值大于root； 所以min和max要一直保留到最后；
		public bool IsValidBST(TreeNode root)
        {
            return isValidBST(root, null, null);
        }
        public bool isValidBST(TreeNode root, TreeNode min, TreeNode max)
        {
            // base case
            if (root == null) return true;
            // 若 root.val 不符合 max 和 min 的限制，说明不是合法 BST
            if (min != null && root.val <= min.val) return false;
            if (max != null && root.val >= max.val) return false;
            // 限定左子树的最大值是 root.val，右子树的最小值是 root.val
            return isValidBST(root.left, min, root)
                && isValidBST(root.right, root, max);
        }