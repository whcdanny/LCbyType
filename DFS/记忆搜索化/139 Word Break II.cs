//Leetcode 139 Word Break II med
//题意：给定一个非空字符串 s 和一个包含非空单词列表的词典 wordDict，要求返回所有可能的句子组成，使得每个句子都是空格分隔的单词序列，且每个单词都是词典中的单词。
//思路：深度优先搜索（DFS）: 使用动态规划来判断字符串 s 是否可以被拆分成词典中的单词。使用一个哈希表 memo 来存储已经计算过的子问题的结果，避免重复计算。使用递归DFS的方式，在每一步中，将当前位置之后的子字符串递归调用寻找下一个单词。
//时间复杂度: 字符串长度为 n，词典中的单词数量为 m，O(2^n * n)
//空间复杂度： 深度可能达到 n, O(n)
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            HashSet<string> wordSet = new HashSet<string>(wordDict);
            Dictionary<string, List<string>> memo = new Dictionary<string, List<string>>();
            return WordBreak_DFS(s, wordSet, memo);
        }

        private List<string> WordBreak_DFS(string s, HashSet<string> wordSet, Dictionary<string, List<string>> memo)
        {
            if (memo.ContainsKey(s))
            {
                return memo[s];
            }                
            List<string> res = new List<string>();
            if (wordSet.Contains(s))
            {
                res.Add(s);
            }
            for(int i = 1; i < s.Length; i++)
            {
                string left = s.Substring(0, i);
                string right = s.Substring(i);
                if (wordSet.Contains(left))
                {
                    List<string> rightRes = WordBreak_DFS(right, wordSet, memo);
                    foreach(string rRes in rightRes)
                    {
                        res.Add(left + " " + rRes);
                    }
                }
            }
            memo[s] = res;
            return res;
        }