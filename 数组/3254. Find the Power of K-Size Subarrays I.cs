//Leetcode 3254. Find the Power of K-Size Subarrays I med
//题目：给定一个整数数组 nums 和一个正整数 k。数组的“能量”（power）定义如下：
//如果所有元素是连续的并且按升序排列，则能量值为该子数组的最大元素。
//否则，能量值为 -1。
//你的任务是计算数组 nums 所有长度为 k 的子数组的能量值，并返回一个整数数组 results。其中 results[i] 表示 nums[i..(i + k - 1)] 的能量值。
//思路:从当前i位置开始，找到i+k位置，然后如果下一个数字不是nums[i]+1,那么就不是递增，那么就是-1
//时间复杂度：O(n * k)
//空间复杂度：O(n - k + 1)
        public int[] resultsArray(int[] nums, int k)
        {
            int n = nums.Length;
            int[] res = new int[n - k + 1];

            for (int i = 0; i < (n - k + 1); i++)
            {
                int curr = nums[i];
                for (var j = i + 1; j < (i + k); j++)
                    if (nums[j] != ++curr)
                    {
                        curr = -1;
                        break;
                    }
                res[i] = curr;
            }
            return res;
        }