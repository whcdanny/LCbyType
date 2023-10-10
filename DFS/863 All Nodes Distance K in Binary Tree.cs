//Leetcode 863 All Nodes Distance K in Binary Tree med
//题意：给定一个二叉树、一个目标节点 target 和一个整数 k，要求找出距离目标节点 target 为 k 的所有节点
//思路：深度优先搜索（DFS）和广度优先搜索（BFS）相结合的方法来解决，DFS）遍历二叉树，构建一个字典 parent_map，用于记录每个节点的父节点信息。（BFS）来查找距离目标节点 target 为 k 的所有节点。首先将 target 加入队列，并将其标记为已访问。在每一层中，遍历队列中的节点，并将它们的左右子节点加入队列，并标记为已访问。同时，查找在 parent_map 中记录的父节点，将其加入队列并标记为已访问。在每一层结束后，将 k 减一
//时间复杂度:   n 是二叉树中节点的个数, DFS的时间复杂度为 O(n),BFS的时间复杂度为 O(n)
//空间复杂度： O(n)
        public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
        {
            Dictionary<TreeNode, TreeNode> parent_Map = new Dictionary<TreeNode, TreeNode>();
            DistanceK_DFS(root, null, parent_Map);

            Queue<TreeNode> queue = new Queue<TreeNode>();
            HashSet<TreeNode> visited = new HashSet<TreeNode>();
            queue.Enqueue(target);
            visited.Add(target);

            while(k > 0 && queue.Count > 0)
            {
                int size = queue.Count;
                for(int i = 0; i < size; i++)
                {
                    TreeNode cur = queue.Dequeue();
                    if(cur.left!=null && !visited.Contains(cur.left))
                    {
                        queue.Enqueue(cur.left);
                        visited.Add(cur.left);
                    }
                    if (cur.right != null && !visited.Contains(cur.right))
                    {
                        queue.Enqueue(cur.right);
                        visited.Add(cur.right);
                    }
                    if (parent_Map.ContainsKey(cur) && !visited.Contains(parent_Map[cur]) && parent_Map[cur] != null)
                    {
                        queue.Enqueue(parent_Map[cur]);
                        visited.Add(parent_Map[cur]);
                    }
                }
                k--;
            }

            List<int> res = new List<int>();
            while (queue.Count > 0)
            {
                res.Add(queue.Dequeue().val);
            }
            return res;
        }
        private void DistanceK_DFS(TreeNode node, TreeNode parent, Dictionary<TreeNode, TreeNode> parent_map) 
        {
            if (node == null)
                return;

            parent_map[node] = parent;
            DistanceK_DFS(node.left, node, parent_map);
            DistanceK_DFS(node.right, node, parent_map);
        }