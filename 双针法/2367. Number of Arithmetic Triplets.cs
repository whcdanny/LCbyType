//Leetcode 2367. Number of Arithmetic Triplets ez
//题意：给定一个严格递增的整数数组 nums 和一个正整数 diff。定义一个三元组 (i, j, k) 是算术三元组，如果满足以下条件：
//i<j<k
//nums[j] - nums[i] == diff
//nums[k] - nums[j] == diff
//要求返回唯一算术三元组的数量。
//思路：左右针，两层循环遍历所有可能的三元组 (i, j, k)。对于每个三元组，检查是否满足算术条件。之间找这些数是否存在nums中；
//nums[j] = nums[i] + diff
//nums[k] = nums[j] + diff = nums[i] + 2 * diff
//时间复杂度: O(n)
//空间复杂度：O(1)
        public int ArithmeticTriplets(int[] nums, int diff)
        {
            int ans = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                int j = Array.IndexOf(nums, nums[i] + diff, i);
                if (j == -1)
                    continue;

                int k = Array.IndexOf(nums, nums[i] + 2 * diff, j);
                if (k == -1)
                    continue;

                ans++;
            }

            return ans;
        }