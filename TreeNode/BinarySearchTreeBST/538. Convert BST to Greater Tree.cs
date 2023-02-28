//538. Convert BST to Greater Tree med
//给一个二叉搜索树，将其转化成Greater Tree，从右侧开始，也就是最大值开始加；
//思路：利用BST中序历遍特性，只不过这次从最右开始，然后从最右侧开始依此回查找没到一个root的时候就给sum+=root.value；
		public TreeNode ConvertBST(TreeNode root)
        {
            traverse_ConvertBST(root);
            return root;
        }
        // 记录累加和
        int sum_traverse_ConvertBST = 0;
        void traverse_ConvertBST(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            traverse_ConvertBST(root.right);
            // 维护累加和
            sum_traverse_ConvertBST += root.val;
            // 将 BST 转化成累加树
            root.val = sum_traverse_ConvertBST;
            traverse_ConvertBST(root.left);
        }