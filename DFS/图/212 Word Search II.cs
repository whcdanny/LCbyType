//Leetcode 212 Word Search II hard
//题意：给定一个字母矩阵 board 和一个包含单词的列表 words，找出列表中所有存在于字母矩阵中的单词。z单词必须按照字母的相对顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。同一个单元格内的字母不允许被重复使用。
//思路：深度优先搜索（DFS）: 首先，将所有单词构建成一个前缀树。遍历整个字母矩阵，对于每一个位置，开始进行 DFS 搜索：每次搜索时，将当前位置的字母拼接到一个字符串中，然后从前缀树中查找是否存在以这个字符串为前缀的单词。如果存在，则将该单词添加到结果集中，并将前缀树中该单词的节点标记为已访问，以避免重复搜索。
//时间复杂度:  m 行 n 列，单词列表中一共有 k 个单词，平均单词长度为 l。前缀树构建的时间复杂度是 O(k * l)。DFS 搜索的时间复杂度是 O(m* n * 4^l)，其中 4^l 表示每个位置有四个可能的相邻位置。总的时间复杂度是 O(k* l + m* n * 4^l)。
//空间复杂度： O(k * l)
        public class TrieNode
        {
            public TrieNode[] Children;
            public string Word;

            public TrieNode()
            {
                Children = new TrieNode[26];
                Word = null;
            }
        }


        private TrieNode BuildTrie(string[] words)
        {
            TrieNode root = new TrieNode();
            foreach (string word in words)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    int index = c - 'a';
                    if (node.Children[index] == null)
                    {
                        node.Children[index] = new TrieNode();
                    }
                    node = node.Children[index];
                }
                node.Word = word;
            }
            return root;
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            TrieNode root = BuildTrie(words);
            HashSet<string> result = new HashSet<string>();

            void FindWords_DFS(int i, int j, TrieNode node)
            {
                char c = board[i][j];
                board[i][j] = '#';
                TrieNode child = node.Children[c - 'a'];

                if (child != null)
                {
                    if (child.Word != null)
                    {
                        result.Add(child.Word);
                        child.Word = null;
                    }

                    int[][] directions = { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
                    foreach (int[] dir in directions)
                    {
                        int ni = i + dir[0];
                        int nj = j + dir[1];
                        if (ni >= 0 && ni < board.Length && nj >= 0 && nj < board[0].Length && board[ni][nj] != '#')
                        {
                            FindWords_DFS(ni, nj, child);
                        }
                    }
                }

                board[i][j] = c;
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    FindWords_DFS(i, j, root);
                }
            }

            return result.ToList();
        }