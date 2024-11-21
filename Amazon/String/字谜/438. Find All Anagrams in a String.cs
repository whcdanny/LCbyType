//Leetcode 438. Find All Anagrams in a String med
//题意：给定两个字符串s和，返回所有起始p索引的数组p字谜在。您可以按任何顺序s返回答案
//例如：s = "cbaebabacd", p = "abc" [0,6]
//思路：利用int[26]，将p中的每个字母的个数存入，并且将s中相对于p.length的每个字母的个数存入
//然后从s的头还是对sarray和parray进行比较，如果完全相同，那么记录初始位置
//然后更新sarray[s[i] - 'a']--; sarray[s[i + p.Length] - 'a']++;
//注意结束的位置是s.Length - p.Length，然后最后再比较一次，因为结尾的res.Add(s.Length - p.Length);
//时间复杂度:  O(n)
//空间复杂度： O(26) = O(1)
        public IList<int> FindAnagrams(string s, string p)
        {
            if (s.Length < p.Length)
                return new List<int>();
            int[] sarray = new int[26];
            int[] parray = new int[26];

            for (int i = 0; i < p.Length; i++)
            {
                sarray[s[i] - 'a']++;
                parray[p[i] - 'a']++;
            }
            List<int> res = new List<int>();
            for (int i = 0; i < s.Length - p.Length; i++)
            {
                if (isSameString(sarray, parray))
                {
                    res.Add(i);
                }
                sarray[s[i] - 'a']--;
                sarray[s[i + p.Length] - 'a']++;
            }
            if (isSameString(sarray, parray))
            {
                res.Add(s.Length - p.Length);
            }
            return res;
        }

        private bool isSameString(int[] sarray, int[] parray)
        {
            for (int i = 0; i < sarray.Length; i++)
            {
                if (sarray[i] != parray[i])
                    return false;
            }
            return true;
        }