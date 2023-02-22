//105. Construct Binary Tree from Preorder and Inorder Traversal med
//给preorder和inorder的数组，推导出二叉树
//思路：根据preorder和inorder的逻辑，推断出preodre的第一位就是root，然后inorder里找到root的话，左边就是整个left，同理右边；所以首先找到root，然后从inorder里找出left和right，然后在递归；
//例如：         1      25467      389                 52647     1     839；
//preorder： rootval root.left rootright； inorder:  root.left rootval rootright;
//
//注意：要给对区间位置；
		public TreeNode BuildTree_Inorder_and_Preorder(int[] preorder, int[] inorder)
        {
            int preLength = preorder.Length;
            int inLength = inorder.Length;
            return binaryTree_Inorder_and_Preorder(preorder, 0, preLength - 1, inorder, 0, inLength - 1);
        }
        private TreeNode binaryTree_Inorder_and_Preorder(int[] preorder, int preStart, int preEnd, int[] inorder, int inStart, int inEnd)
        {
            if (preStart > preEnd || inStart > inEnd)
            {
                return null;
            }
			// root 节点对应的值就是前序遍历数组的第一个元素
            int rootVal = preorder[preStart];
            // rootVal 在中序遍历数组中的索引
            int rootIndex = 0;
            for (int i = inStart; i <= inEnd; i++)
            {
                if (inorder[i] == rootVal)
                {
					//找到rootval在inorder里的位置；
					//根据这个位置用来切割preorder；
                    rootIndex = i;
                    break;
                }
            }
            int leftLength = rootIndex - inStart;
            TreeNode root = new TreeNode(rootVal);
            root.left = binaryTree_Inorder_and_Preorder(preorder, preStart + 1, preStart + leftLength, inorder, inStart, rootIndex - 1);
            root.right = binaryTree_Inorder_and_Preorder(preorder, preStart + leftLength + 1, preEnd, inorder, rootIndex + 1, inEnd);
            return root;
        }