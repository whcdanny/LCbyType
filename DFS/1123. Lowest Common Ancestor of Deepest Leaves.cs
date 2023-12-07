//Leetcode 1123. Lowest Common Ancestor of Deepest Leaves med
//题意：给定二叉树的根节点，返回其最深的叶子节点的最低共同祖先。        
//二叉树的节点是叶子节点，当且仅当它没有子节点。
//树根的深度为0，如果一个节点的深度为d，则其每个子节点的深度为d + 1。
//一组节点S的  共同祖先是具有最大深度的节点A，使得S中的每个节点都在以A为根
//思路：DFS, 最深叶子节点的深度，以及包含这些叶子节点的最低共同祖先。使用DFS（深度优先搜索）来遍历整个二叉树，记录每个节点的深度。在DFS的过程中，比较左子树和右子树的深度，选择较深的一侧进行继续DFS。当左右子树的深度相等时，当前节点即为最深叶子节点的最低共同祖先。返回最深叶子节点的深度和最低共同祖先。
//注：其实就是先找最深的left和right，一旦找到了就直接返回当前root；
//时间复杂度: O(N)，其中 N 是二叉树中的节点数。
//空间复杂度：O(N)，其中 N 是二叉树中的节点数。
        public TreeNode LcaDeepestLeaves(TreeNode root)
        {
            if (root == null)
                return null;

            int leftDepth = GetDepth_LcaDeepestLeaves(root.left);
            int rightDepth = GetDepth_LcaDeepestLeaves(root.right);

            if (leftDepth == rightDepth)
                return root;

            return leftDepth > rightDepth ? LcaDeepestLeaves(root.left) : LcaDeepestLeaves(root.right);
        }

        private int GetDepth_LcaDeepestLeaves(TreeNode node)
        {
            if (node == null)
                return 0;

            return 1 + Math.Max(GetDepth_LcaDeepestLeaves(node.left), GetDepth_LcaDeepestLeaves(node.right));
        }