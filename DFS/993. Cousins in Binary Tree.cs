//Leetcode 993. Cousins in Binary Tree ez
//题意：给定一个二叉树和两个树中的节点 x 和 y，判断它们是否是堂兄弟节点。堂兄弟节点是指深度相同但父节点不同的节点。
//思路：DFS（深度优先搜索）遍历二叉树。在遍历的过程中，记录每个节点的深度和父节点。当找到节点 x 和 y 后，比较它们的深度和父节点是否相同。
//时间复杂度: O(N)，其中N是二叉树中的节点数
//空间复杂度：O(H)，其中H是树的高度。     
        public bool IsCousins(TreeNode root, int x, int y)
        {
            int depthX = -1, depthY = -1;
            TreeNode parentX = new TreeNode(), parentY = new TreeNode();
            DFS_IsCousins(root, null, x, y, 0, ref depthX, ref depthY, ref parentX, ref parentY);
            return depthX == depthY && parentX != parentY;
        }

        private void DFS_IsCousins(TreeNode node, TreeNode parent, int x, int y, int depth, ref int depthX, ref int depthY, ref TreeNode parentX, ref TreeNode parentY)
        {
            if (node == null)
                return;

            if (node.val == x)
            {
                depthX = depth;
                parentX = parent;
            }
            else if (node.val == y)
            {
                depthY = depth;
                parentY = parent;
            }

            DFS_IsCousins(node.left, node, x, y, depth + 1, ref depthX, ref depthY, ref parentX, ref parentY);
            DFS_IsCousins(node.right, node, x, y, depth + 1, ref depthX, ref depthY, ref parentX, ref parentY);
        }
