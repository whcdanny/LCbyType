//211. Design Add and Search Words Data Structure med
//一种数据结构，支持添加新单词，查找字符串是否与任何先前添加的字符串匹配；
//思路： TrieMap；
		public class TrieNode
        {
            private TrieNode[] children;
            public bool IsEndOfWord;
            public Dictionary<char, TrieNode> Children;
            public bool IsWord { get; set; }

            public TrieNode()
            {
                children = new TrieNode[26];
                IsEndOfWord = false;
                Children = new Dictionary<char, TrieNode>();
            }
            
            public TrieNode this[char c]
            {
                get { return children[c - 'a']; }
                set { children[c - 'a'] = value; }
            }

            public bool ContainsKey(char c)
            {
                return children[c - 'a'] != null;
            }
        }
		public class WordDictionary
        {

            private TrieNode root;

            public WordDictionary()
            {
                root = new TrieNode();
            }

            public void AddWord(string word)
            {
                TrieNode node = root;

                foreach (char c in word)
                {
                    if (!node.Children.ContainsKey(c))
                    {
                        node.Children[c] = new TrieNode();
                    }
                    node = node.Children[c];
                }

                node.IsEndOfWord = true;
            }

            public bool Search(string word)
            {
                return Search(word, 0, root);
            }

            private bool Search(string word, int index, TrieNode node)
            {
                if (index == word.Length)
                {
                    return node.IsEndOfWord;
                }

                char c = word[index];

                if (c == '.')
                {
                    foreach (var child in node.Children.Values)
                    {
                        if (Search(word, index + 1, child))
                        {
                            return true;
                        }
                    }
                }
                else if (node.Children.ContainsKey(c))
                {
                    return Search(word, index + 1, node.Children[c]);
                }

                return false;
            }
        }