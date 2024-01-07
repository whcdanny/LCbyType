//Leetcode 1283. Find the Smallest Divisor Given a Threshold med
//题意：给定一个整数数组 nums 和一个整数 threshold，我们需要找到一个最小的正整数 divisor，使得将数组中的每个整数都除以 divisor 后，所有结果的和不超过 threshold。
//思路：使用二分搜索初始化搜索范围，最小值为 1，最大值为数组 nums 中的最大值。
//在每一步的搜索中，计算当前的 mid（中间值），然后将数组中的每个元素除以 mid 得到商，计算这些商的和，判断和是否小于等于 threshold。
//根据比较结果，缩小搜索范围，继续进行二分搜索，直到找到最小的满足条件的正整数 divisor。
//注：因为向上取整
//时间复杂度: O(log(max(nums)))
//空间复杂度：O(1) 
        public int SmallestDivisor(int[] nums, int threshold)
        {
            int left = 1, right = nums.Max();

            while (left < right)
            {
                int mid = left + (right - left) / 2;
                int sum = 0;

                foreach (int num in nums)
                {
                    // 计算商并进行累加                    
                    //sum += (num + mid - 1) / mid;
                    //sum += (int)Math.Ceiling((double)num / mid);
                    if (num % mid == 0)
                        sum += num / mid;
                    else
                        sum += num / mid + 1;
                }

                if (sum > threshold)
                {
                    // 缩小搜索范围
                    left = mid + 1;
                }
                else
                {
                    right = mid;
                }
            }

            return left;
        }