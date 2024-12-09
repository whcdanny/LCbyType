//Leetcode 1910. Remove All Occurrences of a Substring med
//题意：给定两个字符串s和part，对执行以下操作，s直到删除所有出现的子字符串：part
//找到子字符串最左边part的出现位置并将其从中删除s。
//s删除所有出现的 后返回part。
//子字符串是字符串中连续的字符序列。
//思路：用stack来存每个字母，当找到匹配part[last]，
//然后往前一个一个pop如果匹配part一样的话，那就已经pop出去
//如果不一样，把之前pop出去的再放回来；
//时间复杂度：O(n*m)
//空间复杂度：O(n)
        public string RemoveOccurrences(string s, string part)
        {
            Stack<char> stack = new Stack<char>();
            int m = part.Length;
            int last = m - 1;
            for (int i = 0; i < s.Length; i++)
            {
                stack.Push(s[i]);
                if (stack.Count >= m && stack.Peek() == part[last])
                {
                    int idx = last;
                    string removed = "";
                    while (idx >= 0 && stack.Peek() == part[idx])
                    {
                        removed = stack.Pop() + removed;
                        idx--;
                    }
                    if (idx >= 0)
                        foreach (var c in removed) 
                            stack.Push(c);
                }
            }
            string res = "";
            while (stack.Count > 0) 
                res = stack.Pop() + res;
            return res;            
        }        