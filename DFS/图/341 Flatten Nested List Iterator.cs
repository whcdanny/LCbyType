//Leetcode 341 Flatten Nested List Iterator  mid
//题意：实现一个迭代器，用于遍历一个嵌套的列表。
//思路：深度优先搜索（DFS）
//时间复杂度:  n 是列表中的元素个数, O(n)
//空间复杂度：  d 是列表的嵌套深度 O(d)
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
        public interface NestedInteger
        {
            bool IsInteger();
            int GetInteger();
            List<NestedInteger> GetList();
        }
        public class NestedIterator
        {
            private Queue<int> quese;
            public NestedIterator(IList<NestedInteger> nestedList)
            {
                quese = new Queue<int>();
                NestedIterator_DFS(nestedList);
            }
            private void NestedIterator_DFS(IList<NestedInteger> nestedList)
            {
                foreach(var val in nestedList)
                {
                    if (val.IsInteger())
                    {
                        quese.Enqueue(val.GetInteger());
                    }
                    else
                    {
                        NestedIterator_DFS(val.GetList());
                    }
                }
            }
            public bool HasNext()
            {
                return quese.Count > 0;
            }

            public int Next()
            {
                return quese.Dequeue();
            }
        }

        /**
         * Your NestedIterator will be called like this:
         * NestedIterator i = new NestedIterator(nestedList);
         * while (i.HasNext()) v[f()] = i.Next();
         */