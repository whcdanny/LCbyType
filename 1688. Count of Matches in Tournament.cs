1688. Count of Matches in Tournament
//C#
public int NumberOfMatches(int n)
        {
            int sum = 0;
            while (n >= 2)
            {
                if (n % 2 == 0)
                {
                    n = n / 2;
                    sum += n;
                }
                else
                {
                    n = (n - 1) / 2 + 1;
                    sum += n - 1;
                }                                   
            }
            return sum;
        }