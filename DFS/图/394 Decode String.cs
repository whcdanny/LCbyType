//Leetcode 394 Decode String med
//题意：给定一个经过编码的字符串，返回解码后的字符串。编码规则是k[encoded_string]，表示其中的 encoded_string 正好重复 k 次。请注意，k 保证是一个正整数。
//思路：深度优先搜索（DFS）两个栈，一个用来存放重复的次数 countStack，一个用来存放已经解码的字符串 strStack。如果是数字，累积数字构成重复的次数 count。如果是左括号[，将当前的 count 和已解码的字符串压入栈，并分别重置为初始值。如果是右括号]，从栈中取出 count 和已解码的字符串 prevStr，将 prevStr 重复 count 次，并与当前的已解码字符串连接起来。如果是字母，直接将其加入已解码字符串中。
//时间复杂度:  n 是输入字符串的长度, O(n)
//空间复杂度： n 是输入字符串的长度, O(n)
        public string DecodeString(string s)
        {
            Stack<int> countStack = new Stack<int>();
            Stack<string> strStack = new Stack<string>();

            int count = 0;
            string currentStr = "";

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    count = count * 10 + (c - '0');
                }
                else if (c == '[')
                {
                    countStack.Push(count);
                    strStack.Push(currentStr);
                    count = 0;
                    currentStr = "";
                }
                else if (c == ']')
                {
                    int repeatCount = countStack.Pop();
                    string prevStr = strStack.Pop();
                    for (int i = 0; i < repeatCount; i++)
                    {
                        prevStr += currentStr;
                    }
                    currentStr = prevStr;
                }
                else
                {
                    currentStr += c;
                }
            }

            return currentStr;
        }