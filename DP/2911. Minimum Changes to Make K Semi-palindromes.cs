//Leetcode 2911. Minimum Changes to Make K Semi-palindromes hard
//题意：给定一个字符串 s 和一个整数 k，将 s 分成 k 个子字符串，
//使得每个子字符串成为半回文所需的字母变化最小。
//一个半回文是一种可以根据重复模式划分成回文的特殊字符串。
//要检查一个字符串是否是半回文，可以通过以下步骤：
//选择字符串长度的一个正除数 d。d 的范围是 1 到字符串长度，但不包括字符串的长度。
//对于给定的除数 d，将字符串划分为若干组，每组包含字符串中按长度 d 重复模式排列的字符。
//具体地，第一组包括位置 1, 1 + d, 1 + 2d 等的字符；第二组包括位置 2, 2 + d, 2 + 2d 等的字符。
//如果每一组形成回文，则该字符串被认为是半回文。
//思路：动态规划 要在整个字符串中分割出k个区间，显然是dp的套路。
//令dp[i][p]表示将前i个字符分割成符合条件的p个区间，所需要的最小改动操作。显然有：
//for (int i=0; i<n; i++)
//  for (int p=1; p<=k; p++)
//    for (int j=0; j<i; j++
//      dp[i][p] = min(dp[i][p], dp[j][p - 1]+range[j + 1][i]);
//range[j + 1][i] 表示在[j + 1:i]这个区间内，使得其变为k-semi-palindrome的最少改动次数。
//如果无法实现，那么则赋值为无穷大。
//根据题目的数据范围，o(n^3)是可以接受的。最终返回的就是dp[n - 1][k].
//求range[a][b] 呢。
//for (int i = 0; i<n; i++)        
//    for (int j = i; j<n; j++)
//    {       
//        int len = j - i + 1;
//        for (int d=1; d<=len/2; d++)
//        {
//            if (len%d!=0) continue;
//            int sum = 0;
//            for (int r=0; r<d; r++)
//                sum += helper(s, i, j, d, r);  // 从i到j区间内，从第r个开始，依次间隔d
//        range[i][j] = min(range[i][j], sum);
//    }
//}
//注意，d与r的两层循环共用o(nlogn)的复杂度。对于一个长度len，它的因子的个数有log(len)个；
//对于每个因子都需要把整个len长度的子串遍历一遍
//时间复杂度: 预处理每个子字符串的代价为 O(n^3)，因为需要对每个子字符串计算其按每个可能的 d 分割的最小代价。
//动态规划部分的复杂度为 O(n^2 * k)，因为需要计算 dp[i, p]。
//综合来看，时间复杂度为 O(n^3 + n^2 * k)。
//空间复杂度：O(n^2)
        public int MinimumChanges(string s, int k)
        {
            //动态规划求解最小代价：
            //使用二维数组 dp[i, p] 表示将前 i 个字符分成 p 个子字符串的最小代价。
        
            int[,] dp = new int[205, 205];
            int[,] range = new int[205, 205];
            int n = s.Length;

            // 预处理每个子字符串变成半回文的最小代价
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int len = j - i + 1;
                    range[i, j] = int.MaxValue / 2;

                    // 枚举所有可能的分割长度 d
                    for (int d = 1; d <= len / 2; d++)
                    {
                        if (len % d != 0) continue;
                        int sum = 0;

                        // 计算当前分割下变成回文的代价
                        for (int r = 0; r < d; r++)
                        {
                            sum += countChanges(s, i, j, d, r);
                        }

                        range[i, j] = Math.Min(range[i, j], sum);
                    }
                }
            }

            //初始化 dp 数组，dp[i, 1] 表示将前 i 个字符作为一个子字符串的代价，即 range[0, i]。           
            for (int i = 0; i < n; i++)
            {
                dp[i, 1] = range[0, i];
            }

            // 动态规划求解
            for (int i = 0; i < n; i++)
            {
                for (int p = 2; p <= k; p++)
                {
                    dp[i, p] = int.MaxValue / 2;
                    for (int j = 0; j < i; j++)
                    {
                        dp[i, p] = Math.Min(dp[i, p], dp[j, p - 1] + range[j + 1, i]);
                    }
                }
            }

            return dp[n - 1, k];
        }

        // 计算从 s[a] 到 s[b] 中长度为 d 的每个组变成回文的代价
        //预处理：计算每个子字符串变成半回文的代价：
        //使用二维数组 range[i, j] 存储将 s[i...j] 转换为半回文的最小代价。
        //枚举所有可能的分割长度 d，计算每个子字符串按 d 分割成组后变为回文的最小代价。
        private int countChanges(string s, int a, int b, int d, int r)
        {
            int i = a + r;
            int j = b - (d - r) + 1;
            int count = 0;

            while (i < j)
            {
                count += s[i] != s[j] ? 1 : 0;
                i += d;
                j -= d;
            }

            return count;
        }