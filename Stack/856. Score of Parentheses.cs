//Leetcode 856. Score of Parentheses med
//题意：给定一个平衡的括号字符串 s，返回该字符串的得分。
//一个平衡的括号字符串的得分基于以下规则：
//"()" 的得分为 1。
//AB 的得分为 A + B，其中 A 和 B 是平衡的括号字符串。
//(A) 的得分为 2 * A，其中 A 是一个平衡的括号字符串。
//思路：Stack, 栈来处理括号的匹配和计算得分。
//遍历字符串 s，遇到左括号 '(' 就将其入栈；遇到右括号 ')' 则计算其得分。
//如果遇到连续的 '('，则将当前得分入栈并将得分置为 0。
//遍历结束后，栈中存储的就是每个子串的得分，将栈中的得分相加即可得到最终结果。
//时间复杂度：O(n) 
//空间复杂度：O(n) 
        public int ScoreOfParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            int score = 0;

            foreach (char c in s)
            {
                if (c == '(')
                {
                    stack.Push(score);
                    score = 0;
                }
                else
                {
                    score = stack.Pop() + Math.Max(1, 2 * score);
                }
            }

            return score;
        }