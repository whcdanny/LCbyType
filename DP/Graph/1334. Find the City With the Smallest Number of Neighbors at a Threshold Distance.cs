//Leetcode 1334. Find the City With the Smallest Number of Neighbors at a Threshold Distance med
//题意：有 n 个城市，编号从 0 到 n−1。给定一个数组edges，
//其中edges[i]=[fromi, toi, weighti]表示两个城市之间的双向加权边，权重为weighti。
//另有一个整数distanceThreshold 表示阈值距离。
//要求找出满足以下条件的城市：
//从该城市通过某些路径可以到达的城市数目最少，且这些路径的总距离不超过distanceThreshold。
//如果有多个这样的城市，返回编号最大的城市。
//注意：城市i 到城市j 的路径距离等于该路径中所有边权重的和。
//思路：动态规划 + Floy算法 Floyd-Warshall: 
//初始化距离矩阵：
//建立一个n×n 的矩阵 dist，表示任意两点间的最短距离。
//如果两点间有直接边，初始化为边的权重；否则初始化为 ∞。
//动态规划更新最短路径：对于每个中间点k，更新dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
//这样可以求出所有点对间的最短路径。
//统计可达城市数：遍历每个城市，计算其可达的城市数（距离不超过distanceThreshold）。
//比较选择结果：找出可达城市数最少的城市；如果有多个，返回编号最大的城市。
//时间复杂度：O(n^3)
//空间复杂度：O(n^2)
        public int FindTheCity(int n, int[][] edges, int distanceThreshold)
        {
            // 初始化距离矩阵
            int[,] dist = new int[n, n];
            int INF = 1000000; // 表示无穷大

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dist[i, j] = (i == j) ? 0 : INF;
                }
            }

            // 填充直接边的权重
            foreach (var edge in edges)
            {
                int from = edge[0], to = edge[1], weight = edge[2];
                dist[from, to] = weight;
                dist[to, from] = weight;
            }

            // Floyd-Warshall 算法
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                    }
                }
            }

            // 找出满足条件的城市
            int resultCity = -1;
            int minReachableCities = n;

            for (int i = 0; i < n; i++)
            {
                int reachableCities = 0;
                for (int j = 0; j < n; j++)
                {
                    if (dist[i, j] <= distanceThreshold)
                    {
                        reachableCities++;
                    }
                }

                // 更新结果城市
                if (reachableCities < minReachableCities || (reachableCities == minReachableCities && i > resultCity))
                {
                    resultCity = i;
                    minReachableCities = reachableCities;
                }
            }

            return resultCity;
        }