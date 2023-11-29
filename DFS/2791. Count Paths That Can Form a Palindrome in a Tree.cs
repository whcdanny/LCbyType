//Leetcode 2791. Count Paths That Can Form a Palindrome in a Tree   hard
//题意：给定一个树，树的根节点为节点0，节点编号从0到n-1。树用一个大小为n的数组parent表示，其中parent[i] 是节点i的父节点。由于节点0是根节点，parent[0] == -1。同时，给定一个长度为n的字符串s，其中s[i] 是节点i与其父节点之间的边上分配的字符。忽略s[0]。返回节点对(u, v)的数量，其中u<v，并且从u到v的路径上分配的边的字符可以重新排列成回文串。
//思路：DFS（深度优先搜索）算法，用于计算树中存在多少对节点（u, v），它们之间的路径上的字符可以重新排列成回文串
//时间复杂度:  (O(26n))，因为对于每一个(n)个节点，我们可能需要循环遍历所有26个小写英文字母来计算位掩码。
//空间复杂度： (O(n))
        public long CountPalindromePaths(IList<int> parent, string s)
        {
            var n = parent.Count;
            //创建一个数组counts，用于存储路径上各种字符组合的频次。这里使用了一个整数来表示26个字母的出现情况，将每个字母映射到一个二进制位上。
            var counts = new int[1 << 26];
            var 	 = new List<List<int>>(n);

            for (var i = 0; i < n; i++)
                adj.Add(new List<int>());

            for (var i = 1; i < n; i++)
                adj[parent[i]].Add(i);

            var result = 0L;
            var visitedValues = new List<int>();

            Dfs(0, 0);

            return result;

            void Dfs(int i, int v)
            {
                visitedValues.Add(v);
                result += counts[v];
                //遍历26个字母的二进制位，将与当前字符情况异或一个字母位后的情况在counts数组中的值加到结果上
                for (var bit = 0; bit < 26; bit++)
                    //v ^ 1 << bit 表示将 v 的第 bit 位取反
                    result += counts[v ^ 1 << bit];

                counts[v]++;

                foreach (var u in adj[i])
                {
                    /*'a' 是字符 'a' 的 ASCII 码值，因此 s[u] - 'a' 表示字符 s[u] 相对于字母表中的 'a' 的位置。
                    1 << (s[u] - 'a') 表示将二进制数 1 左移 (s[u] - 'a') 位，即将二进制数 1 移到字符 s[u] 在字母表中的位置上。
                    v ^ 1 << (s[u] - 'a') 则表示将 v 的第 (s[u] - 'a') 位取反，即如果 v 的这一位是 0，则结果是 1，如果 v 的这一位是 1，则结果是 0。
                    这样的操作实际上是在对 v 的二进制表示中的某一位进行取反，用于更新字符情况。在这段代码中，它的目的是将路径上的字符情况进行异或操作，考虑字符可以重新排列成回文串的情况。*/
                    Dfs(u, v ^ 1 << s[u] - 'a');
                }
                    
            }
        }
