//Leetcode 444 Sequence Reconstruction med
//题意：给定一个序列 org，以及一个由排列组成的序列的列表 seqs。判断是否可以从 seqs 中重新排列组合出 org。
//思路：拓扑排序,构建一个字典 graph 用来存储节点之间的关系，以及一个字典 inDegree 用来记录每个节点的入度。遍历 seqs，对于每个序列，根据相邻两个元素构建图的关系，并更新入度。如果某个节点的入度大于 1，说明无法确定其位置，返回 false。使用拓扑排序算法，判断是否存在唯一的拓扑排序结果等于 org。
//时间复杂度: 假设 org 的长度为 n，seqs 中的所有元素总数为 m, O(m + n)
//空间复杂度：字典 graph 和 inDegree 分别占用了 O(m) 和 O(n) 的空间，因此总空间复杂度为 O(m + n)
        public bool SequenceReconstruction(int[] org, IList<IList<int>> seqs)
        {
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();
            Dictionary<int, int> inDegree = new Dictionary<int, int>();

            foreach (var seq in seqs)
            {
                for (int i = 0; i < seq.Count; i++)
                {
                    if (!graph.ContainsKey(seq[i]))
                    {
                        graph[seq[i]] = new HashSet<int>();
                        inDegree[seq[i]] = 0;
                    }
                    if (i > 0 && !graph[seq[i - 1]].Contains(seq[i]))
                    {
                        graph[seq[i - 1]].Add(seq[i]);
                        inDegree[seq[i]]++;
                    }
                }
            }

            if (org.Length != inDegree.Count) return false;

            Queue<int> queue = new Queue<int>();
            foreach (var node in inDegree.Keys)
            {
                if (inDegree[node] == 0)
                {
                    queue.Enqueue(node);
                }
            }

            int index = 0;
            while (queue.Count == 1)
            {
                int node = queue.Dequeue();
                if (org[index] != node) return false;
                index++;
                foreach (var neighbor in graph[node])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }

            return index == org.Length;
        }