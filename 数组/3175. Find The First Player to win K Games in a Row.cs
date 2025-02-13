//Leetcode 3175. Find The First Player to win K Games in a Row med
//题目：我们有一个 n 个玩家组成的队列，每个玩家有不同的技能值 skills[i]，技能值越高的玩家在比赛中越有优势。
//每轮比赛中，队首的两个玩家进行对战，技能高的玩家胜出，失败者则排到队列末尾。
//胜者将继续留在队首，直到下一轮继续对战。我们需要找到第一个连续赢得 k 场比赛的玩家，并返回该玩家的初始索引。        
//思路: 从第一个开始，然后如果第二个技能大于现在的，那么最大位置更换，然后重置计数，然后直到找的k个大，或者到n
//这里有个注意的，如果k大于n，那么肯定是skills中最大的那个数的位置
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int FindWinningPlayer(int[] skills, int k)
        {
            int cnt = 0; // 计数器，用于记录当前玩家的连续获胜次数
            int res = 0; // 当前胜者的索引

            // 从第二个玩家开始遍历，因为第一个玩家默认为初始连胜者
            for (int i = 1; cnt < k && i < skills.Length; ++i)
            {
                if (skills[res] < skills[i])
                {
                    // 如果当前玩家的技能值高于当前胜者，更新当前胜者为该玩家
                    res = i;
                    cnt = 1; // 重置连胜计数器
                }
                else
                {
                    // 如果当前胜者继续获胜，则增加连胜次数
                    ++cnt;
                }
            }

            return res; // 返回连续赢得 k 场比赛的玩家索引
        }