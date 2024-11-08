//Leetcode 3194. Minimum Average of Smallest and Largest Elements ez
//题目：给定一个初始为空的浮点数数组 averages，以及一个整数数组 nums，其中 nums 的长度为偶数 n。要求我们对 nums 重复执行 n / 2 次以下操作：
//从 nums 中移除最小元素 minElement 和最大元素 maxElement。
//将(minElement + maxElement) / 2 的结果添加到 averages 中。
//最后，返回 averages 中的最小值。
//思路: 先排序，然后头尾找avge，然后跟min比较找出最小的
//时间复杂度：O(n)
//空间复杂度：O(1)
        public double MinimumAverage(int[] nums)
        {
            // 先对数组进行排序
            Array.Sort(nums);
            int n = nums.Length;
            double min = int.MaxValue;
            for (int i = 0; i < n / 2; i++)
            {
                // 计算平均值
                double average = (nums[i] + nums[n - 1 - i]) / 2.0;
                if (average < min) 
                    min = average;
            }
            return min;
        }