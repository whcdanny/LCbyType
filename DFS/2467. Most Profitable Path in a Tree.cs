//Leetcode 2467. Most Profitable Path in a Tree med
//题意：题意是在一棵树上，每个节点都有一个门，门可能需要花钱打开，也可能提供奖励。有两个人，Alice 和 Bob，分别位于两个节点，每秒钟可以朝着相邻的节点移动。他们可以选择花钱打开节点的门，或者接受奖励。如果他们同时到达一个节点，他们需要平分门的花费或奖励。
//目标是找到 Alice 在移动到叶子节点的过程中能够得到的最大净收入。        
//思路：（DFS）进行遍历，边创建图形
//先算鲍勃访问过的地方,然后算的root0之和，逆向把每一个位置的level算出来，这样用于跟Alice从root0往下的访问level做比较；
//然后算alice路径，查找总和 - 根据级别计算，如果 bob 之前已达到与 alice 相同级别的相同级别，则 sum/2，否则为全额。然后加上子集的最大值；
//时间复杂度: O(N)
//空间复杂度：O(N)
        public int MostProfitablePath(int[][] edges, int bob, int[] amount)
        {
            int n = edges.Length + 1;
            var graph = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            var visited = new HashSet<int>() { bob };
            var bobpath = new int[n];
            Array.Fill(bobpath, int.MaxValue);
            bobpath[bob] = 0;
            var found = false;
            BobPath(graph, bob, bobpath, amount, visited, ref found);
            return AlicePath(graph, 0, bobpath, amount, 0, new HashSet<int>() { 0 });
        }
        public int AlicePath(List<int>[] graph, int cur, int[] bobpath, int[] amount, int level, HashSet<int> visited)
        {
            int sum = level < bobpath[cur] ? amount[cur] : level == bobpath[cur] ? amount[cur] / 2 : 0;
            int max = int.MinValue;
            foreach (var next in graph[cur])
            {
                if (!visited.Add(next)) continue;
                max = Math.Max(max, AlicePath(graph, next, bobpath, amount, level + 1, visited));
                visited.Remove(next);

            }
            return max == int.MinValue ? sum : sum + max;
        }
        public void BobPath(List<int>[] graph, int cur, int[] bobpath, int[] amount, HashSet<int> visited, ref bool found)
        {
            if (found) return;
            if (cur == 0)
            {
                var level = 0;
                foreach (var node in visited)
                    bobpath[node] = level++;
                found = true;
                return;
            }
            foreach (var next in graph[cur])
            {
                if (!visited.Add(next)) continue;
                BobPath(graph, next, bobpath, amount, visited, ref found);
                visited.Remove(next);
            }
        }