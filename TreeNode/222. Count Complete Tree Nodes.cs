//222. Count Complete Tree Nodes med
//算出complete Tree Nodes所有节点数；
//思路：complete tree 是紧凑靠左排列的； 有两种情况，一种是满二叉数，就是每一个点都有左右两个分支，一种是左边全满，然后右边不满，所以先验算是否左右高度一样，一样就是满，不一样就要去左右查找，
		public int CountNodes(TreeNode root)
        {            
            TreeNode l = root, r = root;
            // 沿最左侧和最右侧分别计算高度
            int hl = 0, hr = 0;
            while (l != null)
            {
                l = l.left;
                hl++;
            }
            while (r != null)
            {
                r = r.right;
                hr++;
            }
            // 如果左右侧计算的高度相同，则是一棵满二叉树
            if (hl == hr)
            {
                return (int)Math.Pow(2, hl) - 1;
            }
            // 如果左右侧的高度不同，则按照普通二叉树的逻辑计算
            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }