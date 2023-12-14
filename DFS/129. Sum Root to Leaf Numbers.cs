//Leetcode 129. Sum Root to Leaf Numbers med
//题意：给定一个二叉树，其中每个节点都包含一个 0-9 的数字。每一条从根到叶子的路径都代表一个数字，将这些数字相加，返回总和。
//思路：深度优先搜索（DFS）从根节点开始进行深度优先搜索，遍历每一条从根到叶子的路径。在递归过程中，将当前路径的数字累加，并传递给下一层递归。当遇到叶子节点时，将当前路径的数字加到总和中。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public int SumNumbers(TreeNode root)
        {
            return DFS_SumNumbers(root, 0);
        }

        private int DFS_SumNumbers(TreeNode node, int currentSum)
        {
            if (node == null)
            {
                return 0;
            }

            int sum = currentSum * 10 + node.val;

            if (node.left == null && node.right == null)
            {
                return sum; // 叶子节点，返回当前路径的数字
            }

            int leftSum = DFS_SumNumbers(node.left, sum);
            int rightSum = DFS_SumNumbers(node.right, sum);

            return leftSum + rightSum;
        }