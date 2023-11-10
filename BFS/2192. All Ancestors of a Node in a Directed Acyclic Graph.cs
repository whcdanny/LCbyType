//Leetcode 2192. All Ancestors of a Node in a Directed Acyclic Graph med
//题意：给定一个有向无环图（DAG）的节点数量 n 和边的集合 edges，其中 edges 表示图中的边，每个边由两个节点值构成，表示从一个节点到另一个节点的有向边。要求编写一个函数 GetAncestors，返回图中每个节点的所有祖先节点。具体而言，对于每个节点 i，返回一个列表，其中包含所有能够到达节点 i 的其他节点。
//思路：我们可以使用BFS来解决这个问题, 根据给定的边构建图, 然后从0开始查看 0可以达到的节点，然后根据每个达到的节点添加到ancestors；
//时间复杂度: 假设节点数为 n，边数为 m。构建图的时间复杂度为 O(m)，拓扑排序的时间复杂度为 O(n+m)，因此总的时间复杂度为 O(n+m)。
//空间复杂度：O(n+m)
        public IList<IList<int>> GetAncestors(int n, int[][] edges)
        {
            List<IList<int>> ancestors = new List<IList<int>>();
            List<int>[] adjs = new List<int>[n];           

            for (int i = 0; i < n; i++) //initialize adjacency list.
            {
                adjs[i] = new List<int>();
                ancestors.Add(new List<int>());
            }
            for (int i = 0; i < edges.Length; i++)
            {
                var edge = edges[i];
                int u = edge[0];
                int v = edge[1];
                adjs[u].Add(v);
            }

            for (int i = 0; i < n; i++) {
                Queue<int> queue = new Queue<int>();
                queue.Enqueue(i);
                HashSet<int> visited = new HashSet<int>();
                visited.Add(i);                
                while (queue.Count > 0)
                {
                    int cur = queue.Dequeue();                    
                    foreach(int adj in adjs[cur])
                    {                        
                        if (!visited.Contains(adj))
                        {
                            visited.Add(adj);
                            queue.Enqueue(adj);
                        }                            
                    }
                }
                for (int j = 0; j < n; j++)//once dfs is complete
                {
                    if (i != j && visited.Contains(j)) //check all the visited nodes.
                    {
                        ancestors[j].Add(i); //add them to the list of current node.
                    }
                }

            }
            return ancestors;
        }