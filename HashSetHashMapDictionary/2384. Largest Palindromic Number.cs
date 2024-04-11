//Leetcode 2384. Largest Palindromic Number med
//题意：给定一个仅包含数字的字符串 num，返回可以使用 num 中的数字组成的最大回文整数（以字符串形式表示）。回文整数不能包含前导零。
//思路：hashtable Polyndrom 意味着我们需要计算可用于构建数字的偶数对，因为每个数字将在左侧和右侧出现相同的次数。
//极端情况并不那么简单，因此当提交显示极端情况用例时有许多前导 0 或只有 0 仍应导致“0”时，请弄清楚它们。
//构建左侧部分
//检查中间字符串是否存在
//通过反转左侧来构建右侧
//连接左\中\右并牢记极端情况
//时间复杂度：O(n)
//空间复杂度：O(1)
        public string LargestPalindromic(string num)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            foreach (char symb in num)
            {
                int number = symb - '0';
                if (map.ContainsKey(number))
                {
                    map[number] += 1;
                }
                else
                {
                    map.Add(number, 1);
                }
            }

            StringBuilder sb = new StringBuilder();
            int middle = -1;
            for (int i = 9; i >= 0; i--)
            {
                if (map.ContainsKey(i))
                {
                    int pairs = map[i] / 2;
                    for (int j = 0; j < pairs; j++)
                    {
                        sb.Append(i);
                    }
                    map[i] -= pairs * 2;

                    if (middle < 0 && map[i] > 0)
                    {
                        middle = i;
                    }
                }
            }

            string left = sb.ToString();
            string middleStr = middle == -1 ? String.Empty : middle.ToString();
            string right = Reverse_LargestPalindromic(left);

            if (left.StartsWith('0') && left.EndsWith('0'))
            {
                if (middleStr == String.Empty)
                {
                    return "0";
                }
                else
                {
                    return middleStr;
                }
            }

            return $"{left}{middleStr }{right}";

        }

        public static string Reverse_LargestPalindromic(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }