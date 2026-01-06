//Leetcode 3439. Reschedule Meetings for Maximum Free Time I med
//题意：要求在给定的事件时间范围内，通过最多重新安排 k 个会议的开始时间，
//最大化连续的空闲时间。需要注意的是，会议的相对顺序必须保持不变，且会议不能重叠。
//思路：滑动窗口。计算间隙（gaps 数组）：
//gaps[0] 表示第一个会议开始前的空闲时间（即 startTime[0]）。
//gaps[len] 表示最后一个会议结束后的空闲时间（即 eventTime - endTime[len - 1]）。
//对于中间的间隙，gaps[i] 表示第 i 个会议和第 i-1 个会议之间的空闲时间（即 startTime[i] - endTime[i - 1]）。
//计算前缀和（preSum 数组）：
//preSum[i] 表示从 gaps[0] 到 gaps[i - 1] 的累加和。
//前缀和的作用是快速计算任意区间的空闲时间总和。
//滑动窗口计算最大空闲时间：
//使用滑动窗口的思想，窗口大小为 k + 1（因为调整 k 个会议可以合并 k + 1 个间隙）。
//遍历 preSum 数组，计算每个窗口内的空闲时间总和（即 preSum[i] - preSum[i - (k + 1)]），并更新最大值 res。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime)
        {
            int len = startTime.Length;
            if (len == 0) return eventTime; // 没有会议，所有时间都是空闲的

            // 计算所有间隙
            int[] freeGaps = new int[len + 1];
            freeGaps[0] = startTime[0]; // 第一个会议开始前的空闲时间
            freeGaps[len] = eventTime - endTime[len - 1]; // 最后一个会议结束后的空闲时间
            for (int i = 1; i < len; i++)
            {
                freeGaps[i] = startTime[i] - endTime[i - 1]; // 会议之间的空闲时间
            }

            // 计算前缀和
            int[] prefixSum = new int[len + 2];
            for (int i = 1; i <= len + 1; i++)
            {
                prefixSum[i] = prefixSum[i - 1] + freeGaps[i - 1];
            }

            // 滑动窗口计算最大空闲时间
            int res = 0;
            for (int i = k + 1; i <= len + 1; i++)
            {
                res = Math.Max(res, prefixSum[i] - prefixSum[i - (k + 1)]);
            }

            return res;
        }