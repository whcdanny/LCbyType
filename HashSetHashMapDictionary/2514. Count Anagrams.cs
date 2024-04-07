//Leetcode 2514. Count Anagrams hard
//题意：给定一个字符串 s，包含一个或多个单词。每个连续的单词对之间用一个空格 ' ' 分隔。
//如果字符串 t 的第 i 个单词是字符串 s 的第 i 个单词的排列，则字符串 t 是字符串 s 的一个字谜。
//例如，"acb dfe" 是 "abc def" 的一个字谜，但 "def cab" 和 "adc bef" 不是。
//要求返回字符串 s 的不同字谜的数量。由于答案可能非常大，因此返回答案模 10^9 + 7。
//思路：hashtable, 计算每个单词的distinct permutation的乘积足k
//数目就是n! / prod{k_i !}，其中k_i就是每个字母在该单词中出现的频次。
//ki的阶乘是在分母上，所以需要取逆元。即转换为 n! * prod{inv[k_i]!}。因为ki的频次不超过1e5，所以我们可以提前预处理，用线性时间算出1e5以内所有的inv[i].      
//注：本题的难点在于模下计算 https://github.com/wisdompeak/LeetCode/tree/master/Template/Inverse_Element
//时间复杂度：O(n)
//空间复杂度：O(1)
        private long mod_CountAnagrams = 1000000007;
        private long[] inv = new long[100005];

        public int CountAnagrams(string s)
        {
            List<string> strArr = s.Split(' ').ToList();
            
            inv[1] = 1;
            for (int i = 2; i <= 100000; ++i)
            {
                inv[i] = (mod_CountAnagrams - mod_CountAnagrams / i) * inv[mod_CountAnagrams % i] % mod_CountAnagrams;
            }

            long ret = 1;
            foreach (string str in strArr)
            {
                ret = ret * Helper(str) % mod_CountAnagrams;
            }
            return (int)ret;
        }

        private long Helper(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char ch in s)
            {
                if (!map.ContainsKey(ch))
                {
                    map[ch] = 0;
                }
                map[ch]++;
            }

            int n = s.Length;
            long ret = 1;
            //n的阶乘
            for (int i = 1; i <= n; i++)
            {
                ret = ret * i % mod_CountAnagrams;
            }
            //除以每个出现的频次；这里用到逆元
            //n! / prod{k_i !}，其中k_i就是每个字母在该单词中出现的频次
            foreach (KeyValuePair<char, int> entry in map)
            {
                long v = entry.Value;
                for (int i = 1; i <= v; i++)
                {
                    ret = ret * inv[i] % mod_CountAnagrams;
                }
            }
            return ret;
        }
