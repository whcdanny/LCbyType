//Leetcode 167.Two Sum II - Input Array Is Sorted med
//题意：给定一个已经按非递减顺序排列的整数数组 numbers，从数组中找出两个数使它们的和等于特定目标数 target，返回这两个数的索引
//思路：双指针法来解决这个问题。使用两个指针 left 和 right，分别指向数组的开头和结尾。计算指针所指的两个数的和
//时间复杂度:  n 是字符串的长度, 时间复杂度是 O(n)。
//空间复杂度： O(1)           
        public int[] TwoSumII(int[] numbers, int target)
        {
            int left = 0;
            int right = numbers.Length - 1;

            while (left < right)
            {
                int sum = numbers[left] + numbers[right];
                if (sum == target)
                {
                    // 找到目标值，返回两个数的索引（索引从1开始）
                    return new int[] { left + 1, right + 1 };
                }
                else if (sum < target)
                {
                    // 和小于目标值，左指针右移
                    left++;
                }
                else
                {
                    // 和大于目标值，右指针左移
                    right--;
                }
            }

            return new int[0]; // 如果未找到满足条件的两个数，返回空数组或null
        }