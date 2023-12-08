//Leetcode 965. Univalued Binary Tree ez
//题意：给定一个二叉树，判断是否所有节点的值都相同。如果二叉树是“单值二叉树”，则返回 true，否则返回 false。单值二叉树是指所有节点的值都相同的二叉树。
//思路：（DFS）遍历二叉树，判断每个节点的值是否与根节点的值相同。递归处理每个节点，比较其值与根节点的值是否相同。如果当前节点的值与根节点的值不相同，返回 false。递归处理当前节点的左子树和右子树。如果左子树或右子树中有一个不是单值二叉树，返回 false。如果左子树和右子树都是单值二叉树，返回 true。       
//时间复杂度: O(N)，其中N是二叉树中的节点数
//空间复杂度：O(H)，其中H是树的高度。     
        public bool IsUnivalTree(TreeNode root)
        {
            return IsUnivalTreeHelper(root, root.val);
        }

        private bool IsUnivalTreeHelper(TreeNode node, int value)
        {
            if (node == null)
                return true;

            if (node.val != value)
                return false;

            return IsUnivalTreeHelper(node.left, value) && IsUnivalTreeHelper(node.right, value);
        }