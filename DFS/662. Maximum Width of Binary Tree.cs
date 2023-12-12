//Leetcode 662. Maximum Width of Binary Tree med
//题意：给定一棵二叉树，计算其最大宽度。二叉树的宽度是树中任意两个深度最小的节点之间的距离（包括端点之间的空的层）。
//思路：（DFS）来解决这个问题。在DFS的过程中，记录每一层的最左边和最右边的节点在数组 leftmost 和 rightmost 中。每一层的宽度即为 rightmost - leftmost + 1。递归地遍历树的每个节点，更新 leftmost 和 rightmost 的值。
//注：计算宽度：左孩子节点的编号为当前节点编号的2倍，右孩子节点的编号为当前节点编号的2倍加1。
//时间复杂度: O(N)，其中 N 是二叉树中的节点数
//空间复杂度：O(H)，其中 H 是二叉树的高度。在最坏的情况下，递归栈的深度为 H
        private int result_WidthOfBinaryTree = 0;
        private List<int> leftmost = new List<int>();

        public int WidthOfBinaryTree(TreeNode root)
        {
            DFS_WidthOfBinaryTree(root, 0, 0);
            return result_WidthOfBinaryTree;
        }

        private void DFS_WidthOfBinaryTree(TreeNode node, int depth, int position)
        {
            if (node == null) return;

            if (depth == leftmost.Count)
            {
                leftmost.Add(position);
            }

            result_WidthOfBinaryTree = Math.Max(result_WidthOfBinaryTree, position - leftmost[depth] + 1);

            DFS_WidthOfBinaryTree(node.left, depth + 1, position * 2);
            DFS_WidthOfBinaryTree(node.right, depth + 1, position * 2 + 1);
        }