 //Leetcode 772. Basic Calculator III mid
//题意：实现一个基本的计算器来计算一个简单的字符串表达式，表达式中可能包含非负整数、加号 +、减号 -、乘号 *、除号 /、左括号 (、右括号 ) 和空格字符。
//思路：用两个栈来帮助处理括号表达式。具体的步骤如下：初始化两个栈 numStack 和 opStack 分别用于存储数字和运算符。初始化两个变量 num 和 op 分别用于记录当前的数字和运算符，初始时 num 为0，op 为 +。遍历表达式中的每个字符：如果当前字符是数字，则将其解析为一个整数，并将其存储到 num 中。如果当前字符是运算符：如果是 + 或 -，则将之前的 num 根据前一个运算符 op 进行相应的运算后，加入到 numStack 中，同时将当前运算符更新为 op。如果是* 或 /，则将当前的 num 与栈顶的数字进行相应的运算后，再加入到 numStack 中，同时将当前运算符更新为 op。如果当前字符是左括号(，则将当前的 num 和 op 分别入栈，并将 num 和 op 重新置为初始值0和+。如果当前字符是右括号 )，则从栈中依次弹出数字和运算符进行运算，直到遇到左括号为止。
//时间复杂度：n 是表达式的长度，O(n)。
//空间复杂度：n 是表达式的长度，O(n)
        public int Calculate3_new(string s)
        {
            Stack<int> numStack = new Stack<int>();
            Stack<char> opStack = new Stack<char>();
            int num = 0;
            char op = '+';

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    num = num * 10 + (c - '0');
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    if (op == '+')
                    {
                        numStack.Push(num);
                    }
                    else if (op == '-')
                    {
                        numStack.Push(-num);
                    }
                    else if (op == '*')
                    {
                        numStack.Push(numStack.Pop() * num);
                    }
                    else if (op == '/')
                    {
                        numStack.Push(numStack.Pop() / num);
                    }
                    num = 0;
                    op = c;
                }
                else if (c == '(')
                {
                    numStack.Push(num);
                    opStack.Push(op);
                    num = 0;
                    op = '+';
                }
                else if (c == ')')
                {
                    int temp = 0;
                    while (opStack.Count > 0 && opStack.Peek() != '(')
                    {
                        temp += numStack.Pop();
                        opStack.Pop();
                    }
                    temp += numStack.Pop();
                    opStack.Pop(); // Pop '('
                    numStack.Push(temp);
                }
            }

            if (op == '+')
            {
                numStack.Push(num);
            }
            else if (op == '-')
            {
                numStack.Push(-num);
            }
            else if (op == '*')
            {
                numStack.Push(numStack.Pop() * num);
            }
            else if (op == '/')
            {
                numStack.Push(numStack.Pop() / num);
            }

            int result = 0;
            while (numStack.Count > 0)
            {
                result += numStack.Pop();
            }

            return result;
        }
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