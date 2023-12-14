//Leetcode 144. Binary Tree Preorder Traversal ez
//题意：给定一个二叉树，返回它的先序遍历的节点值列表。    
//思路：深度优先搜索（DFS）递归地对二叉树进行先序遍历。先序遍历的顺序是先根节点，再左子树，最后右子树。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            PreorderDFS_PreorderTraversal(root, result);
            return result;
        }

        private void PreorderDFS_PreorderTraversal(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            result.Add(node.val); // 先访问根节点
            PreorderDFS_PreorderTraversal(node.left, result); // 再访问左子树
            PreorderDFS_PreorderTraversal(node.right, result); // 最后访问右子树
        }