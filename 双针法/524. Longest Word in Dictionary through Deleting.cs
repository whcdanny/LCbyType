//Leetcode 524. Longest Word in Dictionary through Deleting med
//题意：给定一个字符串 s 和一个字符串数组 dictionary，要求从 dictionary 中找到一个字符串，它可以通过删除 s 中的一些字符得到，并且是最长的满足条件的字符串。
//如果有多个满足条件的结果，返回字典序最小的那个。如果不存在这样的字符串，返回空字符串。
//思路：双指针，遍历字符串数组 dictionary 中的每个单词。
//对于每个单词，判断它是否是字符串 s 的子序列，即能通过删除 s 中的一些字符得到。
//如果是子序列，判断当前单词是否比结果字符串更长，或者如果长度相同，则判断字典序是否更小。如果是，则更新结果字符串。
//继续遍历所有单词，直到完成。
//时间复杂度： O(n * m)，其中 n 是字符串数组的长度，m 是数组中字符串的平均长度
//空间复杂度：O(1)
        public string FindLongestWord(string s, IList<string> dictionary)
        {
            string result = "";

            foreach (string word in dictionary)
            {
                if (IsSubsequence(s, word))
                {
                    if (word.Length > result.Length || (word.Length == result.Length && word.CompareTo(result) < 0))
                    {
                        result = word;
                    }
                }
            }

            return result;
        }

        private bool IsSubsequence(string s, string word)
        {
            int i = 0, j = 0;

            while (i < s.Length && j < word.Length)
            {
                if (s[i] == word[j])
                {
                    j++;
                }
                i++;
            }

            return j == word.Length;
        }