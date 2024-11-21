//Leetcode 242. Valid Anagram ez
//题目：给定两个字符串s和t，true如果t是则返回字谜的s，false否则。
//就是说t和s是否有完全一样的字母，这里可以有重复
//思路: 先统计s中出现的26个字母总共个数，list[c - 'a']++;
//然后找t中出现的然后list[c - 'a']--; 如果发现list[c - 'a']<=0，说明这个字母没用在s中出现过
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;
            char[] list = new char[26];
            foreach (char c in s)
            {
                list[c - 'a']++;
            }
            foreach(char c in t)
            {
                if (list[c - 'a'] > 0)
                {
                    list[c - 'a']--;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }