//Leetcode 513. Find Bottom Left Tree Value med
//题意：给定一棵二叉树，找到这棵树最底层、最左边的节点的值。
//思路：（DFS）进行递归。在 DFS 中，我们需要记录当前所在的层级和最左边的节点值。对于每个节点，先递归遍历其左子树，再递归遍历其右子树。在递归的过程中，更新当前层级和最左边的节点值。对于每个节点，只有在其所在的层级大于当前记录的层级时，才会更新最左边的节点值。
//时间复杂度: O(n)，其中 n 为二叉树的节点数。
//空间复杂度：O(h)，其中 h 为二叉树的高度
        private int maxDepth_FindBottomLeftValue = 0;
        private int leftmostValue_FindBottomLeftValue = 0;

        public int FindBottomLeftValue(TreeNode root)
        {
            DFS_FindBottomLeftValue(root, 1);
            return leftmostValue_FindBottomLeftValue;
        }

        private void DFS_FindBottomLeftValue(TreeNode node, int depth)
        {
            if (node == null) return;

            if (depth > maxDepth_FindBottomLeftValue)
            {
                maxDepth_FindBottomLeftValue = depth;
                leftmostValue_FindBottomLeftValue = node.val;
            }

            DFS_FindBottomLeftValue(node.left, depth + 1);
            DFS_FindBottomLeftValue(node.right, depth + 1);
        }