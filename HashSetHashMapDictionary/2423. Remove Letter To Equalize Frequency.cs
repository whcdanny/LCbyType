//Leetcode 2423. Remove Letter To Equalize Frequency ez
//题意：给定一个由小写英文字母组成的字符串 word。你需要选择一个索引，并删除该索引处的字母，以使 word 中每个字母的频率都相等。
//如果可以删除一个字母使得 word 中所有字母的频率都相等，则返回 true；否则返回 false。
//思路：hashtable 算出每个字母出现的频率，然后移除其中一个，然后找出最多最少，如果一样true
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public bool EqualFrequency(string word)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < word.Length; i++)
            {
                if (!map.ContainsKey(word[i]))
                    map.Add(word[i], 0);
                map[word[i]]++;
            }

            int min, max;
            foreach (var toRemove in map.Keys)
            {
                map[toRemove]--;
                min = int.MaxValue;
                max = 0;
                foreach (var repetition in map.Values)
                {
                    if (repetition > 0)
                    {
                        max = Math.Max(max, repetition);
                        min = Math.Min(min, repetition);
                    }
                }

                if (min == max)
                    return true;

                map[toRemove]++;
            }

            return false;
        }