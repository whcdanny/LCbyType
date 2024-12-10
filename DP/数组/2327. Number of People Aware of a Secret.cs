//2327. Number of People Aware of a Secret med
//题意：第 1 天，有一个人发现了一个秘密。
//给定整数 delay，表示每个人在发现秘密后的第 delay 天开始分享秘密，每天分享一次。
//给定整数 forget，表示每个人在发现秘密后的第 forget 天会忘记秘密。忘记后将不再分享。
//给定整数 n，返回第 n 天知道秘密的人数。结果对 取模。
//思路：用dp来存每一天能创建新的秘密的人数，
//记录[n−forget+1,n]，统计那些还未忘记秘密的分享者      
//时间复杂度：O(n⋅(forget−delay))
//空间复杂度：O(n)
        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            int mod = ((int)1e9) + 7;
            int[] dp = new int[n + 1];
            dp[1] = 1; // day 1
            for (int i = 1; i < n; i++)
            {  
                for (int j = i + delay; j < Math.Min(i + forget, n + 1); j++)
                {
                    dp[j] = (dp[i] + dp[j]) % mod;
                }
            }
            int res = 0;
            for (int i = n; i > n - forget; i--)
                res = (res + dp[i]) % mod;
            return res;

        }