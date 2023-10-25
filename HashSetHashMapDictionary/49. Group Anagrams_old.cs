//49. Group Anagrams med
//要求对给定的字符串数组进行分组，使得具有相同字母构成的字符串归为一组
//思路：给一个dictionary来存，每一个词输入后，将其拆分成charlist然后排序然如果dictionary没有就添加，有就再已有的list里加入这个词；
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