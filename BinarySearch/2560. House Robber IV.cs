//Leetcode 2560. House Robber IV med
//题意：强盗抢劫的变种，要求强盗偷取至少 k 个房屋，而且不能偷相邻的房屋。我们需要找到一种偷取方案，使得强盗的偷取能力最小。
//思路：二分搜索, 通过二分查找来找到最小的金额，能够偷取至少 k 个房屋，尝试降低偷取金额； 偷取能力过低，尝试增加偷取金额        
//时间复杂度:  O(nlogm)
//空间复杂度： O(1)
        public int MinCapability(int[] nums, int k)
        {
            int n = nums.Length;
            if (n == 0)
            {
                return 0;
            }

            int left = nums.Min();// 最小金额的下界
            int right = nums.Max();// 最大金额的上界

            if (k == 1)
            {
                return left;
            }

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int take = 0;

                for (int i = 0; i < n; i++)
                {
                    if (nums[i] <= mid)
                    {
                        take += 1;
                        i++;
                    }
                }
                
                if (take >= k)
                {
                    // 能够偷取至少 k 个房屋，尝试降低偷取金额
                    right = mid - 1;
                }
                else
                {
                    // 偷取能力过低，尝试增加偷取金额
                    left = mid + 1;
                }
            }
           
            return left;
        }