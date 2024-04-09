//Leetcode 2451. Odd String Difference ez
//题意：给定一个长度相同的字符串数组 words。假设每个字符串的长度为 n。
//每个字符串 words[i] 可以转换成一个长度为 n - 1 的差分整数数组 difference[i]，
//其中 difference[i][j] = words[i][j + 1] - words[i][j]，其中 0 <= j <= n - 2。
//注意，两个字母之间的差异是它们在字母表中的位置之间的差异，即'a'的位置是0，'b'是1，'z'是25。
//例如，对于字符串 "acb"，差分整数数组为[2 - 0, 1 - 2] = [2, -1]。
//所有字符串中的差分整数数组都相同，除了一个。你需要找到具有不同差分整数数组的字符串。
//思路：hashtable Dictionary找到每个word的difference[i][j] = words[i][j + 1] - words[i][j]  
//然后找出出现的个数==1的
//时间复杂度：O(n)
//空间复杂度：O(n)
        public string OddString(string[] words)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();
            foreach (string s in words)
            {
                string diff = GetDifference(s);
                map[diff] = map.GetValueOrDefault(diff) + 1;
            }
            foreach (string s in words)
                if (map[GetDifference(s)] == 1)
                    return s;
            return string.Empty;
        }

        private string GetDifference(string s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length - 1; i++)
            {
                sb.Append(s[i + 1] - s[i]);
                sb.Append(",");
            }
            return sb.ToString();
        }