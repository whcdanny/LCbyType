//Leetcode 2932. Maximum Strong Pair XOR I ez
//题意：要求从给定的整数数组 nums 中选择两个整数 x 和 y，使得它们构成一个 strong pair，并且它们的按位异或结果是所有 strong pairs 中的最大值。
//一个 strong pair 满足条件 |x - y| <= min(x, y)。
 //思路：hashtable，从第一个开始一次找到满足条件的，然后找到最大的；Math.Abs(nums[i] - nums[j]) <= Math.Min(nums[i], nums[j])   
//时间复杂度：O(n^2)
//空间复杂度：O(n)
        public int MaximumStrongPairXor(int[] nums)
        {
            int maxor = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (Math.Abs(nums[i] - nums[j]) <= Math.Min(nums[i], nums[j]))
                    {
                        int xor = nums[i] ^ nums[j];
                        if (xor > maxor)
                        {
                            maxor = nums[i] ^ nums[j];
                        }
                    }
                }
            }

            return maxor;
        }
