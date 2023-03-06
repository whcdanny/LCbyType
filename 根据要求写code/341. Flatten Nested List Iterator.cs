//341. Flatten Nested List Iterator med
//给一个nestedList，里面可以是单独的int或者list，然后来实现三个function；
//1.NestedIterator(List<NestedInteger> nestedList)： 初始化，nestedList转换成list；
//2.int next()：读取下一个；
//3.boolean hasNext()：是否右下一个;
//思路：根据第一个function，我们需要转化，那么就需要查读到的是否是int（使用IsInteger()），如果是直接加入list里，如果不是递归； 还需要创建全局变量一个读取到第几位的int值，用于hasNext()，这个数更新在next（）；
///**
        //* // This is the interface that allows for creating nested lists.
        //* // You should not implement it, or speculate about its implementation
        interface NestedInteger {
        
             // @return true if this NestedInteger holds a single integer, rather than a nested list.
             bool IsInteger();
        
             // @return the single integer that this NestedInteger holds, if it holds a single integer
             // Return null if this NestedInteger holds a nested list
             int GetInteger();
        
             // @return the nested list that this NestedInteger holds, if it holds a nested list
             // Return null if this NestedInteger holds a single integer
             IList<NestedInteger> GetList();
        }
        class NestedIterator
        {

            private List<Int32> items;
            private Int32 index;
            public NestedIterator(IList<NestedInteger> nestedList)
            {
                items = new List<Int32>();
                index = 0;
                Read(nestedList);
            }
            public void Read(IList<NestedInteger> list)
            {
                for (Int32 i = 0; i < list.Count; ++i)
                {
                    if (list[i].IsInteger())
                    {
                        items.Add(list[i].GetInteger());
                    }
                    else
                    {
                        Read(list[i].GetList());
                    }
                }
            }
            public bool HasNext()
            {
                if (index >= items.Count)
                {
                    return false;
                }
                return true;
            }
            public int Next()
            {
                return items[index++];
            }
        }

        /**
         * Your NestedIterator will be called like this:
         * NestedIterator i = new NestedIterator(nestedList);
         * while (i.HasNext()) v[f()] = i.Next();
         */