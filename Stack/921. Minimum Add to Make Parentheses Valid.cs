//Leetcode 921. Minimum Add to Make Parentheses Valid med
//题意：题目要求给定一个括号字符串 s，每次可以在任意位置插入括号，使得最终的字符串是一个有效的括号字符串。有效的括号字符串满足以下条件之一：
//它是空字符串。
//它可以被写成 AB，其中 A 和 B 都是有效的字符串。
//它可以被写成(A)，其中 A 是一个有效的字符串。
//思路：stack 栈来辅助处理，遍历字符串 s。
//当遇到左括号时，将其压入栈中。
//当遇到右括号时，如果栈不为空且栈顶是左括号，则将栈顶元素出栈，表示匹配成功。
//如果栈为空或栈顶不是左括号，则说明当前右括号没有匹配的左括号，需要插入一个左括号，将结果计数器加一。
//最后，还需要检查栈中是否有剩余的左括号，需要插入相应数量的右括号，将结果计数器加上未匹配的左括号的数量。
//时间复杂度: O(n)，其中 n 是字符串 s 的长度
//空间复杂度：O(n)。
        public int MinAddToMakeValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            int count = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count > 0 && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            count += stack.Count;
            return count;
        }