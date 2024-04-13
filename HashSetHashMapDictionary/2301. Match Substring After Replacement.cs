//Leetcode 2301. Match Substring After Replacement hard
//题意：要求在给定字符串 s 和子串 sub 的情况下，根据给定的字符映射 mappings，判断是否可以通过替换 sub 中的字符来使其成为 s 的子串。
//其中，每个字符在 sub 中最多只能被替换一次。
//具体地，我们可以通过替换 sub 中的字符来构造一个新的字符串，然后判断这个新字符串是否为 s 的子串。如果能够找到一个这样的字符串，则返回 true，否则返回 false。
//思路：hashtable 暴力算法，然后将mapping存入一个bool[,]，
//然后从开始位置和结束位置，每个找出的区间跟sub做匹配，并且跟mapping是否能转化，然后就是true
//时间复杂度：O(n^2)，其中 n 为消息字符串的长度。
//空间复杂度：O(26)
        public bool MatchReplacement(string s, string sub, char[][] mappings)
        {
            int m = s.Length;
            bool[,] table = new bool[256, 256];
            foreach (var x in mappings)
            {
                table[x[0], x[1]] = true;
            }

            for (int start = 0; start < s.Length; start++)
            {
                bool flag = true;
                for (int end = 0; end < sub.Length; end++)
                {
                    if (start + end < m && (sub[end] == s[start + end] || table[sub[end], s[start + end]]))
                    {
                        continue;
                    }

                    flag = false;
                    break;
                }
                if (flag) return true;
            }

            return false;
        }