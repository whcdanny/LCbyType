1599. Maximum Profit of Operating a Centennial Wheel
//C#		
		public int minOperationsMaxProfit(int[] customers, int boardingCost, int runningCost)
        {
            int n = customers.Length;
            int res = -1, maxProfit = 0;
            int gain = 0;
            int wait = 0;
            int board = 0;
            int round = 1;

            while (round <= n || wait > 0)
            {
                wait = round > n ? wait : wait + customers[round - 1];

                // boarding
                board = Math.Min(wait, 4);
                gain += board * boardingCost;
                wait -= board;

                int profit = gain - round * runningCost;
                if (profit > maxProfit)
                {
                    maxProfit = profit;
                    res = round;
                }

                round++;
            }

            return res;
        }