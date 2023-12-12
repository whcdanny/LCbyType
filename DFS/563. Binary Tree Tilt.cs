//Leetcode 563. Binary Tree Tilt ez
//题意：给定一个二叉树，每个节点包含一个整数。定义二叉树的“坡度”为所有节点的左子树之和与右子树之和的差的绝对值。求二叉树的坡度的总和。      
//思路：（DFS）遍历二叉树。对于每个节点，计算左子树和右子树的和，计算当前节点的坡度，并递归计算左右子树的坡度。最后，返回总坡度。
//注：所有节点的左子树之和与右子树之和的差的绝对值
//时间复杂度: O(n)，其中 n 为节点总数
//空间复杂度：O(h)，其中 h 是二叉树的高度
        private int tiltSum_FindTilt = 0;

        public int FindTilt(TreeNode root)
        {
            DFS_CalculateSumAndTilt(root);
            return tiltSum_FindTilt;
        }

        private int DFS_CalculateSumAndTilt(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftSum = DFS_CalculateSumAndTilt(node.left);
            int rightSum = DFS_CalculateSumAndTilt(node.right);

            int currentTilt = Math.Abs(leftSum - rightSum);
            tiltSum_FindTilt += currentTilt;

            return leftSum + rightSum + node.val;
        }