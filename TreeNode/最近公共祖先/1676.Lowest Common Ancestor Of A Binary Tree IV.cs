//1676.Lowest Common Ancestor Of A Binary Tree IV med
//给一个treenodelist，让你找出公共的祖先(LCA)，前提查找的数肯定在所给的TreeNode里
//思路： 先将要查找的treenodelist里的数存入list，方便确认，然后找left和right，然后根据left和right，来得到答案；当left和right同时有值时，这个root就是LCA
		public TreeNode lowestCommonAncestor(TreeNode root, TreeNode[] nodes)
        {
            // 将列表转化成哈希集合，便于判断元素是否存在
            List<int> values = new List<int>();
            foreach (TreeNode node in nodes)
            {
                values.Add(node.val);
            }

            return find_lowestCommonAncestor(root, values);
        }

        // 在二叉树中寻找 values 的最近公共祖先节点
        public TreeNode find_lowestCommonAncestor(TreeNode root, List<int> values)
        {
            if (root == null)
            {
                return null;
            }
            // 前序位置
            if (values.Contains(root.val))
            {
                return root;
            }

            TreeNode left = find_lowestCommonAncestor(root.left, values);
            TreeNode right = find_lowestCommonAncestor(root.right, values);
            // 后序位置，已经知道左右子树是否存在目标值
            if (left != null && right != null)
            {
                // 当前节点是 LCA 节点
                return root;
            }

            return left != null ? left : right;
        }