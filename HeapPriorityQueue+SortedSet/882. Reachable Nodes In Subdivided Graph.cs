//Leetcode 882. Reachable Nodes In Subdivided Graph hard
//题意：给定一个无向图（原始图），其中节点从 0 到 n - 1 标记。你决定将图中的每条边细分为一系列节点，每条边上的新节点数量因边而异。
//图用一组边的二维数组表示，其中 edges[i] = [ui, vi, cnti] 表示原始图中节点 ui 和 vi 之间有一条边，cnti 表示你将细分的新节点总数。注意，cnti == 0 表示你不会细分该边。
//要细分边[ui, vi]，将其替换为（cnti + 1）条新边和 cnti 个新节点。新节点是 x1、x2、...、xcnti，新边是[ui, x1]、[x1, x2]、[x2, x3]、...、[xcnti-1, xcnti]、[xcnti, vi]。
//在这个新图中，你想知道从节点 0 到达的节点数，其中节点可达的距离不超过 maxMoves。
//给定原始图和 maxMoves，返回新图中从节点 0 可达的节点数。
//思路：PriorityQueue + Dijkstra + BFS
//先建立图，点到点的上面的cont；
//pq存入 node和move
//每一次放入node，然后把剩余的move并按剩余移动数排序
//时间复杂度: O(E + V log V)
//空间复杂度：O(E + V)
        public int ReachableNodes(int[][] edges, int maxMoves, int n)
        {
            Dictionary<int, int>[] graph = new Dictionary<int, int>[n];

            for (int i = 0; i < n; i++)
            {
                graph[i] = new Dictionary<int, int>();
            }
            foreach (int[] edge in edges)
            {
                graph[edge[0]][edge[1]] = edge[2];
                graph[edge[1]][edge[0]] = edge[2];
            }
            bool[] visited = new bool[n];
            //node, moves
            PriorityQueue<(int, int), int> pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue((0, maxMoves), -maxMoves);
            int total = 1;
            while (pq.Count > 0)
            {
                (int val, int move) = pq.Dequeue();
                if (visited[val])
                {
                    total -= 1;
                    continue;
                }
                visited[val] = true;

                Dictionary<int, int> neighber = graph[val];
                foreach (int node in neighber.Keys)
                {
                    int count = neighber[node];
                    if (!visited[node] || count > 0)
                    {
                        if (count <= move)
                        {
                            if (count == move) 
                                total -= 1;
                            total += count + 1;
                            neighber[node] = 0;
                            graph[node][val] = 0;
                        }
                        else
                        {
                            total += move;
                            neighber[node] = count - move;
                            graph[node][val] = count - move;
                        }

                        if (move - count - 1 >= 0)
                            pq.Enqueue((node, move - count - 1), -(move - count - 1));
                    }
                }
            }

            return total;
        }