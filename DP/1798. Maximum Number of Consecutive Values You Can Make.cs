//Leetcode 1798. Maximum Number of Consecutive Values You Can Make med
//题意：给定一个整数数组 coins，表示你拥有的硬币，每个硬币的面值为 coins[i]。
//你可以选择一些硬币，使得它们的面值之和为某个值 x。
//要求返回你可以用拥有的硬币组成的连续整数值的最大数量，这些整数值从 0 开始。
//思路：动态规划比较常规的想法是，维护一个集合Set来记录我们构造什么样的面值。
//我们按照从小到大的顺序挨个考察coins，对于当前的c，能够带来什么样的新面值呢？
//显然就是Set里面的每个元素（包括空元素）分别加上c。
//我们这个时候再看一下这个Set，如果此时集合里下一个待构造的面值next小于c的话，那么这个面值以后肯定就再也无法构造。
//因为之后我们遇到的单个硬币都会比next更大，不会带来任何帮助。
//集合需要存储可以构造的所有面值，这个数量可能会非常大。
//比如说k个硬币，任意组合的面值都不重合的话，那么就会有2^k种面值。
//当考察第k+1个硬币带来的集合更新时，很可能会TLE。
//时间复杂度: O(n);
//空间复杂度：O(n)
        public int GetMaximumConsecutive_超时(int[] coins)
        {
            Array.Sort(coins);
            HashSet<int> set = new HashSet<int>();
            set.Add(0);
            int next = 1;
            foreach (var c in coins)
            {
                if (next < c)
                    return next;
                List<int> temp = new List<int> { c };
                foreach (var t in set)
                    temp.Add(t + c);
                foreach (var x in temp)
                    set.Add(x);
                while (set.Contains(next))
                    next++;
            }
            return next;
        }