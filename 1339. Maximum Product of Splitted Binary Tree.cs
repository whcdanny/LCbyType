
//C#
		static long MAX_PRODUCT = 0;
        static long totalSum = 0;

        public static int maxProduct(TreeNode root)
        {
            MAX_PRODUCT = 0;

            // Get complete tree sum
            totalSum = subTreeSum(root);

            // Now we have whole tree sum, Now let's calculate
            subTreeSum(root);

            return (int)(MAX_PRODUCT % (int)(1e9 + 7));
        }

        public static long subTreeSum(TreeNode root)
        {
            if (root == null) return 0;
            long result = root.val + subTreeSum(root.left) + subTreeSum(root.right);

            // Since result is our subtree Sum we can get the product.
            MAX_PRODUCT = Math.Max(MAX_PRODUCT, result * (totalSum - result));
            return result;
        }