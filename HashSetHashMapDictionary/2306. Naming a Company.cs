//Leetcode 2306. Naming a Company hard
//题意：给定一个字符串数组 ideas，表示在命名公司的过程中要使用的名称列表。命名公司的过程如下：
//从 ideas 中选择两个不同的名称，称它们为 ideaA 和 ideaB。
//将 ideaA 和 ideaB 的第一个字母互换。
//如果新名称都不在原始的 ideas 中，则 ideaA 和 ideaB 的组合（用空格分隔的字符串）是一个有效的公司名称。
//否则，它不是一个有效的名称。
//返回有效公司名称的数量。
//思路：hashtable 用hashset的list来存每一个字母开头和其有的substring从第二位开始的；
//然后不同的两个首字母，然后先找到有相同的substring，
//然后answer += 2 * (groups[i].Count - sameSubstring) * (groups[j].Count - sameSubstring);
//时间复杂度：O(n^2)，其中 n 为消息字符串的长度。
//空间复杂度：O(26)
        public long DistinctNames(string[] ideas)
        {
            HashSet<string>[] groups = new HashSet<string>[26];
            for (int i = 0; i < 26; i++)
            {
                groups[i] = new HashSet<string>();
            }

            foreach (var idea in ideas)
            {
                groups[idea[0] - 'a'].Add(idea.Substring(1));
            }

            long answer = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 26; j++)
                {
                    int sameSubstring = 0;
                    foreach (var ideaA in groups[i])
                    {
                        if (groups[j].Contains(ideaA))
                        {
                            sameSubstring++;
                        }
                    }

                    answer += 2 * (groups[i].Count - sameSubstring) * (groups[j].Count - sameSubstring);
                }
            }

            return answer;
        }