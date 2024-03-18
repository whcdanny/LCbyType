//Leetcode 385. Mini Parser med
//题意：给定一个字符串 s，表示一个嵌套列表的序列化形式，实现一个解析器来反序列化它，并返回反序列化后的 NestedInteger。
//每个元素可以是一个整数，也可以是一个列表，其元素可能是整数或其他列表。
//NestedInteger 是一个接口，表示一个嵌套的整数列表，可以是一个整数，也可以是一个嵌套列表。
//思路：Stack ，栈用栈来处理嵌套的结构，每当遇到一个 '[' 时，我们创建一个新的 NestedInteger 对象，并将其压入栈中表示新的嵌套层级。
//每当遇到一个整数或者 ',' 时，我们可以根据情况将其添加到当前嵌套层级的 NestedInteger 对象中。
//每当遇到一个 ']' 时，我们将栈顶的 NestedInteger 对象弹出，并将其添加到上一层级的 NestedInteger 对象中。
//时间复杂度：O(n)，其中 n 是字符串 s 的长度
//空间复杂度：O(n)
        public class NestedInteger
        {

            // Constructor initializes an empty nested list.
            public NestedInteger() { }

            // Constructor initializes a single integer.
            public NestedInteger(int value) { }

            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            public bool IsInteger() { return false; }
 
            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            public int GetInteger() { return 0; }

            // Set this NestedInteger to hold a single integer.
            public void SetInteger(int value) { }

            // Set this NestedInteger to hold a nested list and adds a nested integer to it.
            public void Add(NestedInteger ni) { }

            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger> GetList() { return new List<NestedInteger>(); }
        }
        public NestedInteger Deserialize(string s)
        {
            var stack = new Stack<NestedInteger>();

            // dummy root to avoid st.Count > 0 check
            stack.Push(new NestedInteger());

            NestedInteger current = null;

            for (var i = 0; i < s.Length; i++)
            {
                var ch = s[i];

                if (ch == '[')
                {
                    current = new NestedInteger();
                    stack.Peek().Add(current);
                    stack.Push(current);
                }
                else if (ch == ']')
                {
                    current = stack.Pop();
                }
                else if (ch == ',')
                {
                    continue;
                }
                else // parse digits and '-'
                {
                    var j = i + 1;

                    while (j < s.Length && (Char.IsDigit(s[j]) || s[j] == '-')) 
                        j++;

                    current = new NestedInteger(int.Parse(s[i..j]));//索引 i 到索引 j-1（左闭右开区间）的子字符串

                    stack.Peek().Add(current);

                    i = j - 1;
                }
            }

            return current;
        }