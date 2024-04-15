//Leetcode 2135. Count Words Obtained After Adding a Letter med
//题意：给定两个字符串数组 startWords 和 targetWords。每个字符串都只包含小写英文字母。
//对于 targetWords 中的每个字符串，检查是否可以从 startWords 中选择一个字符串，并对其执行一系列转换操作，使其变成与 targetWords 中的字符串相等。
//转换操作描述如下：
//在字符串的末尾追加任何一个不在字符串中的小写字母。
//例如，如果字符串是 "abc"，则可以添加字母 'd'、'e' 或 'y'，但不能添加 'a'。如果添加 'd'，则结果字符串将是 "abcd"。
//对新字符串中的字母进行任意顺序的重新排列。
//例如，"abcd" 可以重新排列为 "acbd"、"bacd"、"cbda" 等等。注意，它也可以保持原样 "abcd"。
//返回 targetWords 中可以通过对 startWords 中的任何字符串执行上述操作而获得的字符串数量。
//思路：hashtable 辅助function convert word 到 bitmask
//多次重新阅读实际问题，以了解到底要问什么。 🤦‍♂️
//用起始词的位掩码填充哈希。
//通过关闭 1 位来检查起始字中是否存在目标字。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int WordCount(string[] startWords, string[] targetWords)
        {            
            HashSet<int>[] hashset = new HashSet<int>[27];
            for (int i = 0; i < hashset.Length; i++)
                hashset[i] = new HashSet<int>();

            foreach (var word in startWords)
            { 
                hashset[word.Length].Add(w2bit(word));
            }

            int answer = 0;

            foreach (var src in targetWords)
            { 
                var sbit = w2bit(src);
                int mask = 1;
                for (int i = 0; i < 31; i++)
                {
                    if ((sbit & mask) != 0)
                    {
                        if (hashset[src.Length - 1].Contains(sbit ^ mask))
                        {
                            answer++;
                            break;
                        }
                    }
                    mask <<= 1;
                }
            }
            return answer;
        }
        public int w2bit(string word)
        {
            int r = 0;
            foreach (var ch in word)
            {
                var bit = ch - 'a';
                r |= (1 << bit);
            }
            return r;
        }