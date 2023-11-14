//Leetcode 1519. Number of Nodes in the Sub-Tree With the Same Label med
//题意：给定一棵树，其节点标记为 0 到 n-1，以及连接这些节点的边，每个节点都有一个小写字符标签。任务是返回一个数组，其中ans[i]表示第 i 个节点的子树中与节点 i 具有相同标签的节点数。
//思路： BFS 进行遍历，图形表示：使用邻接列表表示树，其中edges[i] = [ai, bi] 表示节点 ai 和 bi 之间的边。根据graph来找到只有一个子集的node，然后进行BFS直到没有，就相当于从tree的最下面往上查找；然后根据每个子集的count来跟新父级的数量；
//时间复杂度: O(N)，其中 N 是树中的节点数。
//空间复杂度：O(N)
        public int[] CountSubTrees(int n, int[][] edges, string labels)
        {
            var graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            int[] result = new int[n];

            int[,] counts = new int[n, 26];
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                counts[i, labels[i] - 'a'] = 1;

                if (i != 0 && graph[i].Count == 1)
                {
                    queue.Enqueue(i);
                }
            }

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                int parent = graph[current].First();
                graph[parent].Remove(current);

                for (int j = 0; j < 26; j++)
                {
                    counts[parent, j] += counts[current, j];
                }

                if (parent != 0 && graph[parent].Count == 1)
                {
                    queue.Enqueue(parent);
                }
            }

            for (int i = 0; i < n; i++)
            {
                result[i] = counts[i, labels[i] - 'a'];
            }

            return result;
        }