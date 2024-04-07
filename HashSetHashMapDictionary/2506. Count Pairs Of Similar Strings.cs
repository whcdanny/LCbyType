//Leetcode 2506. Count Pairs Of Similar Strings ez
//题意：给定一个字符串数组 words，判断其中有多少对字符串是相似的。两个字符串相似，意味着它们包含相同的字符，但是字符的顺序可以不同。
//思路：hashtable, 找出每个word不重复的char，
//然后比较每个word是否有相同的；
//时间复杂度：O(n * m) n 是字符串数组 words 的长度，m 是单个字符串的平均长度
//空间复杂度：O(n * m)
        public int SimilarPairs(string[] words)
        {
            var list = new List<HashSet<char>>();
            var count = 0;
            for (var i = 0; i < words.Length; i++)
            {
                var set = new HashSet<char>();
                foreach (var ch in words[i])
                {
                    if (!set.Contains(ch))
                        set.Add(ch);
                }
                list.Add(set);
            }

            for (var i = 0; i < list.Count; i++)
            {
                for (var j = i + 1; j < list.Count; j++)
                {
                    if (list[i].SetEquals(list[j]))
                        count++;
                }
            }
            return count;
        }