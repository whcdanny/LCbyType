//Leetcode 2564. Substring XOR Queries med
//题意：给定一个二进制字符串 s 和一个二维整数数组 queries，其中 queries[i] = [firsti, secondi]。
//对于第 i 个查询，找到字符串 s 的最短子串，使得该子串的十进制值 val 与 firsti 进行按位异或的结果为 secondi。
//换句话说，val ^ firsti == secondi。
//如果不存在这样的子串，则第 i 个查询的答案为[-1, -1]。如果存在多个答案，选择最左边的一个。
//返回一个数组 ans，其中 ans[i] = [lefti, righti]，表示第 i 个查询的答案。
//思路：hashtable, 将s找到多个substring和出现的初始位置；
//然后根据每个queries找到要找的string，然后检查是否在substring       
//时间复杂度：O(S+Q) S being the length of the string and Q being the length of the queries array
//空间复杂度：O(S)
        public int[][] SubstringXorQueries(string s, int[][] queries)
        {
            Dictionary<string, int> subStrings = new Dictionary<string, int>();
            // int 有 32 位，所以 int 的二进制字符串永远不会超过 32 个字符。
            for (int i = 1; i <= 32; i++)
            {
                for (int j = 0; j + i <= s.Length; j++)
                {
                    string sub = s.Substring(j, i);
                    if (!subStrings.ContainsKey(sub))
                    {
                        subStrings[sub] = j;
                    }
                }
            }
            int[][] ans = new int[queries.Length][];
            for (int i = 0; i < queries.Length; i++)
            {
                int toFind = queries[i][0] ^ queries[i][1];
                string toFindBin = Convert.ToString(toFind, 2);
                if (subStrings.TryGetValue(toFindBin, out int found))
                {
                    ans[i] = new int[] { found, found + toFindBin.Length - 1 };
                }
                else
                {
                    ans[i] = new int[] { -1, -1 };
                }
            }
            return ans;
        }
