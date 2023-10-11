//Leetcode 285 Inorder Successor in BST mid
//题意：在一个二叉搜索树（BST）中找到给定节点的中序遍历的后一个节点
//思路：深度优先搜索（DFS） BST 的特性，如果节点 p 有右子树，则 p 的中序遍历的后继节点是其右子树中最左侧的节点。如果节点 p 没有右子树，那么它的后继节点在其祖先节点中，需要一直向上查找，直到找到一个节点 x，使得 p 在 x 的左子树中，那么 x 就是 p 的中序遍历的后继节点。
//时间复杂度:    n 是 BST 中的节点数, O(n)
//空间复杂度： h 是树的高度 O(h)
        public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
        {
            if (root == null || p == null)
                return null;
            if (p.right != null)
            {
                TreeNode res = p.right;
                while (p.left != null)
                {
                    res = p.left;
                }
                return res;
            }

            TreeNode cur = new TreeNode();
            while (root != null)
            {
                if (root.val > p.val)
                {
                    root = root.left;
                    cur = root;
                }
                else if (root.val < p.val)
                {
                    root = root.right;
                }
                else
                {
                    break;
                }
            }
            return cur;
        }