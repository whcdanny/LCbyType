//Leetcode 1300. Sum of Mutated Array Closest to Target med
//题意：给定一个整数数组 arr 和一个目标值 target，找到一个非负整数 num，使得将 arr 中所有大于 num 的元素替换为 num 后，数组的和最接近于目标值 target。
//思路：二分法: 二分搜索中，计算数组arr中所有元素与当前mid的差值之和diff；如果diff与目标值target相等，说明已经找到了一个完美的调整值；如果diff小于目标值target，说明当前mid可能是一个较小的调整值，将其更新为结果result，并将left更新为mid + 1；如果diff大于目标值target，说明当前mid可能是一个较大的调整值，我们将right更新为mid - 1。
//时间复杂度: n 是数组的长度, O(logn)
//空间复杂度： O(1)    
        public int FindBestValue(int[] arr, int target)
        {
            int left = 0;
            int right = arr.Max();
            int result = 0;
            int minDiff = int.MaxValue;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int sum = CalculateSum(arr, mid);

                if (sum == target)
                {
                    return mid;
                }
                else if (sum < target)
                {
                    if (target - sum < minDiff)
                    {
                        minDiff = target - sum;
                        result = mid;
                    }
                    left = mid + 1;
                }
                else
                {
                    if (sum - target < minDiff)
                    {
                        minDiff = sum - target;
                        result = mid;
                    }
                    right = mid - 1;
                }
            }

            if (CalculateSum(arr, result) <= target)
            {
                return result;
            }
            else
            {
                int sum1 = CalculateSum(arr, result);
                int sum2 = CalculateSum(arr, result + 1);
                return Math.Abs(sum1 - target) < Math.Abs(sum2 - target) ? result : result + 1;
            }
        }

        private int CalculateSum(int[] arr, int value)
        {
            int sum = 0;
            foreach (int num in arr)
            {
                sum += Math.Min(num, value);
            }
            return sum;
        }