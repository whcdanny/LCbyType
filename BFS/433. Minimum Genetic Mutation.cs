//Leetcode 433. Minimum Genetic Mutation med
//题意：给定两个字符串 start 和 end，以及一个字符串数组 bank，字符串 bank 中的元素表示可以进行基因变化的基因序列。每次只能变化一个基因，并且只能使用 bank 中的基因序列进行变化。求从 start 变化到 end 的最小变化次数，如果无法变化到 end，则返回 -1。
//思路：(BFS)来解决。首先，将 start 添加到队列中，并初始化变化次数为 0。然后，进行 BFS 搜索，每次取出队列中的一个元素，遍历 bank 中的基因序列，如果与当前基因序列只有一个字符不同，则将其添加到队列中，并将变化次数加一。直到找到 end 或者队列为空为止。
//时间复杂度: 每个基因序列都可能成为当前节点的下一层节点，因此时间复杂度是 O(N * L^2)，其中 N 是 bank 中基因序列的数量，L 是基因序列的长度。
//空间复杂度：O(N)
        public int MinMutation(string startGene, string endGene, string[] bank)
        {
            HashSet<string> bankSet = new HashSet<string>(bank);
            if (!bankSet.Contains(endGene))
            {
                return -1; // end 不在 bank 中，无法变化到 end
            }

            char[] mutationOptions = { 'A', 'C', 'G', 'T' };
            Queue<string> queue = new Queue<string>();
            queue.Enqueue(startGene);
            int mutations = 0;

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    string current = queue.Dequeue();
                    if (current == endGene)
                    {
                        return mutations; // 已经变化到 end
                    }

                    char[] currentArray = current.ToCharArray();
                    for (int j = 0; j < currentArray.Length; j++)
                    {
                        char originalChar = currentArray[j];
                        foreach (char mutation in mutationOptions)
                        {
                            if (mutation != originalChar)
                            {
                                currentArray[j] = mutation;
                                string mutated = new string(currentArray);
                                if (bankSet.Contains(mutated))
                                {
                                    queue.Enqueue(mutated);
                                    bankSet.Remove(mutated); // 避免重复变化
                                }
                            }
                        }
                        currentArray[j] = originalChar; // 恢复原始字符
                    }
                }
                mutations++;
            }

            return -1; // 无法变化到 end
        }