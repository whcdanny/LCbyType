//Leetcode 2331. Evaluate Boolean Binary Tree ez
//题意：给定一个完全二叉树，其中叶节点的值为0或1，非叶节点的值为2（OR）或3（AND）。节点的评估基于其类型：对于叶节点，评估为节点本身的值（True或False）。对于非叶节点，评估其两个子节点并根据节点的值应用布尔操作。 
//思路：深度优先搜索 (DFS) 的方式       
//时间复杂度: O(N)，其中 N 是树中节点的数量，因为我们需要遍历每个节点。
//空间复杂度：O(H)，其中 H 是树的高度，表示递归调用的最大深度。
        public bool EvaluateTree(TreeNode root)
        {
            if (root == null)
            {
                return false;
            }
            return DFS_EvaluateTree(root);
        }

        private bool DFS_EvaluateTree(TreeNode node)
        {
            // 如果是叶节点，直接返回节点的值
            if (node.left == null && node.right == null)
            {
                return node.val == 1;
            }

            // 对于非叶节点，递归评估左右子节点
            bool leftValue = EvaluateTree(node.left);
            bool rightValue = EvaluateTree(node.right);

            // 根据节点的值进行布尔操作
            if (node.val == 2)
            {
                return leftValue || rightValue;
            }
            else
            {
                return leftValue && rightValue;
            }
        }