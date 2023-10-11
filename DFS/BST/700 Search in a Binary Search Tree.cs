//Leetcode 700 Search in a Binary Search Tree ez
//题意：一个二叉搜索树（BST）中查找一个给定值 val 是否存在
//思路：深度优先搜索（DFS） BST 的特性，如果当前节点的值等于目标值 val，则找到了目标值，返回当前节点。如果目标值小于当前节点的值，则继续在左子树中查找。如果目标值大于当前节点的值，则继续在右子树中查找。
//时间复杂度:    n 是 BST 中的节点数, O(log n)
//空间复杂度： h 是树的高度 O(h)
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;

            if (root.val == val) return root;

            if (val < root.val)
            {
                return SearchBST(root.left, val);
            }
            else
            {
                return SearchBST(root.right, val);
            }
        }