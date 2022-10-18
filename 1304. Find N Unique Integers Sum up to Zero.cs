1304. Find N Unique Integers Sum up to Zero
//C#
		public int[] sumZero(int n)
        {
            int[] result = new int[n];

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    result[i] = i + 1;
                }
                else
                {
                    result[i] = -i;
                }
            }
            if (n % 2 != 0)
            {
                result[n - 1] = 0;
            }
            return result;
        }