//Leetcode 938. Range Sum of BST ez
//题意：给定一个二叉搜索树（BST），以及一个范围 [low, high]，返回BST中所有值在 [low, high] 范围内的节点值之和。
//思路：BST，BST的性质是左子树节点的值小于根节点的值，右子树节点的值大于根节点的值。因此，我们可以通过深度优先搜索（DFS）遍历BST的所有节点，检查节点的值是否在指定的范围内，然后将符合条件的节点值累加。        
//时间复杂度: O(N)，其中N是BST的节点数量
//空间复杂度：BST可能是一个斜树，高度为N，因此空间复杂度为O(N)。在平均情况下，空间复杂度为O(logN)。
        public int RangeSumBST(TreeNode root, int low, int high)
        {
            if (root == null)
            {
                return 0;
            }

            int sum = 0;

            // 如果当前节点的值在指定范围内，则累加到结果中
            if (root.val >= low && root.val <= high)
            {
                sum += root.val;
            }

            // 递归遍历左子树和右子树
            sum += RangeSumBST(root.left, low, high);
            sum += RangeSumBST(root.right, low, high);

            return sum;
        }