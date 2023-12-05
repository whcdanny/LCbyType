//Leetcode 1382. Balance a Binary Search Tree med
//题意：给定一个二叉搜索树（BST），要求返回一个平衡的二叉搜索树，即任何节点的两个子树的深度差不超过1。如果有多个答案，则返回其中任意一个。
//思路： （DFS）使用中序遍历获取原始BST的节点值序列。根据节点值序列构建平衡二叉搜索树。        
//时间复杂度: O(n)，其中 n 是二叉搜索树中的节点数。
//空间复杂度：O(n)，用于存储中序遍历的结果和递归栈的空间
        public TreeNode BalanceBST(TreeNode root)
        {
            List<int> inorderTraversal = new List<int>();
            //原始BST的节点值序列
            DFS_InorderTraversal_BalanceBST(root, inorderTraversal);
            //根据节点值序列构建平衡二叉搜索树。   
            return DFS_BalanceBST_BuildBalancedBST(inorderTraversal, 0, inorderTraversal.Count - 1);
        }

        private void DFS_InorderTraversal_BalanceBST(TreeNode node, List<int> result)
        {
            if (node == null)
            {
                return;
            }

            DFS_InorderTraversal_BalanceBST(node.left, result);
            result.Add(node.val);
            DFS_InorderTraversal_BalanceBST(node.right, result);
        }

        private TreeNode DFS_BalanceBST_BuildBalancedBST(List<int> inorderTraversal, int start, int end)
        {
            if (start > end)
            {
                return null;
            }

            int mid = (start + end) / 2;
            TreeNode root = new TreeNode(inorderTraversal[mid]);

            root.left = DFS_BalanceBST_BuildBalancedBST(inorderTraversal, start, mid - 1);
            root.right = DFS_BalanceBST_BuildBalancedBST(inorderTraversal, mid + 1, end);

            return root;
        }