//Leetcode 3171. Find Subarray With Bitwise OR Closest to K hard
//题目：给定一个整数数组 nums 和一个整数 k，要求找到一个 nums 的子数组 nums[l..r]，
//使得该子数组元素的按位或结果与 k 的绝对差值最小，即 |k - (nums[l] OR nums[l + 1] ... OR nums[r])| 最小。
//返回最小的绝对差值。  
//思路:遍历数组中的每个元素，将每个元素视为子数组的开头。
//对于每个起始元素，扩展子数组以包含后续元素，对子数组元素执行按位与运算。
//计算当前子数组的 AND 值后，使用和 AND 值res之间的最小绝对差进行更新。k        
//时间复杂度：O(30n)
//空间复杂度：O(1)
        public int MinimumDifference(int[] nums, int k)
        {
            int res = int.MaxValue;  // 初始化最小差值为最大整数
            HashSet<int> prev = new HashSet<int>();  // 用于存储前一轮的AND结果集

            foreach (int num in nums)
            {
                HashSet<int> next = new HashSet<int> { num };  // 新的结果集，包含当前数自身
                foreach (int x in prev)
                {
                    next.Add(x & num);  // 将当前数与前一轮的每个结果进行AND运算并加入next
                }
                foreach (int x in next)
                {
                    res = Math.Min(res, Math.Abs(k - x));  // 更新最小差值
                }
                prev = next;  // 更新prev为当前轮的结果集
            }

            return res;  // 返回最小差值
        }