//Leetcode 99. Recover Binary Search Tree med
//题意：给定一个二叉搜索树中的两个节点被错误地交换了，请在不改变其结构的情况下恢复这棵树。
//思路：深度优先搜索（DFS）中序遍历二叉搜索树，将遍历的结果保存在数组中。找到两个交换位置错误的节点。交换这两个节点的值。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(n)
        public void RecoverTree(TreeNode root)
        {
            List<TreeNode> nodes = new List<TreeNode>();
            InOrderTraversal(root, nodes);

            TreeNode first = null, second = null;
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                if (nodes[i].val > nodes[i + 1].val)
                {
                    if (first == null)
                    {
                        first = nodes[i];
                    }
                    second = nodes[i + 1];
                }
            }

            SwapValues(first, second);
        }

        private void InOrderTraversal(TreeNode node, List<TreeNode> nodes)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.left, nodes);
            nodes.Add(node);
            InOrderTraversal(node.right, nodes);
        }

        private void SwapValues(TreeNode node1, TreeNode node2)
        {
            int temp = node1.val;
            node1.val = node2.val;
            node2.val = temp;
        }