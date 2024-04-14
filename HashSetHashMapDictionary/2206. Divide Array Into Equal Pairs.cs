//Leetcode 2206. Divide Array Into Equal Pairs ez
//题意：给定一个包含 2 * n 个整数的数组 nums。
//需要将 nums 分成 n 对，使得：
//每个元素恰好属于一对。
//每一对中的元素相等。
//如果可以将 nums 分成 n 对，则返回 true，否则返回 false。
//思路：hashtable 数组 nums 排序，使得相同的元素相邻。
//遍历排序后的数组，对于每一对相邻的元素，它们可以组成一对。
//如果能够将所有元素都分成一对，则返回 true；否则返回 false。
//时间复杂度：排序为 O(nlogn)，遍历数组为 O(n)， O(nlogn)。
//空间复杂度：O(1)
        public bool DivideArray(int[] nums)
        {
            Array.Sort(nums);
            for (int i = 0; i < nums.Length; i += 2)
            {
                if (nums[i] != nums[i + 1])
                {
                    return false;
                }
            }
            return true;
        }