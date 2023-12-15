//Leetcode 110. Balanced Binary Tree ez
//题意：给定一个二叉树，判断它是否是高度平衡的二叉树。在这里，高度平衡的二叉树是指每个节点的两个子树的深度相差不超过 1。
//思路：深度优先搜索（DFS）一个二叉树是高度平衡的，当且仅当其左右子树都是高度平衡的，且它们的深度差不超过1
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return Math.Abs(DFS_IsBalanced(root.left) - DFS_IsBalanced(root.right)) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        private int DFS_IsBalanced(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(DFS_IsBalanced(node.left), DFS_IsBalanced(node.right));
        }