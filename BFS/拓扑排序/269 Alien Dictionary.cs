//Leetcode 269 Alien Dictionary hard
//题意：给定一个由小写字母组成的字符串列表 words，以及一个小写字母的字母表顺序表。判断是否可以根据字母表顺序表重新排列 words 中的单词，使得它们构成一个有效的字典。
//思路：拓扑排序,可以将字母表顺序表转化成一个有向图，其中图的节点是字母，边表示字母之间的相对顺序关系.构建一个字典 graph 用来存储字母之间的关系，以及一个字典 inDegree 用来记录每个节点的入度。遍历单词列表 words，对于相邻的两个单词 word1 和 word2，找到它们第一个不相等的字符，即 char1 和 char2。在图中添加一条从 char1 到 char2 的有向边，并更新入度。
//时间复杂度: 单词的总长度为 m，单词数量为 n, O(m + n)
//空间复杂度：字典 graph 和 inDegree 分别占用了 O(26) 的空间，因此总空间复杂度为 O(1)。
        public string AlienOrder(string[] words)
        {
            Dictionary<char, HashSet<char>> graph = new Dictionary<char, HashSet<char>>();
            Dictionary<char, int> inDegree = new Dictionary<char, int>();
            foreach(string word in words)
            {
                foreach(char c in word)
                {
                    if (!graph.ContainsKey(c))
                    {
                        graph[c] = new HashSet<char>();
                        inDegree[c] = 0;
                    }
                }
            }

            for(int i = 0; i < words.Length - 1; i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];
                int j = 0;
                while(j < word1.Length && j < word2.Length && word1[j] == word2[j])
                {
                    j++;
                }
                if (j < word1.Length && j < word2.Length)
                {
                    char char1 = word1[j];
                    char char2 = word2[j];
                    if (!graph[char1].Contains(char2))
                    {
                        graph[char1].Add(char2);
                        inDegree[char2]++;
                    }
                }
            }

            Queue<char> queue = new Queue<char>();
            foreach(var node in inDegree.Keys)
            {
                if (inDegree[node] == 0)
                {
                    queue.Enqueue(node);
                }
            }

            StringBuilder result = new StringBuilder();
            while (queue.Count > 0)
            {
                char node = queue.Dequeue();
                foreach(var neighbor in graph[node])
                {
                    inDegree[neighbor]--;
                    if (inDegree[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                    }
                }
            }            

            return result.Length == graph.Count ? result.ToString() : "";
        }