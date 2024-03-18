//Leetcode 341 Flatten Nested List Iterator  mid
//题意：给定一个嵌套的整数列表 nestedList，其中每个元素可以是一个整数，也可以是一个列表，其元素同样可以是整数或其他列表。实现一个迭代器来将其展开。
//要求实现的类 NestedIterator 包含以下方法：
//NestedIterator(List<NestedInteger> nestedList)：用给定的嵌套列表初始化迭代器。
//int next()：返回嵌套列表中的下一个整数。
//boolean hasNext()：如果嵌套列表中仍有整数，则返回 true，否则返回 false。
//思路：Stack 栈来辅助展开嵌套列表。将嵌套列表逆序入栈，这样栈顶元素就是下一个要返回的整数。
//在 hasNext() 方法中，检查栈顶元素是否是整数，如果不是，则将其展开并将展开后的整数压入栈中。
//在 next() 方法中，直接弹出栈顶元素并返回。
//时间复杂度:  初始化迭代器需要遍历所有元素，O(N)，n表示嵌套列表中的总元素个数。hasNext() O(1)，因为只需要检查栈顶元素是否为空 next() O(1)，因为直接从栈顶取元素。
//空间复杂度： O(D)，其中 D 表示嵌套列表的最大深度
        /**
        * // This is the interface that allows for creating nested lists.
        * // You should not implement it, or speculate about its implementation
        * interface NestedInteger {
        *
        *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
        *     bool IsInteger();
        *
        *     // @return the single integer that this NestedInteger holds, if it holds a single integer
        *     // Return null if this NestedInteger holds a nested list
        *     int GetInteger();
        *
        *     // @return the nested list that this NestedInteger holds, if it holds a nested list
        *     // Return null if this NestedInteger holds a single integer
        *     IList<NestedInteger> GetList();
        * }
        */
        public class NestedIterator
        {
            private Stack<NestedInteger> stack;
            public NestedIterator(IList<NestedInteger> nestedList)
            {
                stack = new Stack<NestedInteger>();
                // 将嵌套列表逆序入栈
                for (int i = nestedList.Count - 1; i >= 0; i--)
                {
                    stack.Push(nestedList[i]);
                }
            }

            public bool HasNext()
            {
                // 栈不为空时，持续展开栈顶元素
                while (stack.Count > 0)
                {
                    NestedInteger top = stack.Peek();
                    // 如果栈顶元素是整数，则返回 true
                    if (top.IsInteger())
                    {
                        return true;
                    }
                    // 如果栈顶元素是列表，则展开并将展开后的整数压入栈中
                    IList<NestedInteger> nestedList = top.GetList();
                    stack.Pop();
                    for (int i = nestedList.Count - 1; i >= 0; i--)
                    {
                        stack.Push(nestedList[i]);
                    }
                }
                // 栈为空，没有下一个整数
                return false;
            }

            public int Next()
            {
                return stack.Pop().GetInteger();
            }
        }