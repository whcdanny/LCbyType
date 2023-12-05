//Leetcode 1325. Delete Leaves With a Given Value med
//题意：给定二叉树的根节点 root 和一个整数 target，删除所有叶子节点值为 target 的节点。注意，一旦删除了值为 target 的叶子节点，如果其父节点变成叶子节点且值为 target，则也应该删除（需要一直进行这个过程直到不能删除为止）。
//思路：DFS, 递归处理左右子树，得到处理后的左右子树。如果当前节点是叶子节点且值为 target，则返回 null，表示删除该节点。如果当前节点删除后变成叶子节点且值不为 target，则返回该节点，表示保留。如果当前节点不是叶子节点，则返回该节点，表示保留。
//注：这里不用担心“如果当前节点删除后变成叶子节点且值为target，则继续删除”因为我们每一次都从最底部往上，所以会自动更新，节点
//时间复杂度: O(N)，其中 N 是二叉树的节点数
//空间复杂度：O(H)，其中 H 是二叉树的高度
        public TreeNode RemoveLeafNodes(TreeNode root, int target)
        {
            return DFS_RemoveLeaves(root, target);
        }

        private TreeNode DFS_RemoveLeaves(TreeNode node, int target)
        {
            if (node == null)
            {
                return null;
            }

            // 递归处理左右子树
            node.left = DFS_RemoveLeaves(node.left, target);
            node.right = DFS_RemoveLeaves(node.right, target);

            // 如果当前节点是叶子节点且值为target，则删除, 
            if (node.left == null && node.right == null && node.val == target)
            {
                return null;
            }

            if (node.left == null && node.right == null && node.val != target)
            {
                return node; // 不是target的叶子节点保留
            }

            return node; // 非叶子节点或不是target的叶子节点，保留
        }
