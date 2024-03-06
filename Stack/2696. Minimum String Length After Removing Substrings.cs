//Leetcode 2696. Minimum String Length After Removing Substrings ez
//题意：给定一个仅包含大写英文字母的字符串s。
//你可以对这个字符串执行一些操作，在一个操作中，你可以从s中移除任何一个子串"AB"或"CD"。
//返回你可以得到的结果字符串的最小可能长度。
//注意，字符串在移除子串后会进行连接，并可能产生新的"AB"或"CD"子串。       
//思路：Stack; 用stack来存char，如果前一个是A和当前是B 或者 前一个是C和当前是D，那么都要把前一个pop，如果都不是就push进stack
//时间复杂度：O(n)，其中n为字符串s的长度，因为需要遍历整个字符串。
//空间复杂度：O(n)，最坏情况下，栈的大小为字符串s的长度。
        public int MinLength(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in s)
            {
                if (stack.Count > 0)
                {
                    char peekElement = stack.Peek();
                    char renderElement = c;
                    if (peekElement == 'A' && renderElement == 'B')
                    {
                        stack.Pop();
                    }
                    else if (peekElement == 'C' && renderElement == 'D')
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }
            string ans = "";
            while (stack.Count != 0)
            {
                ans = stack.Peek() + ans;
                stack.Pop();
            }
            return ans.Length;
        }