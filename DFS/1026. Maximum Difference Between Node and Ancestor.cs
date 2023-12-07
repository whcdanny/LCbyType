//Leetcode 1026. Maximum Difference Between Node and Ancestor med
//题意：给定一棵二叉树，每个节点的值都是唯一的正整数。返回任意两个不同节点值之间的最大差值，即最大的|node1.val - node2.val|，其中node1和node2是二叉树中的节点。
//思路：DFS（深度优先搜索）来遍历二叉树。在DFS的过程中，记录当前路径上的最大值和最小值。对于每个节点，计算当前节点值与当前路径上最大值和最小值的差值，并更新结果。递归地处理左子树和右子树。        
//时间复杂度: O(N)，其中N是二叉树中的节点数
//空间复杂度：O(H)，其中H是树的高度
        private int maxDifference_MaxAncestorDiff;
        public int MaxAncestorDiff(TreeNode root)
        {
            maxDifference_MaxAncestorDiff = 0;
            DFS_MaxAncestorDiff(root, root.val, root.val);
            return maxDifference_MaxAncestorDiff;
;
        }

        private void DFS_MaxAncestorDiff(TreeNode node, int maxAncestor, int minAncestor)
        {
            if (node == null)
                return;

            maxDifference_MaxAncestorDiff = Math.Max(maxDifference_MaxAncestorDiff, Math.Max(Math.Abs(node.val - maxAncestor), Math.Abs(node.val - minAncestor)));

            maxAncestor = Math.Max(maxAncestor, node.val);
            minAncestor = Math.Min(minAncestor, node.val);

            DFS_MaxAncestorDiff(node.left, maxAncestor, minAncestor);
            DFS_MaxAncestorDiff(node.right, maxAncestor, minAncestor);
        }