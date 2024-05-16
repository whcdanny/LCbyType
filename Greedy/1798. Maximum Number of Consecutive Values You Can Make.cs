//Leetcode 1798. Maximum Number of Consecutive Values You Can Make med
//题意：给定一个整数数组 coins，表示你拥有的硬币，每个硬币的面值为 coins[i]。
//你可以选择一些硬币，使得它们的面值之和为某个值 x。
//要求返回你可以用拥有的硬币组成的连续整数值的最大数量，这些整数值从 0 开始。
//思路：本题的突破口其实是，要注意到，每次这个集合的元素其实都应该是保证连续的！
//假设当前集合能够构造从0到curMax的连续面值。
//那么显然加入新硬币c之后，就能够构造从c到curMax+c的连续面值。
//如果[0, curMax] 和[c, curMax + c]这两段区间是交叠的，那么新的curMax就是curMax+c。
//如果这两段区间不交叠，即curmax+1 < c（注意+1），那么说明curMax+1无法构造。
//注意，此后的新硬币面值都将大于c，那么也意味着大于curMax+1。
//说明以后任何新硬币都不会给构造curMax+1带来帮助。此时能构造的连续面值就是[0, curMax].
//时间复杂度: O(n);
//空间复杂度：O(n)
        public int GetMaximumConsecutive(int[] coins)
        {
            Array.Sort(coins);
            int curMax = 0;
            foreach(int c in coins)
            {
                if (c > curMax + 1)
                    break;
                curMax += c;
            }
            return curMax + 1;
        }