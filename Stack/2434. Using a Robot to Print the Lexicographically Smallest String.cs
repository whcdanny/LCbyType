//Leetcode 2434. Using a Robot to Print the Lexicographically Smallest String med
//题意：给定一个字符串s和一个当前为空的字符串t的机器人。在s和t都为空之前，应用以下操作之一：
//从字符串s的开头删除第一个字符，并将其给予机器人。机器人将把这个字符追加到字符串t上。
//从字符串t的末尾删除最后一个字符，并将其给予机器人。机器人将这个字符写在纸上。
//返回可以写在纸上的按字典顺序最小的字符串。
//思路：Stack; 用stack来存字母；
//从后往前，确然后面是否有比当前字母小的字母；并且实时跟新这个最小字母；
//当s[i]中去到到它为止最小的字母数，如果比stack最上面的要小，说明还没到这个最小的字母，那边把当前的字母放入stack，i进入下一个；
//如果大于或等于，那么result加入stack最上面这个；i保持不变因为没有进入stack；
//最后如果stack里还有，就直接加入到result
//时间复杂度：O(n)，其中n为字符串s的长度，因为需要遍历整个字符串
//空间复杂度：O(n)，最坏情况下，栈的大小为字符串s的长度。     
        public string RobotWithString(string s)
        {
            int n = s.Length;
            int[] nextSmallest = new int[n];
            
            int smallest = 'z'+ 1;

            for (int i = n - 1; i >= 0; i--)
            {
                smallest = Math.Min(smallest, s[i]);
                nextSmallest[i] = smallest;
            }

            Stack<char> stack = new Stack<char>();
            var result = new StringBuilder();
            int index = 0;

            while (index < n)
            {
                if (stack.Count == 0 || nextSmallest[index] < stack.Peek())
                {
                    stack.Push(s[index]);
                    index++;
                }
                else
                {
                    result.Append(stack.Peek());
                    stack.Pop();
                }
            }

            while (stack.Count > 0)
            {
                result.Append(stack.Peek());
                stack.Pop();
            }

            return result.ToString();
        }
