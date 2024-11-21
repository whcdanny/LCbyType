//75. Sort Colors med
//题目：给定一个包含红色、白色和蓝色，一共 n 个元素的数组，原地对它们进行排序，使得相同颜色的元素相邻，
//并按照红色、白色、蓝色顺序排列。此题中，我们使用整数 0、 1 和 2 分别表示红色、白色和蓝色。
//思路：
//方法1：指针的方法来解决这个问题，分别用left、mid和right来表示当前数组中最后一个0的位置、最后一个1的位置和最后一个2的位置。
//方法2：先找出0，1，2总个数，然后重新分配nums,index从0开始，找出每个出现频率然后重新插入0，1，2；
//时间复杂度:  O(n)
//空间复杂度： O(1)
        public void SortColors(int[] nums)
        {
            //int left = 0, mid = 0, right = nums.Length - 1;
            //while (mid <= right)
            //{
            //    if (nums[mid] == 0)
            //    {
            //        int temp = nums[mid];
            //        nums[mid] = nums[left];
            //        nums[left] = temp;
            //        left++;
            //        mid++;
            //    }
            //    else if (nums[mid] == 1)
            //    {
            //        mid++;
            //    }
            //    else
            //    {
            //        int temp = nums[mid];
            //        nums[mid] = nums[right];
            //        nums[right] = temp;
            //        right--;
            //    }
            //}
            // Initialize frequency Array.
            int[] freq = new int[3];

            // Counting Frequencies of Colors.
            foreach (int color in nums) 
                freq[color]++;

            // Soring numbers based on their frequiencies.
            int num = 0, index = 0;
            while (num < freq.Length)
            {
                int len = freq[num] + index;
                while (index < len) 
                    nums[index++] = num;
                num++;
            }
        }