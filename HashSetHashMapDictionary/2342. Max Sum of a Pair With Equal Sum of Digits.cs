//Leetcode 2342. Max Sum of a Pair With Equal Sum of Digits med
//题意：给定一个非负整数数组 nums，要求找到两个不同的索引 i 和 j，使得 nums[i] 和 nums[j] 的各个数字之和相等，求这两个数的和的最大值。
//思路：hashtable 用dictionary找的每个位置之和以及出现过的最大值，
//找出每个num的各个位置之和，如果有一样的，那么就找出maxSum，然后跟新当前这个和的最大num，用于下一次计算；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaximumSum(int[] nums)
        {
            Dictionary<int, int> digitSums = new Dictionary<int, int>();

            int maxSum = int.MinValue;
            foreach (int num in nums)
            {
                int digitSum = CalculateDigitSum(num);
                if (digitSums.ContainsKey(digitSum))
                {
                    maxSum = Math.Max(maxSum, num + digitSums[digitSum]);
                    digitSums[digitSum] = Math.Max(digitSums[digitSum], num);
                }
                else
                {
                    digitSums[digitSum] = num;
                }
            }

            return maxSum == int.MinValue ? -1 : maxSum;
        }
        // 计算数字的各位数字之和
        private int CalculateDigitSum(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            return sum;
        }