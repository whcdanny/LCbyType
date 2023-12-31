//Leetcode 2054. Two Best Non-Overlapping Events med
//题意：给定一个二维整数数组 events，其中 events[i] = [startTimei, endTimei, valuei] 表示第 i 个事件的开始时间、结束时间和价值。你可以选择至多两个不重叠的事件参加，使得它们的价值之和最大。
//返回这个最大的价值之和。
//注意：开始时间和结束时间是包含的，也就是说，你不能同时参加两个在同一时间开始和结束的事件。具体来说，如果你参加了一个结束时间为 t 的事件，下一个事件必须在 t + 1 或之后开始。
//思路：二分搜索, 现根据头的先排序，然后在从尾到头 将suffix Max,然后用二分法找尾部，然后比较res和当前value+suffix Max；       
//时间复杂度: O(n * log(n))
//空间复杂度：O(n)               
        public int MaxTwoEvents(int[][] events)
        {
            int n = events.Length;
            Array.Sort(events, (int[] a, int[] b) => a[0].CompareTo(b[0]));

            int[] suffixMax = new int[n + 1];

            for (int i = n - 1; i >= 0; i--)
            {
                suffixMax[i] = Math.Max(suffixMax[i + 1], events[i][2]);
            }

            int result = 0;

            for (int i = 0; i < n; i++)
            {
                int index = BinarySearch_MaxTwoEvents(events, events[i][1]);
                result = Math.Max(result, events[i][2] + suffixMax[index]);
            }

            return result;
        }

        public int BinarySearch_MaxTwoEvents(int[][] events, int endTime)
        {
            int left = 0;
            int right = events.Length;

            while (right - left > 1)
            {
                int mid = left + (right - left) / 2;

                if (events[mid][0] > endTime)
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }

            return right;
        }
