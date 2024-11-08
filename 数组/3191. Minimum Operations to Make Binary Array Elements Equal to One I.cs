//Leetcode 3191. Minimum Operations to Make Binary Array Elements Equal to One I med
//题目：给定一个二进制数组 nums，目标是将数组中的所有元素都变为 1。
//每次可以选择连续的 3 个元素，并翻转它们的值（0 变为 1，1 变为 0）。
//要求找出使所有元素都变成 1 所需的最小操作次数；如果无法实现，则返回 -1。
//思路: 从左到右遍历数组，如果当前元素为 0，就必须选择翻转它及其后面的两个元素。
//通过这种方式，确保在当前位置将 0 翻转为 1，以达到将所有元素变成 1 的目的。
//翻转操作：
//遍历数组时，遇到 0 时，将当前位置和其后两个元素（如果存在）翻转，并计数一次操作。
//如果剩余元素不足三个（例如末尾的两个元素为 0 且没有足够的元素翻转），那么就无法实现目标，返回 -1。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinOperations(int[] nums)
        {
            int n = nums.Length;
            int operations = 0;

            for (int i = 0; i <= n - 3; i++)
            {
                if (nums[i] == 0)
                {
                    // 翻转当前位置和其后两个位置的元素
                    nums[i] ^= 1;
                    nums[i + 1] ^= 1;
                    nums[i + 2] ^= 1;
                    operations++;
                }
            }

            // 检查剩余的元素是否全部为 1
            for (int i = n - 3; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    return -1;
                }
            }

            return operations;
        }