//Leetcode 687. Longest Univalue Path med
//题意：给定一个二叉树，找到最长的同值路径的长度。同值路径是指一个路径中所有节点的值都相同。
//思路：（DFS）来解决。我们可以从根节点开始递归地检查每个节点，更新最长同值路径的长度。
//在递归过程中，我们需要维护两个信息：    
//当前节点值相同的路径长度（当前路径长度）： 以当前节点为根节点，向左或向右的最长同值路径的长度。这是通过递归调用获取的。
//当前节点作为路径中的连接点的路径长度（连接路径长度）： 以当前节点为根节点，同时向左和向右的最长同值路径的长度。这是通过将左右子树的当前路径长度相加获得的。
//注：因为最长路径不一定从顶点出发，所以从下往上递归的时候要算每一个跟left和right的value是否相同，并实时更新；
//时间复杂度： O(N)，其中 N 是二叉树中的节点数
//空间复杂度： O(H)，其中 H 是二叉树的高度
        private int maxPathLength_LongestUnivaluePath;
        public int LongestUnivaluePath(TreeNode root)
        {
            maxPathLength_LongestUnivaluePath = 0;
            DFS_LongestUnivaluePath(root);
            return maxPathLength_LongestUnivaluePath;
        }

        private int DFS_LongestUnivaluePath(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int leftLength = DFS_LongestUnivaluePath(node.left);
            int rightLength = DFS_LongestUnivaluePath(node.right);

            int leftPathLength = 0;
            int rightPathLength = 0;

            if (node.left != null && node.left.val == node.val)
            {
                leftPathLength = leftLength + 1;
            }

            if (node.right != null && node.right.val == node.val)
            {
                rightPathLength = rightLength + 1;
            }

            maxPathLength_LongestUnivaluePath = Math.Max(maxPathLength_LongestUnivaluePath, leftPathLength + rightPathLength);

            return Math.Max(leftPathLength, rightPathLength);
        }