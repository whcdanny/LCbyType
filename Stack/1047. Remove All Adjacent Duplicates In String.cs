//Leetcode 1047. Remove All Adjacent Duplicates In String ez
//题意：给定一个字符串 s，由小写英文字母组成。定义一种操作为移除字符串中相邻且相同的字母对，重复进行该操作直至无法继续。返回经过上述操作后的最终字符串。
//思路：stack, 使用栈来模拟操作。遍历字符串 s，对于每个字符，将其与栈顶元素比较，如果相同则弹出栈顶元素，否则将当前字符入栈。
//最终栈中剩余的元素即为去除相邻重复字母后的最终字符串。
//时间复杂度: O(n) 的时间，每个字符入栈和出栈的操作的总时间复杂度为 O(n)
//空间复杂度：O(n)
        public string RemoveDuplicates(string s)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char c in s)
            {
                if (stack.Count > 0 && stack.Peek() == c)
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                sb.Insert(0, stack.Pop());
            }

            return sb.ToString();
        }
