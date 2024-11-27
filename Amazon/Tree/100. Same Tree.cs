//Leetcode 100. Same Tree ez
//题意：给定两个二叉树的根p和q，编写一个函数来检查它们是否相同。
//如果两棵二叉树结构相同，且节点具有相同的值，则认为它们相同。
//思路：递归比较左右枝
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
            {
                return true;
            }

            if (p == null || q == null)
            {
                return false;
            }

            return p.val == q.val
                   && IsSameTree(p.left, q.left)
                   && IsSameTree(p.right, q.right);
        }