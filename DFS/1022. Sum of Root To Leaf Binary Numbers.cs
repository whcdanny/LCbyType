//Leetcode 1022. Sum of Root To Leaf Binary Numbers ez
//题意：给定一棵二叉树，其中每个节点都有一个二进制值。每个根到叶节点的路径代表一个二进制数，返回所有这些二进制数的和。
//思路：DFS（深度优先搜索）来遍历二叉树。在DFS的过程中，维护当前路径上的二进制值。对于每个节点，将当前路径上的二进制值左移一位，然后加上节点的二进制值。如果是叶节点，将当前路径上的二进制值加到结果中。递归地处理左子树和右子树。
//时间复杂度: O(N)，其中N是二叉树中的节点数
//空间复杂度：O(H)，其中H是树的高度
        private int sum_SumRootToLeaf;
        public int SumRootToLeaf(TreeNode root)
        {
            sum_SumRootToLeaf = 0;
            DFS_SumRootToLeaf(root, 0);
            return sum_SumRootToLeaf;
        }

        private void DFS_SumRootToLeaf(TreeNode node, int currentSum)
        {
            if (node == null)
                return;
            //currentSum << 1：将 currentSum 左移一位，相当于将二进制数的每一位都向左移动一位，相当于乘以2。
            //操作符：将左移后的结果与节点的值进行按位或操作。这样，如果节点的值为1，结果的最低位就设置为1，如果节点的值为0，结果的最低位就保持不变。
            currentSum = (currentSum << 1) | node.val;

            if (node.left == null && node.right == null)
            {
                sum_SumRootToLeaf += currentSum;
                return;
            }

            DFS_SumRootToLeaf(node.left, currentSum);
            DFS_SumRootToLeaf(node.right, currentSum);
        }