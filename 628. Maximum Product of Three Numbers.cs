628. Maximum Product of Three Numbers
//C#
public int MaximumProduct(int[] nums)
        {
            int size = nums.Length;
            Array.Sort(nums);
            return Math.Max(nums[size - 1] * nums[size - 2] * nums[size - 3], nums[0] * nums[1] * nums[size-1]);            
        }
		
		public int MaximumProduct(int[] nums)
        {
            int size = nums.Length;            
            int maxA = Int32.MinValue,
                maxB = Int32.MinValue,
                maxC = Int32.MinValue;
            int minA = Int32.MaxValue,
                minB = Int32.MaxValue;
            for (int i = 0; i < size; i++)
            {
                if (nums[i] > maxA)
                {
                    maxC = maxB;
                    maxB = maxA;
                    maxA = nums[i];
                }
                else if (nums[i] > maxB)
                {
                    maxC = maxB;
                    maxB = nums[i];
                }
                else if (nums[i] > maxC)
                    maxC = nums[i];
                if (nums[i] < minA)
                {
                    minB = minA;
                    minA = nums[i];
                }
                else if (nums[i] < minB)
                    minB = nums[i];
            }

            return Math.Max(minA * minB * maxA,
                            maxA * maxB * maxC);
        }
		
//Java
public int MaximumProduct(int[] nums)
        {
            int size = nums.length;
            Arrays.Sort(nums);
            return Math.max(nums[size - 1] * nums[size - 2] * nums[size - 3], nums[0] * nums[1] * nums[size-1]);            
        }
		
		public int MaximumProduct(int[] nums)
        {
            int size = nums.length;            
            int maxA = Integer.MIN_VALUE,
                maxB = Integer.MIN_VALUE,
                maxC = Integer.MIN_VALUE;
            int minA = Integer.MAX_VALUE,
                minB = Integer.MAX_VALUE;
            for (int i = 0; i < size; i++)
            {
                if (nums[i] > maxA)
                {
                    maxC = maxB;
                    maxB = maxA;
                    maxA = nums[i];
                }
                else if (nums[i] > maxB)
                {
                    maxC = maxB;
                    maxB = nums[i];
                }
                else if (nums[i] > maxC)
                    maxC = nums[i];
                if (nums[i] < minA)
                {
                    minB = minA;
                    minA = nums[i];
                }
                else if (nums[i] < minB)
                    minB = nums[i];
            }

            return Math.max(minA * minB * maxA,
                            maxA * maxB * maxC);
        }