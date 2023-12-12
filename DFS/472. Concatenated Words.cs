//Leetcode 472. Concatenated Words hard
//题意：给定一个单词列表，找出其中所有的连接词。连接词是指可以由列表中其他单词按照顺序连接而成的单词。
//思路：深度优先搜索（DFS）来判断它是否是连接词。具体而言，我们从单词的每个前缀开始，尝试在列表中找到以该前缀为起始的其他单词，然后继续递归地判断剩余部分是否是连接词。
//对于判断某个单词 word 是否是连接词，我们可以定义一个辅助函数 CanForm(word, start, wordSet, memo)。其中，start 表示当前递归的起始位置，wordSet 是单词列表的哈希集，memo 是一个记忆化数组，用于记录已经计算过的结果。
//在递归过程中，我们先检查 memo[start] 是否已经计算过，如果是，则直接返回结果；否则，我们尝试在列表中找到以 word[start] 为前缀的单词，然后递归判断剩余部分是否是连接词。最后，我们将结果保存在 memo[start] 中并返回。
//时间复杂度: O(n^2 * m)，其中 n 是单词列表的长度，m 是单词的平均长度。
//空间复杂度：最坏情况下为 O(m)，其中 m 是单词的长度。额外使用了一个哈希集和一个记忆化数组，空间复杂度为 O(n + m)。
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)//超时
        {
            List<string> result = new List<string>();
            HashSet<string> parts = new HashSet<string>(words);
            int[] lengths = words.GroupBy(s => s.Length).Select(g => g.Key).OrderBy(x => x).ToArray();

            foreach (string word in words)
                if (word.Length != lengths[0] && IsConcatenated(word, lengths, parts))
                    result.Add(word);

            return result;            
        }
        public bool IsConcatenated(string word, int[] lengths, HashSet<string> parts, int start = 0)
        {
            foreach (int length in lengths)
            {
                if (start == 0 && length == word.Length)
                    return false;
                if (word.Length < length + start)
                    return false;
                string part = word.Substring(start, length);
                bool valid = parts.Contains(part);
                if (valid && word.Length > length + start)
                    valid &= IsConcatenated(word, lengths, parts, start + length);

                if (valid)
                    return true;
            }

            return false;
        }