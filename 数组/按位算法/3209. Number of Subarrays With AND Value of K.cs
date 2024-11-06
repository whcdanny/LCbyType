//Leetcode 3209. Number of Subarrays With AND Value of K hard
//题目：给定一个整数数组 nums 和一个整数 k，要求返回数组中 子数组 的数量，使得该子数组中所有元素的 按位与 结果等于 k。
//思路: 看code
//时间复杂度：O(rows * cols)
//空间复杂度：O(rows * cols)
        public long CountSubarrays(int[] nums, int k)
        {
            //为按位与值恰好等于 k 的子数组数量
            return atLeastK(nums, k) - atLeastK(nums, k + 1);
        }
        //算按位与值至少为 k 的子数组数量，并使用滑动窗口方法来优化子数组的统计
        public long atLeastK(int[] nums, int k)
        {
            long ans = 0;
            //左边界和右边界
            int i = 0, j = 0, n = nums.Length;
            //记录当前窗口中所有元素的按位与情况
            int[] bits = new int[32];
            //外层 while 循环逐步扩展 j 指针，遍历数组 nums。
            //每当 nums[j] 被包含进窗口时，更新 bits 数组中相应的位的计数。
            while (j < n)
            {
                for (int x = 0; x < 32; x++)
                {
                    if ((nums[j] >> x) % 2 == 1)
                    {
                        bits[x]++;
                    }
                }
                //内层 while 循环移动左边界 i，以确保当前窗口满足 AndVal(bits, j - i + 1) >= k。
                //一旦窗口中的按位与值小于 k，调整 i 来缩小窗口。
                while (j - i + 1 > 0 && AndVal(bits, j - i + 1) < k)
                {
                    for (int x = 0; x < 32; x++)
                    {
                        if ((nums[i] >> x) % 2 == 1)
                        {
                            bits[x]--;
                        }
                    }
                    i++;
                }

                j++;
                ans += j - i + 1;
            }

            return ans;
        }
        //当前窗口内所有元素的按位与值
        public long AndVal(int[] temp, int len)
        {
            long ans = 0;
            for (int i = 0; i < 32; i++)
            {
                //窗口中的所有元素在此位上均为 1
                if (temp[i] == len)
                {
                    ans |= (1 << i);
                }
            }
            return ans;
        }