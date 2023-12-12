//Leetcode 547. Number of Provinces med
//题意：给定一个 n x n 的矩阵 isConnected 表示城市之间的连接情况，其中 isConnected[i][j] = 1 表示城市 i 和城市 j 直接相连，而 isConnected[i][j] = 0 表示二者不直接相连。省份是一组直接或间接相连的城市，组内不含其他没有相连的城市。请你计算并返回该图中省份的数量。
//思路：DFS）来遍历城市，将已访问的城市标记，并对每个省份进行计
//时间复杂度: 遍历所有城市需要 O(n^2) 的时间，其中 n 是城市的数量。广度优先搜索过程中，每个城市只会被访问一次，因此总的时间复杂度为 O(n^2)。
//空间复杂度：广度优先搜索过程中，需要使用 visited 数组来记录城市是否被访问过，其大小为城市的数量 n，因此空间复杂度为 O(n)。
        public int FindCircleNum(int[][] isConnected)
        {
            int n = isConnected.Length;
            bool[] visited = new bool[n];
            int provinces = 0;

            for (int i = 0; i < n; i++)
            {
                if (!visited[i])
                {
                    DFS_FindCircleNum(isConnected, visited, i);
                    provinces++;
                }
            }

            return provinces;
        }

        private void DFS_FindCircleNum(int[][] isConnected, bool[] visited, int city)
        {
            visited[city] = true;

            for (int neighbor = 0; neighbor < isConnected.Length; neighbor++)
            {
                if (isConnected[city][neighbor] == 1 && !visited[neighbor])
                {
                    DFS_FindCircleNum(isConnected, visited, neighbor);
                }
            }
        }