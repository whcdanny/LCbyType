//Leetcode 366 Find Leaves of Binary Tree med
//题意：给定一个二叉树，将其从底向上逐层剥离叶子节点，直到整个树为空
//思路：拓扑排序,BFS   找到所有的叶子节点，并将它们添加到结果列表中。然后，我们从叶子节点开始，不断地将它们从树中移除，直到整个树为空
//时间复杂度: n 是树中节点的数量, O(n)
//空间复杂度： w 是树的最大宽度, O(w);
        public IList<IList<int>> FindLeaves(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();

            while (root != null)
            {
                List<int> leaves = new List<int>();
                root = RemoveLeaves(root, leaves);
                result.Add(leaves);
            }

            return result;
        }

        private TreeNode RemoveLeaves(TreeNode node, List<int> leaves)
        {
            if (node == null) return null;

            if (node.left == null && node.right == null)
            {
                leaves.Add(node.val);
                return null;
            }

            node.left = RemoveLeaves(node.left, leaves);
            node.right = RemoveLeaves(node.right, leaves);

            return node;
        }