//Leetcode 2930. Number of Strings Which Can Be Rearranged to Contain Substring med
//题意：目要求计算长度为n的字符串中，包含子串"leet"的所有可能性的总数，要求返回的结果对10^9 + 7取模。
//思路：动态规划：本题是求长度为n、且包括leet的字符串有多少种。
//看上去是个组合数学的问题，其实可以转化为基础的动态规划。
//我们令dp[i][a][b][c]表示前i个字符里至少有a个'l'，b个'e'，c个't'的种类数目。
//那么计算dp[i][a][b][c]时考虑第i个字符是什么，以及它对a,b,c的影响：
//最终答案就是dp[n][1][2][1]
//事实上很多组合数学的本质就是动态规划。
//比如注明的组合数公式C(m, n) = C(m-1, n) + C(m-1, n-1)其实就是动态转移方程。
//含义就是：从前m个数里取n个，取决于第m个数要不要取？
//是的话，相当于在前m-1里取n-1个；
//不是的话，相当于在前m-1个里面取n个。
//时间复杂度: O(n);
//空间复杂度：O(n)
        int mod_StringCount = 1000000007;
        public int StringCount(int n)
        {
            long[,,,] dp = new long[100005, 2, 3, 2];
            dp[0, 0, 0, 0] = 1;
            for(int i = 1; i <= n; i++)
            {
                for(int a = 0; a < 2; a++)
                {
                    for(int b = 0; b < 3; b++)
                    {
                        for(int c = 0; c < 2; c++)
                        {
                            for(int k = 0; k < 26; k++)
                            {
                                if(k==('l'-'a') && a == 1)
                                {
                                    dp[i, 1, b, c] += dp[i - 1, 0, b, c];
                                }
                                else if(k == ('e' - 'a') && b == 1)
                                {
                                    dp[i, a, 1, c] += dp[i - 1, a, 0, c];
                                }
                                else if (k == ('e' - 'a') && b == 2)
                                {
                                    dp[i, a, 2, c] += dp[i - 1, a, 1, c];
                                }
                                else if (k == ('t' - 'a') && c == 1)
                                {
                                    dp[i, a, b, 1] += dp[i-1, a, b, 0];
                                }
                                else
                                {
                                    dp[i, a, b, c] += dp[i - 1, a, b, c];
                                    dp[i, a, b, c] %= mod_StringCount;
                                }
                            }
                        }
                    }
                }
            }

            return (int)dp[n, 1, 2, 1];

        }