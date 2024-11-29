//Leetcode 208. Implement Trie (Prefix Tree) med
//题意：Trie （发音为“try”）或前缀树是一种树形数据结构，用于高效地存储和检索字符串数据集中的键。
//此数据结构有多种应用，例如自动完成和拼写检查器。
//实现 Trie 类：
//Trie()初始化 trie 对象。
//void insert(String word)将字符串插入word到字典树中。
//boolean search(String word)true如果字符串word在 trie 中（即，之前已插入），则返回，false否则返回。
//boolean startsWith(String prefix)true如果先前插入的字符串含有word前缀prefix，则返回，false否则返回。
//思路：Tire 和 TireNode（private TrieNode[] children; 和 bool isWord）
//一个字母一个字母存，然后有相同字母就存入相同的TireNode，如果不同就建立新的new TireNode
//insert：就更新TrieNode root;
//search: 先看是否可以一个字母一个字母从root里搜索出来，然后当前的node.isWord是否为true
//startsWith：同理，一个字母一个字母从root里搜索出来，不过不用考虑isWord
//时间复杂度:  全部都是O(m) m是word的长度
//空间复杂度： Insert：O(n×m) n是word总个数，m是word的长度；剩下的1；
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

        /**
         * Your Trie object will be instantiated and called as such:
         * Trie obj = new Trie();
         * obj.Insert(word);
         * bool param_2 = obj.Search(word);
         * bool param_3 = obj.StartsWith(prefix);
         */