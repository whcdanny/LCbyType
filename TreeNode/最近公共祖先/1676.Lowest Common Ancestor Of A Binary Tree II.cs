//1676.Lowest Common Ancestor Of A Binary Tree II med
//查找公共的祖先(LCA)通过给的p,q;前提查找的数不一定在所给的TreeNode里
//思路：由于这次的p,q不一定在所给的里面，所以要完全搜索，也就是先进行递归，然后再去找答案，而且如果p,q任意一个不在所给里面，就没有LCA；当left和right同时有值时，这个root就是LCA
		// 用于记录 p 和 q 是否存在于二叉树中
        public bool foundP = false, foundQ = false;

        public TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode res = find_lowestCommonAncestor(root, p.val, q.val);
            if (!foundP || !foundQ)
            {
                return null;
            }
            // p 和 q 都存在二叉树中，才有公共祖先
            return res;
        }

        // 在二叉树中寻找 val1 和 val2 的最近公共祖先节点
        public TreeNode find_lowestCommonAncestor(TreeNode root, int val1, int val2)
        {
            if (root == null)
            {
                return null;
            }
            TreeNode left = find_lowestCommonAncestor(root.left, val1, val2);
            TreeNode right = find_lowestCommonAncestor(root.right, val1, val2);

            // 后序位置，判断当前节点是不是 LCA 节点
            if (left != null && right != null)
            {
                return root;
            }

            // 后序位置，判断当前节点是不是目标值
            if (root.val == val1 || root.val == val2)
            {
                // 找到了，记录一下
                if (root.val == val1) foundP = true;
                if (root.val == val2) foundQ = true;
                return root;
            }

            return left != null ? left : right;
        }