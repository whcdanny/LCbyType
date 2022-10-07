50. Pow(x, n)
//C#	
	public double MyPow(double x, int n) {
        if (n == 0 || x == 1) return 1;
        if (n < 0) return 1 / (x * MyPow (x, -n - 1));
        double ans = 1;
        while (n > 0) {
            if (n % 2 == 1) {
                ans *= x;
            }
            x *= x;
            n >>= 1;
        }
        return ans;
    }