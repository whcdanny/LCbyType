//Leetcode 2351. First Letter to Appear Twice ez
//题意：给定一个由小写英文字母组成的字符串 s，返回第一个出现两次的字母。
//思路：hashtable Dictionary来存出现的char的数量，只要有大于1的，就输出当前char；  
//时间复杂度：O(n)
//空间复杂度：O(1)
        public char RepeatedCharacter(string s)
        {
            int n = s.Length;
            char ans = '\0';
            Dictionary<char, int> count = new Dictionary<char, int>();

            for (int i = 0; i < n; i++)
            {
                if (!count.ContainsKey(s[i]))
                {
                    count[s[i]] = 1;
                }
                else
                {
                    ans = s[i];
                    break;
                }
            }

            return ans;
        }