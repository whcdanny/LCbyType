//Leetcode 2999. Count the Number of Powerful Integers hard
//题意：主要任务是计算在指定范围内，满足以下条件的“powerful”整数的数量：
//整数的末尾必须是字符串 s，即 s 是整数的后缀。
//整数的每一位数字都不超过限制值 limit。
//思路：深度优先搜索（DFS）首先，对于区间内的计数，
//常用的技巧就是转化为helper(to_string(finish), limit, s) - helper(to_string(start-1), limit, s)，
//其中helper(string a, int limit, string s)表示在[1:a]区间内有多少符合条件的数（即每个digit不超过limit且后缀为s）。
//接下来写helper函数。令上限a的长度为d，那么我们计数的时候只需要逐位填充、循环d次即可。对于第k位而言，分两种情况：
//如果填充的前k-1位小于a同样长度的前缀，那么第k位可以任意填充0 ~limit都不会超过上限a。
//甚至从第k+1位起，直至固定的后缀s之前，总共有d = a.size()-s.size()-k位待填充的数字，都可以任意填充为0 ~limit。
//故直接返回计数结果：pow(1+limit, d).
//如果填充的前k-1位等于a同样长度的前缀，那么第k位可以填充为0 ~min(limit, a[k])。
//确定之后，接下来递归处理下一位即可。
//注意，如果填充为a[k] 的话，需要告知递归函数“已构造的前缀继续与a相同”，否则告知递归函数“已构造的前缀小于a”。
//这样下一轮递归函数知道选择哪一个分支。
//时间复杂度: O(n)，其中 n 是二叉树中节点的数量
//空间复杂度：O(h)，其中 h 是二叉树的高度。在最坏情况下，二叉树为单链表，高度为 n，因此空间复杂度为 O(n)
        public long NumberOfPowerfulInt(long start, long finish, int limit, string s)
        {
            return help_NumberOfPowerfulInt(finish.ToString(), limit, s) - help_NumberOfPowerfulInt((start - 1).ToString(), limit, s);
        }

        private long help_NumberOfPowerfulInt(string topValue, int limit, string s)
        {
            if (topValue.Length < s.Length)
                return 0;
            return dfs_NumberOfPowerfulInt(topValue, s, limit, 0, true);
        }

        //k:添加第几位，same：是否之前贴合
        private long dfs_NumberOfPowerfulInt(string topValue, string s, int limit, int k, bool same)
        {
            if (topValue.Length - k == s.Length)
            {
                int len = s.Length;
                if (!same || string.Compare(topValue.Substring(topValue.Length - len), s) >= 0)
                    return 1;
                else
                    return 0;
            }
            long res = 0;
            if (!same)
            {
                int d = topValue.Length - s.Length - k;
                res = (long)Math.Pow(1 + limit, d);
            }
            else
            {
                for(int i = 0; i <= limit; i++)
                {
                    if (i > topValue[k] - '0')
                        break;
                    else if (i == topValue[k] - '0')
                        res += dfs_NumberOfPowerfulInt(topValue, s, limit, k + 1, true);
                    else
                        res += dfs_NumberOfPowerfulInt(topValue, s, limit, k + 1, false);
                }
            }
            return res;
        }