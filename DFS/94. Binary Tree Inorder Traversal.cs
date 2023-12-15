//Leetcode 94. Binary Tree Inorder Traversal med
//题意：给定一个二叉树，返回它的中序遍历。
//思路：深度优先搜索（DFS）中序遍历的顺序是左子树，当前节点，右子树
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            InOrderTraversal(root, result);
            return result;
        }

        private void InOrderTraversal(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal(node.left, result);
            result.Add(node.val);
            InOrderTraversal(node.right, result);
        }