//235. Lowest Common Ancestor of a Binary Search Tree med
//查找公共的祖先(LCA)通过给的p,q;这里时BST,前提查找的数肯定在所给的TreeNode里
//思路：由于时BST，所以如果p,q在一个root.val左右，那么就是答案，如root.val小于p,q中最小值，那么只用查right，反之root.val大于p,q中最大值，只查left;

		public TreeNode LowestCommonAncestor_BST(TreeNode root, TreeNode p, TreeNode q)
        {            
            // 保证 val1 较小，val2 较大
            int val1 = Math.Min(p.val, q.val);
            int val2 = Math.Max(p.val, q.val);
            return find_LowestCommonAncestor_BST(root, val1, val2);
        }
        // 在 BST 中寻找 val1 和 val2 的最近公共祖先节点
        public TreeNode find_LowestCommonAncestor_BST(TreeNode root, int val1, int val2)
        {
            if (root == null)
            {
                return null;
            }
            if (root.val > val2)
            {
                // 当前节点太大，去左子树找
                return find_LowestCommonAncestor_BST(root.left, val1, val2);
            }
            if (root.val < val1)
            {
                // 当前节点太小，去右子树找
                return find_LowestCommonAncestor_BST(root.right, val1, val2);
            }
            // val1 <= root.val <= val2
            // 则当前节点就是最近公共祖先
            return root;
        }
		
		public TreeNode LowestCommonAncestor_BST(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;
            if (root == p || root == q)
                return root;
            if ((root.val > p.val && root.val < q.val) || (root.val < p.val && root.val > q.val))
                return root;
            if (root.val > p.val && root.val > q.val)
                return LowestCommonAncestor_BST(root.left, p, q);
            else
                return LowestCommonAncestor_BST(root.right, p, q);
        }