//Leetcode 2316. Count Unreachable Pairs of Nodes in an Undirected Graph med
//题意：给定一个无向图，包含n个节点和一些边。节点编号从0到n-1。定义一对节点(i, j)为“不可达对”，当且仅当从节点i到节点j不存在路径。你需要计算图中的不可达对的数量。
//思路：我们可以使用BFS来解决这个问题。首先，我们将图表示成邻接列表，然后对于每个节点i，我们从节点i开始进行BFS遍历，并记录可以到达的所有节点。
//时间复杂度: 构建邻接列表的时间复杂度为O(E)，其中E为边的数量。对于每个节点，进行一次BFS的时间复杂度为O(E)，因此总的时间复杂度为O(n*E)。
//空间复杂度：邻接列表的空间复杂度为O(E)，visited数组的空间复杂度为O(n)。
        public long CountPairs(int n, int[][] edges)
        {
            Dictionary<int, List<int>> adjacencyList = new Dictionary<int, List<int>>();
            var curNumberOfNodes = n;
            HashSet<int> visited = new HashSet<int>();            
            long res = 0;
            for(int i = 0; i < n; i++)
            {
                adjacencyList[i] = new List<int>();
            }
            foreach (var edge in edges)
            {                
                adjacencyList[edge[0]].Add(edge[1]);
                adjacencyList[edge[1]].Add(edge[0]);
            }
            
            for (int i = 0; i < n-1; i++)
            {
                if (visited.Contains(i))
                    continue;
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                
                int numberOfConnectedNodes = 1;
                visited.Add(i);                
                while (queue.Count > 0)
                {
                    int cur = queue.Dequeue();
                    foreach (var adj in adjacencyList[cur])
                    {
                        if (!visited.Contains(adj))
                        {
                            queue.Enqueue(adj);
                            visited.Add(adj);
                            numberOfConnectedNodes++;
                        }
                    }
                }
                curNumberOfNodes -= numberOfConnectedNodes;
                if(curNumberOfNodes>0)
                    res += curNumberOfNodes * (long)numberOfConnectedNodes;                
            }
            return res;
        }