//Leetcode 3283. Maximum Number of Moves to Kill All Pawns hard
//题目：在一个 50×50 的棋盘上，有一个骑士和一些兵。给定两个整数 kx 和 ky，表示骑士的位置，以及一个二维数组 positions，其中 positions[i] = [xi, yi] 表示第 i 个兵在棋盘上的位置。
//Alice 和 Bob 进行一场轮流的游戏，Alice 先走。在每一回合中：
//玩家选择一个仍然存在于棋盘上的兵，并用骑士以尽可能少的步数捕获它。注意，玩家可以选择任意一个兵，可能不是可以在最少步数内捕获的那个。
//在捕获所选兵的过程中，骑士可以经过其他兵而不捕获它们。只有被选择的兵可以在这一回合被捕获。
//Alice 尝试最大化两名玩家直到没有兵为止的总移动步数，而 Bob 尝试最小化这个步数。
//返回在假设两名玩家都以最优方式玩时，Alice 可以达到的最大总移动步数。
//思路: BFS+动态规划+位掩码
//看code
//时间复杂度：BFS O(1),DP:O(N*2^N)
//空间复杂度：O(N*2^N)
        static int[][] directions = new int[][]
        {
            new int[] { 2, 1 }, new int[] { -2, 1 }, new int[] { 2, -1 }, new int[] { -2, -1 },
            new int[] { 1, 2 }, new int[] { -1, 2 }, new int[] { 1, -2 }, new int[] { -1, -2 }
        };
        public int MaxMoves(int kx, int ky, int[][] positions)
        {
            int n = positions.Length;
            //包含王和小兵
            List<int[]> pos = new List<int[]>();
            pos.Add(new int[] { kx, ky });
            foreach (var p in positions)
            {
                pos.Add(new int[] { p[0], p[1] });
            }
            //利用 BFS 计算每个位置到骑士的最小步数，并存储在 mindist 数组中。
            int[,] mindist = new int[n + 1, n + 1];//数组中表示王在自己位置，还是已经吃掉某个小兵位置；对应的自己初始位置和小兵位置
            for (int index = 0; index < pos.Count; index++)
            {
                int x = pos[index][0];
                int y = pos[index][1];
                Bfs_MaxMoves(x, y, index, pos, mindist);
            }
            //初始dp，idx: 表示骑士当前的位置索引（在棋盘上的位置，包括骑士和所有的兵）。mask: 使用位掩码来表示哪些兵仍然存在。
            int[,] dp = new int[51, 1 << 15];
            for (int i = 0; i < 51; i++)
                for (int j = 0; j < (1 << 15); j++)
                    dp[i, j] = -1;
            //(1 << n) - 1 表示初始的时候 每个小兵都没有被王吃掉 二进制的退一表达，相当于8：1000 -》8-1=7：0111 
            return dp_MaxMoves(mindist, 0, (1 << n) - 1, pos.Count, true, dp);
        }

        private static int dp_MaxMoves(int[,] mindist, int idx, int mask, int n, bool alice, int[,] dp)
        {
            if (mask == 0) return 0;
            if (dp[idx, mask] != -1) return dp[idx, mask];

            int res = alice ? -1 : int.MaxValue;

            for (int i = 1; i < n; i++)
            {
                //当前小兵是否已经被吃掉
                if ((mask & (1 << (i - 1))) != 0)
                {
                    int moves = mindist[idx, i];
                    //alice是最大化
                    if (alice)
                    {
                        res = Math.Max(res, moves + dp_MaxMoves(mindist, i, (mask ^ (1 << (i - 1))), n, !alice, dp));
                    }
                    //bob是最小化
                    else
                    {
                        res = Math.Min(res, moves + dp_MaxMoves(mindist, i, (mask ^ (1 << (i - 1))), n, !alice, dp));
                    }
                }
            }

            return dp[idx, mask] = res;
        }
        //用二分法找到当前王能用多少步走到小兵的；
        //所以一开始王在初始位置；
        private static void Bfs_MaxMoves(int x, int y, int index, List<int[]> pos, int[,] mindist)
        {
            Queue<int[]> q = new Queue<int[]>();
            q.Enqueue(new int[] { x, y });
            int[,] t = new int[51, 51];

            //初始整个棋盘；
            for (int i = 0; i < 51; i++)
                for (int j = 0; j < 51; j++)
                    t[i, j] = -1;

            //当前王所在的位置；
            t[x, y] = 0;

            while (q.Count > 0)
            {
                var temp = q.Dequeue();
                int currx = temp[0];
                int curry = temp[1];

                foreach (var dir in directions)
                {
                    int newx = currx + dir[0];
                    int newy = curry + dir[1];
                    //有效，且当前位置没有经过
                    if (IsValid(newx, newy) && t[newx, newy] == -1)
                    {
                        t[newx, newy] = 1 + t[currx, curry];
                        q.Enqueue(new int[] { newx, newy });
                    }
                }
            }
            //更新mindist对应王所在是初始位置，还是第几个小兵的位置
            for (int i = 0; i < pos.Count; i++)
            {
                int x_ = pos[i][0];
                int y_ = pos[i][1];
                mindist[index, i] = t[x_, y_];
            }
        }

        private static bool IsValid(int x, int y)
        {
            return x >= 0 && x < 50 && y >= 0 && y < 50;
        }