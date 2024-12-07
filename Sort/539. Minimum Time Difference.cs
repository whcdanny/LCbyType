//539. Minimum Time Difference med
//题目：给定一个24小时制时钟时间点列表，每个时间点的格式是 "HH:MM"，
//请返回列表中任意两个时间点之间的最小时间差，单位为分钟。
//思路：排序List，先将所有时间以分钟为计算，然后排序
//这里注意00：00和24：00，也就是最小0min和最多24*60mins
//所以我们需要比较list中最大到24*60mins中距离和最小到24*60之间的距离是否小于最小：
//(24*60 - times[times.Count - 1]) + times[0]
//时间复杂度:  O(nlogn)
//空间复杂度： O(n)
        public int FindMinDifference(IList<string> timePoints)
        {
            List<int> times = new List<int>();
            foreach(var s in timePoints)
            {
                string[] ss = s.Split(':');
                int hour = int.Parse(ss[0]);
                int min = int.Parse(ss[1]);
                times.Add(hour * 60 + min);
            }
            times.Sort();
            int minDiff = int.MaxValue;
            for (int i = 1; i < times.Count; i++)
            {
                minDiff = Math.Min(minDiff, times[i] - times[i - 1]);
            }
            minDiff = Math.Min(minDiff, (24*60 - times[times.Count - 1]) + times[0]);

            return minDiff;
        }