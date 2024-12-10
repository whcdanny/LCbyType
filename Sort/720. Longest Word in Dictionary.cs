//720. Longest Word in Dictionary med
//题目：给定一个字符串数组 words 表示一个英文单词词典，返回其中可以通过词典中其他单词逐字符构建的最长单词。
//构建规则：
//这个单词从左到右逐字符构建，每个额外的字符都必须在词典中。
//如果有多个符合条件的答案，返回字典序最小的最长单词。
//如果没有符合条件的答案，返回空字符串。
//思路：排序 + 集合判断：
//按单词的长度升序排序，长度相同的按字典序排列。
//使用一个 HashSet 来存储可以被逐字符构建的单词。
//遍历 words，检查当前单词去掉最后一个字符的前缀是否在 HashSet 中。
//如果是，将这个单词加入到 HashSet 中，同时更新结果。
//排序的意义：
//长度升序排序确保每个较短的单词会先于其可能的“长单词”被处理。
//字典序排序保证在长度相同时，字典序最小的单词优先。
//时间复杂度:  O(nlogn+n×m)
//空间复杂度： O(n)
        public string LongestWord(string[] words)
        {
            Array.Sort(words, (a, b) => a.Length == b.Length ? string.Compare(a, b) : a.Length - b.Length);
            HashSet<string> build = new HashSet<string>();
            string res = "";
            foreach(var word in words)
            {
                if(word.Length==1 || build.Contains(word.Substring(0, word.Length - 1)))
                {
                    build.Add(word);
                    if (word.Length > res.Length)
                    {
                        res = word;
                    }
                }
                
            }
            return res;
        }