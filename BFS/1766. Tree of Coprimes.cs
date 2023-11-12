//Leetcode 1766. Tree of Coprimes med
//题意：给定一棵树，节点上有整数值。节点 i 的值是 nums[i]。你需要找到树中与节点 i 具有互质关系的节点 j，并返回数组 ans，其中 ans[i] 是节点 i 的值为 nums[i] 时，与节点 i 具有互质关系的节点的最大深度。如果不存在这样的节点，ans[i] 为 -1。两个正整数 a 和 b 是互质的，当且仅当它们的最大公约数是 1。
//思路：使用BFS,现根据edges创建一个图，然后BFS，找出每个节点对应的父辈节点，然后算出是否为质数，质数就算greatest common divisor=1；
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int[] GetCoprimes(int[] nums, int[][] edges)//超时
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> list = new Dictionary<int, List<int>>();
            for(int i = 0; i < nums.Length; i++){
                list[i] = new List<int>();
            }
            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge[0]))
                {
                    graph[edge[0]] = new List<int>();
                    
                }
                if (!graph.ContainsKey(edge[1]))
                {
                    graph[edge[1]] = new List<int>();
                }
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            list[0].Add(0);
            HashSet<int> visited = new HashSet<int>();
            visited.Add(0);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();                
                if (graph.ContainsKey(node))
                {
                    foreach (var neg in graph[node])
                    {
                        if (!visited.Contains(neg))
                        {
                            queue.Enqueue(neg);
                            visited.Add(neg);
                            list[neg].Add(node);
                            foreach (int n in list[node])
                            {
                                if (!list[neg].Contains(n))
                                    list[neg].Add(n);
                            }

                        }
                    }
                }
            }
            int[] res = new int[nums.Length];
            res[0] = -1;
            foreach(var l in list)
            {                
                List<int> values = l.Value;
                int key = l.Key;
                int sub = int.MaxValue;
                int r = 0;
                if (key == 0)
                    continue;
                foreach(int i in values)
                {
                    int temp = gcd(nums[i], nums[key]);
                    if (temp < sub && temp==1)
                    {
                        r = i;
                        sub = temp;
                    }
                }
                res[key] = sub==int.MaxValue? -1:r;
            }
            return res;
        }
        private int gcd(int a, int b)
        {
            if (b == 0) return a;
            return gcd(b, a % b);
        }