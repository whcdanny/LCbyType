//1249. Minimum Remove to Make Valid Parentheses med
//是一个移除最少数量的括号，使得剩下的括号串成有效的括号组合
//思路：用stack存(，找到）就pop，如果没有，就将位置int存入hashset表示需要移除的位置，历遍完，重新历遍s，然后根据需要以移除的位置，得到result
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