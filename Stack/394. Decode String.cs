//Leetcode 394. Decode String med
//题意：给定一个经过编码的字符串，返回解码后的字符串。
//编码规则如下：k[encoded_string]，其中方括号内的 encoded_string 被重复 k 次。注意，k 是一个正整数。
//假设输入字符串始终有效，没有额外的空格，方括号格式正确等。此外，可以假设原始数据不包含任何数字，数字仅用于表示重复次数 k。例如，不会出现像 3a 或 2[4] 这样的输入。
//思路：Stack 两个栈，一个用于存储重复次数，一个用于存储已经解码的字符串。
//遍历字符串，遇到数字字符时，将数字字符转换为整数并入栈。
//遇到左括号时，将当前重复次数入栈，并重置重复次数为 0。
//遇到右括号时，将栈顶的数字弹出，并根据数字重复栈顶的字符串，将重复后的字符串与栈顶的字符串拼接。
//遇到字母字符时，将其与栈顶的字符串拼接。
//最终栈中存储的字符串即为解码后的结果。
//时间复杂度：O(n)，其中 n 是字符串的长度
//空间复杂度：O(n)
        public string DecodeString(string s)
        {
            Stack<int> countStack = new Stack<int>(); // 用于存储重复次数
            Stack<string> stringStack = new Stack<string>(); // 用于存储已解码的字符串

            int count = 0;
            string currentString = "";

            foreach (char c in s)
            {
                if (char.IsDigit(c))
                {
                    count = count * 10 + (c - '0'); // 更新重复次数
                }
                else if (c == '[')
                {
                    countStack.Push(count); // 将当前重复次数入栈
                    stringStack.Push(currentString); // 将当前已解码的字符串入栈
                    count = 0; // 重置重复次数
                    currentString = ""; // 重置当前已解码的字符串
                }
                else if (c == ']')
                {
                    int repeatTimes = countStack.Pop(); // 弹出栈顶的重复次数
                    string decodedString = stringStack.Pop(); // 弹出栈顶的已解码字符串
                    for (int i = 0; i < repeatTimes; i++)
                    {
                        decodedString += currentString;
                    }
                    currentString = decodedString; // 将当前字符串重复 repeatTimes 次并与栈顶字符串拼接
                }
                else
                {
                    currentString += c; // 将字母字符拼接到当前字符串
                }
            }

            return currentString;            
        }