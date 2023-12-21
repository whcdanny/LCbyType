//Leetcode 2501. Longest Square Streak in an Array med
//题意：给定一个整数数组 nums。如果一个子序列满足以下条件，则称其为“方形条纹”：
//子序列的长度至少为 2；
//将子序列排序后，每个元素（除第一个元素外）都是前一个数字的平方。
//返回 nums 中最长方形条纹的长度，如果没有方形条纹则返回 -1。
//思路：二分搜索, 先排序，然后根据nums位置来进行二分搜索；只要找到当前val的平方就可以继续，否则就进行下一个；
//注：这里得出位置之后nums[i]跟val*val来做比较；如果下了，left升，大了right降；
//时间复杂度:  O(n∗log(n))
//空间复杂度： O(n)
        public int LongestSquareStreak(int[] nums)
        {
            Array.Sort(nums);
            var rs = -1;
            for (int i = 0; i < nums.Length; i++)
            {
                var steak = GetSteak(i, nums);
                if (steak.Any() && rs < steak.Count)
                {
                    rs = steak.Count;
                }
            }
            return rs;
        }
        private List<int> GetSteak(int index, int[] nums)
        {
            var rs = new List<int> { index };
            long val = nums[index];
            index = FindIndex_BinarySearch(val * (long)val, index, nums);
            //如果找到继续寻找；
            while (index != -1)
            {
                rs.Add(index);
                val = val * val;
                index = FindIndex_BinarySearch(val * val, index, nums);
            }
            return rs.Count > 1 ? rs : new List<int>();
        }
        private int FindIndex_BinarySearch(long val, int index, int[] nums)
        {
            var left = index + 1;
            var right = nums.Length - 1;
            //val已经超过最大的数在nums中
            if (val > nums[right]) return -1;
            //nums最后一个数=val
            if (val == nums[right]) return right;

            while (right - left > 1)
            {
                var mid = left+(right - left) / 2;
                if (val < nums[mid])
                {
                    right = mid;
                }
                else
                {
                    left = mid;
                }
            }
            //找到所需要的数；
            if (val == nums[left]) 
                return left;
            return -1;
        }
        public int LongestSquareStreak1(int[] nums)
        {
            Array.Sort(nums);
            int result = -1;
            int index = 0;
            while (index < nums.Length)
            {
                int cnt = -1;
                int num = nums[index];
                int sqr = num * num;

                int found = Array.BinarySearch(nums, index + 1, nums.Length - 1 - index, sqr);

                if (found > 0)
                {
                    cnt = 2;
                    num = sqr;
                    sqr = num * num;
                    found = Array.BinarySearch(nums, found + 1, nums.Length - 1 - found, sqr);
                    while (found > 0)
                    {
                        cnt++;
                        num = sqr;
                        sqr = num * num;
                        found = Array.BinarySearch(nums, found + 1, nums.Length - 1 - found, sqr);
                    }
                }

                index++;
                result = Math.Max(result, cnt);
            }
            return result;
        }
