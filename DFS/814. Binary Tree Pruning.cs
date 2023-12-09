//Leetcode 814. Binary Tree Pruning med
//题意：给定一个二叉树，其中的节点值只包含 0 或 1。二叉树的每个亲节点都要么是 0，要么是 1。只有当一个节点的两个子节点都是 pruneTree 时，本节点才能被剪除。
//请实现 pruneTree 函数，以返回剪除了所有不包含 1 的子树的头节点。
//思路：DFS, DFS 遍历二叉树： 使用深度优先搜索（DFS）遍历二叉树的每个节点。
//剪除不包含 1 的子树： 在遍历的过程中，对于每个节点，判断其左右子树是否需要被剪除。如果左子树需要被剪除且已经被剪除，将左子树置为 null；如果右子树需要被剪除且已经被剪除，将右子树置为 null。
//返回新的根节点： 返回剪除不包含 1 的子树后的二叉树的根节点。
//时间复杂度: O(N)，其中 N 为节点的数量。
//空间复杂度：O(H)，其中 H 是二叉树的高度
        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
            {
                return null;
            }

            // 递归处理左右子树
            root.left = PruneTree(root.left);
            root.right = PruneTree(root.right);

            // 如果当前节点值为 0 且左右子树都为空，则可以剪除该子树
            if (root.val == 0 && root.left == null && root.right == null)
            {
                return null;
            }

            return root;
        }