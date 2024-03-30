//Leetcode 2933. High-Access Employees med
//题意：给定一个二维数组 access_times，其中每行表示一个员工的访问记录，包括员工姓名和访问时间（使用 24 小时制表示）。要求找出访问次数在同一小时内达到三次或更多的高访问员工。
//思路：hashtable，先根据每个员工和其接入时间做一个dictionary，然后将员工和其接入时间进行从小到大排序；
//然后对每个员工，找第i和第i+2这个区间，去判断是否在一共小时之内；
//注：在存时间的时候 分成小时和分钟，在判断是否在一个小时之内，查看是否在同一共小时，如果在肯定对，如果不在一共小时，那么初始时间的分钟一定要大于结束时间的分钟，这样也是一共小时；
//时间复杂度：O(n∗log(n))
//空间复杂度：O(n)
        public IList<string> FindHighAccessEmployees(IList<IList<string>> access_times)
        {
            var dic = CreateDictionary(access_times);
            var res = new List<string>();
            foreach (var item in dic)
            {
                if (IsHighAccess(item.Value)) 
                    res.Add(item.Key);
            }
            return res;
        }
        private bool IsHighAccess(List<int[]> times)
        {
            for (int i = 0; i < times.Count - 2; i++)
            {
                //第一个跟第三个进行算是否在一共小时内；
                if (IsLessThenHour(times[i + 2], times[i])) 
                    return true;
            }
            return false;
        }
        private bool IsLessThenHour(int[] time1, int[] time0)
        {
            //小时数不一样，那么就看分钟是否大于结束分钟，那么就是在一共小时之内；
            if (time0[0] + 1 == time1[0])
            {
                return time0[1] > time1[1];
            }
            if (time0[0] == time1[0])
            {
                return true;
            }
            return false;
        }
        private Dictionary<string, List<int[]>> CreateDictionary(IList<IList<string>> access_times)
        {
            var dic = new Dictionary<string, List<int[]>>();
            for (int i = 0; i < access_times.Count; i++)
            {
                if (!dic.ContainsKey(access_times[i][0])) 
                    dic.Add(access_times[i][0], new List<int[]>());
                dic[access_times[i][0]].Add(ParseTime(access_times[i][1]));
            }
            var res = new Dictionary<string, List<int[]>>();
            foreach (var item in dic)
            {
                //把人和时间从小到大排序；
                var value = item.Value.OrderBy(p => p[0]).ThenBy(p => p[1]).ToList();
                res.Add(item.Key, value);
            }
            return res;
        }
        private int[] ParseTime(string access_time)
        {
            //小时和分钟
            return new[] { Convert.ToInt32(access_time.Substring(0, 2)), Convert.ToInt32(access_time.Substring(2, 2)) };
        }
