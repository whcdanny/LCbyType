//Leetcode 905. Sort Array By Parity ez
//题意：给定一个整数数组 nums，将所有偶数移动到数组的前面，然后是所有奇数。
//返回满足这个条件的任意数组。
//思路：双指针，两个指针 left 和 right 分别指向数组的开头和结尾。
//在循环中，移动 left 指针直到找到一个奇数，移动 right 指针直到找到一个偶数。
//如果 left 小于 right，则交换两个指针指向的元素，然后继续移动指针。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int[] SortArrayByParity(int[] nums)
        {
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                // Move left pointer to find an odd number
                while (left < right && nums[left] % 2 == 0)
                {
                    left++;
                }

                // Move right pointer to find an even number
                while (left < right && nums[right] % 2 == 1)
                {
                    right--;
                }

                // Swap the even and odd numbers
                if (left < right)
                {
                    int temp = nums[left];
                    nums[left] = nums[right];
                    nums[right] = temp;

                    left++;
                    right--;
                }
            }

            return nums;
        }