//Leetcode 3316. Find Maximum Removals From Source String med
//题目：给定一个字符串 source，它的大小为 n；一个字符串 pattern，它是 source 的一个子序列；以及一个已排序的整数数组 targetIndices，该数组包含范围 [0, n - 1] 内的不同数字。
//我们定义一个操作为从 source 中删除一个字符，删除字符的索引 idx 必须是 targetIndices 中的元素，并且删除字符后，pattern 仍然是 source 的一个子序列。
//执行操作不会改变 source 中其他字符的索引。例如，如果你从 "acb" 中删除字符 'c'，则索引为 2 的字符仍然是 'b'。
//要求：返回可以执行的最大操作次数。
//注：这里表示可以删掉多少个targetIndices的位置，依然保持pattern是source的子集；
//思路：动态规划dp + dfs，用dp是防止重复计算，用dfs是因为我们要考虑到之前的结果然后继续分析
//在dp中是要考虑当前source的位置index是否可以移除根据targetIndices
//在比较source和pattern中：
//s[i] == p[j]表示匹配成功，i和j都+1；
//然后考虑i是否可以移除：
//移除：那就+1然后，i+1，然后继续寻找i+1和j的关系
//不移除：那就直接 i+1，然后继续寻找i+1和j的关系
//时间复杂度：递归的最大深度是 O(n * m)，其中 n 是 source 的长度，m 是 pattern 的长度。每个状态只计算一次，因此总的时间复杂度为 O(n * m)。
//空间复杂度：O(n * m) 的空间来存储 dp 数组. 此外，递归调用栈的深度最多为 O(n)，因此总的空间复杂度也是 O(n * m)。
        public int MaxRemovals(string source, string pattern, int[] targetIndices)
        {
            // 初始化 HashSet
            HashSet<int> set = new HashSet<int>(targetIndices);

            // 初始化二维数组 dp
            int[,] dp = new int[source.Length + 1, pattern.Length + 1];
            for (int i = 0; i <= source.Length; i++)
            {
                for (int j = 0; j <= pattern.Length; j++)
                {
                    dp[i, j] = -1;
                }
            }

            // 从 (0, 0) 开始深度优先搜索
            return Dfs_MaxRemovals(source, pattern, 0, 0, dp, set);
        }

        private int Dfs_MaxRemovals(string s, string p, int i, int j, int[,] dp, HashSet<int> set)
        {
            // 当遍历到源字符串的末尾时，检查是否匹配完整的模式字符串
            if (i == s.Length)
            {
                return j == p.Length ? 0 : int.MinValue;
            }

            // 如果该状态已经计算过，则直接返回缓存值
            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }

            int z = int.MinValue, z1 = int.MinValue;

            // 尝试匹配当前字符（如果匹配成功）
            if (j < p.Length && s[i] == p[j])
            {
                z = Dfs_MaxRemovals(s, p, i + 1, j + 1, dp, set);
            }

            // 尝试跳过当前字符（如果在 targetIndices 中则加 1，否则不加）
            if (set.Contains(i))
            {
                z1 = 1 + Dfs_MaxRemovals(s, p, i + 1, j, dp, set);
            }
            else
            {
                z1 = Dfs_MaxRemovals(s, p, i + 1, j, dp, set);
            }

            // 记录状态的最大值，并返回
            return dp[i, j] = Math.Max(z, z1);
        }
        public int MaxRemovals_看不懂(string source, string pattern, int[] targetIndices)
        {
            int n = source.Length;
            int m = pattern.Length;
            int[] target = new int[n];
            int[] dp = new int[m + 1];
            foreach (var i in targetIndices)
            {
                target[i] += 1;
            }
            Array.Fill(dp, int.MinValue);
            dp[m] = 0;
            for (int i = n - 1; i >= 0; --i)
            {
                for(int j = 0; j <= m; ++j)
                {
                    dp[j] += target[i];
                    if (j < m && source[i] == pattern[j])
                    {
                        dp[j] = Math.Max(dp[j], dp[j + 1]);
                    }
                }
            }
            return dp[0];
        }