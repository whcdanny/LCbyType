//387. First Unique Character in a String ez
//题意：给定一个字符串s，找到其中第一个非重复字符并返回其索引。如果不存在，则返回-1。
//思路：建立26个字母的统计，
//然后找出位置i
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int FirstUniqChar(string s)
        {
            var list = new int[26];
            foreach (var c in s)
                list[c - 'a']++;
            for (var i = 0; i < s.Length; i++)
                if (list[s[i] - 'a'] == 1) return i;
            return -1;
        }