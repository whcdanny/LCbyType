//467. Unique Substrings in Wraparound String med
//题目：我们定义一个无限循环的字符串 base 为：
//...zabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcd...
//给定一个字符串 s，返回 s 中的所有非空子字符串在 base 中出现的唯一子字符串的数量。
//思路：动态规划：dp存入以每个字母为结束最长连续有效子串长度
//因为连续得子集数量就是是：因为长度为 n 的字符串包含 1 + 2 + ... + n，
//所以判断 (i > 0 && (s[i] - s[i - 1] == 1 || (s[i - 1] == 'z' && s[i] == 'a')))
//然后更新maxLengthCurrent
//如果不满足条件就重置 maxLengthCurrent = 1;
//最后把每个位置出现的个数都+，因为每个 dp[i] 的值代表以该字符为结尾的所有唯一子串的数量
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public int FindSubstringInWraproundString(string s)
        {
            if (s.Length == 0)
                return 0;

            // dp数组记录以每个字符结尾的最长有效子串长度
            int[] dp = new int[26];
            int maxLengthCurrent = 0;

            for (int i = 0; i < s.Length; i++)
            {
                // 判断当前字符和前一个字符是否构成连续递增关系
                if (i > 0 && (s[i] - s[i - 1] == 1 || (s[i - 1] == 'z' && s[i] == 'a')))
                {
                    maxLengthCurrent++;
                }
                else
                {
                    maxLengthCurrent = 1;
                }

                // 更新以字符 s[i] 结尾的最长有效子串长度
                int index = s[i] - 'a';
                dp[index] = Math.Max(dp[index], maxLengthCurrent);
            }

            // 结果是所有 dp 值之和
            int result = 0;
            foreach (int length in dp)
            {
                result += length;
            }

            return result;            
        }