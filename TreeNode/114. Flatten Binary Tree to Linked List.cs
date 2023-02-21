//114. Flatten Binary Tree to Linked List med
//给一个二叉树，然后将它展开成一个单链表，
//    1				1
//	2	5			 2
//3	 4    6			  3
//					   4
//					    5
//                       6
//思路：利用定义，把左右子树拉平，左右子树已经被拉平成一条链表，将左子树作为右子树，将原先的右子树接到当前右子树的末端
		public void Flatten(TreeNode root)
        {            
            // base case
            if (root == null) return;

            // 利用定义，把左右子树拉平
            Flatten(root.left);
            Flatten(root.right);

            /**** 后序遍历位置 ****/
            // 1、左右子树已经被拉平成一条链表
            TreeNode left = root.left;
            TreeNode right = root.right;

            // 2、将左子树作为右子树
            root.left = null;
            root.right = left;

            // 3、将原先的右子树接到当前右子树的末端
            TreeNode p = root;
            while (p.right != null)
            {
                p = p.right;
            }
            p.right = right;
        }
	
		public void Flatten(TreeNode root)
        {
            if (root == null)
                return;
            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(root);

            while (s.Count != 0)
            {
                TreeNode cur = s.Pop();
                if (cur.left != null)
                {
                    TreeNode next = cur.left;
                    while (next.right != null)
                    {
                        next = next.right;
                    }
                    next.right = cur.right;
                    cur.right = cur.left;
                    cur.left = null;
                }
                if (cur.right != null)
                {
                    s.Push(cur.right);
                }
            }            
        }