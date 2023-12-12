//Leetcode 652. Find Duplicate Subtrees med
//题意：给定一个二叉树，寻找所有重复的子树。一棵重复子树意味着在整棵树中有两个（或以上）完全相同的子树。
//思路：DFS 遍历二叉树，使用哈希表（Dictionary）记录每个子树的出现次数。对于每个子树，使用序列化的方式表示，例如使用先序遍历序列化，将每个子树的序列化字符串作为 key，出现次数作为 value。当某个子树的出现次数达到 2 时，将其添加到结果集中。
//时间复杂度: O(n)
//空间复杂度：O(n)
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            List<TreeNode> result = new List<TreeNode>();
            Dictionary<string, int> subtreeCount = new Dictionary<string, int>();
            DFS_SerializeAndCount(root, subtreeCount, result);
            return result;
        }

        private string DFS_SerializeAndCount(TreeNode node, Dictionary<string, int> subtreeCount, List<TreeNode> result)
        {
            if (node == null) return "#";

            StringBuilder sb = new StringBuilder();
            sb.Append(node.val);
            sb.Append(",");
            sb.Append(DFS_SerializeAndCount(node.left, subtreeCount, result));
            sb.Append(",");
            sb.Append(DFS_SerializeAndCount(node.right, subtreeCount, result));

            string serializedTree = sb.ToString();

            if (!subtreeCount.ContainsKey(serializedTree))
            {
                subtreeCount[serializedTree] = 1;
            }
            else
            {
                subtreeCount[serializedTree]++;
                if (subtreeCount[serializedTree] == 2)
                {
                    result.Add(node);
                }
            }

            return serializedTree;
        }