//Leetcode 101 Symmetric Tree ez  
//题意：判断一个二叉树是否是镜像对称的
//思路：DFS，判断两个节点的值是否相等，并且递归地比较第一个节点的左子树和第二个节点的右子树，以及第一个节点的右子树和第二个节点的左子树
//时间复杂度: n 是二叉树中节点的个数, O(n)
//空间复杂度： O(n);
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric_DFS(root, root);
        }

        private bool IsSymmetric_DFS(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null || root2 == null)
                return false;

            return (root1.val == root2.val) && IsSymmetric_DFS(root1.left, root2.right) && IsSymmetric_DFS(root1.right, root2.left);
        }