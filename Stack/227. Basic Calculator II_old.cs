//227. Basic Calculator II med
//表示一个表达式，只包含非负整数、算符和空格（' '）。算符包括+，-，*和/四种运算符。
//思路：当我们遇到一个加号或减号时，我们可以将其直接入栈。当我们遇到一个乘号或除号时，我们需要弹出栈顶元素并将其与当前数字进行乘法或除法运算，然后将运算结果重新压入栈中，因为乘法和除法的优先级比加法和减法高
        public int Calculate2(string s)
        {
            if (s == null || s.Length == 0)
                return 0;
            Stack<int> stack = new Stack<int>();
            char[] chars = s.ToCharArray();
            int num = 0;
            char sign = '+';
            int res = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (Char.IsDigit(chars[i]))
                {
                    num = num * 10 + (chars[i] - '0');
                }
                if ((!Char.IsDigit(chars[i])) && ' ' != chars[i] || i == s.Length - 1)
                {
                    if (sign == '+')
                        stack.Push(num);
                    else if (sign == '-')
                        stack.Push(-num);
                    else if (sign == '/')
                        stack.Push(stack.Pop() / num);
                    else if (sign == '*')
                        stack.Push(stack.Pop() * num);
                    sign = chars[i];
                    num = 0;
                }
            }
            while (stack.Count != 0)
                res += stack.Pop();
            return res;
        }