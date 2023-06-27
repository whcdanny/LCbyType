//647. Palindromic Substrings med: 给定一个字符串，计算该字符串中回文子串的个数。回文子串是从原字符串中任意位置截取的连续字符所组成的字符串，其正向和反向读取结果相同。
//思路：双针法，以字符串为奇数和偶数长度分别使用双针法；
        public int CountSubstrings(string s)
        {
            int count = 0;
            int n = s.Length;

            // 处理奇数长度的回文串
            for (int i = 0; i < n; i++)
            {
                int left = i;
                int right = i;

                while (left >= 0 && right < n && s[left] == s[right])
                {
                    count++;
                    left--;
                    right++;
                }
            }

            // 处理偶数长度的回文串
            for (int i = 0; i < n - 1; i++)
            {
                int left = i;
                int right = i + 1;

                while (left >= 0 && right < n && s[left] == s[right])
                {
                    count++;
                    left--;
                    right++;
                }
            }

            return count;
        }