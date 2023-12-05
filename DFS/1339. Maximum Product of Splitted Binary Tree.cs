//Leetcode 1339. Maximum Product of Splitted Binary Tree med
//题意：给定二叉树的根节点，通过删除一条边将二叉树分成两个子树，使得这两个子树的节点值之和的乘积最大化。返回最大乘积，由于答案可能很大，需要对 10^9 + 7 取模。        
//思路：DFS, MaxProduct 函数是主函数，它调用 GetTotalSum 函数计算整个树的节点值之和，并调用 CalculateSubtreeSum 函数计算每个子树的节点值之和。最后，返回取模后的最大乘积。
//CalculateSubtreeSum 函数是深度优先搜索的关键。在该函数中，首先递归计算左右子树的节点值之和，然后计算当前子树的节点值之和，并计算剩余的节点值之和。最后，计算当前子树的乘积，并更新最大乘积。
//时间复杂度: O(N)，其中 N 是二叉树的节点数
//空间复杂度：O(H)，其中 H 是二叉树的高度
        private long maxProduct_MaxProduct = 0;

        public int MaxProduct(TreeNode root)
        {
            long totalSum = GetTotalSum(root); // 计算整个树的节点值之和
            CalculateSubtreeSum(root, totalSum); // 计算每个子树的节点值之和
            return (int)(maxProduct_MaxProduct % 1000000007);
        }

        private long GetTotalSum(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }
            long leftSum = GetTotalSum(node.left);
            long rightSum = GetTotalSum(node.right);
            return leftSum + rightSum + node.val;
        }

        private long CalculateSubtreeSum(TreeNode node, long totalSum)
        {
            if (node == null)
            {
                return 0;
            }

            long leftSubtreeSum = CalculateSubtreeSum(node.left, totalSum);
            long rightSubtreeSum = CalculateSubtreeSum(node.right, totalSum);

            long subtreeSum = leftSubtreeSum + rightSubtreeSum + node.val;
            long remainingSum = totalSum - subtreeSum;

            long product = subtreeSum * remainingSum;
            maxProduct_MaxProduct = Math.Max(maxProduct_MaxProduct, product);

            return subtreeSum;
        }