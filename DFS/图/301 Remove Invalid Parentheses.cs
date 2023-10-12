//Leetcode 301 Remove Invalid Parentheses hard
//题意：给定一个只包含字符 '(' 和 ')' 的字符串，移除最小数量的无效括号，使得输入的字符串有效（合法）。
//思路：深度优先搜索（DFS）: 我们需要计算出需要移除的左括号和右括号的数量. 择移除当前位置的括号或者保留它。如果我们选择移除括号，就将左括号或右括号数量相应减一，并继续递归搜索。如果我们选择保留括号，就继续递归搜索下一个位置。
//时间复杂度: O(2^n)
//空间复杂度： O(n)
        public IList<string> RemoveInvalidParentheses(string s)
        {
            int leftToRemove = 0;
            int rightToRemove = 0;

            // 计算需要移除的左括号和右括号数量
            foreach (char c in s)
            {
                if (c == '(')
                {
                    leftToRemove++;
                }
                else if (c == ')')
                {
                    if (leftToRemove > 0)
                    {
                        leftToRemove--;
                    }
                    else
                    {
                        rightToRemove++;
                    }
                }
            }

            HashSet<string> result = new HashSet<string>();
            RemoveInvalidParentheses_DFS(s, 0, 0, leftToRemove, rightToRemove, "", result);

            return result.ToList();
        }
        private void RemoveInvalidParentheses_DFS(string s, int index, int balance, int leftToRemove, int rightToRemove, string current, HashSet<string> result)
        {
            if (leftToRemove < 0 || rightToRemove < 0 || balance < 0)
                return;
            if (index == s.Length)
            {
                if (leftToRemove == 0 && rightToRemove == 0 && balance == 0)
                {
                    result.Add(current);
                }
                return;
            }

            char c = s[index];

            if (c == '(')
            {
                // 不使用当前左括号
                RemoveInvalidParentheses_DFS(s, index + 1, balance, leftToRemove - 1, rightToRemove, current, result);
                // 使用当前左括号
                RemoveInvalidParentheses_DFS(s, index + 1, balance + 1, leftToRemove, rightToRemove, current + c, result);
            }
            else if (c == ')')
            {
                // 不使用当前右括号
                RemoveInvalidParentheses_DFS(s, index + 1, balance, leftToRemove, rightToRemove - 1, current, result);
                // 使用当前右括号
                RemoveInvalidParentheses_DFS(s, index + 1, balance - 1, leftToRemove, rightToRemove, current + c, result);
            }
            else
            {
                // 非括号字符
                RemoveInvalidParentheses_DFS(s, index + 1, balance, leftToRemove, rightToRemove, current + c, result);
            }
        }