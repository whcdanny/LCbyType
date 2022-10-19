1415. The k-th Lexicographical String of All Happy Strings of Length n
/*
["aba", "abc", "aca", "acb", "bab", "bac", "bca", "bcb", "cab", "cac", "cba", "cbc"]
*/
//C#
		public static string GetHappyString(int n, int k)
        {
            if (n != 1 && 3 * (int)Math.Pow(2, n - 1) < k) return "";
            StringBuilder ans = new StringBuilder();
            int count = 0;
            recurHelper("", n, k, ref count, ans);
            return ans.ToString();
        }

        public static void recurHelper(string s, int n, int k, ref int count, StringBuilder sb)
        {
            if (s.Length == n || sb.ToString() != "")
            {
                count++;
                if (count == k) sb.Append(s);
                return;
            }
            if (s == "" || s[s.Length - 1] != 'a') recurHelper(s + "a", n, k, ref count, sb);
            if (s == "" || s[s.Length - 1] != 'b') recurHelper(s + "b", n, k, ref count, sb);
            if (s == "" || s[s.Length - 1] != 'c') recurHelper(s + "c", n, k, ref count, sb);
        }