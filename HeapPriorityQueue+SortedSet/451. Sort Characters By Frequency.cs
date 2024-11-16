//Leetcode 451. Sort Characters By Frequency med
//题意：给定一个字符串s，根据字符出现的频率将其按降序排序。字符的频率是它在字符串中出现的次数。
//返回排序后的字符串。如果有多个答案，则返回其中任何一个。
//思路：PriorityQueue, 最大堆（优先队列）来进行排序。我们首先统计每个字符出现的频率，
//然后将字符和对应的频率放入最大堆中，按照频率进行排序。然后，依次从堆中取出字符，并按照频率拼接成排序后的字符串。
//时间复杂度: 统计字符频率需要O(n)，构建最大堆需要O(nlogn)，取出字符构建排序字符串需要O(nlogn)，因此总时间复杂度为O(nlogn)。
//空间复杂度：O(n)   
        public string FrequencySort(string s)
        {
            int len = s.Length;
            Dictionary<char, int> freeMap = new Dictionary<char, int>();
            for (int i = 0; i < len; i++)
            {
                if (!freeMap.ContainsKey(s[i]))
                    freeMap.Add(s[i], 0);

                freeMap[s[i]]++;
            }

            PriorityQueue<char, int> freqSorted = new PriorityQueue<char, int>();
            foreach (var key in freeMap.Keys)
            {
                freqSorted.Enqueue(key, -freeMap[key]);
            }

            StringBuilder result = new StringBuilder();
            while (freqSorted.Count > 0)
            {
                var key = freqSorted.Dequeue();
                for (int i = 0; i < freeMap[key]; i++)
                    result.Append(key);
            }

            return result.ToString();
        }
        //SortedDictionary 思路跟PQ一样
        public string FrequencySort1(string s)
        {
            // 字符频率统计
            Dictionary<char, int> freqMap = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (freqMap.ContainsKey(c))
                    freqMap[c]++;
                else
                    freqMap[c] = 1;
            }

            // 构建最大堆
            SortedDictionary<int, List<char>> sortedHash = new SortedDictionary<int, List<char>>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
            foreach (var pair in freqMap)
            {
                if (!sortedHash.ContainsKey(pair.Value))
                    sortedHash[pair.Value] = new List<char>();
                sortedHash[pair.Value].Add(pair.Key);
            }

            // 按照频率构建排序后的字符串
            StringBuilder result = new StringBuilder();
            foreach (var pair in sortedHash)
            {
                foreach (char c in pair.Value)
                {
                    for (int i = 0; i < pair.Key; i++)
                    {
                        result.Append(c);
                    }
                }
            }

            return result.ToString();
        }