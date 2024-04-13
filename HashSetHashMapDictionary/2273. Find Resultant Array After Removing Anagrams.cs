//Leetcode 2273. Find Resultant Array After Removing Anagrams ez
//题意：给定一个字符串数组 words，其中每个字符串表示一个单词。
//要求对数组中的字符串进行操作，删除相邻的两个字符串，如果这两个字符串是变位词（anagrams）。直到无法继续删除为止。最后返回操作后的字符串数组。
//变位词是指由相同的字符组成，但是排列顺序不同的两个单词。
//例如，"listen" 和 "silent" 是变位词。
//思路：hashtable 先存入第一个，然后从第二个开始依此跟之前的比较，
//如果是anagrams，那么就跳过，如果不是就添加；       
//时间复杂度：O(n)
//空间复杂度：O(1)
        public IList<string> RemoveAnagrams(string[] words)
        {
            var result = new List<string>() { words[0] };

            for (int i = 1; i < words.Length; i++)
                if (!IsAnagram(words[i - 1], words[i]))
                    result.Add(words[i]);           
            return result;
        }
        public bool IsAnagram(string s1, string s2)
        {
            var map = new Dictionary<char, int>();
            foreach (var element in s1)
                if (map.ContainsKey(element))
                    map[element]++;
                else
                    map[element] = 1;

            foreach (var element in s2)
                if (map.ContainsKey(element))
                    map[element]--;
                else
                    return false;

            foreach (var element in map)
                if (element.Value != 0)
                    return false;

            return true;
        }
