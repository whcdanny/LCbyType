//Leetcode 1315. Sum of Nodes with Even-Valued Grandparent med
//题意：这是一道关于二叉树的问题。题目要求计算具有偶数值祖父节点的节点值之和。
//思路：如果当前节点为空，返回 0。如果存在祖父节点且祖父节点的值为偶数，累加当前节点的值到结果。递归处理左子树和右子树，传递当前节点作为父节点，传递父节点作为祖父节点。
//时间复杂度: O(N)，其中 N 是二叉树的节点数，因为每个节点只会被访问一次
//空间复杂度： O(H)，其中 H 是二叉树的高度
        public int SumEvenGrandparent(TreeNode root)
        {
            return DFS_SumEvenGrandparent(root, null, null);
        }

        private int DFS_SumEvenGrandparent(TreeNode node, TreeNode parent, TreeNode grandparent)
        {
            if (node == null)
            {
                return 0;
            }

            int sum = 0;

            if (grandparent != null && grandparent.val % 2 == 0)
            {
                sum += node.val;
            }

            sum += DFS_SumEvenGrandparent(node.left, node, parent);
            sum += DFS_SumEvenGrandparent(node.right, node, parent);

            return sum;
        }