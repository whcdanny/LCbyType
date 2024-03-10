//Leetcode 1541. Minimum Insertions to Balance a Parentheses String med
//题意：给定一个仅包含字符 '(' 和 ')' 的括号字符串 s。一个括号字符串是平衡的，如果满足以下条件：
//任何一个左括号 '(' 必须有对应的两个连续的右括号 '))'。
//左括号 '(' 必须在对应的两个连续的右括号 '))' 之前。
//换句话说，我们将 '(' 视为开括号，将 '))' 视为闭括号。
//例如，"())"、"())(())))" 和 "(())())))" 是平衡的，而 ")()"、"))()" 和 "(()))" 不是平衡的。
//如果需要，你可以在字符串的任意位置插入字符 '(' 和 ')' 来使其平衡。
//返回使 s 平衡所需的最小插入次数。
//思路：Stack,只存（，然后遇到）查看当前位置和后一个位置是否也是），如果是继续，如果不是count++；
//如果stack里还有（，pop，如果没有count++；
//注：最后如果stack里还有（，那么就需要count += 2 * stack.Count;
//时间复杂度：O(n)，其中 n 是字符串 s 的长度
//空间复杂度：O(n)
        public int MinInsertions(string s)
        {
            Stack<char> stack = new Stack<char>();
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c == '(')
                {
                    stack.Push(c);
                }
                else
                {
                    //如果)和存在下一个）那么就继续；
                    if (i + 1 < s.Length && s[i + 1] == ')')
                    {
                        i++;
                    }
                    //如果没有count++；
                    else
                    {
                        count++;
                    }
                    //因为stack只存(，所以pop
                    if (stack.Any())
                    {
                        stack.Pop();
                    }
                    //如果没有了，count++；
                    else
                    {
                        count++;
                    }
                }
            }
            count += 2 * stack.Count;
            return count;
        }