//Leetcode 2976. Minimum Cost to Convert String I med
//题意：给定两个长度为 n 且由小写英文字母组成的字符串 source 和 target。
//还给定两个字符数组 original 和 changed 以及一个整数数组 cost，其中 cost[i] 表示将字符 original[i] 改变为字符 changed[i] 的成本。
//你需要从字符串 source 开始，在一次操作中，可以选择字符串中的一个字符 x 并以成本 z 将其更改为字符 y，前提是存在一个索引 j 使得 cost[j] == z，original[j] == x，并且 changed[j] == y。
//返回将字符串 source 转换为字符串 target 的最小成本。如果不可能转换，则返回 -1。
//思路：路径问题，使用 Floyd-Warshall 算法计算所有字符之间的最短路径
//题目给出了一系列“字符到字符的变化”，其cost相当于节点到节点的边权。
//最终，题目要求所有指定变化的最小代价和，即对应顶点之间最短距离的和。
//把每个字母转换成a-z的cost都找出，然后根据这个找出最小成本
//时间复杂度：O(26^3 + n)，其中 n 是字符串的长度。26^3 是 Floyd-Warshall 算法的时间复杂度，因为字符集的大小是常数 26，所以这是一个常数时间操作。
//空间复杂度：O(26^2)，用于存储字符之间的转换成本矩阵
        public long MinimumCost(string source, string target, char[] original, char[] changed, int[] cost)
        {
            const long INF = long.MaxValue / 3;
            long[,] d = new long[26, 26];

            // 初始化距离矩阵
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    d[i, j] = i == j ? 0 : INF;
                }
            }

            // 填充距离矩阵
            for (int i = 0; i < cost.Length; i++)
            {
                int from = original[i] - 'a';
                int to = changed[i] - 'a';
                d[from, to] = Math.Min(d[from, to], (long)cost[i]);
            }

            // 使用 Floyd-Warshall 算法计算所有字符之间的最短路径
            for (int k = 0; k < 26; k++)
            {
                for (int i = 0; i < 26; i++)
                {
                    for (int j = 0; j < 26; j++)
                    {
                        if (d[i, k] < INF && d[k, j] < INF)
                        {
                            d[i, j] = Math.Min(d[i, j], d[i, k] + d[k, j]);
                        }
                    }
                }
            }

            // 计算总的最小成本
            long ret = 0;
            for (int i = 0; i < source.Length; i++)
            {
                int a = source[i] - 'a';
                int b = target[i] - 'a';
                if (d[a, b] == INF) return -1;
                ret += d[a, b];
            }

            return ret;
        }