//Leetcode 3083. Existence of a Substring in a String and Its Reverse ez
//题意：给定一个字符串s，要求找到s的任意长度为2的子串，使得该子串在s的反转字符串中也存在。如果存在这样的子串则返回true，否则返回false。
//思路：hashtable，hashset遍历字符串s，对于每个长度为2的子串，检查其是否在s的反转字符串中出现。
//可以使用哈希表来记录s中出现的所有长度为2的子串。
//对于每个长度为2的子串，检查其在哈希表中是否存在，如果存在，则返回true；否则返回false。
//时间复杂度：生成所有长度为2的子串的时间复杂度为O(n)，其中n为字符串s的长度。对于每个子串，检查其在哈希表中是否存在的时间复杂度为O(1)，最终总的时间复杂度为O(n)。
//空间复杂度：O(n)
        public bool IsSubstringPresent(string s)
        {
            HashSet<string> substrings = new HashSet<string>();

            // Generate all substrings of length 2 and add them to the set
            for (int i = 0; i < s.Length - 1; i++)
            {
                string substr = s.Substring(i, 2);
                substrings.Add(substr);
            }

            // Check if any substring exists in the reverse of s
            foreach (string substr in substrings)
            {
                string reverse = ReverseString(substr);
                if (s.Contains(reverse))
                {
                    return true;
                }
            }

            return false;
        }
        private string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }