//Leetcode 291 Word Pattern II hard
//题意：要求在给定一个模式字符串 pattern 和一个目标字符串 str 的情况下，判断是否存在一个非空的映射关系，使得模式字符串中的每个字符与目标字符串中的一个或多个单词相匹配。
//思路：深度优先搜索（DFS,两个字典 patternDict 和 wordDict，分别用于存储模式字符到单词和单词到模式字符的映射。逐步尝试从 pattern 中取一个字符，然后在 str 中寻找对应的单词。如果找到了对应的单词，检查该单词是否已经在 wordDict 中有映射，如果有则比较是否相等，如果不相等则返回 false，如果没有则更新映射关系。递归调用下一层，继续匹配剩下的字符和单词。
//时间复杂度:  n 是输入字符串的长度, O(n)
//空间复杂度： n 是输入字符串的长度, O(n)
        public bool WordPatternMatch(string pattern, string str)
        {
            Dictionary<char, string> patternDict = new Dictionary<char, string>();
            HashSet<string> usedWords = new HashSet<string>();
            return IsMatch(pattern, str, 0, 0, patternDict, usedWords);
        }

        private bool IsMatch(string pattern, string str, int pIdx, int sIdx,
                             Dictionary<char, string> patternDict, HashSet<string> usedWords)
        {
            if (pIdx == pattern.Length && sIdx == str.Length)
            {
                return true;
            }
            if (pIdx == pattern.Length || sIdx == str.Length)
            {
                return false;
            }

            char pChar = pattern[pIdx];

            if (patternDict.ContainsKey(pChar))
            {
                string match = patternDict[pChar];
                if (str.Length - sIdx < match.Length || !str.Substring(sIdx, match.Length).Equals(match))
                {
                    return false;
                }
                return IsMatch(pattern, str, pIdx + 1, sIdx + match.Length, patternDict, usedWords);
            }

            for (int i = sIdx; i < str.Length; i++)
            {
                string word = str.Substring(sIdx, i - sIdx + 1);
                if (usedWords.Contains(word))
                {
                    continue;
                }
                patternDict[pChar] = word;
                usedWords.Add(word);
                if (IsMatch(pattern, str, pIdx + 1, i + 1, patternDict, usedWords))
                {
                    return true;
                }
                patternDict.Remove(pChar);
                usedWords.Remove(word);
            }

            return false;
        }