//Leetcode 235. Lowest Common Ancestor of a Binary Search Tree med 
//题意：给定一个二叉搜索树（BST）以及两个节点 p 和 q，要求找到它们的最低公共祖先
//思路：DFS，由于这是一个二叉搜索树，它具有以下性质,左子树的节点值都小于根节点的值。右子树的节点值都大于根节点的值。如果 p 和 q 的值都小于当前节点的值，说明它们都在当前节点的左子树中，因此继续在左子树中寻找最低公共祖先。如果 p 和 q 的值都大于当前节点的值，说明它们都在当前节点的右子树中，因此继续在右子树中寻找最低公共祖先。如果 p 和 q 的值一个大于当前节点的值，一个小于当前节点的值，那么当前节点就是它们的最低公共祖先。
//时间复杂度:  h 是树的高度, O(h)
//空间复杂度： O(1);
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            while (root != null)
            {
                if (p.val < root.val && q.val < root.val)
                {
                    root = root.left;
                }
                else if (p.val > root.val && q.val > root.val)
                {
                    root = root.right;
                }
                else
                    return root;

            }
            return null;
        }