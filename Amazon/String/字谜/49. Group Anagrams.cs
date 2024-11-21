//Leetcode 49. Group Anagrams med
//题意：给定一个字符串数组，将字母异位词组合在一起。
//思路：遍历字符串数组，对于每个字符串，将其按照字母排序，得到一个唯一的键。
//使用哈希表，以排序后的键作为键，将相应的字符串添加到对应的列表中
//时间复杂度：遍历字符串数组需要 O(nmlog(m)) 的时间，其中 n 是字符串数组的长度，m 是字符串的平均长度。
//空间复杂度：O(n*nlogn)
//空间复杂度：O(n)
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            foreach (string str in strs)
            {
                char[] chars = str.ToCharArray();
                Array.Sort(chars);
                string sortedStr = new string(chars);

                if (map.ContainsKey(sortedStr))
                {
                    map[sortedStr].Add(str);
                }
                else
                {
                    map[sortedStr] = new List<string> { str };
                }
            }

            return new List<IList<string>>(map.Values);
        }