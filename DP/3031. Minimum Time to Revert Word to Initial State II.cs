//Leetcode 3031. Minimum Time to Revert Word to Initial State II hard
//题意：出了一个字符串 word 和一个整数 k。
//在每一秒钟，你必须执行以下操作：
//移除 word 的前 k 个字符。
//在 word 的末尾添加任意 k 个字符。
//需要注意的是，你不一定需要添加和移除相同的字符，但你必须每秒都执行这两个操作。
//你需要返回一个大于零的最小时间，使得 word 能够恢复到初始状态。
//思路：动态规划+KMP：本题的题意是说，在字符串里寻找一个最长的后缀长度len，使得该后缀同时也是字符串的前缀，并且要求n-len是k的整数。
//表示对于s[0:i] 而言的最长公共前后缀长度。即如果next[i]=L，那么就有s[0:L - 1] = s[i - L + 1:i]. （注意，这里所说的最长公共前后缀都不能包括字符串本身。）
//当我们查看len = next[n - 1] 但是发现不满足n-len能被k整除怎么办？
//显然，我们希望尝试word的“第二长的公共前后缀”。
//其实因为s[0:len - 1] = s[n - len:n - 1] 已经是s的最长公共前后缀，那么s[0:len - 1] 的“最长公共前后缀”必然也是s的“公共前后缀”，并且就是第二长的。
//所以我们只需要求s[0:len - 1] 的“最长公共前后缀”即可，那就是next[len - 1]。
//依次类推，我们可以求得s的第二长、第三长...的公共前后缀len。
//只要发现n-len是k的整数倍，就可以知道需要切几刀。
//如果始终不符合条件，那么就意味着要将整个长度n都切完才行。
//时间复杂度: O(n);
//空间复杂度：O(n)
        public int MinimumTimeToInitialState(string word, int k)
        {
            int n = word.Length;
            List<int> lcp = longestPrefix_MinimumTimeToInitialState(word);
            int len = lcp[n - 1];
            while (len != 0 && (n - len) % k != 0)
            {
                len = lcp[len - 1];
            }
            if (len != 0)
                return (n - len) / k;
            else
                return (n % k == 0) ? (n / k) : (n / k + 1);
        }
        public List<int> longestPrefix_MinimumTimeToInitialState(string s)
        {
            int n = s.Length;
            int[] dp = new int[n];
            dp[0] = 0;
            for (int i = 1; i < n; i++)
            {
                int j = dp[i - 1];
                while (j >= 1 && s[j] != s[i])
                {
                    j = dp[j - 1];
                }
                dp[i] = j + (s[j] == s[i] ? 1 : 0);
            }
            return dp.ToList();
        }