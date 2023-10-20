//Leetcode 283. Move Zeroes ez
//题意：将一个数组中的所有零元素移动到数组的末尾，同时保持非零元素的相对顺序不变。
//思路：双指针方法: 使用两个指针 left 和 right，初始时都指向数组的开头。
//时间复杂度:  n 是数组的长度, O(n)
//空间复杂度： O(1)
        public void MoveZeroes(int[] nums)
        {
            int left = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] != 0)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;
                    left++;
                }
            }
        }