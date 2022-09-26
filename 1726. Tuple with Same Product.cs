1726. Tuple with Same Product
//C#
		public int TupleSameProduct(int[] nums)
        {
            var result = 0;
            var dic = new Dictionary<long, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    var prod = nums[i] * nums[j];
                    if (dic.ContainsKey(prod))
                    {
                        result += dic[prod] * 8;
                    }
                    dic.TryAdd(prod, 0);
                    dic[prod]++;
                }
            }
            return result;
        }