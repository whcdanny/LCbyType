//Leetcode 1021. Remove Outermost Parentheses ez
//题意：给定一个字符串 s，由小写英文字母组成。定义一种操作为移除字符串中相邻且相同的字母对，重复进行该操作直至无法继续。返回经过上述操作后的最终字符串。
//思路：stack, 使用一个变量 count 记录当前原语字符串的深度，初始值为 0。
//遍历字符串 s 中的每个字符：
//如果遇到左括号 '('，并且当前深度 count 大于 0，则将当前字符加入结果字符串中。
//如果遇到左括号 '('，并且当前深度 count 等于 0，则将 count 加 1。
//如果遇到右括号 ')'，并且当前深度 count 大于 1，则将当前字符加入结果字符串中。
//如果遇到右括号 ')'，并且当前深度 count 等于 1，则将 count 减 1。
//最终结果即为去除了最外层括号的原语字符串。
//时间复杂度: O(n) 的时间，每个字符入栈和出栈的操作的总时间复杂度为 O(n)
//空间复杂度：O(n)
        public string RemoveOuterParentheses(string s)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;

            foreach (char c in s)
            {
                if (c == '(')
                {
                    if (count > 0)
                    {
                        sb.Append(c);
                    }
                    count++;
                }
                else if (c == ')')
                {
                    count--;
                    if (count > 0)
                    {
                        sb.Append(c);
                    }
                }
            }

            return sb.ToString();
        }