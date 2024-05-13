//Leetcode 2871. Split Array Into Maximum Number of Subarrays med
//题意：给出了一个由非负整数组成的数组 nums。
//我们定义子数组 nums[l..r] 的得分（score）为 nums[l] AND nums[l + 1] AND...AND nums[r]，其中 AND 是按位与操作。
//考虑将数组分割成一个或多个子数组，使得满足以下条件：
//数组的每个元素都恰好属于一个子数组。
//子数组的得分之和是尽可能小的。
//要求返回满足以上条件的分割中子数组的最大数量。
//思路：贪婪算法：先考察所有元素的“与和”。
//如果它不为零，那么我们就不分组，这样能保证“与和”最小，并且“组数”只有一个，必然总和最小。
//如果所有元素的“与和”恰为零（已然最小了），为了保证总和不变大，
//我们只能将任务变为拆分为若干个“与和”为0的subarray。
//我们贪心地从前往后尝试每个元素，一旦凑齐“与和”为0，即划分为一组即可。
//时间复杂度: O(n)
//空间复杂度：O(n)
        public int MaxSubarrays(int[] nums)
        {
            int n = nums.Length;
            int res = 0;
            for(int i = 0; i < n; i++)
            {
                int j = i;
                int val = nums[i];
                while (j + 1 < n && val != 0)
                {
                    j++;
                    val &= nums[j];
                }
                if (val == 0)
                    res++;
                i = j;
            }
            return Math.Max(1, res);
        }