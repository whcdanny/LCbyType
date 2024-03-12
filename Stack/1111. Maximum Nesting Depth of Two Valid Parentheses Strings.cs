//Leetcode 1111. Maximum Nesting Depth of Two Valid Parentheses Strings med
//题意：求将一个有效括号字符串（VPS）分割成两个不相交的子序列 A 和 B，使得这两个子序列仍然是有效括号字符串，并且它们的深度差尽可能小。括号字符串的深度是指左右括号的嵌套层数。
//具体地，给定一个有效括号字符串 seq，我们需要将其分成两个子序列 A 和 B，满足以下条件：
//A 和 B 是有效括号字符串（VPS），即它们只包含字符 "(" 和 ")"，并且满足括号匹配的规则。
//A 和 B 的长度之和等于 seq 的长度。
//A 和 B 的深度差尽可能小，即使得 |depth(A) - depth(B)| 最小。
//括号字符串的深度定义如下：
//空字符串的深度为 0。
//对于两个有效括号字符串 A 和 B，A 和 B 连接后的深度为 max(depth(A), depth(B))。
//对于一个以 "(" 开头，以 ")" 结尾的子串，其深度为嵌套层数，即 1 + depth(A)，其中 A 是去除首尾括号后的子串。
//最终，我们需要返回一个长度为 seq.length 的数组 answer，其中 answer[i] 表示 seq[i] 在 A 中还是 B 中的标记，
///若为 0 则表示在 A 中，若为 1 则表示在 B 中。需要注意的是，即使存在多种分割方式，我们可以返回任意一种满足条件的分割。
//思路：stack, stack用于存（和stack的数量来表示当前有几个内嵌，
//遍历输入的字符串, 如果是（就先算是内嵌个数，然后放入stack，
//如果是）那就看stack是否为空，不为空，就说明有（，那么就stack弹出，并且给出此时stack的个数%2；
//时间复杂度: O(n)，其中 n 为数组 arr 的长度，我们需要遍历数组并维护单调递减栈
//空间复杂度：O(n)
        public int[] MaxDepthAfterSplit(string seq)
        {
            int count = 0;
            int[] output = new int[seq.Length];
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < seq.Length; i++)
            {
                if (seq[i] == ')' && stack.Count>0)
                {
                    if (stack.Peek() == '(')
                    {
                        stack.Pop();
                        output[i] = stack.Count % 2;
                    }
                }
                else
                {
                    output[i] = stack.Count % 2;
                    stack.Push(seq[i]);
                }
            }
            return output;
        }