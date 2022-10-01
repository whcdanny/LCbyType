1567. Maximum Length of Subarray With Positive Product
//C#
		public int GetMaxLen(int[] nums)
        {
            int Pos = 0;
            int Neg = 0;
            int res = 0;
            int n = nums.Length;

            for (int i = 0; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    Pos = Neg = 0;
                }
                else if (nums[i] > 0)
                {
                    Pos += 1;
                    if (Neg != 0)
                    {
                        Neg += 1;
                    }
                    res = Math.Max(res, Pos);
                }
                else
                {
                    int temp = Pos;
                    Pos = Neg;
                    Neg = temp;
                    Neg += 1;
                    if (Pos != 0)
                    {
                        Pos += 1;
                    }
                    res = Math.Max(res, Pos);
                }
            }
            return res;
        }