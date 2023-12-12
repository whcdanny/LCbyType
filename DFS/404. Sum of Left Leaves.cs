//Leetcode 404. Sum of Left Leaves ez
//题意：给定一个二叉树，求所有左叶子节点的和。左叶子节点是指该节点的左子节点且没有左子节点和右子节点。
//思路：从根节点开始进行深度优先搜索。当遇到叶子节点时，判断该节点是否为左叶子节点，如果是，累加其值。分别对左子树和右子树进行递归搜索。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(H)，其中 H 是二叉树的高度
        public int SumOfLeftLeaves(TreeNode root)
        {
            int sum = 0;
            DFS_SumOfLeftLeaves(root, false, ref sum);
            return sum;
        }

        private void DFS_SumOfLeftLeaves(TreeNode node, bool isLeft, ref int sum)
        {
            if (node == null)
            {
                return;
            }

            if (isLeft && node.left == null && node.right == null)
            {
                sum += node.val; // 左叶子节点，累加其值
            }

            DFS_SumOfLeftLeaves(node.left, true, ref sum);
            DFS_SumOfLeftLeaves(node.right, false, ref sum);
        }
