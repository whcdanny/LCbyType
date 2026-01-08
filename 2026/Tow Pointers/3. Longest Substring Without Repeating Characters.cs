//Leetcode 3. Longest Substring Without Repeating Characters med
//题意：给一个string，找出substring其中不包含重复字母
//思路：双针法 + Dictionary, dictionary 存入字母和其对应的位置，
//当发现当前字母在dictionary，再检查位置是否在>=left,确保出现重复的字母在[left, right]中，然后更新left
//right在历遍的时候一直在左移1位，所以不用担心。
//时间复杂度: O(n)
//空间复杂度： O(min(m, n)) n是字符串的长度。m 是字符集的大小
        public int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 0)
                return 0;
            int left = 0;            
            int res = 0;
            Dictionary<char, int> location = new Dictionary<char, int>();
            for(int right = 0; right < s.Length; right++)
            {
                char c = s[right];
                if (location.ContainsKey(c) && location[c] >= left)
                {
                    left = location[c] + 1;
                }                               
                location[c] = right;
                res = Math.Max(res, right - left + 1);
            }
            return res;
        }