//Leetcode 1373. Maximum Sum BST in Binary Tree hard
//题意：给定一个二叉树的根节点 root，找到其中任意一个子树，使得该子树同时满足以下条件：
//该子树是二叉搜索树（BST）。
//返回该子树所有节点值之和的最大值。
//BST的定义是：
//一个节点的左子树只包含值小于该节点的节点。
//一个节点的右子树只包含值大于该节点的节点。
//左右子树也必须是BST。
//思路：深度优先搜索（DFS）遍历树。MaxSumBST 函数是主函数，它调用 Dfs 函数进行深度优先搜索。Dfs 函数返回一个包含四个值的元组：bool 表示当前子树是否是BST。int 表示当前子树的最小值。int 表示当前子树的最大值。int 表示当前子树的节点值之和。在 Dfs 函数中，首先递归处理左右子树，然后判断当前节点是否满足BST的条件。如果满足条件，则更新最大值，并返回当前子树的信息；否则，返回(false, 0, 0, 0) 表示当前子树不是BST。
//注：只要左右数为BST,然后当前node.val大于左边最大值，小于右边最小值；
//时间复杂度: O(N)，其中 N 是二叉树的节点数
//空间复杂度：O(H)，其中 H 是二叉树的高度
        public int MaxSumBST(TreeNode root)
        {
            int maxSum = 0;
            DFS_MaxSumBST(root, ref maxSum);
            return maxSum;
        }

        private (bool, int, int, int) DFS_MaxSumBST(TreeNode node, ref int maxSum)
        {
            if (node == null)
            {
                return (true, int.MaxValue, int.MinValue, 0);
            }

            var (leftIsBST, leftMin, leftMax, leftSum) = DFS_MaxSumBST(node.left, ref maxSum);
            var (rightIsBST, rightMin, rightMax, rightSum) = DFS_MaxSumBST(node.right, ref maxSum);

            if (leftIsBST && rightIsBST && node.val > leftMax && node.val < rightMin)
            {
                int currentSum = node.val + leftSum + rightSum;
                maxSum = Math.Max(maxSum, currentSum);
                return (true, Math.Min(leftMin, node.val), Math.Max(rightMax, node.val), currentSum);
            }
            else
            {
                // If the current subtree is not a BST, return (false, 0, 0, 0)
                return (false, 0, 0, 0);
            }
        }