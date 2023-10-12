//Leetcode 126 Word Ladder II hard
//题意：在给定开始单词和结束单词的情况下，找到从开始单词到结束单词的最短变换序列，并返回所有可能的最短序列。每次只能更改一个字母，并且中间过程的单词必须是词汇表中的有效单词。
//思路：广度优先搜索（BFS）和深度优先搜索（DFS）BFS 构建一个单词变换的图，从开始单词开始，逐层向外扩展，直到找到结束单词或者无法继续扩展。在构建图的过程中，需要记录每个单词的前驱单词列表，用于后续的 DFS 阶段.DFS 来从结束单词回溯到开始单词，构建最短变换序列.递归地生成从结束单词到开始单词的最短序列，注意处理多条路径的情况
//时间复杂度:   n 是单词列表的长度，l 是单词的长度, O(n^2*l)
//空间复杂度： n 是单词列表的长度, O(n^2)
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList)
        {
            IList<IList<string>> result = new List<IList<string>>();
            HashSet<string> wordSet = new HashSet<string>(wordList);
            //记录每个单词的前驱单词列表
            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
            //记录每个单词到开始单词的距离
            Dictionary<string, int> distances = new Dictionary<string, int>();

            if (!wordSet.Contains(endWord))
            {
                return result;
            }

            FindLadders_BFS(beginWord, endWord, wordSet, graph, distances);
            FindLadders_DFS(endWord, beginWord, graph, distances, new List<string> { endWord }, result);

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = result[i].Reverse().ToList();
            }
            return result;
        }

        private void FindLadders_BFS(string beginWord, string endWord, HashSet<string> wordSet, Dictionary<string, List<string>> graph, Dictionary<string, int> distances)
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);
            distances[beginWord] = 0;

            foreach (var word in wordSet)
            {
                graph[word] = new List<string>();
            }
            HashSet<string> visited = new HashSet<string>();
            bool found = false;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                

                for (int i = 0; i < size; i++)
                {
                    string currentWord = queue.Dequeue();
                    visited.Add(currentWord);
                    char[] wordArray = currentWord.ToCharArray();

                    for (int j = 0; j < currentWord.Length; j++)
                    {
                        char originalChar = wordArray[j];

                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (c == originalChar) continue;

                            wordArray[j] = c;
                            string nextWord = new string(wordArray);

                            if (wordSet.Contains(nextWord))
                            {
                                graph[nextWord].Add(currentWord);

                                if (!distances.ContainsKey(nextWord))
                                {
                                    distances[nextWord] = distances[currentWord] + 1;

                                    if (nextWord == endWord)
                                    {
                                        found = true;
                                    }
                                    else
                                    {
                                        if (!visited.Contains(nextWord))
                                            queue.Enqueue(nextWord);
                                    }
                                }
                            }
                        }

                        wordArray[j] = originalChar;
                    }
                }

                if (found)
                {
                    break;
                }
            }
        }

        private void FindLadders_DFS(string currentWord, string endWord, Dictionary<string, List<string>> graph, Dictionary<string, int> distances, List<string> path, IList<IList<string>> result)
        {
            if (currentWord == endWord)
            {
                result.Add(new List<string>(path));
                return;
            }

            if (!graph.ContainsKey(currentWord)) return;

            foreach (var nextWord in graph[currentWord])
            {
                if (distances[nextWord] == distances[currentWord] - 1)
                {
                    path.Add(nextWord);
                    FindLadders_DFS(nextWord, endWord, graph, distances, path, result);
                    path.RemoveAt(path.Count - 1);
                }
            }
        }