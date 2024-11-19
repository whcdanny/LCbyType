//692. Top K Frequent Words med 
//题目要求从给定的字符串列表中找出出现频率前 k 高的单词，并按照频率从高到低、字母顺序从小到大的顺序返回结果
//思路：Dictionary 统计每个单词的出现频率，SortedDictionary 将单词按照频率分组存储，高频率到低频率的顺序遍历 SortedDictionary，并按照字母顺序取出每个频率对应的单词
        public IList<string> TopKFrequent(string[] words, int k)
        {
            Dictionary<string, int> frequencyMap = new Dictionary<string, int>();

            // 统计每个单词的出现频率
            foreach (string word in words)
            {
                if (frequencyMap.ContainsKey(word))
                {
                    frequencyMap[word]++;
                }
                else
                {
                    frequencyMap[word] = 1;
                }
            }

            SortedDictionary<int, List<string>> sortedDict = new SortedDictionary<int, List<string>>();

            // 将单词按照频率分组存入 SortedDictionary
            foreach (var pair in frequencyMap)
            {
                string word = pair.Key;
                int frequency = pair.Value;

                if (sortedDict.ContainsKey(frequency))
                {
                    sortedDict[frequency].Add(word);
                }
                else
                {
                    sortedDict[frequency] = new List<string> { word };
                }
            }

            List<string> result = new List<string>();

            // 从高频率到低频率遍历 SortedDictionary，按照字母顺序取前 k 个单词
            foreach (var pair in sortedDict.Reverse())
            {
                List<string> wordsWithSameFrequency = pair.Value;
                wordsWithSameFrequency.Sort(); // 按照字母顺序排序

                foreach (string word in wordsWithSameFrequency)
                {
                    result.Add(word);
                    if (result.Count == k)
                    {
                        return result;
                    }
                }
            }

            return result;
        }