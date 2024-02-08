//Leetcode 2497. Maximum Star Sum of a Graph med
//题意：给定一个包含 n 个节点（编号从 0 到 n - 1）的无向图。你被给定一个长度为 n 的整数数组 vals，其中 vals[i] 表示第 i 个节点的值。
//同时，你也被给定一个二维整数数组 edges，其中 edges[i] = [ai, bi] 表示存在一条连接节点 ai 和 bi 的无向边。
//星形图是给定图的一个子图，其中包含一个中心节点以及0个或多个邻居节点。换句话说，它是给定图的一组边的子集，这些边具有一个共同的节点。
//下图显示了以蓝色节点为中心的具有3个和4个邻居的星形图。
//思路：PriorityQueue 建立graph，把每条边跟那些边连接，并且value是多少从大到小排序；
//然后从0到n-1找到cur和max进行比较；        
//时间复杂度: O(n + m)
//空间复杂度：O(n)       
        public int MaxStarSum(int[] vals, int[][] edges, int k)
        {
            PriorityQueue<int, int>[] graph = new PriorityQueue<int, int>[vals.Length];
            for (int i = 0; i < vals.Length; i++)
            {
                graph[i] = new PriorityQueue<int, int>();
            }
            foreach (int[] edge in edges)
            {
                graph[edge[0]].Enqueue(edge[1], -vals[edge[1]]);
                graph[edge[1]].Enqueue(edge[0], -vals[edge[0]]);
            }
            int max = int.MinValue;
            for (int i = 0; i < vals.Length; i++)
            {
                int sum = vals[i], count = 0;
                while (count < k && graph[i].Count > 0 && sum + vals[graph[i].Peek()] > sum)
                {
                    sum += vals[graph[i].Dequeue()];
                    count++;
                }
                max = Math.Max(max, sum);
            }
            return max;
        }
		
		public int MaxStarSum1(int[] vals, int[][] edges, int k)
        {
            int n = vals.Length;
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();            
            for (int i = 0; i < n; i++)
            {                
                graph[i] = new List<int>();
            }
            foreach (var edge in edges)
            {                
                graph[edge[0]].Add(vals[edge[1]]);
                graph[edge[1]].Add(vals[edge[0]]);
            }

            int sumMax = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int curSum = vals[i];
                curSum += graph[i].OrderByDescending(n => n).Take(k).Where(n => n > 0).Sum();
                sumMax = Math.Max(sumMax, curSum);
            }
            return sumMax;
        }