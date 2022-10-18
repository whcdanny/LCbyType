1884. Egg Drop With 2 Eggs and N Floors
//C#
		public int[] dp = new int[1001];
        public int TwoEggDrop(int n)
        {
            if (dp[n] == 0)
            {
                for (int i = 1; i <= n; ++i)
                {
                    dp[n] = Math.Min(dp[n] == 0 ? n : dp[n], 1 + Math.Max(i - 1, twoEggDrop(n - i)));
                }
            }
            return dp[n];
            //return (int)Math.Ceiling((Math.Sqrt(1 + 8 * n) - 1) / 2);
        }
        public int twoEggDrop(int n)
        {
            int eggs = 2;
            return drop(n, eggs, new int[n + 1, eggs + 1]);
        }

        public int drop(int floors, int eggs, int[,] dp)
        {
            if (eggs == 1 || floors <= 1)
                return floors;
            if (dp[floors,eggs] > 0)
                return dp[floors,eggs];
            int min = int.MaxValue;
            for (int f = 1; f <= floors; f++)
                min = Math.Min(min, 1 + Math.Max(drop(f - 1, eggs - 1, dp), drop(floors - f, eggs, dp)));
            dp[floors,eggs] = min;
            return min;
        }