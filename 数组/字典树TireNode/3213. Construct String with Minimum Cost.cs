//Leetcode 3213. Construct String with Minimum Cost hard
//题目：给定一个字符串 target，一个字符串数组 words，以及一个整型数组 costs，其中 words 和 costs 的长度相同。
//目标是构建一个与 target 字符串相同的字符串 s。可以进行以下操作任意次：
//选择一个索引 i（0 <= i<words.length），将 words[i] 附加到 s。
//每次附加 words[i] 的代价是 costs[i]。
//返回构建出 target 所需的最小成本。如果无法构建，返回 -1。
//思路: 字典树TrieNode + 动态规划
//dp找的是target每个位置当前能根据words得出的最小cost值；
//用trieNode不每个字母穿成一条线，根据每个word，每个char练成一个以char为节点的线，
//然后如果word结束，要将TrieNode中的isword改成true，并存入相应的cost；
//然后从target的开头开始，根据建立的TrieNode检查，如果存在Children，就继续，
//如果isword那就找出dp[j + 1] = Math.Min(dp[j + 1], dp[i] + node.Cost);
//时间复杂度：O(n * m)，其中 n 是 target 的长度，m 是 words 中最长单词的长度
//空间复杂度：O(sum(len(words[i])))
        public int MinimumCost(string target, string[] words, int[] costs)
        {
            TrieNodeMinimumCost root = BuildTrie(words, costs);
            int n = target.Length;
            int[] dp = new int[n + 1];
            Array.Fill(dp, int.MaxValue);
            dp[0] = 0;

            for (int i = 0; i < n; i++)
            {
                if (dp[i] == int.MaxValue) continue;
                TrieNodeMinimumCost node = root;
                for (int j = i; j < n; j++)
                {
                    char c = target[j];
                    if (!node.Children.ContainsKey(c)) 
                        break;
                    node = node.Children[c];
                    if (node.IsWordEnd)
                    {
                        dp[j + 1] = Math.Min(dp[j + 1], dp[i] + node.Cost);
                    }
                }
            }
            return dp[n] == int.MaxValue ? -1 : dp[n];
        }

        private TrieNodeMinimumCost BuildTrie(string[] words, int[] costs)
        {
            TrieNodeMinimumCost root = new TrieNodeMinimumCost();
            for (int i = 0; i < words.Length; i++)
            {
                TrieNodeMinimumCost node = root;
                foreach (char c in words[i])
                {
                    if (!node.Children.ContainsKey(c))
                    {
                        node.Children[c] = new TrieNodeMinimumCost();
                    }
                    node = node.Children[c];
                }
                node.IsWordEnd = true;
                node.Cost = Math.Min(node.Cost, costs[i]);
            }
            return root;
        }

        public class TrieNodeMinimumCost
        {
            public Dictionary<char, TrieNodeMinimumCost> Children { get; } = new Dictionary<char, TrieNodeMinimumCost>();
            public bool IsWordEnd { get; set; } = false;
            public int Cost { get; set; } = int.MaxValue;
        }
        public int MinimumCost_超时(string target, string[] words, int[] costs)
        {
            int n = target.Length;
            int[] dp = new int[n + 1];

            // 初始化 dp 数组
            Array.Fill(dp, int.MaxValue);
            dp[0] = 0;

            // 动态规划填充 dp 数组
            for (int i = 0; i < n; i++)
            {
                if (dp[i] == int.MaxValue) continue; // 如果当前无法构建，跳过

                // 尝试使用每个 word[j] 进行拼接
                for (int j = 0; j < words.Length; j++)
                {
                    string word = words[j];
                    int cost = costs[j];
                    int len = word.Length;

                    // 检查是否可以从位置 i 开始匹配 word
                    if (i + len <= n && target.Substring(i, len) == word)
                    {
                        dp[i + len] = Math.Min(dp[i + len], dp[i] + cost);
                    }
                }
            }

            // 检查是否可以构建整个 target
            return dp[n] == int.MaxValue ? -1 : dp[n];
        }