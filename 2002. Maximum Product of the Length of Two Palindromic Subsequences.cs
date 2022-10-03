2002. Maximum Product of the Length of Two Palindromic Subsequences
//C#
		public static int maxProduct(String s)
        {
            int l = s.Length; 
            int max = 1 << l; // include all characters
            Dictionary<int, int> map = new Dictionary<int, int>(); // binary representation of the palindrome strings and their lengths
            List<string> test = new List<string>();
            for (int i = 0; i <= max; i++)
            {
                String tmp = "";

                for (int j = 0; j < l; j++)
                {
                    bool include = (i >> j & 1) == 1;

                    if (include)
                    {
                        tmp += s.ElementAt(l - j - 1);
                    }
                }

                if (isPalindrome(tmp))
                {
                    map.Add(i, tmp.Length);
                    test.Add(tmp);
                }
            }

            int xMax = 1;
            foreach (KeyValuePair<int,int> entryA in map)
            {
                int strA = entryA.Key;
                int lenA = entryA.Value;

                foreach (KeyValuePair<int, int> entryB in map)
                {
                    int strB = entryB.Key;
                    int lenB = entryB.Value;

                    if ((strA & strB) == 0)
                    {
                        xMax = Math.Max(xMax, lenA * lenB);
                    }
                }
            }

            return xMax;
        }

        public static bool isPalindrome(String str)
        {
            int l = str.Length;

            for (int i = 0, j = l - 1; i < j; i++, j--)
            {
                if (str.ElementAt(i) != str.ElementAt(j))
                {
                    return false;
                }
            }

            return true;
        }