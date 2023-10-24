//1209. Remove All Adjacent Duplicates in String II med
//是一个移除字符串中所有相邻重复项的问题，但是每个重复项最多可以连续出现k次
//思路：对于每个字符，与栈顶元素进行比较。如果相同且当前重复次数达到了k次，则将栈顶元素出栈，以移除重复项。如果相同但重复次数还未达到k次，则将当前字符和重复次数入栈。如果不相同，则将当前字符和重复次数1入栈。将栈中的字符按照入栈顺序连接起来，即得到最终的字符串结果
        public string RemoveDuplicates(string s, int k)
        {
            Stack<(char, int)> stack = new Stack<(char, int)>();

            foreach (char c in s)
            {
                if (stack.Count > 0 && stack.Peek().Item1 == c)
                {
                    var top = stack.Peek();
                    if (top.Item2 == k - 1)
                    {
                        for (int i = 0; i < k - 1; i++)
                        {
                            stack.Pop();
                        }
                    }
                    else
                    {
                        stack.Push((c, top.Item2 + 1));
                    }
                }
                else
                {
                    stack.Push((c, 1));
                }
            }

            StringBuilder sb = new StringBuilder();
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                sb.Insert(0, item.Item1);
            }

            return sb.ToString();
        }