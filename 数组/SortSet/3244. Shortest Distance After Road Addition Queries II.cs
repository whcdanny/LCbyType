//Leetcode 3244. Shortest Distance After Road Addition Queries II hard
//题目：给定一个整数 n 和一个二维整数数组 queries，表示 n 个城市（编号为 0 到 n-1）之间的公路网络。
//初始状态下，每个城市 i 到 i+1 都有一条单向公路（即从城市 i 到城市 i+1 的单向路），形成一条从 0 到 n-1 的链路。
//每个 queries[i] = [ui, vi] 表示在城市 ui 到 vi 间添加一条新的单向路。每次添加新道路后，需要求出从城市 0 到城市 n-1 的最短路径长度。
//返回一个数组 answer，其中 answer[i] 表示在处理前 i+1 个 queries 后，从城市 0 到城市 n-1 的最短路径长度。
//思路: 初始化：创建一个有序集合 sortedSet，包含城市的索引 [0, 1, ..., n-1]。它表示按顺序的路径节点。
//逐次处理查询：
//对于每个查询，给定范围[queries[i][0] + 1, queries[i][1] - 1] 的中间节点被移除。
//移除中间节点后，路径直接从 queries[i][0] 跳到 queries[i][1]，这样可以减少路径中的节点数。
//GetViewBetween 方法用于获取指定范围的视图并清除它，从而减少路径上的节点。
//结果数组中的当前查询的路径长度计算为 sortedSet.Count - 1，
//因为 sortedSet 的大小表示在当前查询路径上的节点数量，减去 1 得到最终的最短路径长度。
//返回结果：每次查询计算的路径长度存入 result 数组，最终返回结果。
//时间复杂度：O(n + q * (log n + k))
//空间复杂度：O(n)
        public int[] ShortestDistanceAfterQueries1(int n, int[][] queries)
        {
            //创建一个有序集合 sortedSet，包含城市的索引 [0, 1, ..., n-1]。它表示按顺序的路径节点。
            var sortedSet = new SortedSet<int>();
            for (var i = 0; i < n; i++)
            {
                sortedSet.Add(i);
            }

            var result = new int[queries.Length];

            for (var index = 0; index < queries.Length; index++)
            {
                var query = queries[index];
                //GetViewBetween 方法用于获取指定范围的视图并清除它，从而减少路径上的节点。
                var removeRange = sortedSet.GetViewBetween(query[0] + 1, query[1] - 1);
                removeRange.Clear();
                //结果数组中的当前查询的路径长度计算为 sortedSet.Count - 1，
                //因为 sortedSet 的大小表示在当前查询路径上的节点数量，减去 1 得到最终的最短路径长度。
                result[index] = sortedSet.Count - 1;
            }

            return result;
        }