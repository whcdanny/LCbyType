//Leetcode 1190. Reverse Substrings Between Each Pair of Parentheses med
//题意：给定一个字符串s，包含小写英文字母和括号。要求反转每对匹配括号中的字符串，从最内层开始。结果字符串不包含任何括号。
//思路：Stack, 使用栈来辅助处理括号匹配。
//遍历字符串s，当遇到左括号时，将当前索引入栈；当遇到右括号时，出栈操作，将出栈的左括号位置到当前右括号位置的子串进行反转。
//将反转后的子串重新插入到字符串s中原来的位置。
//最后，删除字符串中的所有括号。
//时间复杂度：O(n)，其中n是字符串s的长度。遍历一次字符串s，并在每次遇到括号时进行出栈入栈和子串反转操作。
//空间复杂度：O(n)，使用了一个栈来存储左括号的位置，以及额外的空间来存储反转后的子串。
        public string ReverseParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            StringBuilder sb = new StringBuilder(s);

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else if (s[i] == ')')
                {
                    //开始位置：stack.Pop() + 1不需要(，结束位置: i-1 不需要)
                    ReverseSubstring(sb, stack.Pop() + 1, i - 1);
                }
            }

            // 删除所有括号
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                if (sb[i] == '(' || sb[i] == ')')
                {
                    sb.Remove(i, 1);
                }
            }

            return sb.ToString();
        }

        private void ReverseSubstring(StringBuilder sb, int start, int end)
        {
            while (start < end)
            {
                char temp = sb[start];
                sb[start] = sb[end];
                sb[end] = temp;
                start++;
                end--;
            }
        }