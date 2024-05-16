//Leetcode 2952. Minimum Number of Coins to be Added med
//题意：给定一个硬币面值的数组 coins 和一个目标值 target，问至少需要添加多少个硬币，
//使得可以得到范围 [1, target] 内的所有整数。
//思路：将所有的coins排序后，假设当前已有的硬币能够组成任意[0, limit]之间的面额，那么又得到一枚面值是x的硬币，此时能够组成多少种面额呢？
//显然，当新硬币不用时，我们依然能构造出[0, limit]；
//当使用新硬币时，我们可以构造出[x, limit+x]。
//当这两段区间不连接时，即limit+1<x时，说明我们无论如何也无法构造出面额是limit+1的面额，意味着我们必须单独加入该面额的硬币才能构造出该面额，
//这样我们将上限提高至了2*limit+1。
//反之limit+1>=x时，则意味着我们可以构造出任意[0,limit+x]区间内的面额。
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int MinimumAddedCoins(int[] coins, int target)
        {
            Array.Sort(coins);
            int limit = 1;
            int i = 0;
            int res = 0;
            while (limit < target)
            {
                //不能被覆盖；
                if (i == coins.Length || limit + 1< coins[i])
                {
                    res++;
                    limit += limit + 1;
                }
                else
                {
                    limit += coins[i];
                    i++;
                }
            }
            return res;
        }