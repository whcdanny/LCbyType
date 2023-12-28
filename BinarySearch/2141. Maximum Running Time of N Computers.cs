//Leetcode 2141. Maximum Running Time of N Computers hard
//题意：题目描述有 n 台计算机，每台计算机需要使用电池供电，给定一个整数 n 和一个长度为 n 的数组 batteries，其中第 i 个电池 batteries[i] 表示第 i 台计算机能运行的时间（单位：分钟）。目标是通过合理调配电池，使得所有 n 台计算机能够同时运行，求最长的运行时间。
//可以在初始时将每台计算机插入一块电池，然后随时将电池从一台计算机取下并插入另一台计算机。电池不可充电。
//要求返回最长的同时运行时间。
//思路：二分搜索：由于需要最大化同时运行时间，可以通过二分搜索来找到最大值。在二分搜索的每一步中，假设当前时间为 mid，检查是否存在一种分配方案，使得所有计算机在时间 mid 内都可以运行。
//如果存在这样的方案，说明 mid 可以更大，因此在右半边搜索；否则，在左半边搜索。
//时间复杂度:二分搜索的时间复杂度为 O(logH)，其中 H 表示 high 和 low 之间的距离。 判断是否存在分配方案的时间复杂度为 O(n)。 O(n * logH)
//空间复杂度：O(1)
        public long MaxRunTime(int n, int[] batteries)
        {
            long left = 0, right = batteries.Select(x => (long)x).Sum() / n; ;
            while (left < right)
            {
                long mid = right - (right - left) / 2;
                if (checkOk_MaxRunTime(mid, n, batteries))
                {
                    left = mid;
                }
                else
                {
                    right = mid - 1;
                }
            }
            return left;
        }
        //n台电脑跑T时间；所以需要找最小值batteries和time；
        public bool checkOk_MaxRunTime(long time, int n, int[] batteries)
        {
            long res = 0;
            foreach (int battery in batteries)
            {
                res += Math.Min(time, (long)battery);
                if (res >= (long)time * n)
                    return true;
            }
            return false;
        }