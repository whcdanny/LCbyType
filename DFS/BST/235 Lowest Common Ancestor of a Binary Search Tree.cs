//Leetcode 235 Lowest Common Ancestor of a Binary Search Tree med
//题意：一个二叉搜索树（BST）中找到两个给定节点的最低公共祖先（LCA）
//思路：深度优先搜索（DFS） BST 的特性，如果 p 和 q 的值都小于当前节点的值，说明 p 和 q 都在当前节点的左子树中，因此继续在左子树中寻找最低公共祖先。如果 p 和 q 的值都大于当前节点的值，说明 p 和 q 都在当前节点的右子树中，因此继续在右子树中寻找最低公共祖先。如果 p 和 q 的值分别小于和大于当前节点的值，说明当前节点就是最低公共祖先。
//时间复杂度:    n 是 BST 中的节点数, O(log n)
//空间复杂度： h 是树的高度 O(h)
        public TreeNode LowestCommonAncestor_235(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root.val > p.val && root.val > q.val)
            {
                return LowestCommonAncestor_235(root.left, p, q);
            }
            else if (root.val < p.val && root.val < q.val)
            {
                return LowestCommonAncestor_235(root.right, p, q);
            }
            else
            {
                return root;
            }
        }
public TreeNode LowestCommonAncestor1(TreeNode root, TreeNode p, TreeNode q)
{
    if (root.val > p.val && root.val > q.val)
    {
        return LowestCommonAncestor1(root.left, p, q);
    }
    else if (root.val < p.val && root.val < q.val)
    {
        return LowestCommonAncestor1(root.right, p, q);
    }
    else
    {
        return root;
    }
}