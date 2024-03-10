//Leetcode 2375. Construct Smallest Number From DI String med
//题意：给定一个长度为n的字符串pattern，其中包含字符'I'表示递增和字符'D'表示递减。
//根据以下条件创建一个长度为n+1的字符串num：
//num由数字'1'到'9'组成，每个数字最多使用一次。
//如果pattern[i] == 'I'，则num[i] < num[i + 1]。
//如果pattern[i] == 'D'，则num[i] > num[i + 1]。
//返回满足条件的字典序最小的字符串num。
//思路：Stack; 构建字符串的过程。遍历字符串pattern，根据'I'和'D'的情况，决定当前数字的大小关系。
//如果当前字符是'I'，则将数字放入，并pop出stack中所有的，
//如果当前字符是'D'，则将数字放入，并不用弹出，
//最后，每次pop出就会加到num中；
//注：这里想的就是如果I,我们不囤积再stack中，如果D囤积；
//时间复杂度：O(n)，其中n为字符串pattern的长度，因为需要遍历整个字符串。
//空间复杂度：O(n)，最坏情况下，栈的大小为字符串pattern的长度。
        public string SmallestNumber(string pattern)
        {
            Stack<int> stack = new Stack<int>();
            string num = "";

            // 遍历字符串pattern
            for (int i = 0; i <= pattern.Length; i++)
            {                
                if (i == pattern.Length || pattern[i] == 'I')
                {
                    stack.Push(i + 1); // 将当前的位置的数字压入栈中

                    //弹出栈中的数字，并在数字之间插入当前位置的数字
                    while (stack.Count > 0)
                    {
                        num += stack.Pop();
                    }
                }
                else
                {
                    stack.Push(i + 1); // 将当前的位置的数字压入栈中
                }
            }

            return num;
        }