//Leetcode 28. Find the Index of the First Occurrence in a String ez
//题意：给定一个字符串 haystack 和一个字符串 needle，要求实现一个函数 StrStr，返回 needle 在 haystack 中的第一次出现的位置。
//如果 needle 不是 haystack 的子串，则返回 -1。如果 needle 是空字符串，返回 0。
//思路：KMP算法: 首先我们要预处理模式串p（也就是needle），得到一个关于模式串的后缀数组suf。
//suf[i]表示在字符串p中，截止i位置的最长的后缀字符串，使得它恰好也是p的前缀。
//比如说，如果j=suf[i]，那么p[0:j-1]=p[i-j+1:i]。关于后缀数组的计算
//有了模式串的后缀数组suf，对于字符串s（也就是haystack）也定义类似的后缀数组dp。
//其中dp[i] 表示s里截止i位置的最长的后缀字符串，使得它恰好也是p的前缀。
//注意，这里如果j=suf[i]，那么p[0:j - 1]=s[i - j + 1:i]。
//显然，如果dp[i]==p.size()，那么意味着以s[i] 为结尾的后缀字符串与p完全匹配。
//用动态规划的想法，看看dp[i] 是否能从dp[i - 1]得到。
//如下图：我们想计算dp[i]。我们看一下dp[i - 1]，记j=dp[i - 1]，
//那么p就有一段长度为j的前缀字符串与s[i - 1] 结尾的后缀字符串匹配。
//s:    ________________ * * * * * * * * * * * * * * * *  X _________
//                                                    i-1 i
//p:                     * * * * * * * * * * * * * * * *  Y _________
//                                                    j-1 j
//此时如果有s[i]==p[j]（即X==Y），那么显然已知匹配的长度自然就可以延长1位，即dp[i]=j+1.
//那么如果没有X==Y,我们把眼光放到suf[j - 1] 上，记j'=suf[j-1]，那么p就有一段长度为j'的前缀字符串与p[j - 1] 结尾的后缀字符串匹配.
//s:    ________________ _______________________ + + + +  X _________           
//												      i-1 i
//p:                     + + + + Z _____________ + + + +  Y _________   
//                            j'-1                    j-1 j
//不难推导出p[0:j'-1]也与s[i-j':i - 1] 必然是相等的。
//所以我们在计算dp[i] 的时候可以利用这段长度：只要Z==X，那么dp[i] = j'+1.
//如果Z和X仍然不等，那么我们就再把眼光放到suf[j'-1]上，即j''=suf[j' - 1]，
//同理推导出p[0:j'' - 1] 也与s[i-j'':i-1] 必然是相等的，此时只要考察s[i] 和p[j''] 是否相等个，就可以将dp[i] 推至j''+1...
//依次类推j',j'',j'''..直到我们找到合适的j（注意j可以是0），使得p里面长度为j的前缀字符串，
//恰好等于截止s[i - 1] 的后缀字符串。于是dp[i] 能否突破0，就取决于dp[j]+(s[i]==p[j])了。代码如下：
//注意dp[0] 需要单独计算：dp[0] = (s[0]==p[0])
//当我们计算得到第一处dp[i]=p.size() 时，就说明找到了完整匹配的模式串。
//时间复杂度：O(m * n)
//空间复杂度：O(1)
        public int StrStr(string haystack, string needle)
        {
            int n = haystack.Length;
            int m = needle.Length;
            if (n == 0) return -1;
            if (m == 0) return 0;

            int[] suf = preprocess(needle);

            int[] dp = new int[n];
            Array.Fill(dp, 0);
            dp[0] = (haystack[0] == needle[0] ? 1 : 0);
            if (m == 1 && dp[0] == 1)
                return 0;
            for(int i = 1; i < n; i++)
            {
                int j = dp[i - 1];
                while (j > 0 && (j == needle.Length || haystack[i] != needle[j]))
                    j = suf[j - 1];
                dp[i] = j + (haystack[i] == needle[j] ? 1 : 0);
                if (dp[i] == needle.Length)
                    return i - needle.Length + 1;
            }
            return -1;
        }

        private int[] preprocess(string s)
        {
            int n = s.Length;
            int[] dp = new int[n];
            Array.Fill(dp, 0);
            for(int i = 1; i < n; i++)
            {
                int j = dp[i - 1];
                while(j>=1&& s[j] != s[i])
                {
                    j = dp[j - 1];
                }
                dp[i] = j + (s[j] == s[i] ? 1 : 0);
            }
            return dp;
        }