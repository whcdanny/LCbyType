//Leetcode 3134. Find the Median of the Uniqueness Array hard
//题目：给定一个整数数组 nums，我们需要找到其“唯一性数组”的中位数。
//“唯一性数组”定义为 nums 的所有子数组中不同元素个数的数组，且按升序排序。
//具体地，对于每一个子数组 nums[i..j]（其中 0 <= i <= j<nums.length），计算其中不同元素的个数 distinct(nums[i..j])，
//并将其添加到唯一性数组中。最终的唯一性数组按非递减顺序排序。
//返回该唯一性数组的中位数。如果中位数有两个，则返回较小的一个值。
//思路: 二分搜索+滑窗
//先用二分搜索，猜测一个可能含有的个数
//然后用滑窗大小固定k，然后找出有多少个subarray
//然后再回归二分搜索，如果当前的subarray个数*2大或等于totalsbu，说明可能是答案，
//然后再调整high，反之调整low
//时间复杂度：O(n^2 log n)
//空间复杂度：O(n^2)
        public int MedianOfUniquenessArray(int[] nums)
        {
            int n = nums.Length;
            //totalSub 是 nums 中所有可能的子数组数量，总共有 n * (n + 1) / 2 个子数组
            long totalSub = (long)n * (n + 1) / 2;
            HashSet<int> hs = new HashSet<int>(nums);
            int low = 1;
            int high = hs.Count;
            long ans = 0;

            while (low <= high)
            {

                int mid = (low + high) / 2;
                //找出满足k的所有子集个数
                long count = atMostKSub(nums, mid);
                //如果>=总数，说明可能是mid
                if ((count * 2) >= (totalSub))
                {
                    ans = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return Convert.ToInt32(ans);
        }
        public long atMostKSub(int[] nums, int k)
        {
            int start = 0, end = 0;
            Dictionary<int, int> map = new Dictionary<int, int>();
            int n = nums.Length;
            long ans = 0;
            //找出满足k的所有子集个数
            for (end = 0; end < n; end++)
            {
                if (map.ContainsKey(nums[end]))
                {
                    map[nums[end]]++;
                }
                else
                {
                    map.Add(nums[end], 1);
                }

                while (map.Count > k)
                {
                    map[nums[start]]--;
                    if (map[nums[start]] == 0)
                    {
                        map.Remove(nums[start]);
                    }
                    start++;
                }
                ans += end - start + 1;
            }
            return ans;
        }