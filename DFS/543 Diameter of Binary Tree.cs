//Leetcode 543 Diameter of Binary Tree ez
//题意：给定一个二叉树，要求计算出二叉树中任意两个节点之间的最长路径长度（可以不经过根节点）
//思路：DFS， 从根节点开始，递归地计算每个节点的左右子树的深度，然后更新最长路径的长度
//时间复杂度: n 是二叉树中节点的个数, O(n)
//空间复杂度： O(n);

        //创建一个全局变量 maxDiameter 用于保存最长路径的长度
        private int DiameterOfBinaryTree_depth = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            DiameterOfBinaryTree_DFS(root);
            return DiameterOfBinaryTree_depth;
        }

        private int DiameterOfBinaryTree_DFS(TreeNode root)
        {
            if (root.val == 0)
                return 0;
            int leftDepth = DiameterOfBinaryTree_DFS(root.left);
            int rightDepth = DiameterOfBinaryTree_DFS(root.right);
            //因为可以不经过根节点，所以要left+right；
            DiameterOfBinaryTree_depth = Math.Max(DiameterOfBinaryTree_depth, leftDepth + rightDepth);
            return Math.Max(leftDepth, rightDepth) + 1; 
        }