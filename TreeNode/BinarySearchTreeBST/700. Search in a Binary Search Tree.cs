//700. Search in a Binary Search Tree ez
//给一个二叉搜索树，给一个val，找出他的subTree
//思路：拿当前root的valu来做比较，然后根据大小来判断递归哪一边；
		public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return null;
            }
            // 去左子树搜索
            if (root.val > val)
            {
                return SearchBST(root.left, val);
            }
            // 去右子树搜索
            if (root.val < val)
            {
                return SearchBST(root.right, val);
            }
            return root;
        }