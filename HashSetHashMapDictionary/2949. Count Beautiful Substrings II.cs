//Leetcode 2949. Count Beautiful Substrings II hard
//题意：给定一个字符串 s 和一个正整数 k，要求计算满足以下条件的非空美丽子字符串的数量：
//子字符串中元音字母和辅音字母的数量相等；
//子字符串中元音字母和辅音字母的乘积能够整除 k。(vowels * consonants) % k == 0
//思路：hashtable，
//对于求substring的问题，前缀和之差来解决。显然，对于以i结尾的substring，我们想要找满足条件的起始位置j，需要满足两个条件：
//[j+1:i] 内的元音辅音个数相等 [0:j] 的元音辅音个数之差必须等于[0:i]的元音辅音个数之差。
//[j+1:i] 内的元音辅音个数乘积能被k整除 [(i - j) / 2]^2 % k ==0 <-> [(i - j)]^2 % 4k ==0
//对于第一个条件，我们只要根据[0:i] 的元音辅音个数之差（假设为d），在hash表中查找之前有多少个前缀串的元音辅音个数之差也是d。
//对于第二个条件，理论上只要i与j关于sqrt(4k)同余，那么(i-j)就能被sqrt(4k)整除，也就是说(i-j)^2能被4k整除。
//但是sqrt(4k)可能不是一个整数。所以我们需要将k分解质因数，对于出现奇数次的质因子，显然我们需要再补一个该质因子以便k能被开方。
//我们将这样“松弛”后的k的开方结果记做m，那么我们只要i与j关于2m同余。就保证[(i - j)]^2能被4k整除。
//于是本题的思路就是建立包含两个key的hash，来记录每个前缀的两个信息：
//元音辅音的个数之差，前缀长度关于2m的余数。对于任意的位置i，如果在hash表里能找到两个key都相同的位置j，那么[j + 1:i] 就是符合要求的substring。   
//注：这里i % m 是这样来的  [(i - j) / 2]^2 % k ==0 <-> [(i - j)]^2 % 4k ==0 开根号(i-j)%2sqar(k)- sqar(k)用质因子给一个平方就是m然后2*m (i-j)%m i-j就是i距离0的长度 最后变成i % m
//时间复杂度：O(n+m)
//空间复杂度：O(n+m)
        HashSet<char> setBeautifulSubstrings = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
        public long BeautifulSubstrings(string s, int k)
        {
            List<int> primes = Eratosthenes(k);
            int m = 1;
            //是否为k的质因子(能整除给定正整数的质数)；
            foreach (int p in primes)
            {
                int count = 0;
                while (k % p == 0)
                {
                    count++;
                    k /= p;
                }
                if (count != 0 && count % 2 == 1)//质因子奇数次
                    m *= (int)Math.Pow(p, (count + 1) / 2);
                else if (count != 0 && count % 2 == 0)//
                    m *= (int)Math.Pow(p, count / 2);
            }
            m *= 2;

            int n = s.Length;            
            s = "#" + s;
            int ret = 0;

            Dictionary<int, Dictionary<int, int>> Map = new Dictionary<int, Dictionary<int, int>>();
            Map[0] = new Dictionary<int, int>();
            Map[0][0] = 1;

            int diff = 0;

            for (int i = 1; i <= n; i++)
            {
                if (setBeautifulSubstrings.Contains(s[i]))
                    diff++;
                else
                    diff--;

                if (Map.ContainsKey(diff) && Map[diff].ContainsKey(i % m))
                    ret += Map[diff][i % m];

                if (!Map.ContainsKey(diff))
                    Map[diff] = new Dictionary<int, int>();

                if (!Map[diff].ContainsKey(i % m))
                    Map[diff][i % m] = 0;

                Map[diff][i % m] += 1;
            }

            return ret;
        }

        //生成质数的筛法, 求1-n的所有质数；
        public List<int> Eratosthenes(int n)
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