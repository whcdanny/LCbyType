//Leetcode 2415. Reverse Odd Levels of Binary Tree med
//题意：给定一个二叉树，你需要反转所有奇数层的节点。
//思路：（DFS）遍历树的每一个节点，同时传递当前节点所在的层级。在奇数层级上，交换当前节点的左右子节点。
//时间复杂度: O(N)，其中 N 是树中的节点数量
//空间复杂度： O(logN)
        public TreeNode ReverseOddLevels(TreeNode root)
        {
            ReverseLevels(root.left, root.right, 1);
            return root;
        }


        private void ReverseLevels(TreeNode left, TreeNode right, int level)
        {
            if (left is null || right is null)
            {
                return;
            }

            if (level % 2 == 1)
            {
                var tmp = left.val;
                left.val = right.val;
                right.val = tmp;
            }

            ReverseLevels(left.left, right.right, level + 1);
            ReverseLevels(right.left, left.right, level + 1);
        }