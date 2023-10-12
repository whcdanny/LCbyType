//Leetcode 93 Restore IP Addresses med
//题意：给定一个只包含数字的字符串，将其恢复成所有可能的有效 IP 地址。
//思路：深度优先搜索（DFS）: 在进行判断时，需要考虑以下几点：0 可以作为单独的一部分，但不能有前导零，且不能超过255。部分的长度不能超过3。除了第一部分，其他部分的前导零是不允许的。
//时间复杂度:   n 是字符串的长度, O(2^n)
//空间复杂度： O(n)
        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> res = new List<string>();
            RestoreIp(s, 0, "", res);
            return res;
        }
        private void RestoreIp(string s, int parts, string current, List<string> result)
        {
            if (parts == 4)
            {
                if (s.Length == 0)
                {
                    result.Add(current);
                }
                return;
            }
            for(int i=1; i <= 3 && i <= s.Length; i++)
            {
                string part = s.Substring(0, i);
                if (IsValidPart(part))
                {
                    RestoreIp(s.Substring(i), parts + 1, current + (parts == 0 ? "" : ".") + part, result);
                }
            }
        }
        private bool IsValidPart(string part)
        {
            if (part.Length == 0 || part.Length > 3)
                return false;
            if (part.Length > 1 && part[0] == '0')
                return false;
            int num = int.Parse(part);
            return num >= 0 && num <= 255;
        }