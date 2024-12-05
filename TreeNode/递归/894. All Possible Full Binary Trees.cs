//Leetcode 894. All Possible Full Binary Trees med
//题意：给定一个整数 n，返回所有可能的满二叉树，每棵树的节点值为 0。
//定义满二叉树是指每个节点要么有 0 个孩子，要么有 2 个孩子。树的节点数n 必须是奇数（因为满二叉树的节点数总是奇数）。
//需要构造出所有可能的树，并返回这些树的根节点列表。
//思路：递归方法
//如果是1一个就new TreeNode(0)；
//那就有左右子树
//leftSubtrees = GenerateFullBinaryTrees(i);
//rightSubtrees = GenerateFullBinaryTrees(n - i - 1);
//然后再先左中右开始
//时间复杂度：O(n)
//空间复杂度：O(logn)
        public IList<TreeNode> AllPossibleFBT(int n)
        {
            if (n % 2 == 0)
                return new List<TreeNode>();

            return GenerateFullBinaryTrees(n);
        }

        private IList<TreeNode> GenerateFullBinaryTrees(int n)
        {
            IList<TreeNode> result = new List<TreeNode>();

            if (n == 1)
            {
                result.Add(new TreeNode(0));
                return result;
            }

            for (int i = 1; i < n; i += 2)
            {
                IList<TreeNode> leftSubtrees = GenerateFullBinaryTrees(i);
                IList<TreeNode> rightSubtrees = GenerateFullBinaryTrees(n - i - 1);

                foreach (var leftSubtree in leftSubtrees)
                {
                    foreach (var rightSubtree in rightSubtrees)
                    {
                        TreeNode root = new TreeNode(0);
                        root.left = leftSubtree;
                        root.right = rightSubtree;
                        result.Add(root);
                    }
                }
            }

            return result;
        }