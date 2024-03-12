//Leetcode 1106. Parsing A Boolean Expression hard
//题意：要求对给定的布尔表达式进行求值，布尔表达式可以有以下几种形式：
//'t'：代表 true。
//'f'：代表 false。
//'!(subExpr)'：对内部表达式 subExpr 进行逻辑非操作。
//'&(subExpr1, subExpr2, ..., subExprn)'：对内部表达式 subExpr1, subExpr2, ..., subExprn 进行逻辑与操作，其中 n >= 1。
//'|(subExpr1, subExpr2, ..., subExprn)'：对内部表达式 subExpr1, subExpr2, ..., subExprn 进行逻辑或操作，其中 n >= 1。
//给定的表达式保证是有效的，且符合上述规则。
//我们需要实现一个算法来对给定的布尔表达式进行求值，并返回其结果。
//思路：stack, 栈来存储中间结果和运算符。
//从左到右遍历表达式，对于每个字符进行处理：
//如果是 't' 或 'f'，将其值压入栈中。
//如果是 '!'、'&' 或 '|'，将其压入栈中。
//如果是 '('，将其忽略。
//如果是 ')'，则弹出栈中的元素，直到遇到 '('，并根据弹出的元素和运算符进行运算，将结果压入栈中。
//时间复杂度: O(n)，其中 n 为表达式的长度
 //空间复杂度：O(n)
        public bool ParseBoolExpr(string expression)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (c == ')')
                {
                    HashSet<char> set = new HashSet<char>();

                    while (stack.Peek() != '(')
                    {
                        set.Add(stack.Pop());
                    }

                    stack.Pop(); // Remove '('

                    char op = stack.Pop(); // Get operator
                    //反转；
                    if (op == '!')
                    {
                        stack.Push(set.Contains('t') ? 'f' : 't');
                    }
                    //只要有f and 肯定是false
                    else if (op == '&')
                    {
                        stack.Push(set.Contains('f') ? 'f' : 't');
                    }
                    //只要有t Or 肯定是 true
                    else if (op == '|')
                    {
                        stack.Push(set.Contains('t') ? 't' : 'f');
                    }
                }
                else if (c != ',')
                {
                    stack.Push(c);
                }
            }

            return stack.Peek() == 't';
        }