//Leetcode 101. Symmetric Tree  ez
//题意：给定一个二叉树，检查它是否是镜像对称的。
//思路：深度优先搜索（DFS）递归地检查二叉树是否是对称的。对于每一对对称节点，它们的值应该相等，且它们的左右子树分别是对方的右子树和左子树。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public bool IsSymmetric_101(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            return IsMirror(root.left, root.right);
        }

        private bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            return left.val == right.val
                   && IsMirror(left.left, right.right)
                   && IsMirror(left.right, right.left);
        }