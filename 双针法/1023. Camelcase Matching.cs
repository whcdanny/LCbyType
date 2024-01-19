//Leetcode 1023. Camelcase Matching med
//题意：给定一个模式字符串 pattern 和一个字符串数组 queries，判断每个查询字符串是否与模式匹配。
//模式匹配的规则是：对于模式字符串的每个字符，查询字符串中可以插入小写英文字母，使得最终的查询字符串与模式相等。插入的字符可以放在任意位置，也可以不插入任何字符。        
//思路：双指针，使用双指针法遍历模式字符串和查询字符串，逐字符匹配。在匹配过程中，需要处理以下几种情况：
//如果大写字母不相同就算false，相同的时候j++，然后检查最后是否于pattern长度于J一样；        
//时间复杂度：O(m * n)
//空间复杂度：O(1)
        public IList<bool> CamelMatch(string[] queries, string pattern)
        {
            List<bool> result = new List<bool>();

            char[] patternChars = pattern.ToCharArray();

            foreach (string str in queries)
            {
                bool isMatch = CanMatchCamelMatch(str.ToCharArray(), patternChars);
                result.Add(isMatch);
            }

            return result;
        }

        private bool CanMatchCamelMatch(char[] str, char[] patternChars)
        {
            int j = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (j < patternChars.Length && str[i] == patternChars[j])
                {
                    j++;
                }
                else if (str[i] >= 'A' && str[i] <= 'Z')
                {
                    return false;
                }
            }

            return j == patternChars.Length;
        }