//Leetcode 1717. Maximum Score From Removing Substrings med
//题意：给定一个字符串 s 和两个整数 x 和 y。你可以进行两种操作：
//移除子串 "ab" 并得到 x 分。
//移除子串 "ba" 并得到 y 分。
//你可以任意次数地执行上述操作。返回在字符串 s 上执行上述操作后能获得的最大分数。
//思路：Stack, 栈来模拟操作过程，从左到右遍历字符串 s。
//前字符将其入栈。这里要先找到尽可能多的Max(x,y)，来确定显示"ab" 还是 "ba"
//假设"ab"对应X 大
//如果栈顶有 'a'，且当前字符是 'b'，则将栈顶的 'a' 出栈，并记录得分X。
//然后一直历遍完s；此时stack里含有除了"ab"以外的所有字母了；
//然后在stack中找"ba"，然后用另一个stack存先找的，
//如果栈顶有 'b'，且当前字符是 'a'，则将栈顶的 'b' 出栈，并记录得分Y。
//遍历完字符串后，得分即为所有记录的得分之和。
//注：先找到尽可能多的Max(x,y)，来确定显示"ab" 还是 "ba"
//时间复杂度：O(n)，其中 n 是字符串 s 的长度，遍历一次字符串 s。
//空间复杂度：O(n)
        public int MaximumGain(string s, int x, int y)
        {
            Stack<char> stack = new Stack<char>();
            int score = 0;
            char first = x > y ? 'a' : 'b', second = first == 'a' ? 'b' : 'a';

            foreach (char ch in s)
            {
                if (stack.Count > 0 && stack.Peek() == first && ch == second)
                {
                    score += Math.Max(x, y);
                    stack.Pop();
                }
                else
                {
                    stack.Push(ch);
                }
            }

            Stack<char> temp = new Stack<char>();
            while (stack.Count > 0)
            {
                char ch = stack.Pop();
                if (temp.Count > 0 && temp.Peek() == first && ch == second)
                {
                    score += Math.Min(x, y);
                    temp.Pop();
                }
                else
                {
                    temp.Push(ch);
                }
            }

            return score;
        }