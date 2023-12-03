//Leetcode 2322. Minimum Score After Removals on a Tree hard
//题意：给定一个具有 n 个节点（标记为 0 到 n - 1）和 n - 1 条边的无向连接树。给定一个长度为 n 的整数数组 nums，其中 nums[i] 表示第 i 个节点的值。还给定一个长度为 n - 1 的二维整数数组 edges，其中 edges[i] = [ai, bi] 表示树中节点 ai 和 bi 之间存在一条边。
//移除树的两条不同边，以形成三个连接组件。对于一对被移除的边，定义以下步骤：
//分别对每个连接组件的节点值进行异或运算。
//最大异或值与最小异或值之间的差值即为这对的分数。例如，假设三个连接组件的节点值分别是：[4,5,7]，[1,9] 和[3, 3, 3]。这三个异或值分别为 4 ^ 5 ^ 7 = 6，1 ^ 9 = 8 和 3 ^ 3 ^ 3 = 3。最大异或值为 8，最小异或值为 3。分数为 8 - 3 = 5。
//思路：深度优先搜索 (DFS),构建一个树图.找到all_xor，然后第一个dfs是切第一个，第二个dfs是根据第一个切来切第二。
//注：对所有节点的值进行异或，然后我们只需要关心 2 个分量，因为第三个分量可以通过 找到all_xor^a_xor^b_xor；
//时间复杂度: O(N + N) = O(N)
//空间复杂度：O(H + H) = O(H)
        private int minScore_MinimumScore = int.MaxValue;

        public int MinimumScore(int[] nums, int[][] edges)
        {
            int xor = 0;
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();            
            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge[0])) graph[edge[0]] = new List<int>();
                if (!graph.ContainsKey(edge[1])) graph[edge[1]] = new List<int>();
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);                
            }
            int res = int.MaxValue;
            foreach (int n in nums)
            { // xor all the values 
                xor ^= n;
            }
            DFS_MinimumScore1(0, -1, graph, xor, nums);
            return minScore_MinimumScore;
        }

        private int DFS_MinimumScore1(int cur, int parent, Dictionary<int, List<int>> graph, int xor, int[] nums)
        {
            int val = nums[cur];  // val -> current xor value for this component
            foreach (int next in graph[cur])
            {
                if (parent != next)
                {
                    val ^= DFS_MinimumScore1(next, cur, graph, xor, nums);
                }
            }
            if (cur != 0)
            { // ban node chosen, do dfs again for the other component.
                DFS_MinimumScore2(0, -1, cur, xor, val, graph, nums);
            }
            return val;
        }

        private int DFS_MinimumScore2(int cur, int parent, int ban, int xor, int axor, Dictionary<int, List<int>> graph, int[] nums)
        {
            if (cur == ban)
                return 0;
            int val = nums[cur]; // val -> current xor value for this component
            foreach (int next in graph[cur])
            {
                if (parent != next)
                {
                    val ^= DFS_MinimumScore2(next, cur, ban, xor, axor, graph, nums);
                }
            }
            if (cur != 0)
            { // if it is not a root node, we have a valid 3 components. Update ans.
                int bxor = xor ^ val ^ axor;
                minScore_MinimumScore = Math.Min(minScore_MinimumScore, Math.Max(val, Math.Max(bxor, axor)) - Math.Min(val, Math.Min(bxor, axor)));
            }
            return val;
        }