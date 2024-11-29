//Leetcode 416. Partition Equal Subset Sum med
//题意：给定一个整数数组 nums，请判断是否可以将该数组分成两个子集，
//使得两个子集的元素和相等。如果可以，返回 true；否则返回 false。
//思路：动态规划，dp是否可以通过数组中的某些元素组成和为 j
//因为是两个子集相等，所以找出sum的一半，这是上线
//然后通过sum一半，然后从大到小寻找
//避免在同一轮中重复使用当前的数字 num
//也就是在范围内，num中能组成的和，然后找是否有满足sum一半的
//时间复杂度：O(n×target)
//空间复杂度：O(target) - 需要额外的数组来保存状态。
        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();

            // 如果总和为奇数，直接返回 false
            if (sum % 2 != 0) return false;

            int target = sum / 2;
            bool[] dp = new bool[target + 1];
            dp[0] = true;

            foreach (int num in nums)
            {
                //避免在同一轮中重复使用当前的数字 num
                for (int j = target; j >= num; j--)
                {
                    dp[j] = dp[j] || dp[j - num];
                }
            }

            return dp[target];
        }
        public bool CanPartition_超时(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
                return false;
            int sum = nums.Sum();
            // 如果总和为奇数，直接返回 false
            if (sum % 2 != 0) return false;

            int target = sum / 2;
            int[] dp = new int[2];
            dp[0] = nums[0];
            return testCanPartition(nums, dp, 1);
        }

        private bool testCanPartition(int[] nums, int[] dp, int index)
        {
            bool res = false;
            int val = nums[index];
            if(index == nums.Length-1)
            {
                dp[0] += val;
                if (dp[0] == dp[1])
                    return true;
                dp[0] -= val;
                dp[1] += val;
                if (dp[0] == dp[1])
                    return true;
                dp[1] -= val;
                return false;
            }
            dp[0] += val;
            res = testCanPartition(nums, dp, index+1);
            if (res)
                return true;
            dp[0] -= val;
            dp[1] += val;
            res = testCanPartition(nums, dp, index+1);
            if (res)
                return true;
            dp[1] -= val;
            return res;
        }