//Leetcode 538. Convert BST to Greater Tree med
//题意：给定一个二叉搜索树（BST），将其每个节点的值修改为原来的节点值加上所有大于它的节点值之和。
//思路：DFS, BST，可以按照右根左的顺序进行中序遍历，这样得到的节点值是递减的。在遍历的过程中，累加当前节点值，并更新节点值。这样就能实现每个节点值加上所有大于它的节点值之和。
//时间复杂度: O(n)，其中 n 为树的节点数
//空间复杂度： O(h)，其中 h 为树的高度。最坏情况下，当树为链状（单侧深度），空间复杂度为 O(n)。
        private int sum_ConvertBST = 0;
        public TreeNode ConvertBST(TreeNode root)
        {
            if (root != null)
            {
                ConvertBST(root.right);
                sum_ConvertBST += root.val;
                root.val = sum_ConvertBST;
                ConvertBST(root.left);
            }
            return root;
        }