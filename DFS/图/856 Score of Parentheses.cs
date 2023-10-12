//Leetcode 856 Score of Parentheses  med
//题意：给定一个平衡括号字符串 S，按照以下规则计算其得分："()" 得 1 分。"AB" 得 A + B 分，其中 A 和 B 是平衡括号字符串。"(A)" 得 2 * A 分，其中 A 是平衡括号字符串。
//思路：深度优先搜索（DFS）: 根据这个规则，就是left和right的关系
//时间复杂度:  n 是输入字符串的长度 O(n)
//空间复杂度： O(n)
        public int ScoreOfParentheses(string s)
        {
            return ScoreOfParentheses(s, 0, s.Length - 1);
        }
        private int ScoreOfParentheses(string S, int left, int right)
        {
            if (left + 1 == right)
                return 1;
            int balance = 0;
            for(int i = left; i < right; i++)
            {
                if (S[i] == '(')
                {
                    balance++;
                }
                else
                {
                    balance--;
                }

                if (balance == 0)
                {
                    return ScoreOfParentheses(S, left, i) + ScoreOfParentheses(S, i + 1, right);
                }
            }

            return 2 * ScoreOfParentheses(S, left + 1, right - 1);
        }