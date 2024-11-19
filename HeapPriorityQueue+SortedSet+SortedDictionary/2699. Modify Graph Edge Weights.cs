//Leetcode 2699. Modify Graph Edge Weights hard
//题意：给定一个包含n个节点（标记为0到n-1）的无向加权连通图，以及一个整数数组edges，其中edges[i] = [ai, bi, wi]表示节点ai和bi之间有一条权重为wi的边。
//一些边的权重为-1（wi = -1），而其他的边的权重为正数（wi > 0）。
//你的任务是将所有权重为-1的边进行修改，将它们的权重赋值为范围[1, 2 * 10 ^ 9] 内的正整数，使得从源节点到目标节点的最短距离等于一个整数目标值。如果存在多个修改方案使得从源节点到目标节点的最短距离等于目标值，则任何一个都被认为是正确的。
//如果可能使得从源节点到目标节点的最短距离等于目标值，返回一个包含所有边（即使是未修改的边）的数组，否则返回一个空数组。
//注意：不允许修改初始正权重边的权重。
//思路：PriorityQueue+Dijkstra
//
//时间复杂度：O(n^4)
//空间复杂度：O(n^2)
        public int[][] ModifiedGraphEdges(int n, int[][] edges, int source, int destination, int target)
        {
            HashSet<int>[] map = BuildMap_ModifiedGraphEdges(n, edges);
            int[] distances = new int[n];
            Array.Fill(distances, 1000000001);
            addDistance(map, edges, distances, source, 0);
            int edge = -1;
            while (distances[destination] > target)
            {
                ++edge;
                if (edge >= edges.Length)
                {
                    break;
                }
                if (edges[edge][2] < 0)
                {
                    edges[edge][2] = 1;
                    map[edges[edge][0]].Add(edge);
                    map[edges[edge][1]].Add(edge);
                    addDistance(map, edges, distances, edges[edge][0], distances[edges[edge][1]] + 1);
                    addDistance(map, edges, distances, edges[edge][1], distances[edges[edge][0]] + 1);
                }
            }
            if ((edge < 0 && distances[destination] < target) || distances[destination] > target)
            {
                return new int[][] { };
            }
            else if (edge >= 0 && edge < edges.Length)
            {
                edges[edge][2] += target - distances[destination];
            }
            ++edge;
            while (edge < edges.Length)
            {
                if (edges[edge][2] < 0)
                {
                    edges[edge][2] = 2000000000;
                }
                ++edge;
            }
            return edges;
        }

        private void addDistance(HashSet<int>[] map, int[][] edges, int[] distances, int start, int startDist)
        {
            PriorityQueue<(int node, int dist), int> pq = new PriorityQueue<(int, int), int>();
            pq.Enqueue((start, startDist), startDist);
            int curr, next, dist;
            while (pq.Count > 0)
            {
                curr = pq.Peek().node;
                dist = pq.Peek().dist;
                pq.Dequeue();
                if (distances[curr] <= dist)
                {
                    continue;
                }
                distances[curr] = dist;
                foreach (int edge in map[curr])
                {
                    next = (edges[edge][0] == curr) ? edges[edge][1] : next = edges[edge][0];
                    pq.Enqueue((next, dist + edges[edge][2]), dist + edges[edge][2]);
                }
            }
        }

        private HashSet<int>[] BuildMap_ModifiedGraphEdges(int n, int[][] edges)
        {
            HashSet<int>[] map = new HashSet<int>[n];
            for (int i = 0; i < n; ++i)
            {
                map[i] = new HashSet<int>();
            }
            for (int edge = 0; edge < edges.Length; ++edge)
            {
                if (edges[edge][2] > 0)
                {
                    map[edges[edge][0]].Add(edge);
                    map[edges[edge][1]].Add(edge);
                }
            }
            return map;
        }