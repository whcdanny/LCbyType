//Leetcode 854. K-Similar Strings hard
//题意：题目要求在给定两个相似字符串 A 和 B 的情况下，找到将 A 转变为 B 的最小步骤数。每一步可以交换 A 中的两个字符，并且交换后的字符串仍然与 B 相似。
//思路：这是一个 BFS（广度优先搜索）的问题。我们可以从 A 开始，通过不断交换相邻字符，尝试所有可能的变换，直到得到 B。为了避免重复计算，我们可以使用一个集合 visited 来存储已经处理过的状态。对于每一步，我们可以从当前字符串开始，找到第一个不匹配的字符，然后考虑所有可以交换的字符，将其与当前不匹配的字符交换，得到一个新的字符串。将新的字符串加入队列，继续进行下一步。
//时间复杂度: 假设字符串的长度为 n，在最坏情况下，可能需要尝试 O(n^2) 次交换操作，因此时间复杂度为 O(n^2)。
//空间复杂度：O(2^n)
        public int KSimilarity(string s1, string s2)
        {
            if (s1 == s2) return 0;

            int n = s1.Length;
            HashSet<string> visited = new HashSet<string>();
            Queue<string> queue = new Queue<string>();

            visited.Add(s1);
            queue.Enqueue(s1);

            int steps = 0;

            while (queue.Count > 0)
            {
                int size = queue.Count;

                for (int i = 0; i < size; i++)
                {
                    string current = queue.Dequeue();

                    int j = 0;
                    while (j < n && current[j] == s2[j])
                    {
                        j++;
                    }

                    for (int k = j + 1; k < n; k++)
                    {
                        if (current[k] == s2[j] && current[k] != s2[k])
                        {
                            char[] next = current.ToCharArray();
                            Swap(next, j, k);
                            string nextState = new string(next);

                            if (nextState == s2)
                            {
                                return steps + 1;
                            }

                            if (!visited.Contains(nextState))
                            {
                                visited.Add(nextState);
                                queue.Enqueue(nextState);
                            }
                        }
                    }
                }

                steps++;
            }

            return -1;
        }

        private void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }