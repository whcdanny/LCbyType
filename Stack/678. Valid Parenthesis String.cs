//Leetcode 678. Valid Parenthesis String med
//题意：给定一个只包含三种字符 '('、')' 和 '*' 的字符串 s，如果 s 是有效的，则返回 true。
//有效字符串需满足以下条件：
//任何左括号 '(' 必须有相应的右括号 ')'。
//任何右括号 ')' 必须有相应的左括号 '('。
//左括号 '(' 必须在相应的右括号 ')' 之前。
//同时，字符 '*' 可以被视为单个右括号 ')'，单个左括号 '('，或者是一个空字符串 ""。
//思路：Stack 两个栈分别记录左括号 '(' 和星号 '*' 的索引。
//遍历字符串 s，对于每个字符：
//如果是左括号 '('，将其索引压入左括号栈。
//如果是星号 '*'，将其索引压入星号栈。
//如果是右括号 ')'，首先尝试匹配左括号栈中的左括号，如果左括号栈不为空，则弹出一个左括号，
//否则尝试匹配星号栈中的星号，如果星号栈不为空，则弹出一个星号，否则返回 false。
//最后，检查左括号栈中的左括号和星号栈中的星号是否匹配。如果左括号栈中还有未匹配的左括号，且星号栈中的星号的索引大于左括号栈中的左括号的索引，则返回 false。
//如果遍历完成后左括号栈为空，则返回 true。
//时间复杂度：O(n)，n 为字符串的长度
//空间复杂度：O(n) 
        public bool CheckValidString(string s)
        {
            Stack<int> leftStack = new Stack<int>();
            Stack<int> starStack = new Stack<int>();

            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (ch == '(')
                {
                    leftStack.Push(i);
                }
                else if (ch == '*')
                {
                    starStack.Push(i);
                }
                else
                {
                    if (leftStack.Count > 0)
                    {
                        leftStack.Pop();
                    }
                    else if (starStack.Count > 0)
                    {
                        starStack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            while (leftStack.Count > 0 && starStack.Count > 0)
            {
                if (leftStack.Peek() > starStack.Peek())
                {
                    return false;
                }
                leftStack.Pop();
                starStack.Pop();
            }

            return leftStack.Count == 0;
        }