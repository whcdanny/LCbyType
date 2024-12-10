//68. Validate IP Address med
//题目：给定一个字符串queryIP，返回"IPv4"IP 是否是有效的 IPv4 地址，"IPv6"IP 是否是有效的 IPv6 地址，或者"Neither"IP 是否不是任何类型的正确 IP。
//有效的 IPv4地址是格式为 的 IP，"x1.x2.x3.x4"
//其中和不能包含前导零 和 其他符号。"192.168.01.1""192.168.1.00""192.168@1.1"
//IPv4 地址。0 <= xi <= 255
//有效的 IPv6地址是以下形式的 IP ："x1:x2:x3:x4:x5:x6:x7:x8"
//1 <= xi.length <= 4
//xi是一个十六进制字符串，可能包含数字、小写英文字母（'a'至'f'）和大写英文字母（'A'至'F'）。
//中允许有前导零。
//思路：根据要求对IPv4和IPv6进行判断
//IPv4:!part.All(char.IsDigit)，!int.TryParse(part, out num)
//IPv6:!part.All(c => char.IsDigit(c) || "abcdefABCDEF".Contains(c))
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public string ValidIPAddress(string queryIP)
        {
            if (queryIP.Contains(".") && IsIPv4(queryIP))
            {
                return "IPv4";
            }
            else if (queryIP.Contains(":") && IsIPv6(queryIP))
            {
                return "IPv6";
            }
            else
            {
                return "Neither";
            }
        }

        private bool IsIPv4(string ip)
        {
            string[] parts = ip.Split('.');
            if (parts.Length != 4) return false;

            foreach (string part in parts)
            {
                if (part.Length == 0 || part.Length > 3) return false;
                if (!part.All(char.IsDigit)) return false;

                int num;
                if (!int.TryParse(part, out num) || num < 0 || num > 255) return false;

                // 检查前导零
                if (part.Length > 1 && part[0] == '0') return false;
            }
            return true;
        }

        private bool IsIPv6(string ip)
        {
            string[] parts = ip.Split(':');
            if (parts.Length != 8) return false;

            foreach (string part in parts)
            {
                if (part.Length == 0 || part.Length > 4) return false;
                if (!part.All(c => char.IsDigit(c) || "abcdefABCDEF".Contains(c))) return false;
            }
            return true;
        }