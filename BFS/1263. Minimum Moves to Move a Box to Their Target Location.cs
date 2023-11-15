//Leetcode 1263. Minimum Moves to Move a Box to Their Target Location hard
//题意：店主是一款游戏，玩家在仓库中推箱子，试图将它们送到目标位置。游戏由m x n角色网格表示grid，其中每个元素是墙壁、地板或盒子。你的任务是按照以下规则将盒子移动'B'到目标位置：'T'    
//角色'S'代表玩家。grid如果是地板（空单元格），则玩家可以向上、向下、向左、向右移动。
//该字符'.'代表地板，这意味着可以自由行走的单元格。
//这个角色代表墙，意味着障碍物（不可能走到那里）。 '#' 
//中只有一个框'B'和一个目标单元格。'T'grid
//通过站在盒子旁边然后朝盒子的方向移动，可以将盒子移动到相邻的空闲单元。这是一推。
//玩家不能穿过盒子。
//返回将盒子移动到目标的最小推动次数。如果无法达到目标，则返回-1。
//思路：首先，我们扫描给定的网格以查找并存储人、盒子和目标的位置。接下来，我们用人和盒子的位置初始化一个队列和一个 hashSet。接下来，我们使用该队列对二维网格进行 BFS 遍历。每个队列元素将有新的盒子和人员位置。一旦元素出列，网格上的框位置就会更新为#。BFS 会找到最短距离，因为它的径向搜索模式按照距起点的距离顺序考虑节点 [2]。可以看出，对于未加权图，BFS 等价于 Dijkstra 算法，从而找到这种情况下的最短路径。因此找到的第一条路径将是最短路径。Valid() 用于验证人员位置或盒子位置。CanReach() 是该解决方案的 DFS 部分。它会发现一个人是否可以到达盒子的“后面”。pplLoc 是我们的记忆数组（将其转换为自上而下的 dp）。此实现的一个智能功能是使用 HashSet 来跟踪访问的单元格。HashSet 跟踪“状态”，而不是访问。HashSet 具有元素进入队列时盒子和人的位置，而不仅仅是访问网格单元。如果“状态”不同，这允许我们重新访问某个单元。
//时间复杂度: O(m * n)
//空间复杂度：O(m * n)
        List<int[]> directions = new List<int[]> { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 } };
        public int MinPushBox(char[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;

            int[] target = new int[2]; // 目标位置
            int[] box = new int[2];    // 箱子位置
            int[] person = new int[2]; // 人物位置

            // 找到箱子、目标和人物的初始位置
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == 'B')
                    {
                        box[0] = i;
                        box[1] = j;
                    }
                    else if (grid[i][j] == 'T')
                    {
                        target[0] = i;
                        target[1] = j;
                    }
                    else if (grid[i][j] == 'S')
                    {
                        person[0] = i;
                        person[1] = j;
                    }
                }
            }

            Queue<int[]> queue = new Queue<int[]>();
            HashSet<string> visited = new HashSet<string>();

            int[] startState = new int[] { person[0], person[1], box[0], box[1]};
            queue.Enqueue(startState);
            visited.Add($"{person[0]},{person[1]},{box[0]},{box[1]}");

            
            int res = 0;
            while (queue.Count > 0)
            {
                res++;
                int count = queue.Count;
                for(int i = 0; i < count; i++)
                {
                    int[] state = queue.Dequeue();

                    int personRow = state[0];
                    int personCol = state[1];
                    int boxRow = state[2];
                    int boxCol = state[3];
                    grid[boxRow][boxCol] = '#';

                    foreach (var dir in directions)
                    {
                        var pplLoc = new bool[m, n];
                        if (CanReach(grid, pplLoc, personRow, personCol, boxRow - dir[0], boxCol - dir[1]))
                        {
                            int newBoxRow = boxRow + dir[0];
                            int newBoxCol = boxCol + dir[1];
                            if (newBoxRow == target[0] && newBoxCol == target[1])
                            {
                                return res;
                            }
                            if (Valid(grid, newBoxRow, newBoxCol))
                            {
                                string newState = $"{boxRow},{boxCol},{newBoxRow},{newBoxCol}";
                                if (!visited.Contains(newState))
                                {
                                    visited.Add(newState);
                                    queue.Enqueue(new int[] { boxRow, boxCol, newBoxRow, newBoxCol});
                                }
                            }
                        }
                    }
                    grid[boxRow][boxCol] = '.';
                }                
            }

            return -1;
        }

        bool CanReach(char[][] g, bool[,] pplLoc, int x, int y, int bx, int by)
        {
            if (!Valid(g, x, y) || pplLoc[x, y])
            {
                return false;
            }
            if (bx == x && by == y)
            {
                return true;
            }
            pplLoc[x, y] = true;
            foreach (var d in directions)
            {
                if (CanReach(g, pplLoc, x + d[0], y + d[1], bx, by))
                {
                    return true;
                }
            }
            return false;
        }
        bool Valid(char[][] g, int x, int y)
        {
            if (x < 0 || x >= g.Length || y < 0 || y >= g[0].Length || g[x][y] == '#')
            {
                return false;
            }
            return true;
        }

