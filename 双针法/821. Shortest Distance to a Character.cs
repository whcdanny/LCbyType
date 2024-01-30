//Leetcode 821. Shortest Distance to a Character ez
//题意：给定一个字符串 s 和一个在 s 中出现的字符 c，返回一个整数数组 answer，其中 answer.length == s.length，且 answer[i] 表示从索引 i 到字符串 s 中字符 c 最近的距离。
//两个索引 i 和 j 之间的距离是 abs(i - j)，其中 abs 是绝对值函数。
//思路：双指针，i表示从同开始找，j找到c在s中的位置，并确认跟i之间的距离，找到最小的；
//时间复杂度：O(n^2)，其中s的长度
//空间复杂度：O(n)
        public int[] ShortestToChar(string s, char c)
        {
            List<int> ans = new List<int>();
            for (int i = 0; i < s.Length; i++)
            {
                int distance = int.MaxValue;
                for (int j = 0; j < s.Length; j++)
                    if (s[j] == c && distance > Math.Abs(j - i))
                        distance = Math.Abs(j - i);
                ans.Add(distance);
            }
            return ans.ToArray();
        }