//96. Unique Binary Search Trees med
//给一个数，给出所有可能的BST
//思路：根据推理，每一个数都可以时一开始的位置，再确认root之后可以根据子树得到所有可能性即为left * right；由于会出现重复所以用到dp去记录；
		public int[,] memo_NumTrees;
        public int NumTrees(int n)
        {
            memo_NumTrees = new int[n+1, n+1];
            for(int i=0; i<=n; i++)
            {
                for(int j = 0; j <=n; j++)
                {
                    memo_NumTrees[i, j] = 0;
                }
            }
            return count_NumTrees(1, n);
        }
        public int count_NumTrees(int lo, int hi)
        {
            if (lo > hi)
                return 1;
            if (memo_NumTrees[lo, hi] != 0)
                return memo_NumTrees[lo, hi];
            int res = 0;
            for(int mid = lo; mid <= hi; mid++)
            {
                int left = count_NumTrees(lo, mid - 1);
                int right = count_NumTrees(mid + 1, hi);
                res += left * right;
            }
            memo_NumTrees[lo, hi] = res;
            return res;
        }
//暴力算法;		
		public int NumTrees2(int n)
        {
            if (n <= 0)
            {
                return 0;
            }
            int[] result = new int[n + 1];
            result[0] = 1;
            result[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    result[i] += result[j - 1] * result[i - j];
                }
            }
            return result[n];
        }