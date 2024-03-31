//Leetcode 2808. Minimum Seconds to Equalize a Circular Array med
//题意：给定一个包含 n 个整数的数组 nums。每一秒钟，你需要执行以下操作：
//对于数组中的每个索引 i（0 <= i <= n - 1），将 nums[i] 替换为 nums[i]、nums[(i - 1 + n) % n](前一个) 或 nums[(i + 1) % n](后一个) 中的一个值。
//注意：所有元素同时被替换。
//要求计算使得数组中所有元素相等所需的最小秒数。
//思路：hashtable Dictionary每个数值的相对应的位置，
//对于每个数字假设将所有数改变成当前数字需要多少步；
//找到每个区间，然后找出最大值：ans = Math.Max(ans, (arr[i + 1] - arr[i]) / 2);
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MinimumSeconds(IList<int> nums)
        {
            Dictionary<int, List<int>> map = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (!map.ContainsKey(nums[i]))
                {
                    map[nums[i]] = new List<int>();
                }
                map[nums[i]].Add(i);
            }

            int res = int.MaxValue;
            foreach (var kvp in map)
            {
                List<int> arr = kvp.Value;
                int n = nums.Count;
                //为了找到每个区间，所以对于最后一个区间，给一个结尾位置；
                arr.Add(n + arr[0]);
                int ans = 0;
                for (int i = 0; i < arr.Count - 1; i++)
                {
                    ans = Math.Max(ans, (arr[i + 1] - arr[i]) / 2);
                }
                res = Math.Min(res, ans);
            }
            return res;
        }