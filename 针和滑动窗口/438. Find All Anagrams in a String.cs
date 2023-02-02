//438. Find All Anagrams in a String med
//相当于，输入一个串 S，一个串 P，找到 S 中所有 P 的排列，返回它们的起始索引。
//滑动窗口：一开始让left和right从0开始，right向右滑动，直到找到所有s1;如果满足并且长度等于s1，存下当前start位置也就是left；
//然后滑动left直到不满足当前窗口含有所有t，直到找到是否满足并且长度等于s1，并存入答案；
		public IList<int> FindAnagrams(string s, string p)
        {
            Dictionary<char, int> need = new Dictionary<char, int>(), window = new Dictionary<char, int>();
            foreach (var c in p)
            {
                if (need.ContainsKey(c))
                {
                    need[c]++;
                }
                else
                {
                    need.Add(c, 1);
                }
            }
            int left = 0, right = 0;
            int valid = 0;
            List<int> res = new List<int>();
            while (right < s.Length)
            {
                // c 是将移入窗口的字符
                char c = s[right];
                // 扩大窗口
                right++;
                // 进行窗口内数据的一系列更新
                if (need.ContainsKey(c))
                {
                    if (window.ContainsKey(c))
                    {
                        window[c]++;
                    }
                    else
                    {
                        window.Add(c, 1);
                    }
                    if (window[c] == need[c])
                        valid++;
                }
                // 判断左侧窗口是否要收缩
                while (right - left >= p.Length)
                {
                    // 在这里判断是否找到了合法的子串
                    if (valid == need.Count)
                        res.Add(left);
                    // d 是将移出窗口的字符
                    char d = s[left];
                    // 缩小窗口
                    left++;
                    // 进行窗口内数据的一系列更新
                    if (need.ContainsKey(d))
                    {
                        if (window[d] == need[d])
                            valid--;
                        window[d]--;
                    }
                }
            }
            return res ;
        }