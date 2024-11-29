//Leetcode 91. Decode Ways med
//题意：您截获了一条以数字字符串编码的秘密消息。该消息通过以下映射进行解码：
//"1" -> 'A' "2" -> 'B' "25" -> 'Y' "26" -> 'Z'
//然而，在解码消息时，您会意识到有很多不同的方法可以解码消息，因为某些代码包含在其他代码中（"2"和"5"vs "25"）。
//例如"11106"可以解码成："AAJF"与分组(1, 1, 10, 6) "KJF"与分组(11, 10, 6) 分组(1, 11, 06)无效，因为"06"不是有效代码（只有"6"有效）。
//注意：可能存在无法解码的字符串。
//给定一个仅包含数字的字符串 s，返回解码它的方法数。如果整个字符串无法以任何有效方式解码，则返回0。
//生成测试用例时，答案必须适合32 位整数。
//思路：动态规划，dp每个位置可能显示的个数
//将dp[0]和dp[1]设置为 1，因为有一种方法可以解码空字符串和长度为 1 的字符串。
//将当前的一位数和两位数子字符串转换为整数。
//如果一位数字子字符串不是“0”，dp[i] 则通过添加进行更新dp[i - 1]，因为我们可以将当前数字视为单个字符。
//如果两位数子字符串介于 10 到 26 之间（含），dp[i] 则通过添加进行更新dp[i - 2]，因为我们可以将当前两位数字视为单个字符。
//时间复杂度：O(n)
//空间复杂度：O(1) 
        public int NumDecodings(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] == '0')
            {
                return 0;
            }

            int n = s.Length;
            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; ++i)
            {
                int oneDigit = s[i - 1] - '0';
                int twoDigits = int.Parse(s.Substring(i - 2, 2));

                if (oneDigit != 0)
                {
                    dp[i] += dp[i - 1];
                }

                if (10 <= twoDigits && twoDigits <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[n];
        }