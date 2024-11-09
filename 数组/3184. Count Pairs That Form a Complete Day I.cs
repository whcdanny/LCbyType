//Leetcode 3184. Count Pairs That Form a Complete Day I ez
//题目：给定一个整数数组 hours，其中每个元素表示小时数。
//要求返回 (i, j) 的配对数目，使得 i < j，且 hours[i] + hours[j] 是完整天数（即整除 24 的倍数）。
//完整天数的定义是时间的持续时长为 24 的倍数，例如：1 天是 24 小时，2 天是 48 小时，3 天是 72 小时，依此类推。
//因此，我们需要找到配对(i, j)，使得 hours[i] + hours[j] 能整除 24。
//思路: 两个方法，
//第一个更高效，用Dictionary存每个%24的余数和个数，就是从第一个开始，找hours[i] % 24余数，然后找出(24 - hour) % 24在Dictionary中个数(n)
//第二个更好理解，就是i和i+1然后开始一个一个找，只要满足sum % 24 == 0，res++；(n*n)       
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int CountCompleteDayPairs(int[] hours)
        {
            int counter = 0;
            Dictionary<int, int> dc = new Dictionary<int, int>();
            for (int i = 0; i < hours.Length; i++)
            {
                int hour = hours[i] % 24;
                if (dc.ContainsKey((24 - hour) % 24))
                    counter += dc[(24 - hour) % 24];
                if (!dc.TryAdd(hour, 1))
                    dc[hour]++;
            }
            return counter;
            //int n = hours.Length;
            //int result = 0;
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = i + 1; j < n; j++)
            //    {
            //        int sum = hours[i] + hours[j];
            //        if (sum % 24 == 0) result++;
            //    }
            //}
            //return result;
        }