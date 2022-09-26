826. Most Profit Assigning Work
//C#
		public static int maxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {
            //暴力解决
            int solution = 0;
            foreach (int w in worker)
            {
                int max = int.MinValue;
                for (int i = 0; i < difficulty.Length; i++)
                {
                    if (difficulty[i] <= w && profit[i] > max)
                    {
                        max = profit[i];
                    }
                }
                if (max != int.MinValue)
                {
                    solution += max;
                }
            }
        }
		
		public static int maxProfitAssignment(int[] difficulty, int[] profit, int[] worker)
        {            
            int n = difficulty.Length;
            (int, int)[] jobs = new (int, int)[n];
            for (int i = 0; i < n; i++)
            {
                jobs[i] = (difficulty[i], profit[i]);
            }           

            Array.Sort(jobs, (a, b) => a.Item1 - b.Item1);           
            Array.Sort(worker);

            int ans = 0, j = 0, best = 0;
            foreach (int ability in worker)
            {
                while (j < n && ability >= jobs[j].Item1)
                {
                    best = Math.Max(best, jobs[j].Item2);
                    j++;
                }
                ans += best;
            }
            return ans;
        }