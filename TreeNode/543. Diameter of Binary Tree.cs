//543. Diameter of Binary Tree	med
//最大直径的长度
//思路1：前序算法对每个点计算直径找出最大直径的长度	O(N^2)		
		// 记录最大直径的长度
        public int maxDiameter = 0;

        public int diameterOfBinaryTree(TreeNode root)
        {
            // 对每个节点计算直径，求最大直径
            traverse(root);
            return maxDiameter;
        }

        // 遍历二叉树
        public void traverse(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            // 对每个节点计算直径
            int leftMax = maxDepth(root.left);
            int rightMax = maxDepth(root.right);
            int myDiameter = leftMax + rightMax;
            // 更新全局最大直径
            maxDiameter = Math.Max(maxDiameter, myDiameter);//从头开始跟其他子树比较

            traverse(root.left);
            traverse(root.right);
        }

        // 计算二叉树的最大深度
        public int maxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftMax = maxDepth(root.left);
            int rightMax = maxDepth(root.right);
            return 1 + Math.Max(leftMax, rightMax);
        }
//思路2：后序算法 先走子树一直到底，然后算每一个子树当前的长度，然后再往回查找 O(N)
		public int maxDiameter = 0;

        public int DiameterOfBinaryTree(TreeNode root)
        {
            maxDepth(root);
            return maxDiameter;
        }

        public int maxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            int leftMax = maxDepth(root.left);
            int rightMax = maxDepth(root.right);
            // 后序位置，顺便计算最大直径
            int myDiameter = leftMax + rightMax;
            maxDiameter = Math.Max(maxDiameter, myDiameter);//从尾开始跟父一辈比较

            return 1 + Math.Max(leftMax, rightMax);
        }