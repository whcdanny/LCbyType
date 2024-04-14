//Leetcode 2225. Find Players With Zero or One Losses med
//题意：给定一个整数数组 matches，其中 matches[i] = [winneri, loseri] 表示选手 winneri 在比赛中击败了选手 loseri。
//要求返回一个大小为2的列表 answer，其中：
//answer[0] 是所有未输过比赛的选手列表。
//answer[1] 是只输过一场比赛的选手列表。
//这两个列表中的值应以递增顺序返回。
//注意：    
//只考虑至少参加了一场比赛的选手。
//测试用例将确保没有两场比赛的结果相同。
//思路：hashtable 使用哈希表存储每位选手的输赢情况。
//遍历 matches 数组，更新每位选手的胜场和负场。
//根据条件筛选出未输过比赛和只输过一场比赛的选手。
//将筛选后的选手列表按照要求排序并返回。
//时间复杂度：O(n)，排序为 O(mlogm)，其中 n 是 matches 的长度，m 是选手的数量。
//空间复杂度：O(m)，其中 m 是选手的数量
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            Dictionary<int, int[]> playerStats = new Dictionary<int, int[]>();

            foreach (var match in matches)
            {
                int winner = match[0];
                int loser = match[1];

                if (!playerStats.ContainsKey(winner))
                {
                    playerStats[winner] = new int[2];
                }
                if (!playerStats.ContainsKey(loser))
                {
                    playerStats[loser] = new int[2];
                }

                playerStats[winner][0]++; // Increment wins for winner
                playerStats[loser][1]++; // Increment losses for loser
            }

            List<int> zeroLossPlayers = new List<int>();
            List<int> oneLossPlayers = new List<int>();

            foreach (var playerStat in playerStats)
            {
                int player = playerStat.Key;
                int[] stats = playerStat.Value;

                if (stats[1] == 0)
                {
                    zeroLossPlayers.Add(player);
                }
                else if (stats[1] == 1)
                {
                    oneLossPlayers.Add(player);
                }
            }

            zeroLossPlayers.Sort();
            oneLossPlayers.Sort();

            return new List<IList<int>> { zeroLossPlayers, oneLossPlayers };
        }