//772. Basic Calculator III hard
//给定一个字符串表达式，其中只包含非负整数、加号、减号、乘号、除号、左括号和右括号
//思路：这里如果时'('那么就去找')'然后算这个里面的数，使用递归；当我们遇到一个加号或减号时，我们可以将其直接入栈。当我们遇到一个乘号或除号时，我们需要弹出栈顶元素并将其与当前数字进行乘法或除法运算
        public int Calculate3(string s)
        {
            if (string.IsNullOrEmpty(s)) return 0;

            Stack<int> stack = new Stack<int>();
            char op = '+';
            int num = 0;
            int n = s.Length;

            for (int i = 0; i < n; i++)
            {
                char c = s[i];
                if (char.IsDigit(c))
                {
                    num = num * 10 + (c - '0');
                }
                if (c == '(')
                {
                    int j = i, cnt = 0;
                    while (i < n)
                    {
                        if (s[i] == '(') cnt++;
                        if (s[i] == ')') cnt--;
                        if (cnt == 0) break;
                        i++;
                    }
                    num = Calculate3(s.Substring(j + 1, i - j - 1));
                }
                if (!char.IsDigit(c) && c != ' ' || i == n - 1)
                {
                    if (op == '+')
                    {
                        stack.Push(num);
                    }
                    else if (op == '-')
                    {
                        stack.Push(-num);
                    }
                    else if (op == '*')
                    {
                        stack.Push(stack.Pop() * num);
                    }
                    else if (op == '/')
                    {
                        stack.Push(stack.Pop() / num);
                    }
                    op = c;
                    num = 0;
                }
            }

            int res = 0;
            while (stack.Count > 0)
            {
                res += stack.Pop();
            }

            return res;
        }