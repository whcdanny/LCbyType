//Leetcode 2602. Minimum Operations to Make All Array Elements Equal med
//题意：给定一个由正整数组成的数组 nums 和一个大小为 m 的整数数组 queries。对于每个查询 queries[i]，要求将数组 nums 中的所有元素都变为 queries[i]，并返回进行操作的最小次数。每次操作可以对数组中的元素进行增加或减少 1 的操作。
//请注意，每次查询后，数组将被重置为其原始状态。
//思路：二分搜索, 先将nums排序，然后找出每个位置的之和，用二分法算出，queries 查找的值，在nums的位置，然后根据index，和每个位置的sum，找出index之前和之后的总和；
//注：算index之前的sum，用的是前面的个数*query-之前的sum，index后面的，先用总sum-index之前的sum，再减去大于index个数*query；
//时间复杂度:  O(m * log n)，其中 m 是查询数，n 是数组长度。
//空间复杂度： O(n)
        public IList<long> MinOperations(int[] nums, int[] queries)
        {
            Array.Sort(nums);
            long[] sums = CalculateSums(nums);
            var rs = new List<long>();
            for (int i = 0; i < queries.Length; i++)
            {
                rs.Add(MinOperations(queries[i], sums, nums));
            }
            return rs;
        }
        private long MinOperations(int query, long[] sums, int[] nums)
        {
            var rs = 0L;
            var index = GetIndex(query, nums);
            //计算小于query的元素总和, 相当于直到小于index-1的位置都乘以query 再减去 现有到index-1的sum；
            if (0 < index) 
                rs += index * (long)query - sums[index - 1];
            //计算大于等于query的元素总和;
            //先把index-1之前的Sum算出，
            long smillRangeIndexSum = 0;
            if(index - 1 >= 0)
            {
                smillRangeIndexSum = sums[index - 1];
            }
            //用整体减去index-1之前的sum，这样算出比index位置之后大的sum，
            long largeRangeIndexSum = sums[sums.Length - 1] - smillRangeIndexSum;
            //由于index之后的nums[index] 都比 query大 所以是减法；
            rs += largeRangeIndexSum - (sums.Length - index) * (long)query;
            return rs;
        }
        private int GetIndex(int query, int[] nums)
        {
            var index0 = 0;
            if (query <= nums[index0]) 
                return index0;
            var index1 = nums.Length - 1;
            if (nums[index1] < query) 
                return index1 + 1;
            while (index1 - index0 > 1)
            {
                var indexMid = (index0 + index1) / 2;
                if (nums[indexMid] < query)
                {
                    index0 = indexMid;
                }
                else
                {
                    index1 = indexMid;
                }
            }
            return index1;
        }
        private long[] CalculateSums(int[] nums)
        {
            var rs = new long[nums.Length];
            rs[0] = nums[0];
            long sum = rs[0];
            for (int i = 1; i < rs.Length; i++)
            {
                rs[i] = rs[i - 1] + (long)nums[i];
            }
            return rs;
        }