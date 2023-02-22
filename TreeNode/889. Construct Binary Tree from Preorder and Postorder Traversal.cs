//889. Construct Binary Tree from Preorder and Postorder Traversal med
//给preorder和postorder的数组，推导出二叉树
//思路：通过preorder的第一位确定root，然后第二位必然是left的root，然后根据这个left的root，在postorder里找到这个值的位置，得出left的长度通过postorder，然后在切割preorder；
//例如：         1      25467      389                 56742      893         1 
//preorder： rootval root.left rootright； postorder：  root.left rootright rootval；
		public TreeNode ConstructFromPrePost(int[] preorder, int[] postorder)
        {
            int preLength = preorder.Length;
            int posLength = postorder.Length;
            return binaryTree_ConstructFromPrePost(preorder, 0, preLength - 1, postorder, 0, posLength - 1);
        }
        private TreeNode binaryTree_ConstructFromPrePost(int[] preorder, int preStart, int preEnd, int[] postorder, int posStart, int posEnd)
        {            
            if (preStart > preEnd)
            {
                return null;
            }
            if (preStart == preEnd)
            {
                return new TreeNode(preorder[preStart]);
            }

            // root 节点对应的值就是前序遍历数组的第一个元素
            int rootVal = preorder[preStart];
            // root.left 的值是前序遍历第二个元素
            // 通过前序和后序遍历构造二叉树的关键在于通过左子树的根节点
            // 确定 preorder 和 postorder 中左右子树的元素区间
            // leftRootVal 在后序遍历数组中的索引    
            int leftRootVal = preorder[preStart + 1];
            int index = 0;
            for (int i = posStart; i <= posEnd; i++)
            {
                if (postorder[i] == leftRootVal)
                {
                    //找到leftRootVal在postorder里的位置；
                    //根据这个位置用来切割preorder；
                    index = i;
                    break;
                }
            }                    
            // 左子树的元素个数
            int leftSize = index - posStart + 1;

            // 先构造出当前根节点
            TreeNode root = new TreeNode(rootVal);
            // 递归构造左右子树
            // 根据左子树的根节点索引和元素个数推导左右子树的索引边界
            root.left = binaryTree_ConstructFromPrePost(preorder, preStart + 1, preStart + leftSize,
                    postorder, posStart, index);
            root.right = binaryTree_ConstructFromPrePost(preorder, preStart + leftSize + 1, preEnd,
                    postorder, index + 1, posEnd - 1);

            return root;
        }