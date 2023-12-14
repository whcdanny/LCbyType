//Leetcode 112. Path Sum ez
//题意：给定一个二叉树和一个目标和，判断是否存在从根节点到叶子节点的路径，使得路径上节点值之和等于给定的目标和。
//思路：深度优先搜索（DFS）从根节点开始进行深度优先搜索，递归地查找是否存在满足条件的路径。在递归过程中，记录当前路径上的节点值之和，当到达叶子节点时，判断是否等于给定的目标和。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public bool HasPathSum(TreeNode root, int sum)
        {
            if (root == null)
            {
                return false;
            }

            return HasPathSumDFS(root, sum, 0);
        }

        private bool HasPathSumDFS(TreeNode node, int target, int currentSum)
        {
            if (node == null)
            {
                return false;
            }

            currentSum += node.val;

            if (node.left == null && node.right == null)
            {
                return currentSum == target; // 当到达叶子节点时，判断路径和是否等于目标和
            }

            return HasPathSumDFS(node.left, target, currentSum) || HasPathSumDFS(node.right, target, currentSum);
        }