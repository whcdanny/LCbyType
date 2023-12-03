//Leetcode 1766. Tree of Coprimes hard
//题意：这个问题描述了一棵树，由n个节点组成，节点编号从0到n-1，有确切的n-1条边。每个节点都有一个与之关联的值，树的根节点是节点0。
//为了表示这棵树，你得到一个整数数组 nums 和一个二维数组 edges。每个 nums[i] 表示第i个节点的值，每个 edges[j] = [uj, vj] 表示树中节点 uj 和 vj 之间的一条边。
//两个值x和y是互质的，如果它们的最大公约数 gcd(x, y) 等于1，其中 gcd(x, y) 是x和y的最大公约数。
//一个节点i的祖先是从节点i到根节点的最短路径上的任何其他节点。一个节点不被视为自己的祖先。
//返回一个大小为n的数组 ans，其中 ans[i] 是节点i的最近祖先，使得 nums[i] 和 nums[ans[i]] 互质，如果不存在这样的祖先，则返回-1。
//思路：DFS, 遍关键思想是观察一旦找到与 互质的节点A[i]，那么对于所有 (A[i], j) 对，其中 j 是 i 和互质节点之间的所有节点 = cn，互质节点将cn。简单来说，假设您位于i值为 的节点A[i]。您将开始沿着父节点行走。j您找到了value 与A[j]互质的节点A[i]。所以，j最接近的祖先是i
//现在观察，对于所有节点k，其中 k 是从 到 'j' 的路径上的节点i，closestAncestor(A[i], k) = j
//我们可以记住这个结果，这在以后很有用，并且可以消除重复的计算。        
//时间复杂度: O(N log M)，其中 N 是节点数，M 是节点值的最大值。由于每次检查互质关系时，计算最大公约数需要 O(log M) 的时间。
//空间复杂度： O(N + M)
        public int[] GetCoprimes(int[] nums, int[][] edges)//用memory还超时
        {
            int n = nums.Length;
            int[] closestAnc = new int[n];
            closestAnc[0] = -1;
            if (n == 1)
            {
                return closestAnc;
            }
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++)
            {
                graph[i] = new HashSet<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            
            //DFS_GetCoprimes(graph, nums, ans, 0, -1, new Dictionary<int, List<int>>());
            int[] parent = new int[n];
            bool[] visited = new bool[n];
            parent[0] = -1;
            visited[0] = true;
            findParents(0, graph, parent, visited);

            int[,] memo = new int[51,n];

            // for each node find its closest ancestor which is co prime
            for (int i = 1; i < n; i++)
            {
                closestAnc[i] = getClosestAnc(i, parent, nums, memo);
            }
            return closestAnc;
           
        }
        private void findParents(int node, Dictionary<int, HashSet<int>> graph, int[] parent, bool[] visited)
        {
            HashSet<int> adj = graph[node];
            foreach (int val in adj)
            {
                if (visited[val] == false)
                {
                    parent[val] = node;
                    visited[val] = true;
                    findParents(val, graph, parent, visited);
                }
            }
        }
        private int getClosestAnc(int node, int[] parent, int[] nums, int[,] memo)
        {
            int cur = parent[node];
            int coPrime = -1, unsaved = -1;
            while (cur != -1)
            {
                if (memo[nums[node],cur] != 0)
                {
                    coPrime = memo[nums[node],cur];
                    unsaved = cur;
                    break;
                }
                if (GCD(nums[node], nums[cur]) == 1)
                {
                    coPrime = cur;
                    unsaved = cur;
                    break;
                }
                cur = parent[cur];
            }

            // memoize the result
            cur = parent[node];
            while (cur != unsaved)
            {
                memo[nums[node],cur] = coPrime;
                cur = parent[cur];
            }
            return coPrime;
        }
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }