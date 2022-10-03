1464. Maximum Product of Two Elements in an Array
//C#
		public int MaxProduct(int[] nums)
        {
            Array.Sort(nums);
            return ((nums[nums.Length - 1]-1) * (nums[nums.Length - 2]-1));            
        }
		public int MaxProduct(int[] nums)
        {            
            int max = int.MinValue;
            int secondMax = int.MinValue;

            foreach (int num in nums)
            {
                if (num > max)
                {
                    secondMax = max;
                    max = num;
                }
                else if (num > secondMax) secondMax = num;
            }
            return (max - 1) * (secondMax - 1);
        }