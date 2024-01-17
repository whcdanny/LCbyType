//Leetcode 1754. Largest Merge Of Two Strings med
//题意：给定两个字符串 word1 和 word2。构造一个字符串 merge 的方法如下：只要 word1 或 word2 非空，就可以选择以下操作之一：
//如果 word1 非空，将 word1 的第一个字符附加到 merge，并从 word1 中删除该字符。
//如果 word2 非空，将 word2 的第一个字符附加到 merge，并从 word2 中删除该字符。
//返回你可以构造的字典序最大的 merge。
//思路：双指针法分别从 word1 和 word2 的开头开始比较字符，选择字典序较大的字符附加到 merge。如果两个字符相同，需要继续比较后续的字符，直到找到不同的字符或其中一个字符串为空。选择字符的条件是选择字典序较大的字符。
//时间复杂度：O(len1 + len2)
//空间复杂度：O(len1 + len2)
        public string LargestMerge(string word1, string word2)
        {
            int i = 0, j = 0;
            int len1 = word1.Length, len2 = word2.Length;
            StringBuilder merge = new StringBuilder();

            while (i < len1 && j < len2)
            {
                if (word1.Substring(i).CompareTo(word2.Substring(j)) >= 0)
                {
                    merge.Append(word1[i]);
                    i++;
                }
                else
                {
                    merge.Append(word2[j]);
                    j++;
                }
            }

            while (i < len1)
            {
                merge.Append(word1[i]);
                i++;
            }

            while (j < len2)
            {
                merge.Append(word2[j]);
                j++;
            }

            return merge.ToString();
        }
