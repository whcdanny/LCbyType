//106. Construct Binary Tree from Inorder and Postorder Traversal med
//给inorder和postorder的数组，推导出二叉树
//思路：根据postorder和inorder的逻辑，推断出postorder的第最后一位就是root，然后inorder里找到root的话，左边就是整个left，同理右边；所以首先找到root，然后从inorder里找出left和right，然后在递归；
//例如：		  56742      893         1                52647    1      839；
//postorder：  root.left rootright rootval； inorder:  root.left rootval rootright;
//注意：要给对区间位置；
		public TreeNode BuildTree_Inorder_and_Postorder(int[] inorder, int[] postorder)
        {
            int postLength = postorder.Length;
            int inLength = inorder.Length;
            return binaryTree_Inorder_and_Postorder(inorder, 0, inLength - 1, postorder, postLength - 1);
        }
        private TreeNode binaryTree_Inorder_and_Postorder(int[] inorder, int inStart, int inEnd, int[] postorder, int postEnd)
        {
            if (postEnd < 0 || inStart > inEnd)
            {
                return null;
            }
            // root 节点对应的值就是后序遍历数组的最后一个元素
            int rootVal = postorder[postEnd];
            // rootVal 在中序遍历数组中的索引
            int rootIndex = 0;
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == rootVal)
                {
					//找到rootval在inorder里的位置；
					//根据这个位置用来切割postorde；
                    rootIndex = i;
                    break;
                }
            }            
            TreeNode root = new TreeNode(rootVal);
            root.left = binaryTree_Inorder_and_Postorder(inorder, inStart, rootIndex - 1, postorder, postEnd - (inEnd - rootIndex) - 1);
            root.right = binaryTree_Inorder_and_Postorder(inorder, rootIndex + 1, inEnd, postorder, postEnd - 1);
            return root;
        }