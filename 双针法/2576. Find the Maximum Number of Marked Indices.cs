//Leetcode 2576. Find the Maximum Number of Marked Indices med
//题意：题目要求找出一个整数数组中，通过以下操作最多能标记多少个索引对：
//可以任意多次选择两个不同的未标记索引 i 和 j（i ≠ j），其中 2 * nums[i] <= nums[j]。
//一旦选择了索引对(i, j)，则要标记这两个索引。
//思路：左右针，我们对数组进行排序，先找到中间点，然后left从头， right从这个中间点开始，来检查2 * nums[left] <= nums[right]，
//注：因为是索引对，所以ans+=2；
//时间复杂度: O(n)，其中 n 为数组长度
//空间复杂度：O(1)
        public int MaxNumOfMarkedIndices(int[] nums)
        {
            Array.Sort(nums);

            int n = nums.Length;

            int left = 0, midPoint = (n % 2 == 0) ? n / 2 : n / 2 + 1;

            int right = midPoint;

            int ans = 0;

            while (left < midPoint && right < n)
            {
                if (2 * nums[left] <= nums[right])
                {
                    ans += 2;
                    left++;
                    right++;
                }
                else
                {
                    right++;
                }
            }

            return ans;
        }
