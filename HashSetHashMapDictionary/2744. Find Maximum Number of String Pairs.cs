//Leetcode 2744. Find Maximum Number of String Pairs ez
//题意：给定一个由不同字符串组成的数组 words，判断其中的字符串是否能够成对，条件是当前字符串等于数组中的某个字符串的逆序。返回能够成对的最大字符串对数。
//思路：hashtable, 哈希表记录每个字符串及其逆序在数组中出现的次数。
//遍历数组，对于每个字符串，查找其逆序在哈希表中的出现次数，累加次数作为当前字符串能够成对的最大数量。
//返回累加的最大值即为结果。
//时间复杂度：每个字符串查找其逆序的时间复杂度为 O(m)，其中 m 为字符串长度，因此总体时间复杂度为 O(n * m)，其中 n 为数组长度。
//空间复杂度：O(n)
        public int MaximumNumberOfStringPairs(string[] words)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            int maxPairs = 0;

            foreach (string word in words)
            {
                string reverse = ReverseString_MaximumNumberOfStringPairs(word);
                if (map.ContainsKey(reverse) && map[reverse] > 0)
                {
                    maxPairs++;
                    map[reverse]--;
                }
                else
                {
                    if (!map.ContainsKey(word))
                    {
                        map[word] = 0;
                    }
                    map[word]++;
                }
            }

            return maxPairs;
        }
        private string ReverseString_MaximumNumberOfStringPairs(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }