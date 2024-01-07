//Leetcode 1508. Range Sum of Sorted Subarray Sums med
//题意：给定由 n 个正整数组成的数组 nums。计算所有非空连续子数组的和，然后按升序排序，形成一个新的数组，该数组包含 n * (n + 1) / 2 个数字。返回新数组中从索引 left 到索引 right（从 1 开始索引）的数字之和，结果要对 10^9 + 7 取模。
//思路：使用二分搜索，为了解决这个问题，我们需要首先计算出所有非空连续子数组的和，然后进行排序。我们可以通过双重循环计算和并存储在一个列表中，然后对列表进行排序。
//接下来，我们将新数组中从索引 left 到索引 right 的数字相加，最终结果对 10^9 + 7 取模。
//时间复杂度: 计算所有非空连续子数组的和的时间复杂度为 O(n^2)，排序的时间复杂度为 O(n^2 log(n^2))，总体时间复杂度为 O(n^2 log(n^2))。
//空间复杂度：O(n^2)
        public int RangeSum(int[] nums, int n, int left, int right)
        {
            const int MOD = 1000000007;
            List<int> subarraySums = new List<int>();

            // Calculate all non-empty continuous subarray sums
            for (int i = 0; i < n; i++)
            {
                int currentSum = 0;
                for (int j = i; j < n; j++)
                {
                    currentSum += nums[j];
                    subarraySums.Add(currentSum);
                }
            }

            // Sort the subarray sums
            subarraySums.Sort();

            // Calculate the sum of numbers from index left to index right
            int result = 0;
            for (int i = left - 1; i <= right - 1; i++)
            {
                result = (result + subarraySums[i]) % MOD;
            }

            return result;
        }