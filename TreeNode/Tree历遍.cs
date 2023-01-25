//Tree历遍
		public void traverse(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            // 前序位置
            traverse(root.left);
            // 中序位置
            traverse(root.right);
            // 后序位置
        }