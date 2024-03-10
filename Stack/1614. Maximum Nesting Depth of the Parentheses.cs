//Leetcode 1614. Maximum Nesting Depth of the Parentheses ez
//题意：一个字符串是有效括号字符串（VPS）如果它满足以下条件之一：
//它是一个空字符串 ""，或者是一个不等于 "(" 或 ")" 的单个字符，
//它可以写成 AB（A 与 B 连接在一起），其中 A 和 B 都是 VPS，或者
//它可以写成(A)，其中 A 是一个 VPS。
//我们可以类似地定义任何 VPS S 的嵌套深度 depth(S) 如下：
//depth("") = 0
//depth(C) = 0，其中 C 是一个单个字符不等于 "(" 或 ")" 的字符串。
//depth(A + B) = max(depth(A), depth(B))，其中 A 和 B 是 VPS。
//depth("(" + A + ")") = 1 + depth(A)，其中 A 是一个 VPS。
//例如，""，"()()" 和 "()(()())" 是 VPS（嵌套深度分别为 0、1 和 2），而 ")(" 和 "(()" 不是 VPS。
//给定一个表示为字符串 s 的 VPS，返回 s 的嵌套深度。
//思路：Stack 存入(，当有）的时候，来存maxDepth，然后历遍完，得到max；
//时间复杂度： O(n)，其中 n 为字符串 s 的长度
//空间复杂度：O(1)
        public int MaxDepth(string s)
        {
            int maxDepth = 0;
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    maxDepth = Math.Max(maxDepth, stack.Count);
                    stack.Pop();
                }
            }
            return maxDepth;
        }