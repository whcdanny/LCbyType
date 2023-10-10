//Leetcode 104 Maximum Depth of Binary Tree ez
//题意：给定一个二叉树，找出其最大深度
//思路：DFS，递归计算左子树和右子树的最大深度
//时间复杂度:   n 是二叉树的节点个数, O(n)
//空间复杂度： O(n)
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;

            int leftDepth = MaxDepth(root.left);
            int rightDepth = MaxDepth(root.right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }