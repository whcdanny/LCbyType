//Leetcode 26. Remove Duplicate Numbers in Array ez
//题意：给定一个排序后的数组，删除重复的元素，使得每个元素只出现一次，并返回新的长度。不要使用额外的数组空间，必须在 O(1) 额外空间复杂度内完成。
//思路：双指针方法: 其实是快慢针，指针 left 和 right，初始时都指向数组的开头。遍历数组，当发现 nums[left] != nums[right] 时，说明找到了一个新的不重复元素，将其放到 left+1 的位置，同时将 left 右移一位。
//时间复杂度:  n 是数组的长度, O(n)
//空间复杂度： O(1)
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0) return 0;

            int left = 0;

            for (int right = 1; right < nums.Length; right++)
            {
                if (nums[left] != nums[right])
                {
                    left++;
                    nums[left] = nums[right];
                }
            }

            return left + 1;
        }
        public int RemoveDuplicates_p(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int slow = 0, fast = 0;
            while (fast < nums.Length)
            {
                if (nums[fast] != nums[slow])
                {
                    slow++;

                    nums[slow] = nums[fast];
                }
                fast++;
            }

            return slow + 1;
        }