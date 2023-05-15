//20. Valid Parentheses ez
//简单的括号匹配问题
//思路：如果当前字符是左括号（'('，'{'，'['），将其压入栈中如果当前字符是右括号（')'，'}'，']'），判断栈是否为空, 如果栈为空，说明右括号没有与之对应的左括号，返回false。如果栈不为空，弹出栈顶元素，并判断弹出的左括号与当前右括号是否匹配。如果不匹配，返回false。如果匹配，继续遍历下一个字符。
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