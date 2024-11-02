//Leetcode 3238. Find the Number of Winning Players ez
//题目：给定一个整数 n 表示游戏中玩家的数量，以及一个二维数组 pick，其中 pick[i] = [xi, yi] 表示玩家 xi 选择了颜色 yi 的球。
//每个玩家的获胜条件为：玩家 i 获胜的条件是必须选择至少 i + 1 个相同颜色的球。具体条件如下：
//玩家 0 只需选择任意一个球即可获胜；
//玩家 1 需要选择至少 2 个相同颜色的球才能获胜；
//玩家 i 需要选择至少 i + 1 个相同颜色的球才能获胜。
//目标是计算满足获胜条件的玩家总数。
//思路: 记录每个玩家的球的颜色计数：
//使用一个字典 playerColorCount 来存储每个玩家对每种颜色球的选择次数。
//遍历 pick 数组，对于每条记录 pick[i] = [xi, yi]，更新 playerColorCount 中玩家 xi 对颜色 yi 的计数。
//判断每个玩家是否获胜：
//初始化一个 winningPlayers 计数器，用于记录满足条件的获胜玩家。
//对每个玩家 i，检查其对每种颜色球的选择次数，判断是否有任何颜色球的计数达到或超过 i + 1，满足条件即计入获胜玩家。
//时间复杂度：O(m)，其中 m 是 pick 数组的长度
//空间复杂度：O(n * c)，其中 c 是每个玩家所选择颜色的种类数
        public int WinningPlayerCount(int n, int[][] pick)
        {
            // 记录每个玩家对每种颜色球的选择次数
            var playerColorCount = new Dictionary<int, Dictionary<int, int>>();

            foreach (var p in pick)
            {
                int player = p[0];
                int color = p[1];

                if (!playerColorCount.ContainsKey(player))
                {
                    playerColorCount[player] = new Dictionary<int, int>();
                }
                if (!playerColorCount[player].ContainsKey(color))
                {
                    playerColorCount[player][color] = 0;
                }
                playerColorCount[player][color]++;
            }

            int winningPlayers = 0;

            // 检查每个玩家是否获胜
            foreach (var kvp in playerColorCount)
            {
                int player = kvp.Key;
                int requiredCount = player + 1;

                // 检查该玩家选择的所有颜色球的计数
                foreach (var colorCount in kvp.Value.Values)
                {
                    if (colorCount >= requiredCount)
                    {
                        winningPlayers++;
                        break;
                    }
                }
            }

            return winningPlayers;
        }