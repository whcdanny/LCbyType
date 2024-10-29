//Leetcode 3264. Final Array State After K Multiplication Operations I ez
//题目：给定一个整数数组 nums，一个整数 k，以及一个整数 multiplier。
//你需要对 nums 执行 k 次操作。在每次操作中：
//找到数组中最小的值 x。如果最小值有多个出现，则选择第一个出现的。
//将选中的最小值 x 替换为 x * multiplier。
//返回一个整数数组，表示在执行完所有 k 次操作后的 nums 的最终状态。
//思路: 找到最小值：在每次操作中，遍历数组找到最小值，并记录其索引。
//替换最小值：将找到的最小值替换为 x * multiplier。
//重复操作：重复上述步骤 k 次。
//返回结果：最终返回修改后的数组。
//时间复杂度：O(k * n)，其中 k 是操作次数，n 是数组的长度
//空间复杂度：O(1)
        public int[] GetFinalState(int[] nums, int k, int multiplier) {
            int n = nums.Length;
            for (int i = 0; i < k; i++)
            {
                // 找到数组中最小的值及其索引
                int minIndex = 0;
                for (int j = 1; j < n; j++)
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // 用 x * multiplier 替换最小值
                nums[minIndex] *= multiplier;
            }

            return nums;
        }