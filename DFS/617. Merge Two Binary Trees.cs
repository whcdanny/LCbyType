//Leetcode 617. Merge Two Binary Trees ez
//题意：给定两个二叉树，将它们合并成一个新的二叉树。合并规则是，如果两个节点重叠，将它们的值相加；否则，取非空节点的值。
//思路：DFS）遍历两个二叉树的对应节点，并将它们合并
//时间复杂度: O(n)，其中 n 为节点总数
//空间复杂度：O(h)，其中 h 为二叉树的高度。
        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
            {
                return null;
            }

            int val = (t1 == null ? 0 : t1.val) + (t2 == null ? 0 : t2.val);
            TreeNode newNode = new TreeNode(val);

            newNode.left = MergeTrees(t1?.left, t2?.left);
            newNode.right = MergeTrees(t1?.right, t2?.right);

            return newNode;
        }