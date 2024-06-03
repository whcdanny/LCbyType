//Leetcode 2827. Number of Beautiful Integers in the Range hard
//题意：给定三个正整数 low, high, 和 k。
//一个数如果满足以下两个条件则是美丽的：
//数字中的偶数位数和奇数位数的个数相等。
//这个数能被 k 整除。
//返回区间[low, high] 中美丽整数的数量。
//思路：深度优先搜索（DFS）+ 动态规划
//常规的数位计算的套路。开局就是return helper(large) - helper(low-1)，其中helper表示符合条件、且小于等于larger的数字的个数。
//DFS的思想来逐个填充每个位置上的数字。在填充的过程中我们要监控两个量。
//第一个是奇数数位与偶数数位的个数之差，我们期望在填充完毕之后是0.
//第二个是当前构造的数字对于k的模，我们期望在填充完毕之后也是0.
//dfs(len, isSame, diff, r)，表示还有len个数字需要填充（或者说当前需要填充倒数第len个位置），isSame表示之前已填充的数字是否与原数num的前缀贴合，diff表示当前奇数数位与偶数数位的个数之差，r表示已经构造的数字对于k的模。
//考虑当前数字d的填充时，需要分两大类：
//isSame是false，那么说明当前d可以从0填到9都没有任何顾虑（不会超过原数），故
//for (int d = 0; d <= 9; d++)
//ret += dfs(len-1, false, diff+((d%2==0)*2-1), (r*10+d)%k);
//isSame是true，那么说明当前d可以从0填到D = num[n - len]-1都没有任何顾虑（不会超过原数），即
//int D = num[n - len];
//for (int d = 0; d<D; d++)
//ret += dfs(len-1, false, diff+((d%2==0)*2-1), (r*10+d)%k);
//但是d最大只能取到D，并且在下一个回合的过程中仍将标记isSame=true，即
//int D = num[n - len];
//ret += dfs(len-1, true, diff+((D%2==0)*2-1), (r*10+D)%k);
//最终条件是当len==0时，只有当diff==0 && r==0的时候才会返回1（因为此时已经将一个具体的数构造出来了），其余的时候我们构造出的是一个不符合条件的数，返回0.
//最后我们加上记忆化。我们看到有四个参量len,isSame,diff,r，所以就定义memo[11][2][22][22] 来存储各个dfs的结果，来避免重复的搜索。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)
        private int k_NumberOfBeautifulIntegers;

        public int NumberOfBeautifulIntegers(int low, int high, int k)
        {
            this.k_NumberOfBeautifulIntegers = k;
            return Helper(high, k) - Helper(low - 1, k);
        }

        private int Helper(long num, int k)
        {
            int[,,,] memo = new int[11, 2, 22, 22];
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int m = 0; m < 22; m++)
                    {
                        for (int nn = 0; nn < 22; nn++)
                        {
                            memo[i, j, m, nn] = -1;
                        }
                    }
                }
            }

            string Num = num.ToString();
            int n = Num.Length;

            int ret = 0;
            for (int len = 2; len < n; len += 2)
            {
                for (int d = 1; d <= 9; d++)
                {
                    ret += dfs_NumberOfBeautifulIntegers(len - 1, false, (d % 2 == 0) ? 1 : -1, d % k, Num, memo);
                }
            }

            if (n % 2 == 0)
            {
                int D = Num[0] - '0';
                for (int d = 1; d < D; d++)
                {
                    ret += dfs_NumberOfBeautifulIntegers(n - 1, false, (d % 2 == 0) ? 1 : -1, d % k, Num, memo);
                }
                ret += dfs_NumberOfBeautifulIntegers(n - 1, true, (D % 2 == 0) ? 1 : -1, D % k, Num, memo);
            }

            return ret;
        }

        //len:长度 isSame：是否跟前缀的数贴合；diff;前奇数数位与偶数数位的个数之差; r: 构造的数字对于k的模;
        private int dfs_NumberOfBeautifulIntegers(int len, bool isSame, int diff, int r, string num, int[,,,] memo)
        {
            int n = num.Length;

            if (len == 0)
            {
                return (diff == 0 && r == 0) ? 1 : 0;
            }

            if (memo[len, isSame ? 1 : 0, diff + 10, r] != -1)
            {
                return memo[len, isSame ? 1 : 0, diff + 10, r];
            }

            int ret = 0;
            //isSame：是否跟前缀的数贴合，不贴合那么就可以选0-9，如果不贴合，那么对多到这个位置的上限数字；
            if (!isSame)
            {
                for (int d = 0; d <= 9; d++)
                {
                    ret += dfs_NumberOfBeautifulIntegers(len - 1, false, diff + ((d % 2 == 0) ? 1 : -1), (r * 10 + d) % k_NumberOfBeautifulIntegers, num, memo);
                }
            }
            else
            {
                int D = num[n - len] - '0';
                for (int d = 0; d < D; d++)
                {
                    ret += dfs_NumberOfBeautifulIntegers(len - 1, false, diff + ((d % 2 == 0) ? 1 : -1), (r * 10 + d) % k_NumberOfBeautifulIntegers, num, memo);
                }
                //刚好选择上限的数字，那么isSame是true
                ret += dfs_NumberOfBeautifulIntegers(len - 1, true, diff + ((D % 2 == 0) ? 1 : -1), (r * 10 + D) % k_NumberOfBeautifulIntegers, num, memo);
            }

            memo[len, isSame ? 1 : 0, diff + 10, r] = ret;

            return ret;
        }