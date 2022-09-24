935. Knight Dialer
//C#		
		public static int KnightDialer(int n)
        {
            long sum = 0;
            int mod = 1000000007;
            long[] firstMove = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            long[] followMove = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            while (n-- > 1)
            {
                followMove[0] = (firstMove[4] + firstMove[6]) % mod;
                followMove[1] = (firstMove[6] + firstMove[8]) % mod;
                followMove[2] = (firstMove[7] + firstMove[9]) % mod;
                followMove[3] = (firstMove[4] + firstMove[8]) % mod;
                followMove[4] = (firstMove[3] + firstMove[9] + firstMove[0]) % mod;
                followMove[5] = 0;
                followMove[6] = (firstMove[1] + firstMove[7] + firstMove[0]) % mod;
                followMove[7] = (firstMove[2] + firstMove[6]) % mod;
                followMove[8] = (firstMove[1] + firstMove[3]) % mod;
                followMove[9] = (firstMove[2] + firstMove[4]) % mod;
                firstMove = (long[])followMove.Clone();
            }
            foreach (long num in firstMove)
            {
                sum += num;
                sum = sum % mod;
            }
            return (int)sum;
        }