//56. Merge Intervals med
        /*给出一个区间的集合，请合并所有重叠的区间。
         * 示例 1：
         * 输入: intervals = [[1,3],[2,6],[8,10],[15,18]]
         * 输出: [[1,6],[8,10],[15,18]]
         * 解释: 区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6]。*/
        //思路：将区间按照左端点排序,初始化一个栈，将第一个区间压入栈;如果其左端点大于栈顶区间的右端点，则将该区间直接压入栈中；否则将栈顶区间的右端点更新为该区间的右端点的较大值。
        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
                return new int[0][];

            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            Stack<int[]> stack = new Stack<int[]>();
            stack.Push(intervals[0]);

            for(int i = 0; i < intervals.Length; i++)
            {
                int[] top = stack.Peek();
                if (intervals[i][0] > top[1])
                    stack.Push(intervals[i]);
                else
                    top[1] = Math.Max(top[1], intervals[i][1]);
            }
            return stack.ToArray();
        }