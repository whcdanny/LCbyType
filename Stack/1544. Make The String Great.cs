//Leetcode 1544. Make The String Great ez
//题意：给定一个由大小写英文字母组成的字符串 s。
//一个好的字符串是指该字符串中不存在相邻的字符 s[i] 和 s[i + 1]，满足以下条件：
//0 <= i <= s.length - 2
//s[i] 是小写字母，而 s[i + 1] 是同一个字母的大写形式，或者反之。
//为了使字符串变好，你可以选择移除两个相邻的字符，这样可以让字符串变得好。你可以重复这个过程，直到字符串变得好为止。
//返回使字符串变好后的结果。根据给定的约束条件，答案是唯一的。
//注意：空字符串也被视为好的字符串。
//思路：Stack,存入字母，如果放入的字母是大写字母并且这个大写字母和前一位的小写字母是一个，那么就弹出；
//时间复杂度：O(n)，其中 n 是字符串 s 的长度
//空间复杂度：O(n)
        public string MakeGood(string s)
        {
            var stack = new Stack<char>();
            foreach (var c in s)
            {
                if (stack.Count > 0 && stack.Peek() != c && char.ToLower(stack.Peek()) == char.ToLower(c))
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            var sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            return new string(sb.ToString().Reverse().ToArray());
        }