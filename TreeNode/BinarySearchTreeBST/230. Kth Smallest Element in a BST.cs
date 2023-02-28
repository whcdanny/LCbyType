//230. Kth Smallest Element in a BST med
//给一个二叉搜索树，找到第k个的最小元素；
//思路：用BST中中序遍历，因为左边用于小于root，所以先从左边开始遍历，然后中序遍历看位置，如果是k，则输出当前root值
		public int KthSmallest(TreeNode root, int k)
        {            
            // 利用 BST 的中序遍历特性
            traverse_KthSmallest(root, k);
            return res_KthSmallest;
        }
        // 记录结果
        int res_KthSmallest = 0;
        // 记录当前元素的排名
        int rank = 0;
        void traverse_KthSmallest(TreeNode root, int k)
        {
            if (root == null)
            {
                return;
            }
            traverse_KthSmallest(root.left, k);
            /* 中序遍历代码位置 */
            rank++;
            if (k == rank)
            {
                // 找到第 k 小的元素
                res_KthSmallest = root.val;
                return;
            }
            /*****************/
            traverse_KthSmallest(root.right, k);
        }
//思路：思路同上，只不存如stack，然后当pop到k的时候，输出当前root值		
		public int KthSmallest(TreeNode root, int k)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (true)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = root.left;
                }
                root = stack.Pop();
                if (--k == 0)
                    return root.val;
                root = root.right;
            }            
        }