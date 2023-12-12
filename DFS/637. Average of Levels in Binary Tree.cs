//Leetcode 637. Average of Levels in Binary Tree ez
//题意：给定一个二叉树，返回每一层节点值的平均值。
//思路：DFS 同时记录每个节点所在的层数和每层的节点值之和。遍历完成后，计算每一层的平均值，并将结果存储在列表中。
//时间复杂度: O(n)
//空间复杂度：O(h)，其中 h 为二叉树的高度
        public IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> averages = new List<double>();
            List<int> counts = new List<int>();

            DFS_CalculateAverages(root, 0, averages, counts);

            for (int i = 0; i < averages.Count; i++)
            {
                averages[i] /= counts[i];
            }

            return averages;
        }

        private void DFS_CalculateAverages(TreeNode node, int level, List<double> averages, List<int> counts)
        {
            if (node == null) return;

            if (level < averages.Count)
            {
                averages[level] += node.val;
                counts[level]++;
            }
            else
            {
                averages.Add(node.val);
                counts.Add(1);
            }

            DFS_CalculateAverages(node.left, level + 1, averages, counts);
            DFS_CalculateAverages(node.right, level + 1, averages, counts);
        }