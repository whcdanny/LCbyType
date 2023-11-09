//Leetcode2385. Amount of Time for Binary Tree to Be Infected med
//题意：给定一个有根节点的二叉树，每个节点都有一个独特的编号。同时，给定一个二叉树节点表，表示起始感染的节点。如果一个节点被感染，它会感染其父节点和所有的子节点。在每个时间单位，感染会传播给未感染的相邻节点。请计算感染所有节点所需的最短时间。
//思路：我们可以使用BFS（广度优先搜索）,根据root先把他们做成一个graph，然后再根据这个graph，用BFS，将起始感染点放入queue，开始历遍直到所有root都被传染；
//时间复杂度: O(n)，其中n是树中的节点数
//空间复杂度：O(n)
        public int AmountOfTime(TreeNode root, int start)
        {            
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            BuildGraph(root, graph);

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);
            HashSet<int> visited = new HashSet<int>();
            visited.Add(start);
            int time = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    int node = queue.Dequeue();

                    foreach (int neighbor in graph[node])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
                time++;
            }

            return time;
        }

        private void BuildGraph(TreeNode node, Dictionary<int, List<int>> graph)
        {
            if (node == null)
            {
                return;
            }

            if (!graph.ContainsKey(node.val))
            {
                graph[node.val] = new List<int>();
            }

            if (node.left != null)
            {
                graph[node.val].Add(node.left.val);
                if (!graph.ContainsKey(node.left.val))
                {
                    graph[node.left.val] = new List<int>();
                }
                graph[node.left.val].Add(node.val);
                BuildGraph(node.left, graph);
            }

            if (node.right != null)
            {
                graph[node.val].Add(node.right.val);
                if (!graph.ContainsKey(node.right.val))
                {
                    graph[node.right.val] = new List<int>();
                }
                graph[node.right.val].Add(node.val);
                BuildGraph(node.right, graph);
            }
        }