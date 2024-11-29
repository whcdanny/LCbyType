//56. Merge Intervals med
//题意：
/*给出一个区间的集合，请合并所有重叠的区间。
* 示例 1：
* 输入: intervals = [[1,3],[2,6],[8,10],[15,18]]
* 输出: [[1,6],[8,10],[15,18]]
* 解释: 区间[1, 3] 和[2, 6] 重叠, 将它们合并为[1, 6]。*/
//输入: [10,2]        
//思路：先要给intervals排序，
//然后用res存最终区域，将第一个intervals[0]放入，
//然后从第二个开始就跟res最后一个区域的end去做比较
//intervals[i][0] <= res[^1][1], 说明当前区域可以被添加到res最后一个区域，
//然后只要更新res[^1][1] = Math.Max(res[^1][1], intervals[i][1]);
//时间复杂度：O(nlogn)。
//空间复杂度：O(n)。
        public int[][] Merge1(int[][] intervals)
        {
            if (intervals.Length == 0)
                return new int[0][];

            Array.Sort(intervals, (a, b) => a[0] - b[0]);

            List<int[]> res = new List<int[]>();
            res.Add(intervals[0]);
            for (int i = 1; i < intervals.Length; i++)
            {
                if (intervals[i][0] <= res[^1][1])
                {
                    res[^1][1] = Math.Max(res[^1][1], intervals[i][1]);
                }
                else
                {
                    res.Add(intervals[i]);
                }
            }
            return res.ToArray();
        }