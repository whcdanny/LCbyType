//Leetcode 2350. Shortest Impossible Sequence of Rolls hard
//题意：给定一个长度为 n 的整数数组 rolls 和一个整数 k。你掷出一个 k 面的骰子，点数从 1 到 k，共 n 次，其中第 i 次掷骰子的结果是 rolls[i]。
//返回无法从 rolls 中取得的最短掷骰子序列的长度。
//长度为 len 的掷骰子序列是 len 次掷骰子的结果。
//思路：hashtable 说白了，
//第一是有k个，[1][2]...[k]  
//第二是k*k个，[1,1] [1,2],... [2,1]...[4,4]
//所以从后往前找，用hashset，这样从后往前只要有hashset的count等于k，就说明当前能满足k个，然后依此往前，这样能找到多少个这样区间，就能找的几个；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int ShortestSequence(int[] rolls, int k)
        {
            HashSet<int> set = new HashSet<int>();
            int ret = 0;
            for (int i = rolls.Length - 1; i >= 0; i--)
            {
                set.Add(rolls[i]);
                if (set.Count == k)
                {
                    ret++;
                    set.Clear();
                }
            }
            return ret + 1;
        }