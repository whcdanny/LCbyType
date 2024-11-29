//Leetcode 212 Word Search II hard
//题意：给定一个字母矩阵 board 和一个包含单词的列表 words，找出列表中所有存在于字母矩阵中的单词。
//z单词必须按照字母的相对顺序，通过相邻的单元格内的字母构成，其中“相邻”单元格是那些水平相邻或垂直相邻的单元格。
//同一个单元格内的字母不允许被重复使用。
//思路：Trie+深度优先搜索（DFS）: 
//首先，将所有单词构建成一个前缀树。
//遍历整个字母矩阵，对于每一个位置，开始进行 DFS 搜索：
//每次搜索时，将当前位置的字母拼接到一个字符串中，然后从前缀树中查找是否存在以这个字符串为前缀的单词。
//如果存在，则将该单词添加到结果集中，并将前缀树中该单词的节点标记为已访问，以避免重复搜索。
//时间复杂度:  前缀树构建的时间复杂度是 O(k * l)。DFS 搜索的时间复杂度是 O(m* n * 4^l)，其中 4^l 表示每个位置有四个可能的相邻位置。总的时间复杂度是 O(k* l + m* n * 4^l)。
//空间复杂度： O(k * l)
        public class TrieNode_212
        {
            public TrieNode_212[] Children;
            public string Word;

            public TrieNode_212()
            {
                Children = new TrieNode_212[26];
                Word = null;
            }
        }


        private TrieNode_212 BuildTrie(string[] words)
        {
            TrieNode_212 root = new TrieNode_212();
            foreach (string word in words)
            {
                TrieNode_212 node = root;
                foreach (char c in word)
                {
                    int index = c - 'a';
                    if (node.Children[index] == null)
                    {
                        node.Children[index] = new TrieNode_212();
                    }
                    node = node.Children[index];
                }
                node.Word = word;
            }
            return root;
        }
        
        public IList<string> FindWords(char[][] board, string[] words)
        {
            TrieNode_212 root = BuildTrie(words);
            HashSet<string> result = new HashSet<string>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == '#')
                        continue;
                    FindWords_DFS(board, i, j, root, result);
                }
            }

            return result.ToList();
        }
        void FindWords_DFS(char[][] board, int i, int j, TrieNode_212 node, HashSet<string> result)
        {
            char c = board[i][j];
            board[i][j] = '#';
            TrieNode_212 curNode = node.Children[c - 'a'];

            if (curNode != null)
            {
                if (curNode.Word != null)
                {
                    result.Add(curNode.Word);
                    curNode.Word = null;
                }

                int[][] directions = { new int[] { 1, 0 }, new int[] { -1, 0 }, new int[] { 0, 1 }, new int[] { 0, -1 } };
                foreach (int[] dir in directions)
                {
                    int ni = i + dir[0];
                    int nj = j + dir[1];
                    if (ni >= 0 && ni < board.Length && nj >= 0 && nj < board[0].Length && board[ni][nj] != '#')
                    {
                        FindWords_DFS(board, ni, nj, curNode, result);
                    }
                }
            }

            board[i][j] = c;
        }