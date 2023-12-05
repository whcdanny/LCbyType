//Leetcode 1519. Number of Nodes in the Sub-Tree With the Same Label med
//题意：一个树，树是一个连通的、无环的、由n个节点和n-1条边组成的图。树的根是节点0，树的每个节点都有一个标签，标签是一个小写字符，给定在字符串 labels 中。也就是说，节点i的标签是 labels[i]。
//边数组 edges 的形式是 edges[i] = [ai, bi]，这表示在树中节点ai和bi之间有一条边。
//要求返回一个大小为n的数组，其中 ans[i] 表示第i个节点子树中与节点i的标签相同的节点数。
//一个树T的子树是由T中的一个节点和其所有后代节点组成的树
//思路： DFS, 对于每个节点，使用一个长度为26的数组 count 记录与当前节点的标签相同的节点数。递归遍历每个邻接节点，合并子树中的节点计数。将当前节点的计数存储在结果数组中。       
//时间复杂度: O(n)，其中 n 是树中节点的数量，因为每个节点最多访问一次
//空间复杂度：O(n)，使用了邻接表、visited 数组和 result 数组
        public int[] CountSubTrees(int n, int[][] edges, string labels)
        {
            List<int>[] tree = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                tree[i] = new List<int>();
            }

            // 构建树的邻接表表示
            foreach (var edge in edges)
            {
                tree[edge[0]].Add(edge[1]);
                tree[edge[1]].Add(edge[0]);
            }

            int[] result = new int[n];
            bool[] visited = new bool[n];

            DFS_CountSubTrees(0, tree, labels, visited, result);

            return result;
        }

        private int[] DFS_CountSubTrees(int node, List<int>[] tree, string labels, bool[] visited, int[] result)
        {
            visited[node] = true;
            int[] count = new int[26];
            count[labels[node] - 'a']++;

            foreach (var neighbor in tree[node])
            {
                if (!visited[neighbor])
                {
                    int[] subCount = DFS_CountSubTrees(neighbor, tree, labels, visited, result);

                    // 合并子树节点计数
                    for (int i = 0; i < 26; i++)
                    {
                        count[i] += subCount[i];
                    }
                }
            }

            // 将当前节点的计数存储在结果数组中
            result[node] = count[labels[node] - 'a'];

            return count;
        }