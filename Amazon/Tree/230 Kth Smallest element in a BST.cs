//Leetcode 230 Kth Smallest element in a BST  ez
//题意：给定一个二叉搜索树（BST）的根节点和一个整数 k，找到树中第 k 小的节点
//思路：深度优先搜索（DFS） BST 的特性，中序遍历 BST 会得到一个有序的节点序列
//时间复杂度: n 是 BST 中的节点数, O(n)
//空间复杂度： h 是树的高度 O(h)
        public int KthSmallest(TreeNode root, int k)
        {
            List<int> orders = new List<int>();
            InorderTraversal(root, orders);
            return orders[k - 1];
        }
        private void InorderTraversal(TreeNode node, List<int> inorder)
        {
            if (node == null)
                return;
            InorderTraversal(node.left, inorder);
            inorder.Add(node.val);
            InorderTraversal(node.right, inorder);
        }