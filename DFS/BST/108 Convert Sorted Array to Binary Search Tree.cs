//Leetcode 108 Convert Sorted Array to Binary Search Tree ez
//题意：将一个有序数组转换为一个平衡的二叉搜索树
//思路：深度优先搜索（DFS） BST 的特性，数组的中间元素作为根节点，并将数组分成左右两部分，分别递归地构建左子树和右子树
//时间复杂度:    n 是 BST 中的节点数, O(n)
//空间复杂度： h 是树的高度 O(h)
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            return BuildSortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode BuildSortedArrayToBST(int[] nums, int left, int right)
        {
            if(left > right)
                return null;
            int mid = left + right / 2;
            TreeNode root = new TreeNode(nums[mid]);
            root.left = BuildSortedArrayToBST(nums, left, mid - 1);
            root.right = BuildSortedArrayToBST(nums, mid + 1, right);
            return root;
        }