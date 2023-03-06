//236. Lowest Common Ancestor of a Binary Tree med
//查找公共的祖先(LCA)通过给的p,q;前提查找的数肯定在所给的TreeNode里
//思路：对每个root都来检查，是否能找到p，q在left和right，两种情况，一种p,q分别在root的左右或左右分支上，第二种p或q就是LCA;当left和right同时有值时，这个root就是LCA
		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {           
            return find_LowestCommonAncestor(root, p.val, q.val);
        }
        public TreeNode find_LowestCommonAncestor(TreeNode root, int val1, int val2)
        {
            if (root == null)
            {
                return null;
            }
            // 前序位置
            if (root.val == val1 || root.val == val2)
            {
                // 如果遇到目标值，直接返回
                return root;
            }
            TreeNode left = find_LowestCommonAncestor(root.left, val1, val2);
            TreeNode right = find_LowestCommonAncestor(root.right, val1, val2);
            // 后序位置，已经知道左右子树是否存在目标值
            if (left != null && right != null)
            {
                // 当前节点是 LCA 节点
                return root;
            }

            return left != null ? left : right;
        }
		
		public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
                return root;
            TreeNode left = LowestCommonAncestor(root.left, p, q);
            TreeNode right = LowestCommonAncestor(root.right, p, q);
            if (left != null && right != null)
                return root;
            return left != null ? left : right;           
        }