//Leetcode 3321. Find X-Sum of All K-Long Subarrays II hard
//题意：给定一个长度为 n 的整数数组 nums，以及两个整数 k 和 x。
//要求计算每个长度为 k 的子数组的 x-和，其中 x-和 的计算方式如下：
//统计子数组中所有元素的出现次数。
//仅保留出现次数最多的前 x 个元素。如果有多个元素的出现次数相同，优先选择值较大的元素。
//计算这些保留元素的和。
//如果子数组中的不同元素数量少于 x，则 x-和 为子数组中所有元素的总和。
//返回一个长度为 n - k + 1 的整数数组 answer，其中 answer[i] 表示子数组 nums[i..i + k - 1] 的 x-和。
//思路：滑动窗口法：这里要注意超时，所以要自建一个class XSortedSet 类用于管理当前窗口中元素的频率及其对应的 x-和
//SortedSet更有效，这里有两个XSortedSet，用于存储当前窗口中的频繁元素，用于存储不在window中的元素。
//滑窗的大小为x，并且当放入新的元素的时候，如果超过k了，就要把i-k的元素，移除，
//window只存最大的x的数字与其频率；然后在每一次添加和移除元素的时候，实时更新，并算出sum
//时间复杂度：每个元素最多只会被处理两次（一次添加，一次移除），SortedSet（添加和移除）都是 O(logm)，整体时间复杂度为 O(nlogm)，其中m是窗口中不同元素的数量。
//空间复杂度：O(m)
        public class XSortedSet
        {
            private SortedSet<(int Count, int Num)> Sorted = new SortedSet<(int Count, int Num)>();
            
            public long XSum { get; private set; }

            public int Count => Sorted.Count;

            public (int Count, int Num) Min => Sorted.Min;

            public (int Count, int Num) Max => Sorted.Max;

            public void Add((int Count, int Num) entry)
            {
                if (Sorted.Add(entry))
                    XSum += 1L * entry.Count * entry.Num;
            }

            public void Remove((int Count, int Num) entry)
            {
                if (Sorted.Remove(entry))
                    XSum -= 1L * entry.Count * entry.Num;
            }
        }
        public long[] FindXSum_1(int[] nums, int k, int x)
        {
            var window = new XSortedSet();
            var outWindow = new XSortedSet();
            var freq = new Dictionary<int, int>();
            var answer = new long[nums.Length - k + 1];

            for (var i = 0; i < nums.Length; i++)
            {
                freq.TryAdd(nums[i], 0);
                ExpandWindow(nums[i]);

                //如果窗口长度已经超过k个，要移除i-k元素
                if (i - k >= 0)
                    ShrinkWindow(nums[i - k]);
                //刚好长度为k或者总长度小于k，那么就算出sum
                if (i - k + 1 >= 0)
                    answer[i - k + 1] = window.XSum;
            }

            return answer;

            void ExpandWindow(int num)
            {
                var rem = (freq[num], num);
                var add = (++freq[num], num);

                outWindow.Remove(rem);
                window.Remove(rem);
                window.Add(add);
                //window只存前x大的数字，所以如果window的size超过x，要移除min
                if (window.Count > x)
                {
                    var entry = window.Min;
                    window.Remove(entry);
                    outWindow.Add(entry);
                }
            }

            void ShrinkWindow(int num)
            {
                var rem = (freq[num], num);
                var add = (--freq[num], num);

                window.Remove(rem);
                outWindow.Remove(rem);
                outWindow.Add(add);
                //window只存前x大的数字，所以如果window的size少于x，要从outwindow中找max
                if (window.Count < x)
                {
                    var entry = outWindow.Max;
                    outWindow.Remove(entry);
                    window.Add(entry);
                }
            }
        }