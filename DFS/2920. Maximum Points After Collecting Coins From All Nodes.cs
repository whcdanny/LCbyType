//Leetcode 2920. Maximum Points After Collecting Coins From All Nodes hard
//题意：给定一棵以节点 0 为根的无向树，树上的每个节点都有一定数量的硬币。从根节点开始，你需要收集所有硬币，但是每个节点的硬币只能在其祖先节点的硬币已经被收集后才能被收集。对于每个节点，有两种方式可以收集硬币：
//方式一： 收集所有硬币，但你会失去 coins[i] - k 个点数。如果 coins[i] - k 是负数，你将失去 abs(coins[i] - k) 个点数。
//方式二： 收集所有硬币，但你只会获得 floor(coins[i] / 2) 个点数。如果选择方式二，那么对于节点 i 子树中的每个节点 j，coins[j] 会减少到 floor(coins[j] / 2)。
//任务是返回在收集树上所有节点的硬币后能够获得的最大点数。
//思路：DFS）来遍历树的每个节点。对于每个节点，我们可以考虑两种收集方式，并计算在每个方式下能够获得的最大点数。我们将这两个值相加，返回节点的硬币数与两种方式的最大点数之和的较大值。为了避免多次计算，我们可以在递归的过程中记录每个节点的并且减少的值，以便在计算其他节点时能够复用。
//时间复杂度:  在遍历树的每个节点的过程中，我们对每个节点进行了常数时间的操作，因此时间复杂度是 O(N)，其中 N 是节点数。
//空间复杂度： 递归调用栈的最大深度为树的高度，最坏情况下为 N，因此空间复杂度是 O(N)。
        public int MaximumPoints(int[][] edges, int[] coins, int k)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();
            for (int i = 0; i < coins.Length; i++)
            {
                graph[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            return DFS_MaximumPoints(graph, coins, 0, -1, k, memo);
        }

        private int DFS_MaximumPoints(Dictionary<int, List<int>> graph, int[] coins, int node, int parent, int k, Dictionary<(int, int), int> memo, int dir = 0)
        {
            if (dir > 13) return 0;
            if (memo.ContainsKey((node, dir))) return memo[(node, dir)];
            int cost = coins[node] / (1 << dir);
            int way1 = (cost - k);
            int way2 = cost / 2;
            foreach (var neighbor in graph[node])
            {
                if (neighbor == parent) continue;
                way1 += DFS_MaximumPoints(graph, coins, neighbor, node, k, memo, dir); // 计算方式一的值
                way2 += DFS_MaximumPoints(graph, coins, neighbor, node, k, memo, dir + 1); // 计算方式二的值
            }

            int result = Math.Max(way1, way2);
            memo[(node, dir)] = result;
            return result;
        }