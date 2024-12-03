//Leetcode 913. Cat and Mouse hard
//题意：在一个无向图上，有两名玩家：老鼠 (Mouse) 和猫 (Cat)。他们交替进行游戏。
//图的表示方式：graph[a] 是一个列表，表示与节点a 相连的所有节点b。
//游戏初始时，老鼠位于节点 1，猫位于节点 2，洞位于节点 0。
//游戏规则：
//老鼠和猫分别沿着相邻的边移动。老鼠从节点 1 开始，猫从节点 2 开始，老鼠先移动。
//猫 不能 移动到洞(节点 0)。
//游戏结束的三种情况：
//如果猫和老鼠占据同一个节点，猫获胜。
//如果老鼠到达洞(节点 0)，老鼠获胜。
//如果某个状态重复（即两者的位置与轮次都相同），判定为平局。
//目标：根据两者最优的策略，返回以下结果：
//1：如果老鼠获胜。2：如果猫获胜。0：如果游戏平局。
//思路：动态规划 + BFS
//先建图
//用bool存入每个节点与node0相连的节点，如果与node0相连为true
//动态规划：dp[mouseNode, catNode, turn(0 表示鼠标，1 表示猫)] gameResults
//结果是1：鼠从该状态能获胜。2：猫从该状态能获胜。0：该状态为平局。-1：状态尚未计算。
//再建立一个问计数器 visitCounter，用于记录某状态被访问的次数[mouseNode, catNode, turn(0 表示鼠标，1 表示猫)]
//BFS:用queue来存[mouseNode, catNode, turn(0 表示鼠标，1 表示猫)]
//初始化queue：我们用倒退方向，
//鼠赢 [0, i, 0] = 1; [0, i, 1] = 1;
//猫赢 [i, i, 0] = 2; [i, i, 1] = 2;
//然后每一次倒退相当于，所以 先根据queue和gameResults 找出 mousePos, catPos, turn 还有 result;
//猫的回合：查看相连的node（父节点）
//先看是否已经有了结果，
//然后此时是老鼠赢，那么更新当前为老鼠赢，因为子节点赢了，父节点更新
//如果是还是没有结果，那么更新visitCounter计数器，然后如果当前位置的总个数==所有节点的个数：
//说明所有可能下老鼠都赢不了，只有猫赢gameResults[neighbor, catPos, 0] = 2;
//鼠的回合：查看相连的node（父节点）
//先看是否已经有了结果，
//然后此时是猫赢，那么更新当前为猫赢，因为子节点赢了，父节点更新
//如果是还是没有结果，那么更新visitCounter计数器，然后如果当前位置的总个数==(所有节点的个数 或者 所有节点个数-1（取决于是不是连着node0））：
//说明所有可能下老鼠都赢不了，只有猫赢gameResults[neighbor, catPos, 0] = 2;
//最后看[1,2,0]的结果如果-1就是0，其他就根据结果来
//时间复杂度：O(n^3) 状态数量：n^2, 每个状态的邻居数量最坏结果都相邻n;
//空间复杂度：O(n^2)
        public int CatMouseGame(int[][] graph)
        {
            //Mouse开始node 1
            //Cat开始node 2
            //Mouse到达node 0 (the hole)
            //Cat在同一个node
           
            //建图
            int numberOfNodes = graph.Length;

            var graphList = new List<int>[numberOfNodes];

            for (int i = 0; i < numberOfNodes; i++)
            {
                graphList[i] = new List<int>(graph[i]);
            }

            // 标记每个节点是否与洞（节点 0）相连，方便后续猫的行动判断。
            bool[] hasEdgeToHole = new bool[numberOfNodes];

            for (int i = 1; i < numberOfNodes; i++)
            {
                foreach (var neighbor in graphList[i])
                {
                    if (neighbor == 0)
                    {
                        hasEdgeToHole[i] = true;
                    }
                }
            }

            //mousePos：鼠的位置;catPos：猫的位置;turn：当前轮到谁行动（0 表示鼠标，1 表示猫）
            //1：鼠从该状态能获胜。2：猫从该状态能获胜。0：该状态为平局。-1：状态尚未计算。
            int[,,] gameResults = new int[numberOfNodes, numberOfNodes, 2];

            for (int i = 0; i < numberOfNodes; i++)
            {
                for (int j = 0; j < numberOfNodes; j++)
                {
                    gameResults[i, j, 0] = gameResults[i, j, 1] = -1;
                }
            }
            // 初始化访问计数器 visitCounter，用于记录某状态被访问的次数。
            int[,,] visitCounter = new int[numberOfNodes, numberOfNodes, 2];
            
            Queue<(int mousePos, int catPos, int turn)> gameQueue = new Queue<(int, int, int)>();

            //老鼠赢
            for (int i = 1; i < numberOfNodes; i++)
            {
                gameResults[0, i, 1] = 1;
                gameResults[0, i, 0] = 1;
                gameQueue.Enqueue((0, i, 1));
                gameQueue.Enqueue((0, i, 0));
            }

            //猫赢
            for (int i = 1; i < numberOfNodes; i++)
            {
                gameResults[i, i, 0] = 2;
                gameResults[i, i, 1] = 2;
                gameQueue.Enqueue((i, i, 0));
                gameQueue.Enqueue((i, i, 1));
            }

            //Processing the Game States
            //如果老鼠回合，移动到最近node并且避免cat相撞；If it’s the mouse's turn, it moves to a neighboring node, avoiding the cat if possible
            //如果猫的回合，移动到最近的node并向老鼠并且不能到0If it’s the cat's turn, it tries to catch the mouse by moving closer to the mouse
            while (gameQueue.Count > 0)
            {
                var (mousePos, catPos, turn) = gameQueue.Dequeue();
                int result = gameResults[mousePos, catPos, turn];

                //已经有结果了
                if (gameResults[1, 2, 0] != -1)
                {
                    break;
                }

                //老鼠回合
                if (turn == 0)
                {
                    foreach (var neighbor in graphList[catPos])
                    {
                        //猫不能移动到0
                        if (neighbor == 0)
                            continue;

                        //已经有结果了
                        if (gameResults[mousePos, neighbor, 1] != -1)
                            continue;

                        //猫胜利，更新到父状态。
                        if (result == 2)
                        {
                            gameResults[mousePos, neighbor, 1] = result;
                            gameQueue.Enqueue((mousePos, neighbor, 1));
                        }
                        else
                        {
                            //统计访问次数，检查是否可以标记为鼠标胜利。
                            visitCounter[mousePos, neighbor, 1]++;

                            int maxDegree = hasEdgeToHole[neighbor] ? graphList[neighbor].Count - 1 : graphList[neighbor].Count;
                            //如果一个状态被所有可能的父状态访问，并且这些父状态都未能让猫胜利;
                            //也就是说如果我访问了所有可能性，然后发现还是无法改变这个node的结果让猫赢吗，那么肯定是鼠赢
                            if (visitCounter[mousePos, neighbor, 1] >= maxDegree)
                            {
                                gameResults[mousePos, neighbor, 1] = 1;
                                gameQueue.Enqueue((mousePos, neighbor, 1));
                            }
                        }
                    }
                }
                else //猫的回合
                {
                    foreach (var neighbor in graphList[mousePos])
                    {
                        //已经有结果了
                        if (gameResults[neighbor, catPos, 0] != -1)
                            continue;

                        //鼠胜利，更新到父状态。
                        if (result == 1)
                        {
                            gameResults[neighbor, catPos, 0] = result;
                            gameQueue.Enqueue((neighbor, catPos, 0));
                        }
                        else 
                        {
                            //统计访问次数，检查是否可以标记为猫胜利。
                            visitCounter[neighbor, catPos, 0]++;

                            int maxDegree = graphList[neighbor].Count;
                            //所有可能结果都指向猫胜利。
                            if (visitCounter[neighbor, catPos, 0] == maxDegree)
                            {
                                gameResults[neighbor, catPos, 0] = 2;
                                gameQueue.Enqueue((neighbor, catPos, 0));
                            }
                        }
                    }
                }
            }
            if (gameResults[1, 2, 0] == -1)
            {
                return 0; 
            }
            else
            {
                return gameResults[1, 2, 0];
            }
        }