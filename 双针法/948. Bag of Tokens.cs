//Leetcode 948. Bag of Tokens med
//题意：你有一个初始能量 power，一个初始分数 0，和一个令牌袋，其中 tokens[i] 是第 i 个令牌的价值（从 0 开始索引）。
//你的目标是通过可能的方式最大化你的总分：
//如果你当前的能量至少为 tokens[i]，你可以正面播放第 i 个令牌，失去 tokens[i] 能量并获得 1 分。
//如果你当前的分数至少为 1，你可以反面播放第 i 个令牌，获得 tokens[i] 能量并失去 1 分。
//每个令牌最多可以播放一次，顺序任意。你不必播放所有的令牌。
//返回在播放任意数量的令牌后你可以达到的最大分数。
//思路：双指针，令牌按照价值从小到大排序。
//使用两个指针，一个指向令牌的起始位置，一个指向令牌的结束位置。
//如果当前能量大于等于令牌的价值，正面播放令牌，得分加一，能量减少。
//如果当前能量小于令牌的价值，反面播放令牌，得分减一，能量增加。
//时间复杂度：O(nlogn)，其中 n 是令牌的数量，排序的时间复杂度为 O(nlogn)
//空间复杂度：O(1)
        public int BagOfTokensScore(int[] tokens, int power)
        {
            Array.Sort(tokens);
            int left = 0, right = tokens.Length - 1;
            int score = 0, maxScore = 0;

            while (left <= right)
            {
                if (power >= tokens[left])
                {
                    power -= tokens[left++];
                    score++;
                    maxScore = Math.Max(maxScore, score);
                }
                else if (score > 0)
                {
                    power += tokens[right--];
                    score--;
                }
                else
                {
                    break;
                }
            }

            return maxScore;
        }