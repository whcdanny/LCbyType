//Leetcode 227. Basic Calculator II mid
//题意：实现一个基本的计算器来计算一个简单的字符串表达式，表达式中只包含非负整数、加号 +、减号 -、乘号 * 和除号 /，可以假设给定的表达式总是有效的。
//思路：用一个栈来辅助进行计算。
//具体的步骤如下：初始化一个栈 stack 用于存储数字。
//初始化一个变量 num 用于记录当前的数字。
//初始化一个变量 sign 用于记录当前的运算符，初始时 sign 为 +
//注：这里得sign是在你读取到新的sign之前的，而不是最新的。
//时间复杂度：n 是表达式的长度，O(n)。
//空间复杂度：n 是表达式的长度，O(n)
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