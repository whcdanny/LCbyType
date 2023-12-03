//Leetcode 2101. Detonate the Maximum Bombs med
//题意：给定一个二维数组 bombs，表示一些位置上的炸弹，数组的每个元素 [x, y] 表示在位置 (x, y) 上有一颗炸弹。当一颗炸弹爆炸时，其爆炸范围是整个行和整列。任务是找到最大的炸弹数量，使得所有炸弹都能被引爆。
//思路：我们可以使用BFS来解决这个问题, 根据bomb的半径算出一个正方形的爆炸范围，如果其他的任意bomb的和现在的bomb的边长a^2+b^2<=c^2，相当于三角形。然后根据这个找到的连锁爆炸范围，进行bfs，找到能最大引爆的数量；
//时间复杂度:  O(n^2)
//空间复杂度： O(n)
        public int MaximumDetonation(int[][] bombs)
        {
            // Calculate all bombs that bomb i will reach.
            List<int>[] inRange = new List<int>[bombs.Length];
            for (int i = 0; i < bombs.Length; i++)
            {
                inRange[i] = new List<int>();
                long distSq = (long)bombs[i][2] * (long)bombs[i][2];
                for (int j = 0; j < bombs.Length; j++)
                {
                    if (i == j) continue;

                    if (Math.Pow(bombs[i][0] - bombs[j][0], 2)
                        + Math.Pow(bombs[i][1] - bombs[j][1], 2) <= distSq)
                    {
                        inRange[i].Add(j);
                    }
                }
            }

            // Choose starting bomb and calculate max damage
            int result = 0;
            
            for (int i = 0; i < bombs.Length; i++)
            {
                bool[] visited = new bool[bombs.Length];
                result = Math.Max(result, DFS_MaximumDetonation(bombs, visited, inRange, i));
            }
            return result;
        }

        // DFS from starting bomb, returns total hit
        public int DFS_MaximumDetonation(int[][] bombs, bool[] visited, List<int>[] inRange, int b)
        {
            int res = 0;
            visited[b] = true;
            res++;
            foreach(int bomb in inRange[b])
            {
                if (!visited[bomb])
                    res += DFS_MaximumDetonation(bombs, visited, inRange, bomb);
            }
            return res;
        }