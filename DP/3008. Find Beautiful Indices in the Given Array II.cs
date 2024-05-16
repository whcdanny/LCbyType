//Leetcode 3008. Find Beautiful Indices in the Given Array II hard
//题意：给定一个字符串 s，两个字符串 a 和 b，以及一个整数 k。定义美丽的索引为满足以下条件的索引 i：
//0 <= i <= s.length - a.length
//s[i..(i + a.length - 1)] 等于字符串 a
//同时，存在索引 j 满足以下条件：
//0 <= j <= s.length - b.length
//s[j..(j + b.length - 1)] 等于字符串 b
//|j - i| <= k
//要求找出所有满足条件的美丽的索引，并按升序排序返回。
//思路：动态规划+KMP：很显然，我们只需要找出a在s中出现的所有位置pos1，以及b在s中出现的所有位置pos2。这个用KMP的模板即可。
//对于pos1中的每个位置i，我们只需要查找i-k在pos2里的位置（lower_bound，第一个大于等于该数的迭代器），
//以及i+k在pos2里的位置（upper_bound，第一个大于该数的迭代器），两个位置之差即代表有多少pos2的元素位于[i - k, i + k] 之间。
//时间复杂度: O(n);
//空间复杂度：O(n)
        public IList<int> BeautifulIndices_超时(string s, string a, string b, int k)
        {
            List<int> A = StrStr_3008(s, a);
            List<int> B = StrStr_3008(s, b);

            List<int> rets = new List<int>();
            if (A.Count == 0 || B.Count == 0)
                return rets;
            foreach (int i in A)
            {
                int index1 = B.BinarySearch(i - k);//LowerBound(B, i - k);
                int index2 = B.BinarySearch(i + k + 1);//UpperBound(B, i + k);
                if (index1 == index2)
                    continue;
                if (index1 < 0)
                    index1 = -index1;
                if (index2 < 0)
                    index2 = -index2;
                if (index2 - index1 >= 0 && !rets.Contains(i))
                    rets.Add(i);
            }
            return rets;
        }
        public List<int> StrStr_3008(string haystack, string needle)
        {
            List<int> res = new List<int>();            
            int n = haystack.Length;
            int m = needle.Length;
            if (m == 0) return new List<int>();
            if (n == 0) return new List<int>();

            List<int> suf = Preprocess(needle);
            
            int[] dp = new int[n];
            Array.Fill(dp, 0);            
            dp[0] = (haystack[0] == needle[0]) ? 1 : 0;
            if (m == 1 && dp[0] == 1)
                res.Add(0);

            for (int i = 1; i < n; i++)
            {
                int j = dp[i - 1];                
                while (j >= 1 && (j == needle.Length || haystack[i] != needle[j]))
                    j = suf[j - 1];
                dp[i] = j + ((haystack[i] == needle[j]) ? 1 : 0);
                if (dp[i] == needle.Length)
                    res.Add(i - needle.Length + 1);
            }
            return res;
        }

        public List<int> Preprocess(string s)
        {
            int n = s.Length;
            int[] dp = new int[n];
            Array.Fill(dp, 0);
            for (int i = 1; i < n; i++)
            {
                int j = dp[i - 1];
                while (j >= 1 && s[j] != s[i])
                {
                    j = dp[j - 1];
                }
                dp[i] = j + ((s[j] == s[i]) ? 1 : 0);
            }
            return dp.ToList();
        }