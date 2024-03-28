//Leetcode 3076. Shortest Uncommon Substring in an Array med
//题意：给定一个大小为n的字符串数组arr，每个字符串非空。要求找到一个字符串数组answer，使得：
//answer[i] 是字符串arr[i]中不出现在数组arr的其他字符串中的最短子串。
//如果存在多个这样的子串，则选择字典序最小的那个。
//如果不存在这样的子串，则answer[i] 应为空字符串。
//思路：hashtable，两个Dictionary一个存每个arr可以有的所有substring，一个存所有substring出现的次数
//然后根据第一个的arr里所有的substring找第二个是否右其中出现个数为0的吗；
//时间复杂度：假设数组arr的长度为n，每个字符串的平均长度为m。生成所有子串O(n * m^2)，检查每个字符串O(n * m^2)，因此总的时间复杂度为O(n^2 * m^2)。
//空间复杂度：O(n * m^2)
        public string[] ShortestSubstrings(string[] arr)
        {
            var result = new List<string>();
            var map = new Dictionary<string, HashSet<int>>();
            var cache = new Dictionary<int, string[]>();

            for (var i = 0; i < arr.Length; i++)
            {
                var words = GetSubstrings(arr[i]);
                cache[i] = words;

                foreach (var word in words)
                {
                    if (map.ContainsKey(word))
                        map[word].Add(i);
                    else
                        map.Add(word, new HashSet<int> { i });
                }
            }

            for (var i = 0; i < arr.Length; i++)
            {
                var pick = string.Empty;
                foreach (var str in cache[i])
                {
                    if (map.TryGetValue(str, out var set))
                    {
                        if (set.Count == 1)
                        {
                            pick = str;
                            break;
                        }
                    }
                }
                result.Add(pick);
            }

            return result.ToArray();
        }

        private string[] GetSubstrings(string word)
        {
            var list = new List<string>();
            for (var i = 0; i < word.Length; i++)
                for (var j = i + 1; j <= word.Length; j++)
                    list.Add(word[i..j]);
            return list.OrderBy(x => x.Length).ThenBy(x => x).ToArray();
        }