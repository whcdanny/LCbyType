//Leetcode 313. Super Ugly Number med
//题目：超级丑数是一个正整数，其所有的质因子都属于给定的质数数组 primes。
//现在给定一个整数 n 和一个整数数组 primes，要求返回第 n 个超级丑数。
//注意：超级丑数是从 1 开始的，例如第 1 个超级丑数是 1。
//保证第n 个超级丑数可以用 32 位有符号整数表示。
//思路: 动态规划 
//定义一个数组dp[i] 表示第i个超级丑数
//初始化 dp[0] = 1，因为第 1 个超级丑数是 1。
//然后int[] times 表示当前每个质数对应的超级丑数索引
//一开始都是dp[0]=1,由于primes的数字从小到大，这样
//long[] curPrime是一个每一次当前的prime队列，这样可以找出每次的最小值
//minVal = Math.Min(minVal, curPrimes[j])找出当前最小值
//然后更新这个最小值对应的curPrimes[j]
//更新times[j]++;curPrimes[j] = (long) primes[j] * uglyNumbers[times[j]];        
//时间复杂度：O(n*m)
//空间复杂度：O(n+m)
        public int NthSuperUglyNumber(int n, int[] primes)
        {            
            int[] uglyNumbers = new int[n];
            uglyNumbers[0]= 1;
            int m = primes.Length;
            int[] times = new int[m];           
            long[] curPrimes = new long[m];
            for(int i = 0; i < m; i++)
            {
                curPrimes[i] = primes[i];
            }
            for(int i = 1; i < n; i++)
            {
                long minVal = long.MaxValue;
                for(int j = 0; j < m; j++)
                {
                    minVal = Math.Min(minVal, curPrimes[j]);
                }
                uglyNumbers[i] = (int)minVal;
                for(int j = 0; j < m; j++)
                {
                    if (curPrimes[j] == minVal)
                    {
                        times[j]++;
                        curPrimes[j] = (long)primes[j] * uglyNumbers[times[j]];
                    }
                }
            }
            return uglyNumbers[n - 1];
        }