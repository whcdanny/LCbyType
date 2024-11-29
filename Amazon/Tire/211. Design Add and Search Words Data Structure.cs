//Leetcode 211. Design Add and Search Words Data Structure med
//题意：设计一个数据结构，支持两个操作：
//void addWord(word)：将一个单词 word 添加到数据结构中。
//bool search(word)：检查数据结构中是否存在与给定的单词 word 匹配的单词。匹配规则是可以使用点字符 '.' 来代替任何一个字母。
//思路：字典树（Trie）数据结构来解决, 在搜索时考虑使用深度优先搜索（DFS）;
//使用字典树作为底层数据结构。每个节点表示一个字母，叶子节点表示一个完整的单词。
//在 addWord 操作中，逐个插入字母构建字典树。
//在 search 操作中，递归地使用深度优先搜索。对于每个字符，如果是点字符 '.'，则需要考虑所有可能的子节点，否则只需要考虑相应的字母。
//时间复杂度: 添加单词时，时间复杂度为 O(K)，其中 K 是单词的长度。搜索单词时，时间复杂度最坏情况为 O(26^M)，其中 M 是单词中的点字符 '.' 的数量。
//空间复杂度：O(N)，其中 N 是添加到字典树中的所有字母的数量
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
                node.IsWord = true;
            }

            public bool Search(string word)
            {
                return SearchRecursive(word, 0, root);
            }

            private bool SearchRecursive(string word, int index, TrieNode node)
            {
                if (index == word.Length)
                {
                    return node.IsWord;
                }

                char c = word[index];

                if (c == '.')
                {
                    foreach (var child in node.Children.Values)
                    {
                        if (SearchRecursive(word, index + 1, child))
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (node.Children.ContainsKey(c))
                    {
                        return SearchRecursive(word, index + 1, node.Children[c]);
                    }
                }

                return false;
            }

            private class TrieNode
            {
                public Dictionary<char, TrieNode> Children { get; private set; }
                public bool IsWord { get; set; }

                public TrieNode()
                {
                    Children = new Dictionary<char, TrieNode>();
                    IsWord = false;
                }
            }

        }

        /**
         * Your WordDictionary object will be instantiated and called as such:
         * WordDictionary obj = new WordDictionary();
         * obj.AddWord(word);
         * bool param_2 = obj.Search(word);
         */