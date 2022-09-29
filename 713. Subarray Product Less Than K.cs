713. Subarray Product Less Than K
//C#
		public int NumSubarrayProductLessThanK(int[] nums, int k)
        {
            int n = nums.Count();
            int product = 0;
            int res = 0;
            for (int start = 0, end = 0; end < n; end++)
            {
                product *= nums[end];

                while (start < end && product >= k)
                {
                    product /= nums[start++];
                }
                if (product < k)
                {
                    res += 1 + end - start;
                }
            }
            return res;            
        }
		public int NumSubarrayProductLessThanK(int[] nums, int k)
        {            
            int n = nums.Count();
            int count = 0;
            int i, j, mul;

            for (i = 0; i < n; i++)
            {

                // Counter for single element
                if (nums[i] < k)
                    count++;

                mul = nums[i];

                for (j = i + 1; j < n; j++)
                {

                    // Multiple subarray
                    mul = mul * nums[j];

                    // If this multiple is less
                    // than k, then increment
                    if (mul < k)
                        count++;
                    else
                        break;
                }
            }

            return count;
        }