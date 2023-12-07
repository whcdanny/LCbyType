//Leetcode 1161. Maximum Level Sum of a Binary Tree med
//题意：给定一个二叉树的根节点 root，找到具有最大和的层。如果两个层具有相同的和，则返回其中最小的层。
//思路：DFS, 把每一个level的sum算出，然后找到最大值；
//时间复杂度: O(N)，其中 N 是二叉树中的节点数。
//空间复杂度：O(N)，其中 N 是二叉树中的节点数。
        public int MaxLevelSum(TreeNode root)
        {
            Dictionary<int, int> levelSum = new Dictionary<int, int>();
            DFS_MaxLevelSum(1, levelSum, root);
            return levelSum.Where(x => x.Value == levelSum.Values.Max()).First().Key;
        }
        public static void DFS_MaxLevelSum(int level, Dictionary<int, int> levelSum, TreeNode node)
        {
            if (node == null) return;
            if (levelSum.ContainsKey(level)) levelSum[level] += node.val;
            else levelSum.Add(level, node.val);
            DFS_MaxLevelSum(level + 1, levelSum, node.left);
            DFS_MaxLevelSum(level + 1, levelSum, node.right);
        }