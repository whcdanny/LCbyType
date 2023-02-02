//567. Permutation in String med
//给两个string，找出s2是否含有s1的集合、、s1 = "ab", s2 = "eidbaooo"
//滑动窗口：一开始让left和right从0开始，right向右滑动，直到找到所有s1;如果满足并且长度等于s1，true
//然后滑动left直到不满足当前窗口含有所有t，直到找到是否满足并且长度等于s1；
		public bool CheckInclusion(string s1, string s2)
        {
            Dictionary<char, int> need = new Dictionary<char, int>(), window = new Dictionary<char, int>();
            foreach (var c in s1)
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
            while (right < s2.Length)
            {
                // c 是将移入窗口的字符
                char c = s2[right];
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
                while (right-left>=s1.Length)
                {
                    // 在这里判断是否找到了合法的子串
                    if (valid == need.Count)
                        return true;
                    // d 是将移出窗口的字符
                    char d = s2[left];
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
            return false;
        }