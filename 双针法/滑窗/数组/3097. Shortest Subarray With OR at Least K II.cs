//Leetcode 3097. Shortest Subarray With OR at Least K II med
//题目：题目描述
//给定一个由非负整数组成的数组 nums 和一个整数 k。
//定义一个子数组为 特殊子数组，如果该子数组中所有元素的按位或(bitwise OR) 值大于等于 k。
//返回 最短特殊子数组的长度，如果不存在这样的子数组，返回 -1
//思路: 滑窗，维护窗口 [l, r]：
//随着 r 的移动（遍历数组），窗口逐步扩大，计算新增元素对按位或的影响。
//如果窗口的按位或值满足条件(>= k)，尝试收缩窗口，从左边移除元素，寻找更短的符合条件的子数组。
//按位统计法：cnt 数组用来统计当前窗口内每个位上的 1 的个数：cnt[i] 表示当前窗口中，第 i 位上有多少个 1。
//按位或的计算基于 cnt：如果 cnt[i] > 0，说明第 i 位上至少有一个 1，那么结果的第 i 位就为 1
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinimumSubarrayLength1(int[] nums, int k)
        {
            var count = new int[32];
            var minLength = int.MaxValue;
            for (int left = 0, right = 0; right < nums.Length; right++)
            {
               
                AddValue(count, nums[right]);
                for (; left <= right && GetValue(count) >= k; left++)
                {
                    minLength = Math.Min(minLength, right - left + 1);
                    //从左侧移除元素以尝试缩小窗口
                    RemoveValue(count, nums[left]);
                }
            }
            return minLength == int.MaxValue ? -1 : minLength;            
        }
        //将元素 n 加入窗口
        public void AddValue(int[] count, int n)
        {
            //将 n 的二进制位拆分，每个位的贡献计入
            for (var bit = 0; n != 0; n >>= 1)
                count[bit++] += n & 1;
        }
        //计算当前窗口的按位或值
        public int GetValue(int[] count)
        {
            var result = 0;
            for (int mask = 1, bit = 0; bit < 32; mask <<= 1, bit++)
            {
                if (count[bit] != 0)
                    result |= mask;
            }
            return result;
        }
        //将元素 n 移出窗口
        public void RemoveValue(int[] count, int n)
        {
            for (var bit = 0; n != 0; n >>= 1)
                count[bit++] -= n & 1;
        }