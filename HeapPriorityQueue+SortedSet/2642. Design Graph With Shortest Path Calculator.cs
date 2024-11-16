//Leetcode 2642. Design Graph With Shortest Path Calculator hard
//题意：有一个有向加权图，由n个从0到n-1编号的节点组成。图的边最初由给定的数组edges表示，其中edges[i] = [fromi, toi, edgeCosti]表示从fromi到toi有一条边，成本为edgeCosti。
//实现Graph类：
//Graph(int n, int[][] edges)：使用n个节点和给定的边数组初始化对象。
//addEdge(int[] edge)：向边的列表中添加一条边，其中edge = [from, to, edgeCost]。添加新边之前保证两个节点之间没有边。
//int shortestPath(int node1, int node2)：返回从node1到node2的最小路径成本。如果不存在路径，返回-1。路径的成本是路径中所有边的成本之和。
//思路：PriorityQueue + BFS        
//用PriorityQueue 可以找到最短Shortest Path
//这里还需要用到BFS，这样就可以历遍所有跟寻找的node1到node2的最短距离；
//时间复杂度：O(V + E)
//空间复杂度：O(V + E)
        public class Graph
        {
            private readonly int m_n;
            private readonly List<(int node, int cost)>[] m_graph;

            public Graph(int n, int[][] edges)
            {
                m_n = n;
                m_graph = new List<(int node, int cost)>[n];
                for (int i = 0; i < n; i++)
                    m_graph[i] = new List<(int node, int cost)>();
                foreach (var edge in edges)
                    AddEdge(edge);
            }

            public void AddEdge(int[] edge)
            {
                m_graph[edge[0]].Add((edge[1], edge[2]));
            }

            //BFS
            public int ShortestPath(int node1, int node2)
            {                
                var visited = new bool[m_n];
                var queue = new PriorityQueue<int, int>();
                queue.Enqueue(node1, 0);

                while (queue.TryDequeue(out int currNode, out int currCost))
                {
                    if (visited[currNode]) continue;
                    if (currNode == node2) return currCost;
                    visited[currNode] = true;

                    foreach (var next in m_graph[currNode])
                    {
                        queue.Enqueue(next.node, next.cost + currCost);
                    }
                }

                return -1;
            }
        }