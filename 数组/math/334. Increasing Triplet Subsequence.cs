//Leetcode 334. Increasing Triplet Subsequence med
//题目：给定一个整数数组 nums，如果存在满足以下条件的三元组索引 (i, j, k)，返回 true，否则返回 false：       
//i<j<k       
//nums[i]<nums[j]<nums[k]
//思路: 定义两个变量 first 和 second，分别表示递增三元组中的第一个和第二个数字：
//初始值设为最大值。
//在遍历数组时更新这两个变量。
//如果当前数字大于 second，说明找到了递增三元组
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool IncreasingTriplet(int[] nums)
        {
            int first = int.MaxValue;
            int second = int.MaxValue;

            foreach (int num in nums)
            {
                if (num <= first)
                {
                    first = num; // 更新第一个数字
                }
                else if (num <= second)
                {
                    second = num; // 更新第二个数字
                }
                else
                {
                    // 如果当前数字大于 second，说明找到了递增三元组
                    return true;
                }
            }

            return false; // 遍历结束未找到递增三元组
        }