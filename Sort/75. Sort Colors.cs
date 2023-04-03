//75. Sort Colors med
        //给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，并按照红色、白色、蓝色顺序排列。此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。
        //思路：指针的方法来解决这个问题，分别用left、mid和right来表示当前数组中最后一个0的位置、最后一个1的位置和最后一个2的位置。
        public void SortColors(int[] nums)
        {
            int left = 0, mid = 0, right = nums.Length - 1;
            while (mid <= right)
            {
                if (nums[mid] == 0)
                {
                    int temp = nums[mid];
                    nums[mid] = nums[left];
                    nums[left] = temp;
                    left++;
                    mid++;
                }
                else if (nums[mid] == 1)
                {
                    mid++;
                }
                else
                {
                    int temp = nums[mid];
                    nums[mid] = nums[right];
                    nums[right] = temp;
                    right--;
                }
            }
        }