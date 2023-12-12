//Leetcode 437. Path Sum III  med 
//题意：给定一棵二叉树，每个节点包含一个整数值。要求计算出有多少条路径的和等于给定的目标值。
//路径的定义是从树中的任意节点出发，向下移动，每次只能移动到一个相邻的节点。路径和是路径上所有节点值的总和。
//思路：深度优先搜索（DFS）来解决这个问题。在DFS的过程中，我们维护一个累计和，表示从根节点到当前节点的路径和。对于每个节点，我们计算以当前节点为路径终点的和等于目标值的路径数量。
//在递归过程中，我们遍历每个节点，并累积路径和。在遍历过程中，如果在当前节点的路径上有和等于目标值的子路径，我们就增加计数。
//时间复杂度: O(N^2)，其中 N 是二叉树的节点数量
//空间复杂度：O(H)，其中 H 是二叉树的高度。在最坏情况下，二叉树为链状结构，高度为 N，空间复杂度为 O(N)。
        public int PathSum(TreeNode root, int sum)
        {
            if (root == null) return 0;
            return DFS_PathSum(root, sum) + PathSum(root.left, sum) + PathSum(root.right, sum);
        }

        private int DFS_PathSum(TreeNode node, int sum)
        {
            if (node == null) return 0;

            int count = 0;
            if (node.val == sum)
            {
                count++;
            }

            count += DFS_PathSum(node.left, sum - node.val);
            count += DFS_PathSum(node.right, sum - node.val);

            return count;
        }