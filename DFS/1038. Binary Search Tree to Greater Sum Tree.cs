//Leetcode 1038. Binary Search Tree to Greater Sum Tree med
//题意：给定一个二叉搜索树（BST），请你将其每个节点的值替换为原树中大于或等于该节点值的节点值之和。也就是说，对于BST中的每个节点，要求将其值修改为原树中大于或等于该节点值的所有节点值之和。
//思路：DFS, 中序遍历可以得到有序的节点序列。从最右边（最大值）开始进行中序遍历，并不断累加节点的值。将每个节点的值更新为累加和。
//时间复杂度: O(N)，其中 N 是二叉搜索树的节点数
 //空间复杂度：O(H)，其中 H 是二叉搜索树的高度
        // 记录累加和
        public int sum_traverse_BstToGst = 0;
        public TreeNode BstToGst(TreeNode root)
        {
            traverse_BstToGst(root);
            return root;
        }
       
        void traverse_BstToGst(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            traverse_BstToGst(root.right);
            // 维护累加和
            sum_traverse_BstToGst += root.val;
            // 将 BST 转化成累加树
            root.val = sum_traverse_BstToGst;
            traverse_BstToGst(root.left);
        }