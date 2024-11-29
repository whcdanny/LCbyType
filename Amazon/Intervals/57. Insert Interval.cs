//57. Insert Interval med
//题目：给定一个不重叠间隔的数组intervals，其中表示间隔的开始和结束，并按 升序排序。
//还给定一个表示另一个间隔的开始和结束的间隔。intervals[i] = [starti, endi]ithintervalsstartinewInterval = [start, end]
//插入newInterval到仍然按升序排序intervals并且仍然没有任何重叠区间（如果需要，合并重叠区间）。intervalsstartiintervals
//intervals插入后返回。
//请注意，您不需要intervals就地修改。您可以创建一个新数组并返回它。
//思路：先考虑什么时候可以添加intervals中的，
//位置：[in0，in1] [new0,new1] or [new, new1] [in0,in1] 
//然后是newInterval是与intervals 部分重叠 或者 全部重叠
//[in0     in1]
//     [new0,   new1] 这样我们需要更新newInterval
//[new0         new1]
//[new0,   new1]
//     [in0,    in0] 这样我们也需要更新newInterval
//[new0,        new1]
//注：最后何时添加newInterval，一个是当intervals还有然后 isisAfterNewInterval
//一个是把newInterval，添加到intervals最后，那么都历遍完，再把加入
//时间复杂度:  O(n)
//空间复杂度： O(n)
        public int[][] Insert(int[][] intervals, int[] newInterval)
        {
            if (intervals.Length == 0) 
                return newInterval.Length == 0 ? new int[0][] : new[] { newInterval };
            if (newInterval.Length == 0) 
                return intervals;

            List<int[]> result = new List<int[]>(intervals.Length + 1);
            bool addedNewInterval = false;

            foreach (int[] interval in intervals)
            {
                bool isBeforeNewInterval = interval[1] < newInterval[0];
                bool isAfterNewInterval = interval[0] > newInterval[1];

                if (isAfterNewInterval && !addedNewInterval)
                {
                    result.Add(newInterval);
                    addedNewInterval = true;
                }

                if (isBeforeNewInterval || isAfterNewInterval)
                    result.Add(interval);

                bool intersectsNewAtBeginning = newInterval[0] >= interval[0] && newInterval[0] <= interval[1];
                bool intersectsNewAtEnd = newInterval[1] >= interval[0] && newInterval[1] <= interval[1];

                if (intersectsNewAtBeginning)
                    newInterval[0] = interval[0];

                if (intersectsNewAtEnd)
                    newInterval[1] = interval[1];
            }

            if (!addedNewInterval && newInterval.Length > 0)
                result.Add(newInterval);

            return result.ToArray();
        }