//Leetcode 337. House Robber III med
//题意：给定一棵二叉树，其中每个节点都表示一个房屋，节点的值表示该房屋中的金额。不能同时抢劫相邻的房屋（父子节点直接相连的房屋不能同时抢劫）。求解在不触发警报的情况下，能够抢到的最大金额。
//装满任意一个水壶。清空任意一个水壶。从一个水壶向另一个水壶倒水，直到装满或倒空。
//思路：DFS,动态规划问题。 对于每个节点，有两种选择：抢劫该节点或者不抢劫。因此，需要计算两个值：抢劫该节点的最大金额：当前节点的值加上不抢劫左右子节点的最大金额。不抢劫该节点的最大金额：左右子节点的最大金额之和        
//注：当不抢当前节点，也需要左右子节点中的最大金额而不能只算0（表示子节点偷了）的而不算1（表示子节点不偷）；
//时间复杂度: O(N)，其中 N 是二叉树的节点数量。
//空间复杂度：O(H)，其中H 是二叉树的高度。
        public int Rob(TreeNode root)
        {
            int[] result = RobSub(root);
            return Math.Max(result[0], result[1]);
        }

        private int[] RobSub(TreeNode root)
        {
            if (root == null)
            {
                return new int[] { 0, 0 };
            }

            int[] left = RobSub(root.left);
            int[] right = RobSub(root.right);

            // 抢劫该节点
            int rob = root.val + left[1] + right[1];

            // 不抢劫该节点，取左右子节点中的最大金额
            int notRob = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);

            return new int[] { rob, notRob };
        }