//Leetcode 968. Binary Tree Camerasl hard
//题意：给定一个二叉树，要求在二叉树的节点上放置监视器，使得整个二叉树都被监控到。监视器可以放在任何节点上，也可以不放。
//每个节点上有三种状态：
//0：表示该节点未被监控，但其子节点被监控。
//1：表示该节点被监控。
//2：表示该节点未被监控，且其子节点未被监控。  
//思路：DFS递归遍历二叉树的每个节点，并返回该节点的状态。节点的状态有三种：0 表示被监视，1 表示已经放置了监视器，2 表示未被监视。每个节点，递归处理其左右子节点，返回当前节点的状态。
//注：其实是把状态告诉上一级；让他们做决策；告诉上一级你将处于什么状态；当前节点状态为 2 时，说明当前节点是叶子节点，需要父节点来监视，因此父亲节点将 count_MinCameraCover 增加，并返回 1 表示父节点已经监视。
//当前节点状态为 1 时，说明当前节点已经被监视，返回 0 表示已经覆盖。
//当前节点状态为 0 时，说明当前节点已经被覆盖，返回 2 表示是一个叶子节点
//时间复杂度: O(N)，其中N是二叉树中的节点数
//空间复杂度：O(H)，其中H是树的高度。     
        private int count_MinCameraCover;
        public int MinCameraCover(TreeNode root)
        {
            count_MinCameraCover = 0;
            if (DFS_MinCameraCover(root) > 1) count_MinCameraCover++;
            return count_MinCameraCover;            
        }
        public int DFS_MinCameraCover(TreeNode node)
        {
            //0 表示被监视，1 表示已经放置了监视器，2 表示未被监视。
            if (node is null) return 0; // covered

            int left = DFS_MinCameraCover(node.left);
            int right = DFS_MinCameraCover(node.right);

            if (left == 2 || right == 2) // leaves
            {
                count_MinCameraCover++; // cover by parent
                return 1; // parent
            }

            return (left == 1 || right == 1) ? 0 : 2; // if parents, then covered, else leaves
        }