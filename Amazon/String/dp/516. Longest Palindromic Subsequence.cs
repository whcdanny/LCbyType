//Leetcode 516. Longest Palindromic Subsequence med
//题目：给定一个字符串 s，找到其中 最长回文子序列 的长度。
//回文子序列 是指一个可以通过删除一些或不删除任何字符（同时保持字符顺序不变）得到的子序列，并且该子序列是一个回文。
//例如，字符串 "bbbab" 的最长回文子序列是 "bbbb"，长度为 4。
//如果字符串为空，返回 0。
//思路: 动态规划，dp[i][j] i是起始位置，j是结束位置
//如果一致，那么就相当于[i,j]区间从[i+1，j-1]+2
//如果不一致，那么就要舍弃其中一个字符，找出最大值保存
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int LongestPalindromeSubseq(string s)
        {
            int n = s.Length;
            int[,] dp = new int[n, n];
            for(int i = 0; i < n; i++)
            {
                dp[i, i] = 1;
            }
            
            for(int len = 2; len <= n; len++)
            {
                for(int i = 0; i <= n - len; i++)
                {
                    //i表示开始，j表示结尾位置
                    int j = i + len - 1;
                    //如果一致，那么就相当于[i,j]区间从[i+1，j-1]+2
                    if (s[i] == s[j])
                    {
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                    //如果不一致，那么就要舍弃其中一个字符，找出最大值保存
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[0, n-1];
        }