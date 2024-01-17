//Leetcode 1755. Closest Subsequence Sum hard
//题意：给定整数数组 nums 和整数 goal。
//要求选择 nums 的一个子序列，使其元素的和尽可能接近 goal。也就是说，如果子序列的元素和为 sum，则希望最小化绝对差值 abs(sum - goal)。
//要求返回绝对差值的最小可能值。
//思路：二分搜索法: 先将nums分为两部分 算subset sum of num1和num2，然后算出每一部分一系列和，选i个的和，比如前半是{1，2}选0个 就是{0} 如果选1个{1，2} 如果选2个{3} 依此类推；
//然后我们希望从num1+num2接近goal 所以我们可以排序num2，然后从num1中找一个数，然后用二分法找到mid list2[mid] <= goal - sum1 然后找出min
//时间复杂度：O(n∗2^(n/2))
//空间复杂度：O(2^(n/2))
        public int MinAbsDifference(int[] nums, int goal)
        {
            int n = nums.Length;

            if (n == 1)
            {
                return Math.Min(Math.Abs(goal), Math.Abs(goal - nums[0]));
            }

            var list1 = Build_MinAbsDifference(nums, 0, (n - 1) / 2);
            var list2 = Build_MinAbsDifference(nums, (n + 1) / 2, n - 1);

            list2.Sort();

            int min = int.MaxValue;

            foreach (int sum1 in list1)
            {
                int start = 0;
                int end = list2.Count - 1;

                int mid;
                while (start + 1 < end)
                {
                    mid = start + (end - start) / 2;

                    if (list2[mid] <= goal - sum1)
                    {
                        start = mid;
                    }
                    else
                    {
                        end = mid;
                    }
                }

                int sum2 = list2[start];
                min = Math.Min(min, Math.Abs(sum1 + sum2 - goal));

                sum2 = list2[end];
                min = Math.Min(min, Math.Abs(sum1 + sum2 - goal));
            }

            return min;
        }

        private List<int> Build_MinAbsDifference(int[] nums, int l, int r)
        {
            int n = r - l + 1;

            var list = new List<int>();

            int sum;
            for (int mask = 0; mask < 1 << n; mask++)
            {
                sum = 0;

                for (int i = 0; i < n; i++)
                {
                    if (((mask >> i) & 1) > 0)
                    {
                        sum += nums[l + i];
                    }
                }

                list.Add(sum);
            }

            return list;
        }