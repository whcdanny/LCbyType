//Leetcode 32. Longest Valid Parentheses hard
//题意：给定一个只包含 '(' 和 ')' 的字符串 s，找出最长的有效（格式正确且连续）括号子串的长度。
//思路：Stack 栈来辅助求解。我们定义一个栈来存储括号的下标。
//遍历字符串 s，遇到 '(' 就将其下标入栈，遇到 ')' 就将栈顶元素出栈，表示匹配成功。
//如果栈为空，则说明当前 ')' 没有匹配的 '('，我们将该 ')' 的下标入栈，作为一个分割点。
//遍历结束后，栈中剩下的元素即为无法匹配的 '(' 的下标，我们可以通过这些下标来计算最长有效括号子串的长度。
//计算相邻的两个分割点之间的距离，即为有效括号子串的长度。
//时间复杂度: O(n)，其中 n 是字符串的长度
//空间复杂度：O(n)
        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int maxLen = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxLen = Math.Max(maxLen, i - stack.Peek());
                    }
                }
            }
            return maxLen;
        }