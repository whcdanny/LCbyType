//Leetcode 951 Flip Equivalent Binary Trees med 
//题意：给定两棵二叉树 root1 和 root2，可以对其中一个或两个进行翻转操作，判断它们是否相等。
//思路：DFS，判断不翻转左子树,翻转左子树
//时间复杂度: n 是二叉树中节点的个数, O(n)
//空间复杂度： O(n);
        public bool FlipEquiv(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null || root2 == null)
                return false;
            if (root1.val != root2.val)
                return false;
            return (FlipEquiv(root1.left, root2.left) && FlipEquiv(root1.right, root2.right)) 
                ||(FlipEquiv(root1.left, root2.right) && FlipEquiv(root1.right, root2.left));
        }