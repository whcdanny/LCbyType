//Leetcode 104. Maximum Depth of Binary Tree ez
//题意：给定一个二叉树，找出其最大深度。最大深度是从根节点到最远叶子节点的最长路径上的节点数量。
//思路：深度优先搜索（DFS）递归地计算二叉树的最大深度。对于每个节点，其最大深度等于左右子树的最大深度加上1。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)。
        public int MaxDepth_104(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return 1 + Math.Max(MaxDepth_104(root.left), MaxDepth_104(root.right));
        }