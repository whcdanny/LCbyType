//Leetcode 1004 Max Consecutive Ones III med
//题意：给定一个由 0 和 1 组成的数组 A，可以将最多 K 个 0 替换成 1，找到可以得到的最长连续 1 的个数。
//思路：双指针方法。使用两个指针 left 和 right 分别指向数组的开头。
//维护一个变量 zeroCount 来记录当前窗口内的 0 的数量。
//遍历数组，当zeroCount<=K的时候，找出最长的长度，
//当 zeroCount > K 时，找到当前长度中最先出现的0的位置，然后将 left 右移到这个0的下一位，这样窗口内的 0 的数量不超过 K。
//时间复杂度:  n 是字符串的长, O(n)
//空间复杂度： O(1)
        public int LongestOnes(int[] nums, int k)
        {            
            int left = 0;
            int right = 0;
            int zeroCount = 0;
            int res = 0;
            while (right <= nums.Length)
            {
                if (nums[right] == 0)
                {
                    zeroCount++;
                }
                while (zeroCount > k)
                {
                    if (nums[left] == 0)
                    {
                        zeroCount--;
                    }
                    left++;
                }
                res = Math.Max(res, right - left + 1);
                right++;
            }
            return res;
        }