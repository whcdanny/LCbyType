//Leetcode 623. Add One Row to Tree med
//题意：给定一个二叉树，以及一个值 v 和深度 d，向二叉树中第 d 层的所有节点添加一行，新行的值都为 v。添加行的位置是从左到右。
//思路：DFS,遍历二叉树，找到第 d - 1 层的节点，然后分别在其左子树和右子树中添加新的节点。
//时间复杂度: O(n)，其中 n 是二叉树的节点数
//空间复杂度：O(h)，其中 h 为二叉树的高度
        public TreeNode AddOneRow(TreeNode root, int v, int d)
        {
            if (d == 1)
            {
                TreeNode newRoot = new TreeNode(v);
                newRoot.left = root;
                return newRoot;
            }

            DFS_AddRow(root, v, d, 1);
            return root;
        }

        private void DFS_AddRow(TreeNode node, int v, int d, int currentDepth)
        {
            if (node == null) return;

            if (currentDepth == d - 1)
            {
                TreeNode leftNode = new TreeNode(v);
                leftNode.left = node.left;
                node.left = leftNode;

                TreeNode rightNode = new TreeNode(v);
                rightNode.right = node.right;
                node.right = rightNode;
            }
            else
            {
                DFS_AddRow(node.left, v, d, currentDepth + 1);
                DFS_AddRow(node.right, v, d, currentDepth + 1);
            }
        }