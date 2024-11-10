//Leetcode 3169. Count Days Without Meetings med
//题目：我们有一个正整数 days 表示员工的可用工作天数（从第 1 天开始），以及一个二维数组 meetings，
//其中 meetings[i] = [start_i, end_i] 表示第 i 个会议从第 start_i 天到第 end_i 天（包括在内）。这些会议可能有重叠。
//我们的任务是计算员工在没有会议安排的情况下，可以工作的天数。
//思路:先按照每个会议开始时间排序，
//然后从第一个开始确定start和end
//然后如果第一个会议的开始时间不是第1天，则计数第1天到第start-1天为无会议天数
//然后历遍如果end < meetings[i][0]，说明当前会议的起始时间在前一个会议结束时间之后，则中间有无会议天数
//如果end > meetings[i][0] ，说明会议有部分覆盖，找出新的start和end
//最后一个会议的结束时间小于总天数，则最后几天为无会议天数
//时间复杂度：O(n log n)
//空间复杂度：O(1)
        public int CountDays(int days, int[][] meetings)
        {
            // 按照每个会议的起始时间排序
            Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

            int count = 0;

            // 初始化第一个会议的起始和结束时间
            int start = meetings[0][0];
            int end = meetings[0][1];

            // 如果第一个会议的开始时间不是第1天，则计数第1天到第start-1天为无会议天数
            if (start != 1)
            {
                count += (start - 1);
            }

            // 遍历剩余的会议
            for (int i = 1; i < meetings.Length; i++)
            {
                if (end < meetings[i][0])
                {
                    // 如果当前会议的起始时间在前一个会议结束时间之后，则中间有无会议天数
                    count += (meetings[i][0] - end - 1);
                    start = meetings[i][0];
                    end = meetings[i][1];
                }
                else
                {
                    // 更新重叠会议的起始和结束时间
                    start = Math.Min(start, meetings[i][0]);
                    end = Math.Max(end, meetings[i][1]);
                }
            }

            // 如果最后一个会议的结束时间小于总天数，则最后几天为无会议天数
            if (end < days)
            {
                count += days - end;
            }

            return count;
        }