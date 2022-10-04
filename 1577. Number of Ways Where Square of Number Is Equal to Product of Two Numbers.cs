1577. Number of Ways Where Square of Number Is Equal to Product of Two Numbers
//C#		
		public int NumTriplets(int[] nums1, int[] nums2)
        {
            long result = 0;
            foreach (long num in nums1)
            {
                result += TwoProduct(num * num, nums2);
            }
            foreach (long num in nums2)
            {
                result += TwoProduct(num * num, nums1);
            }
            return (int)result;
        }
        private long TwoProduct(long n, int[] nums)
        {
            var map = new Dictionary<long, long>();
            long count = 0;
            foreach (var num in nums)
            {
                if (n % num == 0)
                {
                    if (map.TryGetValue(n / num, out var result))
                    {
                        count += result;
                    }
                }
                map[num] = map.ContainsKey(num) ? ++map[num] : 1;
            }
            return count;
        }
		
		public int NumTriplets(int[] nums1, int[] nums2)
        {
            var sq1 = new BigInteger[nums1.Length];
            var sq2 = new BigInteger[nums2.Length];

            for (var i = 0; i < nums1.Length; i++)
                sq1[i] = new BigInteger(nums1[i]) * new BigInteger(nums1[i]);

            for (var i = 0; i < nums2.Length; i++)
                sq2[i] = new BigInteger(nums2[i]) * new BigInteger(nums2[i]);

            return Calc(sq1, nums2) + Calc(sq2, nums1);
        }

        private int Calc(BigInteger[] sq, int[] nums)
        {
            var ans = 0;
            var map = new Dictionary<BigInteger, int>();

            foreach (var s in sq)
            {
                var local = 0;
                if (map.ContainsKey(s))
                {
                    ans += map[s];
                    continue;
                }

                for (var i = 0; i < nums.Length; i++)
                {
                    if (s % nums[i] != 0)
                        continue;

                    var n = s / nums[i];

                    for (var j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] == n)
                            local++;
                    }
                }

                map[s] = local;
                ans += local;
            }

            return ans;
        }