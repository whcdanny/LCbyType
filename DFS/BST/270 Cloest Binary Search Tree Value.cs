//Leetcode 270 Cloest Binary Search Tree Value ez
//题意：在一个二叉搜索树中找到最接近给定值 target 的节点值
//思路：深度优先搜索（DFS） BST 的特性，根据 BST 的性质，如果目标值 target 小于当前节点的值，则继续搜索左子树；如果大于当前节点的值，则继续搜索右子树。
//时间复杂度:    n 是 BST 中的节点数, O(log n)
//空间复杂度： h 是树的高度 O(h)
        public int ClosestValue(TreeNode root, double target)
        {
            int closest = root.val;

            while (root != null)
            {
                if (Math.Abs(target - root.val) < Math.Abs(target - closest))
                {
                    closest = root.val;
                }
                root = target < root.val ? root.left : root.right;
            }
            return closest;
        }