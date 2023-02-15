//28. Find the Index of the First Occurrence in a String med
//给两个string haystack needle， 从haystack 找到是否含有needle
//思路： 从haystack开始和needle比较 找到一样的，就是慢，快的看不懂
		public int StrStr(string haystack, string needle)
        {
            if (needle.Count()==0) return 0;
            int m = haystack.Count(), n = needle.Count();
            if (m < n) return -1;
            for (int i = 0; i <= m - n; ++i)
            {
                int j = 0;
                for (j = 0; j < n; ++j)
                {
                    if (haystack[i + j] != needle[j]) break;
                }
                if (j == n) return i;
            }
            return -1;
        }