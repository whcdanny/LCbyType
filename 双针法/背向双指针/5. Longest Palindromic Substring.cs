//5. Longest Palindromic Substring med
//给一个字符串，找出最长的palindromic
//思路：用左右针 这次从中间开始往两边延展，因为长度奇偶，所以为了保险要找i和i+1位置的
public static string LongestPalindrome(string s)
        {
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                // 以 s[i] 为中心的最长回文子串
                string s1 = palindrome(s, i, i);
                // 以 s[i] 和 s[i+1] 为中心的最长回文子串
                string s2 = palindrome(s, i, i + 1);                
                res = res.Length > s1.Length ? res : s1;
                res = res.Length > s2.Length ? res : s2;
            }
            return res;
        }
        public static string palindrome(string s, int l, int r)
        {
            // 防止索引越界
            while (l >= 0 && r < s.Length
                    && s[l] == s[r])
            {
                // 双指针，向两边展开
                l--; r++;
            }
            // 返回以 s[l] 和 s[r] 为中心的最长回文串
            return s.Substring(l+1, r - l-1);//C#的substring是（起始位置，长度） Java的substring（起点，终点）
        }