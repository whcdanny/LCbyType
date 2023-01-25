//104. Maximum Depth of Binary Tree ez
//找出最大路径
//思路1:历遍二叉树，然后进入一个节点depth++，离开的时候depth--；
		// 记录最大深度
        public int res = 0;
        // 记录遍历到的节点的深度
        public int depth = 0;

        // 主函数
        public int maxDepth(TreeNode root)
        {
            traverse(root);
            return res;
        }

        // 二叉树遍历框架
        public void traverse(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            // 前序位置
            depth++;
            if (root.left == null && root.right == null)
            {
                // 到达叶子节点，更新最大深度
                res = Math.Max(res, depth);
            }
            traverse(root.left);
            traverse(root.right);
            // 后序位置
            depth--;
        }
// 思路2：利用递归，计算每一个子树的左右最大深度；
        public int maxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            // 利用定义，计算左右子树的最大深度
            int leftMax = maxDepth(root.left);
            int rightMax = maxDepth(root.right);
            // 整棵树的最大深度等于左右子树的最大深度取最大值，
            // 然后再加上根节点自己
            int res = Math.Max(leftMax, rightMax) + 1;

            return res;
        }
		
		public int MaxDepth(TreeNode root) {
        if(root == null)
            return 0;
        return Math.Max(MaxDepth(root.left), MaxDepth(root.right))+1;
		}