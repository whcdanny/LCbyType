1969. Minimum Non-Zero Product of the Array Elements
//C#
		int mod = 1000000007;
        public int minNonZeroProduct(int p)
        {
            long a = (1L << p) - 1L;
            long x = a - 1L;
            long n = x / 2L;
            long pow = Pow(x % mod, n) % mod;
            return (int)((a % mod) * (pow % mod) % mod);
        }

        private long Pow(long x, long n)
        {
            long ans = 1;
            long xTemp = x;
            while (n > 0)
            {
                if (n % 2 == 1)
                {
                    ans = ans * xTemp;
                    ans %= mod;
                }
                xTemp *= xTemp;
                xTemp %= mod;
                n /= 2;
            }
            return ans;
        }