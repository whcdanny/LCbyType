559. Maximum Depth of N-ary Tree
//C#
		int max = 0;
        public int maxDepth(Node root)
        {
            if (root == null) 
                return 0;
            helper(root, 1);
            return max;
        }

        public void helper(Node root, int depth)
        {
            if (root.children.Count == 0)
            {
                if (depth > max) max = depth;
            }
            else
            {
                foreach (Node child in root.children)
                {
                    helper(child, depth + 1);
                }
            }
        }