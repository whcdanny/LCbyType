//Leetcode 3151. Special Array I ez
//题目：一个数组被认为是“特殊数组”，当它的每一对相邻元素具有不同的奇偶性。
//也就是说，对于数组中的每对相邻元素，一个是奇数，另一个是偶数。
//给定一个整数数组 nums，判断它是否是特殊数组，如果是则返回 true，否则返回 false。
//思路: 为了检查数组是否满足特殊数组的条件，我们需要验证所有相邻元素的奇偶性是否不同。具体步骤如下：
//遍历数组的每对相邻元素。
//如果某一对相邻元素具有相同的奇偶性，则直接返回 false，因为数组不满足特殊数组的条件。
//如果遍历完所有相邻元素都符合奇偶不同的条件，则返回 true。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public bool IsArraySpecial(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                // 检查相邻元素的奇偶性
                if ((nums[i] % 2) == (nums[i + 1] % 2))
                {
                    return false; // 如果相同，则不是特殊数组
                }
            }
            return true; // 如果所有相邻元素不同奇偶，则是特殊数组
        }