//76. Minimum Window Substring hard
//给两个string一个是s，一个t，找出s中含有t的substring
//滑动窗口：一开始让left和right从0开始，right向右滑动，直到找到所有t，然后记下当前的start和长度用于substring；
//然后滑动left直到不满足当前窗口含有所有t，和之前的长度比较，如果当前长度小，那么记下start和长度，然后right再继续移动；依此直到结束；
		public string MinWindow(string s, string t)
        {
            Dictionary<char, int> need = new Dictionary<char, int>(), window = new Dictionary<char, int>();
            foreach(var c in t)
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
            // 记录最小覆盖子串的起始索引及长度 用于substring
            int start = 0, len = Int32.MaxValue;
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
                while (valid == need.Count)
                {
                    // 在这里更新最小覆盖子串
                    if (right - left < len)
                    {
                        start = left;
                        len = right - left;
                    }
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
            return len == Int32.MaxValue ? "" : s.Substring(start, len);
        }
		
//同理，只是用到的数据结构不一样，空间复杂度一样	
		public string MinWindow(string s, string t) {
			int count = 0, distinctChars = 0;
			int[] occurrences = new int[256], targets = new int[256];
			foreach (var ch in t)
			{
				if (targets[ch] == 0)
				{
					distinctChars++;
				}
				targets[ch]++;
			}

			int left = 0, right = 0;
			int start = 0, length = s.Length;

			while (right < s.Length)
			{
				char ch = s[right];
				occurrences[ch]++;
				if (targets[ch] > 0 && occurrences[ch] == targets[ch])
				{
					count++;
				}

				while (left <= right 
				&& (ch = s[left]) < 256 
				&& (targets[ch] == 0 || occurrences[ch] > targets[ch]))
				{
					occurrences[ch]--;
					left++;
				}

				if (count == distinctChars)
				{
					int len = right - left + 1;
					if (len < length)
					{
						start = left;
						length = len;
					}
				}
				right++;
			}

			return count == distinctChars ? s.Substring(start, length) : "";
		}