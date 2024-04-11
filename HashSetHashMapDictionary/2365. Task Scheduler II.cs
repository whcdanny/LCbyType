//Leetcode 2365. Task Scheduler II med
//题意：给定一个由正整数构成的数组 tasks，表示需要按顺序完成的任务，其中 tasks[i] 表示第 i 个任务的类型。
//同时给定一个正整数 space，表示完成一个任务后必须间隔的最小天数。
//每天，直到所有任务完成，你必须执行以下操作之一：
//完成 tasks 中的下一个任务，或者
//休息一天。
//返回完成所有任务所需的最小天数。
//思路：hashtable 用Dictionary来存task和应当完成当前任务的days
//如果没有，那么就存入当前时间，如果有，且当前日期task的days+space大于现在的day说明需要等待；
//更新day；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public long TaskSchedulerII(int[] tasks, int space)
        {
            Dictionary<int, long> map = new Dictionary<int, long>();
            long days = 0;

            for (int i = 0; i < tasks.Length; i++)
            {
                days++;

                if (!map.ContainsKey(tasks[i]))
                {
                    map.Add(tasks[i], days);
                }
                else
                {                    
                    if (map[tasks[i]] + space >= days)
                    {
                        days = map[tasks[i]] + space + 1;
                    }
                    map[tasks[i]] = days;
                }
            }

            return days;
        }