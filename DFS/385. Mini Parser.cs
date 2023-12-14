//Leetcode 385. Mini Parser med
//题意：给定一个字符串 s，表示一个嵌套的整数列表，实现一个迷你解析器，将该字符串解析为整数列表。其中，字符串可以包含整数或其他嵌套列表，但不会包含多余的空格。
//输入: s = "[123,[456,[789]]]"
//输出: [123, [456, [789]]]
//思路：DFS, 初始化指针 index 为 0。
//遍历字符串，对于每个字符，根据不同情况进行处理：
//如果是数字，解析整数。
//如果是负数，解析；
//如果是[，表示遇到嵌套列表，递归解析嵌套列表。
//如果是,，表示当前列表中的元素结束。
//如果是]，表示当前列表结束，返回结果。
//返回最终解析得到的整数列表。
//注：这里前缀的算法就是当你放入1的时候，来算10，11，12，相当于1*10+i；
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(D)，其中 D 是字符串中的最大嵌套深度
        public interface NestedInteger_Deserialize
        {
 
            // Constructor initializes an empty nested list.
            public void NestedInteger_Deserialize();
 
            // Constructor initializes a single integer.
             public void NestedInteger_Deserialize(int value);
 
            // @return true if this NestedInteger holds a single integer, rather than a nested list.
            bool IsInteger();
 
            // @return the single integer that this NestedInteger holds, if it holds a single integer
            // Return null if this NestedInteger holds a nested list
            int GetInteger();
 
            // Set this NestedInteger to hold a single integer.
            public void SetInteger(int value);
 
            // Set this NestedInteger to hold a nested list and adds a nested integer to it.
            public void Add(NestedInteger_Deserialize ni);
 
            // @return the nested list that this NestedInteger holds, if it holds a nested list
            // Return null if this NestedInteger holds a single integer
            IList<NestedInteger_Deserialize> GetList();
        }
        public NestedInteger_Deserialize Deserialize(string s)
        {
            int index = 0;
            return Parse_Deserialize(s, ref index);
        }

        private NestedInteger_Deserialize Parse_Deserialize(string s, ref int index)
        {
            NestedInteger_Deserialize result = null;//new NestedInteger_Deserialize();

            // 如果字符串以数字或负号开头
            if (s[index] == '-' || char.IsDigit(s[index]))
            {
                int num = 0;
                int sign = 1;

                // 处理负号
                if (s[index] == '-')
                {
                    sign = -1;
                    index++;
                }

                // 解析数字
                while (index < s.Length && char.IsDigit(s[index]))
                {
                    num = num * 10 + (s[index] - '0');
                    index++;
                }

                result.SetInteger(sign * num);
            }
            // 如果字符串以 '[' 开头
            else if (s[index] == '[')
            {
                index++; // 跳过 '['
                while (index < s.Length && s[index] != ']')
                {
                    result.Add(Parse_Deserialize(s, ref index));
                    if (index < s.Length && s[index] == ',')
                    {
                        index++; // 跳过 ','
                    }
                }
                index++; // 跳过 ']'
            }

            return result;
        }
