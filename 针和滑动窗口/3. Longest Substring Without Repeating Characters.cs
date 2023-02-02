//3. Longest Substring Without Repeating Characters med
//给定一个string s，找出其中不包含重复字符的最长子串的长度
//滑动窗口： 跟之前一样right右移，如果当前的window出现重复，left移动，并算出当前长度来跟res做比较；
		public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> window = new Dictionary<char, int>();
            int res = 0;// 记录结果
            int left = 0, right = 0;
            while (right < s.Length)
            {
                char c = s[right];
                right++;
                // 进行窗口内数据的一系列更新
                if (window.ContainsKey(c))
                {
                    window[c]++;
                }
                else
                {
                    window.Add(c, 1);
                }
                // 判断左侧窗口是否要收缩
                while (window[c] > 1)
                {
                    char d = s[left];
                    left++;
                    // 进行窗口内数据的一系列更新
                    window[d]--;
                }
                // 在这里更新答案
                res = Math.Max(res, right - left);
            }
            return res;
        }