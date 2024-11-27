//Leetcode 124 Binary Tree Maximum Path Sum hard  
//题意：给定一个二叉树，求出其中任意节点开始、结束的路径中，节点值之和的最大值
//思路：DFS， 递归计算左右子树的最大路径
//时间复杂度: n 是二叉树中节点的个数, O(n)
//空间复杂度： O(n);
//保存最大路径和的值，初始值设为负无穷大
        private int maxPathSum_Count = int.MinValue;
        public int maxPathSum(TreeNode root)
        {
            maxPathSum_DFS(root);
            return maxPathSum_Count;
        }

        private int maxPathSum_DFS(TreeNode root)
        {
            if (root == null)
                return 0;

            int leftSum = Math.Max(0, maxPathSum_DFS(root.left));
            int rightSum = Math.Max(0, maxPathSum_DFS(root.right));

            int curPathSum = root.val + leftSum + rightSum;

            maxPathSum_Count = Math.Max(maxPathSum_Count, curPathSum);

            return root.val + Math.Max(leftSum, rightSum);
        }