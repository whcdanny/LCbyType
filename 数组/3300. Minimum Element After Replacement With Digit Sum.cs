//Leetcode 3300. Minimum Element After Replacement With Digit Sum ez
//题目：给定一个整数数组 nums。你需要将 nums 中的每个元素替换为其数字之和。
//返回所有替换后的数组中的最小元素。
//思路：数字之和计算：对于每个数字，将其替换为其各位数字之和。例如，对于 123，其数字之和为 1 + 2 + 3 = 6。
//遍历数组：遍历数组 nums，对每个元素计算其数字之和，并更新最小值。
//时间复杂度：O(n * d)，其中 n 是数组的长度，d 是每个数字的位数
//空间复杂度：O(1) 
        public int MinElement(int[] nums)
        {
            int minElement = int.MaxValue;

            foreach (int num in nums)
            {
                int digitSum = SumOfDigits(num);
                // 更新最小值
                minElement = Math.Min(minElement, digitSum);
            }

            return minElement;
        }
        // 计算数字之和的辅助函数
        private int SumOfDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }