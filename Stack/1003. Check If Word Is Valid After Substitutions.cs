//Leetcode 1003. Check If Word Is Valid After Substitutions med
//题意：给定一个字符串 s，判断它是否是有效的。
//一个字符串 s 是有效的，如果我们可以从空字符串 t = "" 开始，通过以下操作任意次数后将 t 转变为 s：
//在 t 中的任意位置插入字符串 "abc"。更正式地，t 变为 tleft + "abc" + tright，其中 t == tleft + tright。注意，tleft 和 tright 可能是空的。
//思路：stack, 栈来模拟匹配过程。
//遍历字符串 s 中的每个字符，如果当前字符为 'c'，则尝试从栈顶依次弹出 'b' 和 'a'，看是否与当前字符相匹配。
//最后判断栈是否为空，如果为空则表示成功匹配，返回 true；否则返回 false。
//时间复杂度: 遍历字符串 s 的时间复杂度为 O(n)，其中 n 是字符串 s 的长度
//空间复杂度：使用了一个栈来模拟匹配过程，栈的最大深度为字符串 s 的长度，因此空间复杂度为 O(n)。
        public bool IsValid_1003(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == 'c')
                {
                    if (stack.Count < 2 || stack.Pop() != 'b' || stack.Pop() != 'a')
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }