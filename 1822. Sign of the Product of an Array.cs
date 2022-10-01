1822. Sign of the Product of an Array
//C#
		public int ArraySign(int[] nums)
        {
            if (nums.Contains(0))
                return 0;
            int sum = 0;
            foreach(int num in nums)
            {
                if (num < 0)
                    sum += 1;
            }
            if (sum % 2 == 0)
                return 1;
            else
                return -1;            
        }
		public int ArraySign(int[] nums)
        {            
            int ans = 1;
            foreach (int n in nums)
            {
                if (n == 0)
                {
                    return 0;
                }
                ans *= (n > 0) ? 1 : -1;
            }
            return ans;
        }