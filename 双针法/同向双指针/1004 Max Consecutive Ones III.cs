//Leetcode 1004 Max Consecutive Ones III med
//题意：给定一个由 0 和 1 组成的数组 A，可以将最多 K 个 0 替换成 1，找到可以得到的最长连续 1 的个数。
//思路：双指针方法来解决这个问题。使用两个指针 left 和 right 分别指向数组的开头。维护一个变量 zeroCount 来记录当前窗口内的 0 的数量。遍历数组，当 zeroCount > K 时，将 left 右移，同时更新窗口状态，直到窗口内的 0 的数量不超过 K。
//时间复杂度:  n 是字符串的长, O(n)
//空间复杂度： O(1)
        public int LongestOnes(int[] nums, int k)
        {
            int left = 0, right = 0;
            int count = 0;
            int res = 0;
            while (right < nums.Length)
            {
                if (nums[right] == 0)
                {
                    count++;                    
                }
                while (count > k)
                {
                    if (nums[left] == 0)
                        count--;
                    left++;
                }
                res = Math.Max(res, right - left + 1);
                right++;
            }
            return res;
        }