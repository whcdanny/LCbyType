//Leetcode 364 Nested List Weight Sum II mid
//题意：给定一个嵌套的列表，其中每个元素要么是一个整数，要么是一个列表（嵌套元素）。整数的权重为其深度，列表的权重是深度加一。计算列表的反向总权重和，即所有元素的权重乘以它们在列表中的层级，并求和。
//思路：深度优先搜索（DFS）递归地遍历嵌套列表，并同时计算当前深度,迭代完成后，得到的总和即为所求
//时间复杂度:  n 是列表中的元素个数, O(n)
//空间复杂度：  d 是列表的嵌套深度 O(d)
        public int DepthSumInverse(List<NestedInteger> nestedList)
        {
            int depth = GetDepth(nestedList);
            return GetDepth_DFS(nestedList, depth);
        }

        private int GetDepth(List<NestedInteger> nestedList)
        {
            int maxDepth = 1;
            foreach (var item in nestedList)
            {
                if (!item.IsInteger())
                {
                    maxDepth = Math.Max(maxDepth, 1 + GetDepth(item.GetList()));
                }
            }
            return maxDepth;
        }

        private int GetDepth_DFS(List<NestedInteger> nestedList, int depth)
        {
            int sum = 0;
            foreach (var item in nestedList)
            {
                if (item.IsInteger())
                {
                    sum += item.GetInteger() * depth;
                }
                else
                {
                    sum += GetDepth_DFS(item.GetList(), depth - 1);
                }
            }
            return sum;
        }