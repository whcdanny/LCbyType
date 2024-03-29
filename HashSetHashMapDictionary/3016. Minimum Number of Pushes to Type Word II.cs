//Leetcode 3016. Minimum Number of Pushes to Type Word II med
//题意：给定一个字符串word，包含小写英文字母。
//电话键盘上的按键与不同的小写英文字母集合映射，可以通过按键来形成单词。
//例如，按键2与["a", "b", "c"] 映射，我们需要按一次键来输入"a"，两次键来输入"b"，三次键来输入"c"。
//允许重新映射编号为2到9的键到不同的字母集合。
//键可以重新映射到任意数量的字母，但每个字母必须映射到且仅映射到一个键。需要找到输入字符串word所需的最小按键次数。
//要求返回重新映射键后输入单词所需的最小按键次数。
//思路：hashtable, 算出每个字母的出现的频率；
//出现次数最多的字母开始，逐步减少出现次数
//根据这个规则按键2与["a", "b", "c"] 映射，我们需要按一次键来输入"a"，两次键来输入"b"，三次键来输入"c"。
//(index / 8 + 1) * counts[i] 要知道这是第几次按当前按键，一共总共能按八个键；起初是0，所以+1；
//时间复杂度：O(n)
//空间复杂度：O(26)
        public int MinimumPushes(string word)
        {
            int[] counts = new int[26];

            for (int i = 0; i < word.Length; ++i)
            {
                counts[word[i] - 'a']++;
            }

            Array.Sort(counts);

            int res = 0;
            int index = 0;
            for (int i = 25; i >= 0; --i, ++index)
            {
                res += (index / 8 + 1) * counts[i];
            }

            return res;
        }