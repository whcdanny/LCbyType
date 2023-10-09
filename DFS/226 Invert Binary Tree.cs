//Leetcode 226 Invert Binary Tree ez  
//题意：给定一个二叉树，要求将其每个节点的左右子树
//思路：DFS， 递归左子树和右子树进行翻转
//时间复杂度: n 是二叉树中节点的个数, O(n)
//空间复杂度： O(n);
        public TreeNode InvertTree(TreeNode root)
        {
            InvertTree_Invert(root);
            return root;
        }

        private void InvertTree_Invert(TreeNode root)
        {
            if (root == null)
                return;
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
            InvertTree_Invert(root.left);
            InvertTree_Invert(root.right);
        }