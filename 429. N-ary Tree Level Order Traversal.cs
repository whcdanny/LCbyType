429. N-ary Tree Level Order Traversal
//C#
		public IList<IList<int>> levelOrder(Node root)
        {
            var levelOrder = new List<IList<int>>();
            if (root == null)
                return levelOrder;
            Order(0, root, levelOrder);
            return levelOrder;
        }

        public void Order(int level, Node node, List<IList<int>> levelOrder)
        {
            if (node == null)
                return;
            if (level == levelOrder.Count)
            {
                levelOrder.Add(new List<int>());
            }
            levelOrder[level].Add(node.val);
            if (node.children != null)
            {
                foreach (Node child in node.children)
                {
                    Order(level + 1, child, levelOrder);
                }
            }
        }