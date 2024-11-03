//Leetcode 3229. Minimum Operations to Make Array Equal to Target hard
//题目：给定两个相同长度的正整数数组 nums 和 target。
//在一次操作中，可以选择 nums 的任意子数组，将其中的每个元素加 1 或减 1。
//要求返回使得 nums 等于 target 所需的最小操作次数。
//思路: 每个位置三种情况，大于(inc)，等于，小于(dec)
//然后当i后面的如果也是大于，那么就看diff值，
//这个diff也有三种情况，大于，等于，小于，
//如果大于，那么opt+=diff-inc，表示前面加到target，然后这个位置还需要再加；
//小于也是这样，
//注意：当从大于转到小于的时候，inc或者dec要0；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public long MinimumOperations(int[] nums, int[] target)
        {
            var n = nums.Length;
            long incr = 0, decr = 0, ops = 0;

            for (var i = 0; i < n; i++)
            {
                var diff = target[i] - nums[i];

                if (diff > 0)
                {
                    if (incr < diff)
                        ops += diff - incr;
                    incr = diff;
                    decr = 0;
                }
                else if (diff < 0)
                {
                    if (diff < decr)
                        ops += decr - diff;
                    decr = diff;
                    incr = 0;
                }
                else
                {
                    incr = decr = 0;
                }
            }

            return ops;
        }