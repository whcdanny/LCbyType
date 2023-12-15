//Leetcode 111. Minimum Depth of Binary Tree ez
//题意：给定一个二叉树，找出其最小深度。最小深度是从根节点到最近的叶子节点的最短路径上的节点数量。
//思路：深度优先搜索（DFS）从根节点开始进行深度优先搜索，递归地查找最小深度。在递归过程中，对于每个节点，计算其左右子树的最小深度，取其中较小的值，并加上当前节点的深度。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public int MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return MinDepthDFS(root);
        }

        private int MinDepthDFS(TreeNode node)
        {
            if (node == null)
            {
                return int.MaxValue; // 表示空节点的深度为无穷大
            }

            if (node.left == null && node.right == null)
            {
                return 1; // 叶子节点的深度为 1
            }

            int leftDepth = MinDepthDFS(node.left);
            int rightDepth = MinDepthDFS(node.right);

            return 1 + Math.Min(leftDepth, rightDepth);
        }