 //Leetcode 1087 Brace Expansion med
//题意：给定一个字符串，其中包含了小写字母和花括号 {} 以及逗号 ,。花括号可以表示为一个字符的选择，逗号表示多个字符的连接。你需要将这个字符串展开成所有可能的组合。例如，对于输入 {a,b}c{d,e}f，可以生成的组合包括 acdf, acef, bcdf, bcef
//思路：深度优先搜索（DFS）: 遇到左括号 { 时，找到对应的右括号 }，之间的部分就是一个可以选择的字符集合。
//时间复杂度:  符串的长度为 n, O(n^n)
//空间复杂度： O(n)
        public string[] Expand(string S)
        {
            List<string> result = new List<string>();
            ExpandDFS(S, 0, new StringBuilder(), result);
            return result.ToArray();
        }

        private void ExpandDFS(string S, int index, StringBuilder current, List<string> result)
        {
            if (index == S.Length)
            {
                result.Add(current.ToString());
                return;
            }

            if (S[index] == '{')
            {
                int end = index;
                while (S[end] != '}') end++;

                List<char> options = new List<char>();
                for (int i = index + 1; i < end; i += 2)
                {
                    options.Add(S[i]);
                }
                options.Sort();

                foreach (char c in options)
                {
                    current.Append(c);
                    ExpandDFS(S, end + 1, current, result);
                    current.Length--;
                }
            }
            else
            {
                current.Append(S[index]);
                ExpandDFS(S, index + 1, current, result);
                current.Length--;
            }
        }