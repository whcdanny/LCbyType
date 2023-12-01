//Leetcode 2440. Create Components With Same Value hard
//题意：给定一个包含 n 个节点（标号从 0 到 n - 1）的无向树。同时给定一个长度为 n 的整数数组 nums，其中 nums[i] 表示第 i 个节点的值。此外，还有一个长度为 n - 1 的二维整数数组 edges，表示树的边，其中 edges[i] = [ai, bi] 表示存在一条连接节点 ai 和 bi 的边。
//允许你删除一些边，将树分割成多个连通分量。定义一个分量的值为该分量中所有节点值的总和。现在要求计算最多可以删除多少条边，使得每个连通分量的值相同。
//思路：（DFS）先建立图，然后算出总和，和最大的子集。然后根据最大的子集开始一直算到总和。        
//注：能被整除才说明可以算删除边； 
//时间复杂度: O(V + V + E + logV * V)
//空间复杂度：O(V + E + V)
        public int components_ComponentValue = 0;
        public int ComponentValue(int[] nums, int[][] edges)
        {
            int n = nums.Length;
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            int totalSum = 0;
            int maxNumber = 0;
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
                totalSum += nums[i];
                maxNumber = Math.Max(maxNumber, nums[i]);
            }

            foreach (var edge in edges)
            {
                int u = edge[0];
                int v = edge[1];
                graph[u].Add(v);
                graph[v].Add(u);
            }            
            int maxComponents = 0;
            for (int i = maxNumber; i <= totalSum; i++)
            {
                components_ComponentValue = 0;
                //能被整除才说明可以删除边；
                if (totalSum % i == 0)
                {
                    int x = DFS_ComponentValue(graph, 0, -1, nums, i);
                    if (x == 0)
                    {                        
                        maxComponents = Math.Max(maxComponents, components_ComponentValue);
                    }
                }
            }
            return maxComponents - 1;
        }
        public int DFS_ComponentValue(Dictionary<int, List<int>> graph, int node, int paretn, int[] nums, int k)
        {
            int sum = 0;
            foreach (int neighbor in graph[node])
            {
                if (neighbor != paretn)
                {
                    sum += DFS_ComponentValue(graph, neighbor, node, nums, k);
                }
            }
            sum += nums[node];
            if (sum == k) components_ComponentValue++;
            return sum == k ? 0 : sum;
        }