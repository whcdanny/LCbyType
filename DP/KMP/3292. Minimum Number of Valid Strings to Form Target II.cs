//Leetcode 3292. Minimum Number of Valid Strings to Form Target II hard
//题目：给定一个字符串数组 words 和一个字符串 target。如果一个字符串 x 是 words 中任意一个字符串的前缀，则称这个字符串 x 是有效的。
//要求返回形成 target 所需的最少有效字符串个数。如果无法形成 target，则返回 -1。
//思路：KPM + DP 动态规划
//KMP（Knuth-Morris-Pratt）算法是一个高效的字符串搜索算法，它的核心在于利用已经匹配的部分信息来避免重复比较，从而提高搜索效率。
//具体到代码中的 CalculateSuffixAsPrefixKMP 方法，它的作用是计算一个字符串的 LPS（Longest Prefix Suffix）数组，这个数组在模式匹配中起到了关键作用。
//这里建立dp 动态规划数组，dp[i] 表示构成 target 前 i 个字符所需的最少有效字符串的数量
//preLenths表示存储可以用于构成 target 之前的每个位置的有效前缀长度
//把每个word和target通过#结合在一起#前是word后面是target
//然后用KPM+LPS，CalculateSuffixAsPrefixKMP，PS 数组：给定一个字符串 s，LPS 数组的第 i 个元素表示字符串 s[0...i] 中，最长的相等前缀和后缀的长度。
//LPS 数组的关键作用在于，匹配失败后可以通过 lps 数组的信息直接跳到下一个可能匹配的字符，而不必逐个字符比较，从而大幅减少不必要的比较。
//在内部循环中，通过 LPS 数组判断当前 word 对应的有效前缀长度，并将其添加到 preLengths 数组中。
//对于 preLengths[i] 中的每个有效前缀长度 len，更新 dp[i + 1] 的值为 dp[i + 1 - len] + 1 和当前的 dp[i + 1] 的最小值。
//这个更新表示如果我们用一个有效前缀 len 来覆盖 target 的一部分，那么还需要 dp[i + 1 - len] 个有效字符串
//时间复杂度：O(m * n)，其中 m 是 words 的长度，n 是 target 的长度
//空间复杂度：O(n)， dp 数组和 preLengths 数组
        public int MinValidStrings_2(string[] words, string target)
        {
            int nt = target.Length;
            int[] dp = new int[nt + 1];
            HashSet<int>[] preLengths = new HashSet<int>[nt + 1];
            for (int i = 0; i <= nt; i++)
            {
                dp[i] = nt + 1;
                preLengths[i] = new HashSet<int>();
            }

            dp[0] = 0;
            foreach (var word in words)
            {
                StringBuilder sb = new StringBuilder(word);
                sb.Append("#");
                sb.Append(target);
                var lpsConcat = CalculateSuffixAsPrefixKMP(sb.ToString());
                for (int i = 0; i < nt; i++)
                {
                    int posInConcat = word.Length + i + 1;
                    if (lpsConcat[posInConcat] > 0)
                    {
                        preLengths[i].Add(lpsConcat[posInConcat]);
                    }
                }
            }

            for (int i = 0; i < nt; i++)
            {
                foreach (var len in preLengths[i])
                {
                    dp[i + 1] = Math.Min(dp[i + 1 - len] + 1, dp[i + 1]);
                }
            }

            return dp[nt] > nt ? -1 : dp[nt];
        }

        public int[] CalculateSuffixAsPrefixKMP(string s)
        {
            int n = s.Length;
            int[] lps = new int[n];
            lps[0] = 0;
            for (int i = 1; i < n; i++)
            {
                int t = lps[i - 1];

                while (t > 0 && s[i] != s[t])
                    t = lps[t - 1];
                if (s[i] == s[t])
                    t++;
                lps[i] = t;
            }
            return lps;
        }