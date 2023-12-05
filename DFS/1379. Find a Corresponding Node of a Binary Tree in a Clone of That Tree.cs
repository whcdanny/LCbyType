//Leetcode 1379. Find a Corresponding Node of a Binary Tree in a Clone of That Tree ez
//题意：给定两个二叉树original，并给出对原始树中cloned节点的引用。target树cloned是树的副本original。返回对树中同一节点的引用cloned。请注意，您不允许更改两棵树或target节点中的任何一个，并且答案必须是对树中节点的引用cloned。
//思路：DFS, 递归地遍历原始树和克隆树。如果当前节点为目标节点 target，则返回克隆树中相应的节点。否则，在左子树和右子树中查找目标节点。
//时间复杂度: O(n)，其中 n 是二叉树中的节点数。需要遍历整个二叉树
//空间复杂度： O(h)，其中 h 是二叉树的高度。递归调用的栈深度取决于二叉树的高度。在最坏情况下，二叉树退化为链表，高度为 n。
        public TreeNode GetTargetCopy(TreeNode original, TreeNode cloned, TreeNode target)
        {
            if (original == null || cloned == null)
            {
                return null;
            }

            if (original == target)
            {
                return cloned;
            }

            TreeNode leftResult = GetTargetCopy(original.left, cloned.left, target);
            TreeNode rightResult = GetTargetCopy(original.right, cloned.right, target);

            return leftResult ?? rightResult;
        }