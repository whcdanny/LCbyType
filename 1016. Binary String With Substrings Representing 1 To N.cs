1016. Binary String With Substrings Representing 1 To N
//C#
		public static bool QueryString(string s, int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (!s.Contains(Convert.ToString(Convert.ToInt32(i.ToString(), 10), 2)))
                {
                    return false;
                }
            }
            return true;
        }