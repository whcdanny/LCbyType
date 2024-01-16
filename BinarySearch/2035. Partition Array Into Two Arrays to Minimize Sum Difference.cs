//Leetcode 2035. Partition Array Into Two Arrays to Minimize Sum Difference hard
//题意：给定一个包含 2 * n 个整数的数组 nums。需要将 nums 划分为两个长度为 n 的数组，以最小化两个数组的和的绝对差。为了划分 nums，将 nums 的每个元素放入两个数组中的一个。
//返回可能的最小绝对差。
//思路：二分搜索法: 先求出总sum，先将nums分为两部分，然后算出每一部分一系列和，选i个的和，比如前半是{1，2}选0个 就是{0} 如果选1个{1，2} 如果选2个{3} 依此类推；
//然后我们希望 x+y=sum-(x+y) 2y = sum-2x y=(sum-2x)/2;这样用二分法找出后半部分 满足条件的y，然后再找合适的min；
//时间复杂度：O(n∗2^n)
//空间复杂度：O(2^n)
        public int MinimumDifference(int[] nums)
        {
            int n = nums.Length;

            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }

            var dict1 = Build(nums, 0, (n - 1) / 2);
            var dict2 = Build(nums, n / 2, n - 1);

            foreach (int key in dict2.Keys)
            {
                dict2[key].Sort();
            }

            int min = int.MaxValue;

            foreach (int count in dict1.Keys)
            {
                foreach (int sum1 in dict1[count])
                {
                    if (dict2[n / 2 - count].Count > 0)
                    {
                        int target = (sum - 2 * sum1) / 2;

                        int start = 0;
                        int end = dict2[n / 2 - count].Count - 1;

                        int mid;
                        while (start + 1 < end)
                        {
                            mid = start + (end - start) / 2;

                            if (dict2[n / 2 - count][mid] <= target)
                            {
                                start = mid;
                            }
                            else
                            {
                                end = mid;
                            }
                        }

                        int sum2 = dict2[n / 2 - count][start];
                        min = Math.Min(min, Math.Abs(2 * (sum1 + sum2) - sum));

                        sum2 = dict2[n / 2 - count][end];
                        min = Math.Min(min, Math.Abs(2 * (sum1 + sum2) - sum));
                    }
                }
            }

            return min;
        }
        //枚举所有子数组，使用位运算来确定是否包含某个元素，计算子数组的和，并将和与组合数量添加到 dict 字典中。
        private IDictionary<int, List<int>> Build(int[] nums, int l, int r)
        {
            int n = r - l + 1;

            var dict = new Dictionary<int, List<int>>();
            for (int i = 0; i <= n; i++)
            {
                dict.Add(i, new List<int>());
            }

            int count;
            int sum;
            for (int mask = 0; mask < 1 << n; mask++)
            {
                count = 0;
                sum = 0;

                for (int i = 0; i < n; i++)
                {
                    if (((mask >> i) & 1) > 0)
                    {
                        count++;
                        sum += nums[l + i];
                    }
                }

                dict[count].Add(sum);
            }

            return dict;
        }