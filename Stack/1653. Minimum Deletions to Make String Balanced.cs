//Leetcode 1653. Minimum Deletions to Make String Balanced med
//题意：给定一个只包含字符 'a' 和 'b' 的字符串 s​​​​。
//你可以删除 s 中的任意数量的字符，使得 s 变得平衡。如果不存在一对下标(i, j)，满足 i<j 且 s[i] = 'b' 和 s[j]= 'a'，则 s 是平衡的。
//返回使 s 平衡所需的最小删除次数。
//思路：Stack 这里的想法是只要我们遇到'b'就将其推入堆栈。
//但是如果我们遇到'a'怎么办，在这种情况下我们检查是否已经存在'b'然后我们从堆栈中弹出'b'（这表示删除操作）。
//时间复杂度：O(n)，其中 n 为字符串 s 的长度
//空间复杂度：O(N)

        public int MinimumDeletions(string s)
        {
            int count = 0;
            Stack<char> stack = new Stack<char>();
            char c = ' ';
            for (int i = 0; i < s.Length; i++)
            {
                c = s[i];
                if (stack.Count != 0 && (stack.Peek() == 'b' && c == 'a'))
                {
                    stack.Pop();
                    count++;
                }
                else if (c == 'b')
                    stack.Push(c);
            }
            return count;
        }