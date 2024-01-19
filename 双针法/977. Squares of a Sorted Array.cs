//Leetcode 977. Squares of a Sorted Array ez
//题意：给定一个非递减顺序排列的整数数组 nums，返回一个按非递减顺序排列的每个数字的平方数组。数组中有可能有负数；
//思路：双指针，化左指针 left 为 0，右指针 right 为数组的最后一个元素的下标 nums.Length - 1。
//创建一个结果数组 result，用于存放平方值。
//使用一个循环，从数组的最后一个元素开始向前遍历，比较左右指针指向的元素的平方值的大小，将较大的平方值添加到结果数组的末尾。
//时间复杂度：O(n)，其中 n 是数组的长度
//空间复杂度：O(1)
        public int[] SortedSquares(int[] nums)
        {
            int left = 0, right = nums.Length - 1;
            int[] result = new int[nums.Length];
            int index = nums.Length - 1;

            while (left <= right)
            {
                int leftSquare = nums[left] * nums[left];
                int rightSquare = nums[right] * nums[right];

                if (leftSquare > rightSquare)
                {
                    result[index--] = leftSquare;
                    left++;
                }
                else
                {
                    result[index--] = rightSquare;
                    right--;
                }
            }

            return result;
        }