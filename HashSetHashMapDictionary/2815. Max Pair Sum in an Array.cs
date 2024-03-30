//Leetcode 2815. Max Pair Sum in an Array ez
//题意：给定一个整数数组 nums，要求找出数组中两个数的最大和，使得这两个数的最大数字相等
//思路：hashtable 遍历数组 nums，使用哈希表记录每个数字对应的最大数字。
//遍历数组 nums，对于每个数字，将其最大数字与当前最大和进行比较，更新最大和。
//如果存在满足条件的两个数，则返回最大和；否则返回 -1。
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int MaxSum(int[] nums)
        {
            Dictionary<int, int> maxDigits = new Dictionary<int, int>();
            int maxSum = -1;

            foreach (int num in nums)
            {
                int digit = GetMaxDigit(num);
                if (!maxDigits.ContainsKey(digit))
                {
                    maxDigits[digit] = -1;
                }

                if (maxDigits[digit] != -1)
                {
                    maxSum = Math.Max(maxSum, maxDigits[digit] + num);
                }

                maxDigits[digit] = Math.Max(maxDigits[digit], num);
            }

            return maxSum;
        }
        private int GetMaxDigit(int num)
        {
            int maxDigit = -1;
            while (num > 0)
            {
                maxDigit = Math.Max(maxDigit, num % 10);
                num /= 10;
            }
            return maxDigit;
        }