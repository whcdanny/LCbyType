303. Range Sum Query - Immutable		
//C#		
		public class NumArray
        {

            int[] temp;
            public NumArray(int[] nums)
            {
                temp = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    temp[i] = i == 0 ? nums[0] : temp[i - 1] + nums[i];
                }
            }

            public int SumRange(int left, int right)
            {
                if (left < 0 || right > temp.Length)
                {
                    return 0;
                }
                if (left == 0)
                {
                    return temp[right];
                }
                else
                {
                    return temp[right] - temp[left - 1];
                }
            }
        }