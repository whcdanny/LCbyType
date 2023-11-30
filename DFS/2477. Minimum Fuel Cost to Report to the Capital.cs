//Leetcode 2477. Minimum Fuel Cost to Report to the Capital med
//题意：每个城市都有一辆车，车上有固定数量的座位，代表可以在他们所在的城市使用车辆前往首都开会，也可以在途中更换车辆。你需要返回使得总燃料消耗最小的策略。
//思路：创建邻接表并应用 DFS 后序递归和回溯,在回溯的时候，将代表人数返回给父级，然后计算并更新燃油升数
//时间复杂度: O(n)
//空间复杂度：O(n)
        public long MinimumFuelCost(int[][] roads, int seats)
        {            
            var n = roads.Length + 1;
            var graph = new List<int>[n];

            for (int i = 0; i < n; i++)
                graph[i] = new List<int>();

            for (int i = 0; i < roads.Length; i++)
            {
                graph[roads[i][0]].Add(roads[i][1]);
                graph[roads[i][1]].Add(roads[i][0]);
            }           

            var liters = 0L;
            var visited = new bool[n];
            visited[0] = true;
            for (int i = 0; i < graph[0].Count; i++)
                DFS_MinimumFuelCost(graph[0][i], graph, visited, seats, ref liters);

            return liters;            
        }
        int DFS_MinimumFuelCost(int node, List<int>[] graph, bool[] visited, int seats, ref long liters)
        {            
            var reps = 1;
            visited[node] = true;
            for (int j = 0; j < graph[node].Count; j++)
            {
                if (!visited[graph[node][j]])
                {                    
                    reps += DFS_MinimumFuelCost(graph[node][j], graph, visited, seats, ref liters);
                }
            }

            //确保每辆汽车都能够容纳到至少一个代表，即使有多余的座位也需要算作一辆汽车的升数。
            if (reps <= seats)
                liters++;
            else
            {
                liters += reps / seats;
                if (reps % seats != 0) liters++;
            }
            return reps;
        }