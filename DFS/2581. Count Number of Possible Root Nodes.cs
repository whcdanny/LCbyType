//Leetcode 2581. Count Number of Possible Root Nodes hard
//题意：Alice有一棵包含 n 个节点的无向树，节点编号从 0 到 n - 1。树用一个二维整数数组 edges 表示，其中 edges[i] = [ai, bi] 表示树中存在一条连接节点 ai 和 bi 的边。
//Alice希望Bob能够找到树的根节点。她允许Bob提出关于她树的多个猜测。在一次猜测中，Bob执行以下操作：
//选择两个不同的整数 u 和 v，使得树中存在一条边[u, v]。
//告诉Alice在树中 u 是 v 的父节点。
//Bob的猜测用一个二维整数数组 guesses 表示，其中 guesses[j] = [uj, vj] 表示Bob猜测 uj 是 vj 的父节点。
//Alice很懒，不回答Bob的每一次猜测，只是说至少 k 次猜测是正确的。给定二维整数数组 edges、guesses 和整数 k，返回可能是Alice树根节点的节点数。如果没有这样的树，返回 0。      
//思路：DBS，这是一个图问题，我们可以尝试将每个节点作为根，然后遍历它，找出有多少个正确的猜测，如果>=k，则这是一个有效的节点。使用边构建无向图        对于每个节点i，以它为根，然后遍历图找到所有正确的猜测，如果>=k，则i是可能的必须避免重复遍历，我们使用 memo 来缓存[parent - node, child - node] 的结果，所以我们只需要遍历整个图（所有边）两次。
//时间复杂度: O(n)
//空间复杂度：O(n^2)
        public int RootCount(int[][] edges, int[][] guesses, int k)
        {
            int res = 0;
            int n = edges.Length + 1;
            //build undirect graph by edges
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            //build direct graph by guesses
            HashSet<int>[] directGraph = new HashSet<int>[n];
            for (int i = 0; i < n; i++)
                directGraph[i] = new HashSet<int>();

            foreach (var guess in guesses)
            {
                directGraph[guess[0]].Add(guess[1]);
            }

            //memo is {parent, {child, count}}, count is all valid guesses traverse from parent to all childs
            var memo = new Dictionary<int, Dictionary<int, int>>();
            for (int i = 0; i < n; i++)
            {
                int count = DFS_RootCount(i, -1, graph, directGraph, memo);
                if (count >= k)
                    res++;
            }
            return res;
        }

        private int DFS_RootCount(int curr, int parent, List<int>[] graph, HashSet<int>[] directGraph, Dictionary<int, Dictionary<int, int>> memo)
        {
            if (!memo.ContainsKey(parent))
                memo.Add(parent, new Dictionary<int, int>());
            //already traversed from
            if (memo[parent].ContainsKey(curr))
                return memo[parent][curr];
            else
            {
                int res = 0;
                foreach (var next in graph[curr])
                {
                    if (next == parent) continue;
                    if (directGraph[curr].Contains(next)) res++;//{curr,next} is existed in guesses
                    res += DFS_RootCount(next, curr, graph, directGraph, memo);//DFS
                }
                memo[parent].Add(curr, res);
                return memo[parent][curr];
            }
        }