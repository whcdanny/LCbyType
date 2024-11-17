//Leetcode 3291. Minimum Number of Valid Strings to Form Target I med
//题目：给定一个字符串数组 words 和一个字符串 target。如果一个字符串 x 是 words 中任意一个字符串的前缀，则称这个字符串 x 是有效的。
//要求返回形成 target 所需的最少有效字符串个数。如果无法形成 target，则返回 -1。
//思路：构建字典数，Node + 动态归回
//字典树，相当于每个word的从头开始像一个树一样如果两个word都是a开头他们就公用一个“a”node;
//然后再看他们第二个字母；以此类推建立出一个这样的树；
//然后建立dp表示从 target 的开头到索引 i 所需的最少有效字符串的数量。
//然后根据target从前往后历遍，然后根据target的每个位置，根据构建的字典树，找出最少能满足的个数
//时间复杂度：O(m + n^2)，其中 m 是 words 的总字符数，n 是 target 的长度。
//空间复杂度：O(m + n)，其中 m 用于字典树存储，n 用于动态规划数组。
        public class Node
        {
            public Dictionary<char, Node> g = new Dictionary<char, Node>();
        }

        public int MinValidStrings(string[] words, string target)
        {
            // 构建字典树
            Node n = new Node();
            foreach (var word in words)
            {
                Node m = n;
                foreach (var c in word)
                {
                    if (!m.g.ContainsKey(c))
                        m.g[c] = new Node();
                    m = m.g[c];
                }
            }
            // 初始化动态规划数组，设置为较大的值
            int[] dp = Enumerable.Repeat(0, target.Length+1).Select(x => (int)10e6).ToArray();
            dp[0] = 0; // 初始状态

            // 从前向后遍历 target
            for (int j = 0; j < target.Length; j++)
            {
                if (dp[j] == 10e6) continue; // 如果当前位置不可达，跳过

                Node m = n;
                for (int i = j; i < target.Length; i++)
                {
                    if (!m.g.ContainsKey(target[i]))
                        break;
                    m = m.g[target[i]];
                    // 更新 r[i + 1] 为构造从 0 到 i 的最小有效字符串数量
                    dp[i + 1] = Math.Min(dp[i + 1], dp[j] + 1);
                }
            }

            // 检查最后一个位置
            return dp[target.Length] >= 10e6 ? -1 : dp[target.Length];            
        }