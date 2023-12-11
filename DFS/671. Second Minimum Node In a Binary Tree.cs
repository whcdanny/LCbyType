//Leetcode 671. Second Minimum Node In a Binary Tree ez
//题意：给定一个二叉树，找到该树中的第二小的节点。节点的值是非负整数，并且每个节点都有零个或两个子节点。如果没有第二小的节点，则返回 -1。
//思路：DFS, 这是因为题目要求找到二叉树中第二小的节点，而根节点的值是最小的。如果当前节点的值大于根节点的值，那么该节点的值就是大于根节点的最小值。因此，我们直接返回该值。
//注：树中的节点值满足条件：父节点的值小于等于子节点的值
//时间复杂度： O(N)，其中 N 是树中的节点数量。
//空间复杂度： O(H)，其中 H 是树的高度
        public int FindSecondMinimumValue(TreeNode root)
        {
            // 通过 DFS 找到第二小的值
            return DFS_FindSecondMinimumValue(root, root.val);
        }

        private int DFS_FindSecondMinimumValue(TreeNode node, int rootValue)
        {
            // 如果节点为空，返回 -1
            if (node == null) return -1;

            // 如果当前节点的值大于根节点的值，那么当前节点就是第二小的节点
            if (node.val > rootValue) return node.val;

            // 递归搜索左右子树，找到左右子树中的第二小的节点
            int left = DFS_FindSecondMinimumValue(node.left, rootValue);
            int right = DFS_FindSecondMinimumValue(node.right, rootValue);

            // 如果左右子树中都没有第二小的节点，返回 -1
            if (left == -1) return right;
            if (right == -1) return left;

            // 返回左右子树中的较小值
            return Math.Min(left, right);
        }