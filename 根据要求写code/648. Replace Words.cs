//648. Replace Words med
//词根root，跟其他一些词组组成另一个长单词successor，给一个句子包含successor，转换为root表示；
//思路： Trie的算法；
		public class Trie
        {
            private TrieNode root;

            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    if (!node.ContainsKey(c))
                    {
                        node[c] = new TrieNode();
                    }
                    node = node[c];
                }
                node.IsWord = true;
            }

            public bool Search(string word)
            {
                TrieNode node = FindNode(word);
                return node != null && node.IsWord;
            }

            public bool StartsWith(string prefix)
            {
                return FindNode(prefix) != null;
            }

            private TrieNode FindNode(string word)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    if (!node.ContainsKey(c))
                    {
                        return null;
                    }
                    node = node[c];
                }
                return node;
            }
            public string GetRoot(string word)
            {
                TrieNode node = root;
                StringBuilder sb = new StringBuilder();
                foreach (char c in word)
                {
                    if (node.ContainsKey(c))
                    {
                        sb.Append(c);
                        node = node[c];
                        if (node.IsWord)
                        {
                            return sb.ToString();
                        }
                    }
                    else
                    {
                        return word;
                    }
                }
                return word;
            }
        }

        public class TrieNode
        {
            private TrieNode[] children;
            public bool IsWord { get; set; }

            public TrieNode()
            {
                children = new TrieNode[26];
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

        public string ReplaceWords(IList<string> dictionary, string sentence)
        {
            Trie trie = new Trie();
            foreach (string word in dictionary)
            {
                trie.Insert(word);
            }

            string[] words = sentence.Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = trie.GetRoot(words[i]);
            }

            return string.Join(' ', words);
        }