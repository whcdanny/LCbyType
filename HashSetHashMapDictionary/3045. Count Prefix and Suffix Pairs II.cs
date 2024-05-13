//Leetcode 3045. Count Prefix and Suffix Pairs II hard
//题意：给出了一个字符串数组 words。
//定义一个布尔函数 isPrefixAndSuffix，它接受两个字符串 str1 和 str2：
//如果 str1 同时是 str2 的前缀和后缀，则 isPrefixAndSuffix(str1, str2) 返回 true，否则返回 false。
//要求返回一个整数，表示满足 i<j 且 isPrefixAndSuffix(words[i], words[j]) 为 true 的索引对数。
//思路：hashtable，用一个dictionary来存每个word和其出现的个数，用hashset存一共有多少长的word
//当输入word，先看是否dictionary已经有了，那么就count+；然后根据hashet，找的当前word长度长于这个hashet里的
//然后根据lenght找出前缀和后缀，然后如果前后缀相同并且dictionary里是否存在，那么就count+；
//时间复杂度：O(n)
//空间复杂度：O(n)
        Dictionary<string, long> dict_CountPrefixSuffixPairs = new Dictionary<string, long>();
        HashSet<int> lengths_CountPrefixSuffixPairs = new HashSet<int>();
        public long CountPrefixSuffixPairs(string[] words)
        {
            long count = 0;
            for (int i = 0; i < words.Length; ++i)
            {
                count += CheckPrefixSuffix(words[i]);
                dict_CountPrefixSuffixPairs.TryAdd(words[i], 0);
                dict_CountPrefixSuffixPairs[words[i]]++;
                lengths_CountPrefixSuffixPairs.Add(words[i].Length);
            }
            return count;
        }
        private long CheckPrefixSuffix(string s)
        {
            long count = 0;
            if (dict_CountPrefixSuffixPairs.ContainsKey(s))
            {
                count += dict_CountPrefixSuffixPairs[s];
            }
            foreach (var length in lengths_CountPrefixSuffixPairs)
            {
                if (s.Length > length)
                {
                    string prefix = s.Substring(0, length);
                    string suffix = s.Substring(s.Length - length);
                    if (prefix == suffix && dict_CountPrefixSuffixPairs.ContainsKey(prefix))
                    {
                        count += dict_CountPrefixSuffixPairs[prefix];
                    }
                }
            }
            return count;
        }