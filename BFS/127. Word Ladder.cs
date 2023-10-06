//Leetcode 27. Word Ladder hard
//题意：给定两个单词（beginWord 和 endWord）和一个字典，找出从 beginWord 到 endWord 的最短转换序列的长度，转换需要遵循如下规则：每次只能改变一个字母。转换过程中的中间单词必须是字典中的单词。
//思路：广度优先搜索（BFS）序列化： beginWord 开始，将其添加到队列中，并标记为已访问。然后，我们开始遍历队列中的单词，对于每个单词，我们尝试将其每一个字母替换成 a 到 z 中的某一个字母，看是否存在于字典中，并且没有被访问过。如果是，则将新的单词添加到队列中，并更新其路径长度。
//时间复杂度: 单词列表中有 n 个单词，每个单词的长度为 m, O(n*m^2)
//空间复杂度：O(n)
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            HashSet<string> wordSet = new HashSet<string>(wordList);
            if (!wordSet.Contains(endWord)) return 0;

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(beginWord);

            int level = 1;

            while (queue.Count > 0)
            {
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    string word = queue.Dequeue();
                    char[] wordChars = word.ToCharArray();
                    for (int j = 0; j < word.Length; j++)
                    {
                        char originalChar = wordChars[j];
                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            if (c == originalChar) continue;
                            wordChars[j] = c;
                            string newWord = new string(wordChars);
                            if (newWord == endWord) return level + 1;
                            if (wordSet.Contains(newWord))
                            {
                                queue.Enqueue(newWord);
                                wordSet.Remove(newWord);
                            }
                        }
                        wordChars[j] = originalChar;
                    }
                }
                level++;
            }

            return 0;
        }