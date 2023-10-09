//Leetcode 236 Lowest Common Ancestor of a Binary Tree med 
//题意：给定一个二叉树以及两个节点 p 和 q，要求找到它们的最低公共祖先
//思路：DFS，递归终止条件，即如果 root 为空或者等于 p 或 q，则直接返回 root。然后递归地在左子树和右子树中寻找目标节点 p 和 q。如果左子树返回的结果不为空且右子树返回的结果也不为空，则说明 p 和 q 分别位于当前节点的左右子树中，那么当前节点就是它们的最低公共祖先。如果左子树返回的结果为空，则说明 p 和 q 都在右子树中，那么返回右子树的结果即可。反之亦然。
//时间复杂度:  n 是二叉树中节点的个数, O(n)
//空间复杂度： O(n);
        public TreeNode LowestCommonAncestor_236(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q) return root;

            TreeNode left = LowestCommonAncestor_236(root.left, p, q);
            TreeNode right = LowestCommonAncestor_236(root.right, p, q);

            if (left != null && right != null) return root;
            return left != null ? left : right;
        }