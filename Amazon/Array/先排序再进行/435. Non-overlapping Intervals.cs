//Leetcode 435. Non-overlapping Intervals med
//题目：给定一个区间数组，intervals其中，返回需要删除的最小区间数，以使其余区间不重叠。intervals[i] = [starti, endi]
//请注意，仅在一点相切的区间是不重叠的。例如，[1, 2]和[2, 3] 是不重叠的。
//思路: 先对intervals终点进行排序，然后将第一个的end作为界限，
//如果下一个intervals[i][0] < end，那么说明要删除这个当前区间
//如果没有就进行下一个，然后更新end = intervals[i][1];
//时间复杂度：O(nlogn)
//空间复杂度：O(n)
        public int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length == 0)
                return 0;
            Array.Sort(intervals, (a, b) => a[1].CompareTo(b[1]));
            int count = 0;
            int end = intervals[0][1];            
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] < end)
                {
                    count++;
                }
                else
                {
                    end = intervals[i][1];
                }
            }
            return count;
        }