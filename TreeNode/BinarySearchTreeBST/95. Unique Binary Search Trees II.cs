//95. Unique Binary Search Trees II med
//给一个数，给出所有可能出现的BST
//思路：root可以时所有值，所以从1开始；递归构造left和right； 给root节点穷举所有左右子树的组合；
		public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new List<TreeNode>();
            return generateTrees(1, n);
        }
        public IList<TreeNode> generateTrees(int start, int end)
        {
            IList<TreeNode> list = new List<TreeNode>();

            if (start > end)
            {
                list.Add(null);
                return list;
            }

            for (int i = start; i <= end; i++)
            {
                IList<TreeNode> lefts = generateTrees(start, i - 1);
                IList<TreeNode> rights = generateTrees(i + 1, end);

                foreach (TreeNode l in lefts)
                {
                    foreach (TreeNode r in rights)
                    {
                        TreeNode node = new TreeNode(i);
                        node.left = l;
                        node.right = r;
                        list.Add(node);
                    }
                }
            }

            return list;
        }