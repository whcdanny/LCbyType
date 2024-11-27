//Leetcode 224. Basic Calculator hard
//题意：给你一个字符串表达式 s ，请你实现一个基本计算器来计算并返回它的值
//思路：用一个栈来帮助处理括号表达式，遍历字符串时，
//如果遇到数字，则将数字解析为整数添加到当前结果中。
//如果遇到加号或减号，则更新符号变量。
//如果遇到左括号，则将当前结果和符号入栈，并重新初始化结果和符号。
//如果遇到右括号，则从堆栈中弹出上一级结果和符号，并将当前结果乘以符号并加上上一级结果。
//最终结果为最后的结果
//时间复杂度：n 是表达式的长度，O(n)。
//空间复杂度：n 是表达式的长度，O(n)
        public int Calculate1(string s)
        {
            int result = 0;
            int sign = 1;

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (Char.IsDigit(c))
                {
                    int num = c - '0';
                    while (i + 1 < s.Length && Char.IsDigit(s[i + 1]))
                    {
                        num = num * 10 + (s[i + 1] - '0');
                        i++;
                    }
                    result += sign * num;
                }
                else if (c == '+')
                {
                    sign = 1;
                }
                else if (c == '-')
                {
                    sign = -1;
                }
                else if (c == '(')
                {
                    stack.Push(result);
                    stack.Push(sign);
                    result = 0;
                    sign = 1;
                }
                else if (c == ')')
                {
                    result = stack.Pop() * result + stack.Pop();
                    sign = 1;
                }
            }

            return result;
        }