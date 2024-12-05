//Leetcode 918. Maximum Sum Circular Subarray med
//题目：给定一个长度为 
//n 的循环数组 nums，要求返回一个非空子数组的最大可能和。
//循环数组：数组末尾和开头是相连的。例如，nums[-1] 等效于 nums[n - 1]，nums[n] 等效于 nums[0]。
//子数组：数组的连续部分（从 nums[i] 到 nums[j]，包括两端）。
//解题关键点
//数组是循环的，因此有两种可能的最大子数组和：
//最大子数组位于原数组的中间部分（标准 Kadane 算法可以解决）。
//最大子数组跨越数组末尾和开头部分（需要特定处理）。
//如果考虑跨越的部分，问题可以转换为：
//最大和等于数组总和 - 最小子数组和。
//思路: 前缀和：totalSum：整个数组的元素和，用于计算跨越情况的最大子数组和。
//currentMax 和 maxSum：分别表示当前最大子连续数组和及全局最大子连续数组和。
//currentMax 是动态更新的，每次将当前元素加入子数组后，取当前子数组的最大值。
//maxSum 记录当前遍历到的最大子数组和。
//currentMin 和 minSum：分别表示当前最小子数组和及全局最小子数组和。
//与最大子数组类似，但这里关注的是最小值。
//特殊情况：如果 maxSum 为负，说明数组中所有数字都为负数，此时最大子数组和就是数组中的最大元素。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MaxSubarraySumCircular(int[] nums)
        {
            int totalSum = 0;
            int maxSum = int.MinValue;
            int currentMax = 0;
            int minSum = int.MaxValue;
            int currentMin = 0;

            foreach (int num in nums)
            {
                totalSum += num;
                currentMax = Math.Max(currentMax + num, num);
                maxSum = Math.Max(maxSum, currentMax);
                currentMin = Math.Min(currentMin + num, num);
                minSum = Math.Min(minSum, currentMin);
            }

            //如果 maxSum 为负，说明数组中所有数字都为负数，此时最大子数组和就是数组中的最大元素
            if (maxSum < 0)
            {
                return maxSum;
            }

            //如果有可能的循环数组，则计算 totalSum - minSum 并取最大值。
            return Math.Max(maxSum, totalSum - minSum);
        }