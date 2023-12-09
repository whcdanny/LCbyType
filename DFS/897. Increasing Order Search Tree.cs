//Leetcode 897. Increasing Order Search Tree ez
//题意：给定一个二叉搜索树（Binary Search Tree），重新排列树，使树中的每个节点的值都大于其左子树中的任何节点的值，同时小于树中右子树中的任何节点的值。
//思路：使用递归进行深度优先搜索，中序遍历二叉搜索树。在递归过程中，构建新的链表节点，并将其连接起来。返回新链表的头节点。
//时间复杂度: O(N)，其中 N 为二叉搜索树的节点数
//空间复杂度：O(H)，其中 H 为二叉搜索树的高度
        private TreeNode result_IncreasingBST;
        public TreeNode IncreasingBST(TreeNode root)
        {
            TreeNode dummy = new TreeNode(0);
            result_IncreasingBST = dummy;
            InOrderTraversal_IncreasingBST(root);
            return dummy.right;
        }

        private void InOrderTraversal_IncreasingBST(TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            InOrderTraversal_IncreasingBST(node.left);

            result_IncreasingBST.right = new TreeNode(node.val);
            result_IncreasingBST = result_IncreasingBST.right;

            InOrderTraversal_IncreasingBST(node.right);
        }