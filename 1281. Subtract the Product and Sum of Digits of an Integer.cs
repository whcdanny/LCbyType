1281. Subtract the Product and Sum of Digits of an Integer	
//C#	
	public int SubtractProductAndSum(int n) {
        int sumProduct = 1, sumSum = 0;

            while (n > 0)
            {
                sumProduct *= n % 10;
                sumSum += n % 10;
                n /= 10;
            }

            return (sumProduct - sumSum);
    }