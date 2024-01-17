//Leetcode 1782. Count Pairs Of Nodes hard
//题意：给定一个无向图，其中有n个节点（编号从0到n-1）和一组边。对于每个查询，定义incident(a, b)为与节点a或b相连的边的数量。对于每个查询，找出满足以下两个条件的节点对(a, b)的数量：
//a<b
//incident(a, b) > queries[j]
//返回一个数组answers，其中answers[j] 表示第j个查询的答案。
//思路：双指针法，
//先找到每个点被用到多少次；然后排序inDegree
//再把每个边出现次数算一下，因为会存在（1，2）（2，1）；
//根据queries先算一个大概的总共可能数，逻辑是如果inDegree[left]+inDegree[right]>query,就可以righ--，因为满足我们要找到不满足的位置，此时就是[right临界值 - right]都跟left满足，那么每一次都是当前right-left的可能性；
//首先a,b满足 然后a的总数+b的总数再减去重复被算的：inDegree[edge.a] + inDegree[edge.b] > query && inDegree[edge.a] + inDegree[edge.b] - map[edge] <= query)
//时间复杂度：排序操作的时间复杂度为O(NlogN)，对每个查询的处理的时间复杂度为O(Q * N)，其中N是节点数，Q是查询数。因此，总体时间复杂度为O(Q * N + NlogN)。
//空间复杂度：O(n)
        public int[] CountPairs(int n, int[][] edges, int[] queries)
        {
            int[] inDegree = new int[n + 1];

            for (int i = 0; i < edges.Length; ++i)
            {
                inDegree[edges[i][0]]++;
                inDegree[edges[i][1]]++;
            }

            int[] duplicate = inDegree.ToArray();

            Array.Sort(duplicate);

            Dictionary<(int a, int b), int> map = new Dictionary<(int a, int b), int>();

            for (int i = 0; i < edges.Length; ++i)
            {
                int a = edges[i][0];
                int b = edges[i][1];

                if (a > b)
                    (a, b) = (b, a);

                if (!map.TryAdd((a, b), 1))
                    map[(a, b)] += 1;
            }

            int[] result = new int[queries.Length];

            int index = 0;

            foreach (int query in queries)
            {
                // Fast Estimation (two pointers)
                int total = TwoPointers(duplicate, query);

                // Correction (some total values are Overestiated)
                foreach (var edge in map.Keys)
                    if (inDegree[edge.a] + inDegree[edge.b] > query &&
                        inDegree[edge.a] + inDegree[edge.b] - map[edge] <= query)
                        total -= 1;

                result[index++] = total;
            }

            return result;
        }
        public int TwoPointers(int[] array, int query)
        {
            int left = 1;
            int right = array.Length - 1;
            int total = 0;

            while (left < right)
                if (array[left] + array[right] > query)
                    total += (right-- - left);
                else
                    left++;

            return total;
        }