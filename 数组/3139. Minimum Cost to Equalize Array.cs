//Leetcode 3139. Minimum Cost to Equalize Array hard
//题目：给定一个整数数组 nums 和两个整数 cost1 和 cost2，可以执行以下两种操作任意次：
//选择 nums 中的一个索引 
//i，将 nums[i] 增加 1，并花费 cost1。
//选择 nums 中的两个不同索引 
//i,j，将 nums[i] 和 nums[j] 同时增加 1，并花费 cost2。
//要求计算将数组中的所有元素变为相等所需的最小成本。由于答案可能非常大，返回结果对 取模的值。
//思路: 对数组进行排序，找出最大元素。
//如果数组只有一个或两个元素，则返回根据它们与给定成本之间的差异计算的成本。
//如果 cost2 大于或等于 cost1 的两倍，则最好将每个元素增加到数组中的最大元素。
//计算最大元素与数组中每个元素之间的差异总和subSun，并找出最大差异maxDis。
//根据这个差异，计算各种情况下的最小成本：
//如果最大差异小于或等于总和的一半，那么最佳策略是将每个元素增加到最大元素。
//如果最大差异大于总和的一半，那么我们需要找到一个额外的数字来使总和均匀，并尝试不同的数字来最小化成本。
//找最小成本的时候
//当 sum 为奇数时，先用 cost1 处理一个差距，确保 sum 为偶数
//当 max 小于或等于 sum - max 时，意味着可以通过成对调整（即使用 cost2）来平衡所有差距。
//如果 max 大于 sum - max，意味着最大的差距 max 已经超过了其他差距之和。
//这种情况下，只靠成对调整不足以平衡所有差距，还需要单独增加一些元素
//超过了其他差距的部分，需要通过 cost1 单独调整。
//剩下的差距 sum - max 可以通过成对调整 cost2 来处理
//时间复杂度：O(n log n)
//空间复杂度：O(1)
        public int MinCostToEqualizeArray(int[] nums, int cost1, int cost2)
        {
            int MOD = (int)1e9 + 7;
            Array.Sort(nums);
            int n = nums.Length;
            if (n == 1) return 0;
            if (n == 2) return (int)((long)(nums[1] - nums[0]) * cost1 % MOD);
            if (cost2 >= cost1 * 2)
            {
                long res = 0;
                foreach (int num in nums)
                {
                    res = (res + (long)(nums[n - 1] - num) * cost1) % MOD;
                }
                return (int)res;
            }

            long subSum = 0;//每个元素提升到最大元素 nums[n - 1] 所需的总成本
            long maxDis = 0;//里面相邻两个数最大差值
            foreach (int num in nums)
            {
                subSum += nums[n - 1] - num;
                maxDis = Math.Max(maxDis, nums[n - 1] - num);
            }

            long result = long.MaxValue;
            //最大值附近尝试不同的目标值 k
            //意思是让现在nums中最大值nums[n-1]也需要cost，也就是达到的目标值比nums[n-1]最大值还要大，原始有可能cost1太大；
            for (int k = nums[n - 1]; k <= nums[n - 1] + 2; k++)
            {
                result = Math.Min(result, MinCost(subSum + (k - nums[n - 1]) * n, maxDis + (k - nums[n - 1]), cost1, cost2));
            }
            //如果最大差异小于或等于总和的一半，那么最佳策略是将每个元素增加到最大元素。
            //如果最大差异大于总和的一半，那么我们需要找到一个额外的数字来使总和均匀，并尝试不同的数字来最小化成本。
            if (maxDis > subSum - maxDis)
            {
                //相当于多出来的值，平分给剩下的值，让subSum和maxDis都相对应增加
                for (int k = (int)((2 * maxDis - subSum) / (n - 2)); k <= (int)((2 * maxDis - subSum) / (n - 2)) + 2; k++)
                {
                    result = Math.Min(result, MinCost(subSum + k * n, maxDis + k, cost1, cost2));
                }
            }

            return (int)(result % MOD);
        }

        private long MinCost(long sum, long max, int cost1, int cost2)
        {
            long result = 0;
            //当 sum 为奇数时，先用 cost1 处理一个差距，确保 sum 为偶数
            if (sum % 2 == 1)
            {
                result += cost1;
                max--;
                sum--;
            }
            //当 max 小于或等于 sum - max 时，意味着可以通过成对调整（即使用 cost2）来平衡所有差距。
            if (max <= sum - max)
            {
                result = (result + sum / 2 * cost2);
                return result;
            }
            //如果 max 大于 sum - max，意味着最大的差距 max 已经超过了其他差距之和。
            //这种情况下，只靠成对调整不足以平衡所有差距，还需要单独增加一些元素
            result = (result + (max - (sum - max)) * cost1);//超过了其他差距的部分，需要通过 cost1 单独调整。
            result = (result + (sum - max) * cost2);//剩下的差距 sum - max 可以通过成对调整 cost2 来处理
            return result;
        }