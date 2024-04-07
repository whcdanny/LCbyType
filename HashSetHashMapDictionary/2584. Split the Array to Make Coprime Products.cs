//Leetcode 2584. Split the Array to Make Coprime Products hard
//题意：给定一个整数数组 nums，求最小的索引 i，使得数组可以在索引 i 处进行有效的分割。
//有效的分割要求分割点左侧的元素乘积与分割点右侧的元素乘积互质（即最大公约数为1）。
//思路：hashtable, 因为本题里nums的数值都很大，连乘几个数就会溢出，所以我们无法通过直接计算乘积来解题。
//既然是互质，从质因数入手。如果某个质因数p在nums里存在的范围是从[a:b]，那么显然，我们所寻找的前缀切割位置不能在[a:b] 的中间，否则切割前后的两部分就会有公约数p。
//考察每个元素，记录它的所有质因数。然后对每种质因数，我们记录它在nums里出现的范围，只要记录第一次出现和最后一次出现的位置即可，记做一个区间。
//寻找某个前缀的位置，使其不能切割任何一个区间。可以用扫描线（差分数组）来做。
//对于一个区间[a, b]，我们就记录差分diff[a]+=1, diff[b]-=1，这样当我们从前往后的积分值第一次出现零的时候，就表示该处没有落在任何区间里面，即是符合条件的前缀截止位置。
//时间复杂度：O(n))
//空间复杂度：O(n)
        public int FindValidSplit(int[] nums)
        {
            int maxNum = nums.Max();
            List<int> primes = Eratosthenes_1(maxNum);            

            Dictionary<int, Tuple<int, int>> Map = new Dictionary<int, Tuple<int, int>>();

            for (int i = 0; i < nums.Length; i++)
            {
                int x = nums[i];
                foreach (int p in primes)
                {
                    if (x == 1) break;
                    if (p * p > x)
                    {
                        if (!Map.ContainsKey(x))
                            Map[x] = new Tuple<int, int>(i, i);
                        Map[x] = new Tuple<int, int>(Map[x].Item1, i);
                        break;
                    }

                    if (x % p == 0)
                    {
                        if (!Map.ContainsKey(p))
                            Map[p] = new Tuple<int, int>(i, i);
                        Map[p] = new Tuple<int, int>(Map[p].Item1, i);
                    }
                    while (x % p == 0) x /= p;
                }
            }

            int n = nums.Length;
            int[] diff = new int[n + 1];
            foreach (var pair in Map)
            {
                int k = pair.Key;
                var v = pair.Value;
                if (v.Item1 == v.Item2) continue;

                diff[v.Item1] += 1;
                diff[v.Item2] -= 1;
            }

            int sum = 0;
            for (int i = 0; i < n - 1; i++)
            {
                sum += diff[i];
                if (sum == 0)
                    return i;
            }

            return -1;
        }
        public List<int> Eratosthenes_1(int n)
        {
            List<int> q = new List<int>(n + 1);
            List<int> primes = new List<int>();
            for (int i = 0; i <= n; i++)
            {
                q.Add(0);
            }

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (q[i] == 1) continue;
                int j = i * 2;
                while (j <= n)
                {
                    q[j] = 1;
                    j += i;
                }
            }

            for (int i = 2; i <= n; i++)
            {
                if (q[i] == 0)
                    primes.Add(i);
            }
            return primes;
        }