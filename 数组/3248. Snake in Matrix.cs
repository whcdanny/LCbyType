//Leetcode 3248. Snake in Matrix ez
//题目：在一个 n x n 的矩阵 grid 中，有一条蛇从 0 号位置出发，
//并可以向四个方向移动：上、右、下、左。矩阵中每个格子的编号由 grid[i][j] = (i * n) + j 给出。
//给定 n（表示矩阵的大小）和一个字符串数组 commands（其中每个命令要么是 "UP"、"RIGHT"、"DOWN"、"LEFT"），
//表示蛇的移动方向。题目保证蛇始终保持在矩阵边界内。
//要求：执行完所有命令后，返回蛇最终所在的格子编号。
//思路: 初始化起始位置：蛇从 0 号格子开始，即在位置 (0, 0)。
//移动方向的映射：
//使用一个字典定义四个方向的位移：
//"UP"：(-1, 0)，向上移动一行；
//"RIGHT"：(0, 1)，向右移动一列；
//"DOWN"：(1, 0)，向下移动一行；
//"LEFT"：(0, -1)，向左移动一列。
//逐个执行命令：
//初始化蛇的当前位置 (x, y) 为 (0, 0)。
//遍历 commands 数组，根据每个命令更新 (x, y)：
//根据命令获取对应的行列增量 (dx, dy)。
//更新当前位置为 (x + dx, y + dy)。
//计算最终位置编号：
//最终的编号为 x * n + y。
//时间复杂度：O(n + q * (log n + k))
//空间复杂度：O(n)
        public int FinalPositionOfSnake(int n, IList<string> commands)
        {
            // 初始位置为 (0, 0)
            int x = 0, y = 0;

            // 定义方向的映射
            var directions = new Dictionary<string, (int, int)>
            {
                { "UP", (-1, 0) },
                { "RIGHT", (0, 1) },
                { "DOWN", (1, 0) },
                { "LEFT", (0, -1) }
            };

            // 执行每个命令
            foreach (var command in commands)
            {
                var (dx, dy) = directions[command];
                x += dx;
                y += dy;
            }

            // 计算最终位置的编号
            return x * n + y;
        }