2064. Minimized Maximum of Products Distributed to Any Store
//C#		
		public int minimizedMaximum(int n, int[] quantities)
        {
            int left = 1, right = int.MinValue;
            foreach (int q in quantities)
            {
                right = Math.Max(right, q);
            }
            while (left < right)
            {
                int mid = left + (right - left) / 2;//期望值
                if (isPossible(mid, quantities, n))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return left;
        }

        public bool isPossible(int mid, int[] quantities, int stores)
        {
            int count = 0;
            foreach (int q in quantities)
            {
                count += q / mid;
                count += q % mid == 0 ? 0 : 1;
            }
            return count <= stores;
        }