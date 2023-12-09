//Leetcode 886. Possible Bipartition med
//题意：给定一个整数 N，表示人的数量，和一个二维数组 dislikes，其中 dislikes[i] = [a, b] 表示人 a 和人 b 之间互相不喜欢。如果可以将人分成两组，使得每组中的人都不互相不喜欢，返回 true；否则返回 false。    
//思路：DFS, 这是一个图的着色问题。首先，根据 dislikes 构建图，然后使用 BFS 或 DFS 遍历图，并为每个人着色。在遍历的过程中，如果发现两个相邻的人已经着了相同的颜色，说明不能分成两组，返回 false；否则返回 true。      
//时间复杂度: O(N + E)，其中 N 是人的数量，E 是不喜欢关系的数量。
//空间复杂度：O(N + E)，用于存储图的邻接表和记录人的颜色。在最坏情况下，可能需要存储所有的不喜欢关系。
        public bool PossibleBipartition(int N, int[][] dislikes)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            int[] colors = new int[N + 1];

            // Build graph
            foreach (var dislike in dislikes)
            {
                if (!graph.ContainsKey(dislike[0]))
                {
                    graph[dislike[0]] = new List<int>();
                }
                if (!graph.ContainsKey(dislike[1]))
                {
                    graph[dislike[1]] = new List<int>();
                }
                graph[dislike[0]].Add(dislike[1]);
                graph[dislike[1]].Add(dislike[0]);
            }

            // DFS traversal
            for (int i = 1; i <= N; i++)
            {
                if (colors[i] == 0 && !DFS_PossibleBipartition(i, 1, colors, graph))
                {
                    return false;
                }
            }

            return true;
        }

        private bool DFS_PossibleBipartition(int person, int color, int[] colors, Dictionary<int, List<int>> graph)
        {
            if (colors[person] != 0)
            {
                return colors[person] == color;
            }

            colors[person] = color;
            if (graph.ContainsKey(person))
            {
                foreach (var neighbor in graph[person])
                {
                    if (!DFS_PossibleBipartition(neighbor, -color, colors, graph))
                    {
                        return false;
                    }
                }
            }

            return true;
        }