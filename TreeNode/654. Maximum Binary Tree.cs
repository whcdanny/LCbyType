//654. Maximum Binary Tree med
//给我一个不重复的数组，然后根据数组建立一个二叉树
//思路：先从数组中找到当前的最大数值，然后左边的数组就是这个树的left，同理右边一样；
		public TreeNode constructMaximumBinaryTree(int[] nums)
        {
            return build(nums, 0, nums.Length - 1);
        }

        // 定义：将 nums[lo..hi] 构造成符合条件的树，返回根节点
        public TreeNode build(int[] nums, int lo, int hi)
        {
            // base case
            if (lo > hi)
            {
                return null;
            }

            // 找到数组中的最大值和对应的索引
            int index = -1, maxVal = Int32.MinValue;
            for (int i = lo; i <= hi; i++)
            {
                if (maxVal < nums[i])
                {
                    index = i;
                    maxVal = nums[i];
                }
            }

            // 先构造出根节点
            TreeNode root = new TreeNode(maxVal);
            // 递归调用构造左右子树
            root.left = build(nums, lo, index - 1);
            root.right = build(nums, index + 1, hi);

            return root;
        }