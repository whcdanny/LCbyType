//Leetcode 3255. Find the Power of K-Size Subarrays II med
//题目：给定一个整数数组 nums 和一个正整数 k。数组的“能量”（power）定义如下：
//如果所有元素是连续的并且按升序排列，则能量值为该子数组的最大元素。
//否则，能量值为 -1。
//你的任务是计算数组 nums 所有长度为 k 的子数组的能量值，并返回一个整数数组 results。其中 results[i] 表示 nums[i..(i + k - 1)] 的能量值。
//思路:preSum，前缀和
//因为是比前一个多1，所以做一个前缀和的数组，
//这样再利用k为区间，然后只要比较preSumes[i] + k - 1 和 preSumes[i + k - 1]是否相同就知道是否是递增为1的区间了
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int[] resultsArray1(int[] nums, int k)
        {
            int n = nums.Length;
            int[] preSumes = new int[n];
            preSumes[0] = 0;
            for (int i = 1; i < n; i++)
            {
                preSumes[i] = preSumes[i - 1] + ((nums[i] == (nums[i - 1] + 1)) ? 1 : 0);
            }

            var ans = new int[n - k + 1];
            for (int i = 0; i < n - k + 1; i++)
            {
                if (preSumes[i + k - 1] == (preSumes[i] + k - 1))
                {
                    ans[i] = (nums[i + k - 1]);
                }
                else
                {
                    ans[i] = -1;
                }
            }
            return ans;
        }