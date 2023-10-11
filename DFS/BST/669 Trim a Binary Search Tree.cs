//Leetcode 669 Trim a Binary Search Tree med
//题意：修剪一个二叉搜索树，使得所有节点的值都在给定的范围 [low, high] 内
//思路：深度优先搜索（DFS） BST 的特性，如果根节点的值小于 low，那么根节点及其左子树都不在范围内，需要修剪左子树，并返回修剪后的右子树。如果根节点的值大于 high，那么根节点及其右子树都不在范围内，需要修剪右子树，并返回修剪后的左子树。如果根节点的值在范围内，那么分别递归修剪左子树和右子树，并将修剪后的左子树和右子树连接到根节点。
//时间复杂度:    n 是 BST 中的节点数, O(n)
//空间复杂度： h 是树的高度 O(h)
        public TreeNode TrimBST(TreeNode root, int low, int high)
        {
            if (root == null)
                return null;
            if (root.val < low)
            {
                return TrimBST(root.right, low, high);
            }
            else if (root.val > high)
            {
                return TrimBST(root.left, low, high);
            }
            else
            {
                root.left = TrimBST(root.left, low, high);
                root.right = TrimBST(root.right, low, high);
                return root;
            }
        }