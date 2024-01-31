//Leetcode 80. Remove Duplicates from Sorted Array II  med
//题意：给定一个按非递减顺序排序的整数数组 nums，要求在原地修改数组，使得每个元素最多出现两次。返回修改后数组的长度。
//思路：双指针，其中 slow 指针指向当前已处理的数组的末尾（最终结果），fast 指针用于遍历整个数组。
//由于每个元素最多出现两次，因此，当 nums[fast] 不等于 nums[slow - 2] 时，说明当前元素与 slow 指针前两个位置的元素不相同，可以加入结果数组。
//否则，当前元素已经出现两次，跳过，fast 指针继续向后移动。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int RemoveDuplicates_80(int[] nums)
        {
            if (nums.Length <= 2)
            {
                return nums.Length;
            }

            int slow = 2; // Slow pointer starts from the third element
            for (int fast = 2; fast < nums.Length; fast++)
            {
                if (nums[fast] != nums[slow - 2])
                {
                    // If the current element is different from the two elements before slow
                    nums[slow] = nums[fast];
                    slow++;
                }
            }

            return slow;
        }