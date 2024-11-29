//Leetcode 139. Word Break med
//题意：Word Break 问题：给定一个字符串 s 和一个字符串字典 wordDict，判断字符串 s 是否可以拆分为一个或多个在 wordDict 中出现的单词。
//要求：
//可以多次使用字典中的相同单词。
//返回结果为布尔值：true 表示可以拆分，false 表示不能。
//思路：Trie 树定义：
//TrieNode 类：包含 Children（用于存储子节点）和 IsEndOfWord（标记是否是一个完整单词）。
//Trie 类：提供 Insert 方法将单词插入 Trie 树，并提供 GetRoot 方法获取根节点。
//动态规划逻辑：
//使用布尔数组 dp，其中 dp[i] 表示字符串 s[0:i] 是否可以拆分为字典中的单词。
//外层循环遍历字符串 s 的每个起始位置 i。
//内层循环尝试从 i 开始匹配 Trie 树中的单词。
//如果在trienode中找到有children，那么更新node，
//如果结束，IsEndOfWord为true，则设置 dp[j + 1] = true（表示 s[0:j + 1] 可以拆分）。
//时间复杂度:  全部都是O(m) m是word的长度
//空间复杂度： Insert：O(n×m) n是word总个数，m是word的长度；剩下的1；
        public class TrieNode_139
        {
            public bool IsEndOfWord { get; set; }
            public TrieNode_139[] Children { get; }

            public TrieNode_139()
            {
                IsEndOfWord = false;
                Children = new TrieNode_139[26];
            }
        }
        public class Trie_139
        {
            private TrieNode_139 root;

            public Trie_139()
            {
                root = new TrieNode_139();
            }

            // 插入单词
            public void Insert(string word)
            {
                var node = root;
                foreach (char c in word)
                {
                    int index = c - 'a';
                    if (node.Children[index] == null)
                    {
                        node.Children[index] = new TrieNode_139();
                    }
                    node = node.Children[index];
                }
                node.IsEndOfWord = true;
            }            
            public TrieNode_139 GetRoot()
            {
                return root;
            }
        }
        public bool WordBreak(string s, IList<string> wordDict)
        {
            // 构建 Trie 树
            Trie_139 trie = new Trie_139();
            foreach (var word in wordDict)
            {
                trie.Insert(word);
            }

            int n = s.Length;
            bool[] dp = new bool[n + 1];
            dp[0] = true;

            for(int i = 0; i < n; i++)
            {
                if (!dp[i])
                    continue;
                TrieNode_139 node = trie.GetRoot();
                for(int j = i; j < n; j++)
                {
                    int index = s[j] - 'a';
                    if (node.Children[index] == null)
                    {
                        break;
                    }
                    node = node.Children[index];
                    if (node.IsEndOfWord)
                        dp[j + 1] = true;
                }
            }
            return dp[n];

        }