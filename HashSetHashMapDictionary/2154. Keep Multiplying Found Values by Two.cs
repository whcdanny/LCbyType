//Leetcode 2154. Keep Multiplying Found Values by Two ez
//题意：给定一个整数数组 nums 和一个整数 original，表示要在 nums 中搜索的第一个数字。
//然后进行以下步骤：
//如果 original 在 nums 中找到，则将其乘以二（即，设置 original = 2 * original）。
//否则，停止该过程。
//重复此过程，直到找不到该数字为止。
//返回 original 的最终值。
//思路：hashtable 使用哈希表存储数组 nums 中的数字，以便快速查找。
//循环遍历原始数字 original 在数组 nums 中是否存在，若存在则将其乘以二，直到找不到为止。
//时间复杂度：O(n)，其中 n 为数组 nums 的长度
//空间复杂度：O(n)
        public int FindFinalValue(int[] nums, int original)
        {
            HashSet<int> numSet = new HashSet<int>(nums);

            while (numSet.Contains(original))
            {
                original *= 2;
            }

            return original;
        }