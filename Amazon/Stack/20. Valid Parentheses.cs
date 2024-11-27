//Leetcode 20. Valid Parentheses ez
//题意：给定一个只包含字符 '(', ')', '{', '}', '[' 和 ']' 的字符串，判断字符串是否有效。有效字符串需满足：左括号必须用相同类型的右括号闭合。左括号必须以正确的顺序闭合。
//思路：可以使用栈来解决这个问题。遍历字符串，当遇到左括号时，将其压入栈中，当遇到右括号时，检查栈顶的左括号是否与之匹配，如果匹配则将栈顶元素弹出，继续遍历，如果不匹配则返回 false。
//时间复杂度：n 是表达式的长度，O(n)。
//空间复杂度：n 是表达式的长度，O(n)
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    char top = stack.Pop();
                    if ((c == ')' && top != '(') || (c == '}' && top != '{') || (c == ']' && top != '['))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }