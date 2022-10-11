1492. The kth Factor of n
//C#
		public int KthFactor(int n, int k)
        {
            for (int d = 1; d <= n / 2; ++d)
                if (n % d == 0 && --k == 0)
                    return d;
            return k == 1 ? n : -1;
        }