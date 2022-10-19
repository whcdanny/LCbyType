2438. Range Product Queries of Powers
//C#
	public static int[] productQueries(int n, int[][] queries)
        {
            List<int> powers = new List<int>();
            int bit = 0;
            while (n != 0)
            {
                if (n % 2 == 1)
                {
                    powers.Add(bit);
                }
                n /= 2;
                ++bit;
            }
            int mod = (int)(1e9 + 7);
            int[] prefix = new int[powers.Count + 1];
            for (int i = 1; i < prefix.Length; ++i)
            {
                prefix[i] = prefix[i - 1] + powers[i - 1];
            }
            int len = queries.Length;
            int[] res = new int[len];
            for (int i = 0; i < len; ++i)
            {
                int start = queries[i][0];
                int end = queries[i][1];
                int cur = prefix[end + 1] - prefix[start];
                long ans = 1l;
                while (cur != 0)
                {
                    ans = (ans << 1) % mod;
                    --cur;
                }
                res[i] = (int)(ans % mod);

            }
            return res;
        }