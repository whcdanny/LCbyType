1856. Maximum Subarray Min-Product	
//C#		
		public static int maxSumMinProduct(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int mod = 1_000_000_007;
            int size = nums.Length;
            long maxP = 0;

            Stack<int> stack = new Stack<int>();
            long[] sum = new long[nums.Length];

            for (int i = 0; i <= size; ++i)
            {
                if (i < size)
                {
                    sum[i] = (i == 0) ? nums[i] : sum[i - 1] + nums[i];
                }

                int curNum = (i == size) ? -1 : nums[i];

                while((stack.Count != 0) && (nums[stack.Peek()] >= curNum))
                {
                    int min = stack.Pop();
                    int left = (stack.Count == 0) ? 0 : stack.Peek() + 1;
                    int right = i - 1;

                    long subSum = (left == 0) ? sum[right] : sum[right] - sum[left - 1];
                    maxP = Math.Max(maxP, nums[min] * subSum);
                }
                stack.Push(i);
            }

            return (int)(maxP % mod);
        }