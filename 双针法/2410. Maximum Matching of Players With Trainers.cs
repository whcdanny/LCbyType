//Leetcode 2410. Maximum Matching of Players With Trainers med
//题意：给定两个数组 players 和 trainers，分别表示玩家和教练的能力值和训练能力。一个玩家可以与一个训练师匹配，如果玩家的能力不超过训练师的训练能力。每个玩家和训练师最多只能匹配一次。问最大匹配数量是多少。
//思路：左右针，玩家和训练师的能力值分别排序。
//使用两个指针 i 和 j 分别遍历玩家和训练师。
//如果当前玩家的能力值不超过当前训练师的训练能力，则进行匹配，同时移动玩家指针 i。
//时间复杂度: O(m log m + n log n)，其中 m 和 n 分别是玩家和训练师的数量。遍历的时间复杂度为 O(min(m, n))
//空间复杂度：O(1)
        public int MatchPlayersAndTrainers(int[] players, int[] trainers)
        {
            Array.Sort(players);
            Array.Sort(trainers);

            int matchCount = 0;
            int i = 0;
            int j = 0;

            while (i < players.Length && j < trainers.Length)
            {
                if (players[i] <= trainers[j])
                {
                    matchCount++;
                    i++;
                }
                j++;
            }

            return matchCount;
        }