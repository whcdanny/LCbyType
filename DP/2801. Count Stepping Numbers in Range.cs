//Leetcode 2801. Count Stepping Numbers in Range hard
//题意：给定两个字符串形式的正整数 low 和 high，求区间 [low, high] 内的所有 "stepping numbers" 的个数。
//一个 "stepping number" 是指其相邻的数字的绝对差为1的整数。例如：123、321 都是 "stepping numbers"。
//由于答案可能非常大，因此需要返回答案对 
//取模的结果。
//思路：深度优先搜索（DFS）+ 动态规划
//转化为前缀之差的形式：return helper(high) - helper(low) + check(low). 
//其中helper(num)表示求[1, num] 区间内符合要求的数的个数。
//用dfs的方法来这个填充每一位。
//设计dfs(len, prev, isSame)表示在当前“状态”最终会有多少个合法的数字，
//其中len还有多少位需要填充，prev表示上一位填充的数字是什么，isSame表示之前填充的所有数字是否与num的前缀贴合。
//如果isSame==false，
//那么只要prev+1<=9，那么就可以在当前位填充prev+1；
//只要prev-1>=0，那么就可以在当前位填充prev-1. 递归函数里的isSame都是false。
//如果isSame==true，令当前位置上num的数字是D，
//那么只要prev+1<D ，那么就可以在当前位填充prev+1；
//只要prev-1>=0 && prev-1<D，那么就可以在当前位填充prev-1. 递归函数里的isSame都是false。
//此外，如果prev+1==D，位置也可以填充prev+1，只不过后续的递归函数里isSame=true。
//同理，如果prev-1==D，位置也可以填充prev-1，只不过后续的递归函数里isSame=true。
//在helper函数里，需要枚举数的长度、起始位置的填充（d只能从1开始选择），调用各自的dfs函数，并将结果相加。
//最后别忘了记忆化数组memo[len][prev][isSame] 来减少重复计算。
//时间复杂度: O(n * 2 * 11)，其中 n 是 num 的长度。考虑到递归会计算所有的子问题。
//空间复杂度：O(n * 2 * 11)，用于存储动态规划的状态
        const long mod_CountSteppingNumbers = 1000000007;

        public int CountSteppingNumbers(string low, string high)
        {
            long res = help_CountSteppingNumbers(high) - help_CountSteppingNumbers(low);
            res = (res + mod_CountSteppingNumbers) % mod_CountSteppingNumbers;
            res = (res + (check_CountSteppingNumbers(low) ? 1 : 0) + mod_CountSteppingNumbers) % mod_CountSteppingNumbers;

            return (int)res;
        }

        private bool check_CountSteppingNumbers(string s)
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (Math.Abs(s[i] - s[i - 1]) != 1) return false;
            }
            return true;
        }

        private long help_CountSteppingNumbers(string num)
        {
            long ret = 0;

            int n = num.Length;
            long[,,] memo = new long[105, 10, 2];
            for (int i = 0; i < 105; i++)
                for (int j = 0; j < 10; j++)
                    for (int k = 0; k < 2; k++)
                        memo[i, j, k] = -1;

            for (int len = 1; len < n; len++)
            {
                for (int d = 1; d <= 9; d++)
                {
                    ret = (ret + dfs_CountSteppingNumbers(len - 1, d, false, num, memo)) % mod_CountSteppingNumbers;
                }
            }

            int D = num[0] - '0';
            for (int d = 1; d < D; d++)
            {
                ret = (ret + dfs_CountSteppingNumbers(n - 1, d, false, num, memo)) % mod_CountSteppingNumbers;
            }
            ret = (ret + dfs_CountSteppingNumbers(n - 1, D, true, num, memo)) % mod_CountSteppingNumbers;

            return ret;
        }

        private long dfs_CountSteppingNumbers(int len, int prev, bool isSame, string num, long[,,] memo)
        {
            if (len == 0) return 1;

            if (memo[len, prev, isSame ? 1 : 0] != -1)
                return memo[len, prev, isSame ? 1 : 0];

            int n = num.Length;
            long ret = 0;
            if (!isSame)
            {
                if (prev + 1 <= 9)
                    ret = (ret + dfs_CountSteppingNumbers(len - 1, prev + 1, false, num, memo)) % mod_CountSteppingNumbers;
                if (prev - 1 >= 0)
                    ret = (ret + dfs_CountSteppingNumbers(len - 1, prev - 1, false, num, memo)) % mod_CountSteppingNumbers;
            }
            else
            {
                int D = num[n - len] - '0';
                if (prev + 1 < D)
                    ret += dfs_CountSteppingNumbers(len - 1, prev + 1, false, num, memo);
                else if (prev + 1 == D)
                    ret += dfs_CountSteppingNumbers(len - 1, prev + 1, true, num, memo);
                ret %= mod_CountSteppingNumbers;

                if (prev - 1 >= 0 && prev - 1 < D)
                    ret += dfs_CountSteppingNumbers(len - 1, prev - 1, false, num, memo);
                else if (prev - 1 >= 0 && prev - 1 == D)
                    ret += dfs_CountSteppingNumbers(len - 1, prev - 1, true, num, memo);
                ret %= mod_CountSteppingNumbers;
            }

            memo[len, prev, isSame ? 1 : 0] = ret;
            return ret;
        }