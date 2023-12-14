//Leetcode 145. Binary Tree Postorder Traversal ez
//题意：给定一个二叉树，返回它的后序遍历的节点值列表        
//思路：深度优先搜索（DFS）递归地对二叉树进行后序遍历。后序遍历的顺序是先左子树，再右子树，最后根节点。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            PostorderDFS_PostorderTraversal(root, result);
            return result;
        }

        private void PostorderDFS_PostorderTraversal(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            PostorderDFS_PostorderTraversal(node.left, result); // 先访问左子树
            PostorderDFS_PostorderTraversal(node.right, result); // 再访问右子树
            result.Add(node.val); // 最后访问根节点
        }