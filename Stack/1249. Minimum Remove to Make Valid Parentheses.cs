//Leetcode 1249. Minimum Remove to Make Valid Parentheses mid
//题意：给定一个只包含字符 '(' 和 ')' 的字符串，去掉最少的括号使得字符串成为一个有效的括号表达式。返回所有可能的有效字符串。  
//思路：可以使用栈来解决这个问题。遍历字符串，当遇到左括号时，将其下标入栈，当遇到右括号时，检查栈顶元素是否是左括号，如果是，将栈顶元素出栈，表示匹配成功，否则将右括号下标入栈。遍历结束后，栈中存储的就是需要移除的括号的下标，将这些下标对应的字符从字符串中移除，得到一个有效的括号表达式。
//时间复杂度：O(n)
//空间复杂度：O(n) 
        public string MinRemoveToMakeValid(string s)
        {
            Stack<int> stack = new Stack<int>();
            HashSet<int> removeIndices = new HashSet<int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(')
                {
                    stack.Push(i);
                }
                else if (c == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        removeIndices.Add(i);
                    }
                }
            }

            while (stack.Count > 0)
            {
                removeIndices.Add(stack.Pop());
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (!removeIndices.Contains(i))
                {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }