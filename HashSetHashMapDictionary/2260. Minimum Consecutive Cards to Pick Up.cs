//Leetcode 2260. Minimum Consecutive Cards to Pick Up med
//题意：给定一个整数数组 cards，其中 cards[i] 表示第 i 张卡片的值。如果两张卡片的值相同，则称它们是匹配的。
//返回你必须拿起的连续卡片的最小数量，以便在拿起的卡片中有一对匹配的卡片。如果无法找到匹配的卡片，则返回 -1。
//思路：hashtable 用dictionary存入每个数字和其出现的位置，然后当找到之前出现的数字，那就算出当前len，然找出minlen      
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinimumCardPickup(int[] cards)
        {
            var dict = new Dictionary<int, int>();
            int len = -1;
            int minLen = int.MaxValue;
            for (int i = 0; i < cards.Length; i++)
            {
                if (dict.ContainsKey(cards[i]))
                {
                    len = i - dict[cards[i]] + 1;
                    if (len < minLen)
                    {
                        minLen = len;
                    }
                }
                dict[cards[i]] = i;
            }
            return minLen == int.MaxValue ? -1 : minLen;
        }