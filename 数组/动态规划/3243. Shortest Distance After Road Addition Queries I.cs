//Leetcode 3243. Shortest Distance After Road Addition Queries I med
//题目：给定一个整数 n 和一个二维整数数组 queries，表示 n 个城市（编号为 0 到 n-1）之间的公路网络。
//初始状态下，每个城市 i 到 i+1 都有一条单向公路（即从城市 i 到城市 i+1 的单向路），形成一条从 0 到 n-1 的链路。
//每个 queries[i] = [ui, vi] 表示在城市 ui 到 vi 间添加一条新的单向路。每次添加新道路后，需要求出从城市 0 到城市 n-1 的最短路径长度。
//返回一个数组 answer，其中 answer[i] 表示在处理前 i+1 个 queries 后，从城市 0 到城市 n-1 的最短路径长度。
//思路: 动态规划 
//初始化邻接表和最短路径数组：
//Paths[i]：存储每个城市的所有直接可达的城市。初始状态下，所有城市仅可到达它的下一个城市。
//shortest[i]：记录从城市 0 到城市 i 的最短路径长度。初始化为每个城市的下标值，因为在初始链路中，城市 i 到达自己需要经过 i 条路。
//处理每个查询：
//对于每个查询[ui, vi]，在 Paths[ui] 中加入 vi，表示新建了一条从 ui 到 vi 的单向道路。
//从 ui 开始遍历并更新从 0 到各个城市的最短路径。对于每个出边 next，更新 shortest[next] 为 shortest[j] + 1，表示添加这条边后的路径可能更短。
//记录最短路径：
//每次查询后，将当前从 0 到 n-1 的最短路径记录到结果数组 res 中。
//时间复杂度：O(n + m) ∗ m queries的m长度
//空间复杂度：O(n + m) queries的m长度
        public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
        {
            List<int>[] Paths = new List<int>[n];
            int[] shortest = new int[n];
            for (int i = 0; i < n; ++i)
            {
                Paths[i] = new List<int>();
                if (i + 1 < n)
                {
                    Paths[i].Add(i + 1);
                }
                shortest[i] = i;
            }
            int[] res = new int[queries.Length];
            for (int q = 0; q < queries.Length; ++q)
            {
                Paths[queries[q][0]].Add(queries[q][1]);
                for (int j = queries[q][0]; j < n; ++j)
                {
                    foreach (int next in Paths[j])
                    {
                        shortest[next] = Math.Min(shortest[next], shortest[j] + 1);
                    }
                }
                res[q] = shortest[n - 1];
            }
            return res;
        }