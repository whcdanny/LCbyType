//Leetcode 3440. Reschedule Meetings for Maximum Free Time II med
//题意：求在给定的活动总时长内，重新安排至多一个会议的开始时间（保持会议时长不变），使得会议之间的最长连续空闲时间最大化。
//需要注意的是，重新安排后的会议仍需保持不重叠，且不能超出活动的时间范围。
//思路：先找出每个会议的左侧每个的最大值存入list，再找出每个会议的右侧每个的最大值存入list
//再找出每个gap空挡存入list
//然后在两个gap中twoGaps = gaps[i] + gaps[i + 1];，根据当前会议的大小curSize = endTime[i] - startTime[i];
//然后找出会议i的left和right：(i > 0 && leftMaxGap[i - 1] >= curSize || i < len && rightMaxGap[i + 1] >= curSize)
//然后找出最后的答案：maxWind = Math.Max(maxWind, twoGaps + curSize);
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime)
        {
            int maxWind = 0;
            int len = startTime.Length;
            if (eventTime == 0 || len != endTime.Length)
                return maxWind;

            int preGap = 0, preEnd = 0;
            List<int> leftMaxGap = new List<int>(), gaps = new List<int>();
            for (int i = 0; i <= len; i++)
            {
                int gap = 0;
                if (i < len)
                {
                    gap = startTime[i] - preEnd;
                    maxWind = Math.Max(maxWind, gap + preGap);
                    preEnd = endTime[i];
                }
                else
                {
                    gap = eventTime - preEnd;
                    maxWind = Math.Max(maxWind, gap + preGap);
                }

                gaps.Add(gap);
                leftMaxGap.Add(Math.Max(gap, leftMaxGap.Count > 0 ? leftMaxGap.Last() : 0));
                preGap = gap;
            }

            int[] rightMaxGap = new int[len + 1];
            rightMaxGap[len] = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                rightMaxGap[i] = Math.Max(rightMaxGap[i + 1], gaps[i + 1]);
            }

            for (int i = 0; i < len; i++)
            {
                int twoGaps = gaps[i] + gaps[i + 1];
                int curSize = endTime[i] - startTime[i];
                if (i > 0 && leftMaxGap[i - 1] >= curSize || i < len && rightMaxGap[i + 1] >= curSize)
                    maxWind = Math.Max(maxWind, twoGaps + curSize);
            }
            return maxWind;
        }