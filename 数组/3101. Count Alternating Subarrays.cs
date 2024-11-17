//Leetcode 3101. Count Alternating Subarrays med
//题目：给定一个二进制数组 nums，我们定义一个 交替子数组 为一个子数组，其中相邻的两个元素没有相同的值。
//例如，子数组 [0, 1, 0, 1] 是交替的，而 [0, 1, 1, 0] 不是。
//返回数组中所有交替子数组的数量。
//思路: 给一个 start，然后就是每个相邻的作比较，找出交替，如果相同就更新start
//这里的关键是每一个交替数组的个数是i - start + 1;
//时间复杂度：O(n)
//空间复杂度：O(1)
        public long CountAlternatingSubarrays(int[] nums)
        {
            //开始时，将 end 初始化为 0，表示所有子数组都可以从第一个元素开始。
            int start = 0;
            long res = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                //当前元素与前一个元素相同，不满足交替条件
                if (nums[i] == nums[i - 1])
                {
                    start = i;
                }
                res += i - start + 1;
            }
            return res;
        }