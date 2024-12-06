//Leetcode 998. Maximum Binary Tree II med
//题意：最大树是每个节点的值都大于其子树中任何其他值的一个树。
//给定root一棵最大二叉树和一个整数val。
//与上一个问题一样，给定的树是使用以下例程从列表a（ ）递归构建的：root = Construct(a)Construct(a)
//如果a为空，则返回null。
//否则，设a[i] 为 的最大元素a。创建一个root值为 的节点a[i]。
//的左孩子root将是Construct([a[0], a[1], ..., a[i - 1]])。
//的右子项root将是Construct([a[i + 1], a[i + 2], ..., a[a.length - 1]])。
//返回root。
//请注意，我们并没有直接给出a，只有一个根节点root = Construct(a)。
//假设b是 的副本，a并在其后附加了值val。保证b具有唯一值。
//返回Construct(b)。
//思路：递归方法
//先将root分解成list：In-order traversal - Left -> Root -> Right
//然后将val加入list后面；然后再建成treeNode
//找到list中最大的值，然后分成[0,i-1][i+1,len]递归然后一次分配
//时间复杂度：O(n)
//空间复杂度：O(n)
        public TreeNode InsertIntoMaxTree(TreeNode root, int val)
        {
            List<int> list = new List<int>();
            findArray(root, list);
            list.Add(val);
            return ConstructMaximumBinaryTree(list.ToArray());
        }

        private void findArray(TreeNode root, List<int> list)
        {
            if (root.left != null)
                findArray(root.left, list);            
            list.Add(root.val);
            if (root.right != null)
                findArray(root.right, list);
        }

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            return build_ConstructMaximumBinaryTree(nums, 0, nums.Length - 1);
        }
        public TreeNode build_ConstructMaximumBinaryTree(int[] nums, int low, int high)
        {
            // base case
            if (low > high)
            {
                return null;
            }

            // 找到数组中的最大值和对应的索引
            int index = -1, maxVal = Int32.MinValue;
            for (int i = low; i <= high; i++)
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
            root.left = build_ConstructMaximumBinaryTree(nums, low, index - 1);
            root.right = build_ConstructMaximumBinaryTree(nums, index + 1, high);

            return root;
        }