//Leetcode 44. Wildcard Matching hard
//题意：给定一个输入字符串 s 和一个模式字符串 p，实现支持通配符匹配的算法。通配符包括：
//'?'：匹配任意单个字符。
//'*'：匹配任意长度的字符序列（包括空序列）。
//匹配要求覆盖整个输入字符串 s，即不能是部分匹配。
//思路：动态规划，dp[i][j]，表示字符串 s 的前 i 个字符与模式 p 的前 j 个字符是否匹配
// s 为空时（即 dp[0, j] 表示空字符串与模式的前 j 个字符是否匹配），模式 p 仍然有可能匹配空字符串：
//p 是由连续的 '*'  或者 p 的前缀包含非 '*' 的字符，则空字符串无法匹配该模式
//如果 p[j - 1] == '?' 或 s[i - 1] == p[j - 1]：
//dp[i][j] = dp[i - 1][j - 1]。
//如果 p[j - 1] == '*'：
//dp[i][j] = dp[i - 1][j] || dp[i][j - 1]。
//dp[i - 1][j] 表示 '*' 匹配当前字符。
//dp[i][j - 1] 表示 '*' 匹配空字符。
//时间复杂度：O(n*m)
//空间复杂度：O(n*m) 
        public bool IsMatch(string s, string p)
        {
            int m = s.Length, n = p.Length;
            bool[,] dp = new bool[m + 1, n + 1];

            // 初始化空字符串和空模式匹配
            dp[0, 0] = true;

            // 初始化当字符串为空时的匹配情况
            for (int j = 1; j <= n; j++)
            {
                if (p[j - 1] == '*')
                {
                    dp[0, j] = dp[0, j - 1];
                }
            }

            // 填充 DP 表
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] == '?' || s[i - 1] == p[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        dp[i, j] = dp[i - 1, j] || dp[i, j - 1];
                    }
                }
            }

            return dp[m, n];
        }