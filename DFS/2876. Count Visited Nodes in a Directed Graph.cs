//Leetcode 2876. Count Visited Nodes in a Directed Graph hard
//题意：有一个包含 n 个节点（编号从 0 到 n-1）和 n 条有向边的有向图。
//给定一个 0 索引的数组 edges，其中 edges[i] 表示存在一条从节点 i 到节点 edges[i] 的边。
//考虑如下过程：你从一个节点 x 开始，通过边不断访问其他节点，直到你到达一个在此过程中已经访问过的节点为止。
//返回一个数组 answer，其中 answer[i] 是如果从节点 i 开始执行此过程将访问的不同节点的数量。
//思路：深度优先搜索（DFS）对于任何有向图而言，顺着边的方向走向去，
//只有两种归宿：要么进入死胡同，要么进入循环圈。
//所以你可以把有向图简单地认为就是若干个单链并入一个环。
//先找出入度为零的节点，然后用拓扑排序的方法将所有单链上的节点排除掉。
//剩下的就是环上的节点。从环的任意节点出发，可以遍历整个环得到环的长度（也就是对于这些节点的答案）。
//最后再遍历单链节点，dfs直至遇到环的入口，这段距离加上环的长度，就是对于这些节点的答案。
//时间复杂度: O(n)
//空间复杂度：O(n)
//下一个的点
        public int[] next_CountVisitedNodes;
        //入度，相当于毛刺，或者说就是外支点
        public int[] indegree_CountVisitedNodes;
        public int[] CountVisitedNodes(IList<int> edges)
        {
            int n = edges.Count;
            int[] res = new int[n];
            next_CountVisitedNodes = new int[n];
            indegree_CountVisitedNodes = new int[n];

            for (int i = 0; i < n; i++)
            {
                next_CountVisitedNodes[i] = edges[i];
                indegree_CountVisitedNodes[edges[i]] += 1;
            }

            Queue<int> q = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                if (indegree_CountVisitedNodes[i] == 0)
                    q.Enqueue(i);
            }

            while (q.Count > 0)
            {
                int len = q.Count;
                while (len-- > 0)
                {
                    int cur = q.Dequeue();
                    int nxt = next_CountVisitedNodes[cur];
                    indegree_CountVisitedNodes[nxt]--;
                    if (indegree_CountVisitedNodes[nxt] == 0)
                        q.Enqueue(nxt);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (indegree_CountVisitedNodes[i] == 0) continue;
                if (res[i] != 0) continue;

                int j = i;
                int len = 1;
                while (next_CountVisitedNodes[j] != i)
                {
                    len++;
                    j = next_CountVisitedNodes[j];
                }

                j = i;
                while (next_CountVisitedNodes[j] != i)
                {
                    res[j] = len;
                    j = next_CountVisitedNodes[j];
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (indegree_CountVisitedNodes[i] != 0) continue;
                DFS_CountVisitedNodes(i, res);
            }

            return res;
        }
        private int DFS_CountVisitedNodes(int cur, int[] rets)
        {
            if (rets[cur] != 0)
                return rets[cur];

            rets[cur] = DFS_CountVisitedNodes(next_CountVisitedNodes[cur], rets) + 1;
            return rets[cur];
        }