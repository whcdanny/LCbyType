1137. N-th Tribonacci Number
//C#		
		public int Tribonacci(int n)
        {
            int first = 0, second = 1;
            int third = 1;

            if (n ==0)
                return first;
            if (n == 1)
                return second;
            if (n == 2)
                return third;
            int curr = 0;
            for (int i = 3; i <= n; i++)
            {
                curr = first + second + third;
                first = second;
                second = third;
                third = curr;
            }
            return curr;            
        }
		public int Tribonacci(int n)
        {            
            if (n == 0)
            {
                return 1;
            }
            else if (n == 1)
            {
                return 1;
            }
            else if (n == 2)
            {
                return 1;
            }
            return Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
        }