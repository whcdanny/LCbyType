//Leetcode 572 Subtree of Another Tree ez
//题意：给定两棵二叉树 s 和 t，判断 t 是否是 s 的子树（t 可以是 s 的任意子树，而不仅仅是它的子树）
//思路：DFS，递归地比较左子树和右子树是否也相等
//时间复杂度:   m 是树 s 的节点数，n 是树 t 的节点数,,  O(m*n)
//空间复杂度： h1 和 h2 分别是树 s 和 t 的高度, O(max(h1, h2))
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null)
                return true;
            if (root == null || subRoot == null)
                return false;

            return IsSameTree(root, subRoot) || IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }

        private bool IsSameTree(TreeNode root, TreeNode subRoot)
        {
            if (root == null && subRoot == null)
                return true;
            if (root == null || subRoot == null)
                return false;

            return root.val == subRoot.val && IsSameTree(root.left, subRoot.left) && IsSameTree(root.right, subRoot.right);
        }