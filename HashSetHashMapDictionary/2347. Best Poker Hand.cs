//Leetcode 2347. Best Poker Hand ez
//题意：给定一个包含 5 张扑克牌的整数数组 ranks 和字符数组 suits，表示每张牌的点数和花色。要求判断这 5 张牌组成的扑克手牌的类型，并按照优先级从高到低返回其类型。
//扑克牌的类型按照优先级如下：
//"Flush": 五张牌的花色全部相同。
//"Three of a Kind": 五张牌中有三张点数相同的牌。
//"Pair": 五张牌中有两张点数相同的牌。
//"High Card": 五张牌中没有符合以上条件的情况，取最高点数的牌作为高牌。
//思路：hashtable 用两个dictionary来存点数出现的个数，和花色出现的个数；
//然后根据花色，和点数，来得出答案；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public string BestHand(int[] ranks, char[] suits)
        {
            Dictionary<char, int> dcSuits = new Dictionary<char, int>();
            Dictionary<int, int> dcRanks = new Dictionary<int, int>();
            bool isFlush = false;
            bool isKind = false;
            bool isPair = false;
            for (int i = 0; i < ranks.Length; i++)
            {
                if (!dcRanks.ContainsKey(ranks[i]))
                {
                    dcRanks[ranks[i]] = 1;
                }
                else
                {
                    dcRanks[ranks[i]] += 1;
                }
                if (!dcSuits.ContainsKey(suits[i]))
                {
                    dcSuits[suits[i]] = 1;
                }
                else
                {
                    dcSuits[suits[i]] += 1;
                }
                if (dcSuits[suits[i]] == 5)
                    isFlush = true;
                if (dcRanks[ranks[i]] == 3)
                    isKind = true;
                if (dcRanks[ranks[i]] == 2)
                    isPair = true;               
            }
            if (isFlush)
                return "Flush";
            if (isKind)
                return "Three of a Kind";
            if (isPair)
                return "Pair";
            return "High Card";
        }