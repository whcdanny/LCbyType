//Leetcode 339 Nested List Weight Sum mid
//题意：每个元素要么是一个整数，要么是一个列表（嵌套元素）。整数的权重为其深度，列表的权重是深度加一。计算列表的总权重和，即所有元素的权重之和
//思路：深度优先搜索（DFS）
//时间复杂度:  n 是列表中的元素个数, O(n)
//空间复杂度：  d 是列表的嵌套深度 O(d)
        public int DepthSum(List<NestedInteger> nestedList)
        {
            return DepthSum_DFS(nestedList, 1);
        }

        private int DepthSum_DFS(List<NestedInteger> nestedList, int depth)
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
                    sum += DepthSum_DFS(item.GetList(), depth + 1);
                }
            }
            return sum;
        }