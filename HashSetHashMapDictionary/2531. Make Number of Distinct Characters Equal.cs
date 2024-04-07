//Leetcode 2531. Make Number of Distinct Characters Equal med
//题意：给定两个字符串 word1 和 word2。
//每次移动可以选择两个下标 i 和 j，其中 0 <= i<word1.length 且 0 <= j<word2.length，并交换 word1[i] 和 word2[j]。
//判断是否存在一次移动后，word1 和 word2 中的不同字符数量相等。
//思路：hashtable, 两个Dictionary分别存入word1和word2出现字母的频率；得出总共有多少个不同的字母在这两个word
//然后找不同的字母，如果频率为1，就从对应的总数字母中减去，因为不符合交换，就算交换也没有意义；
//然后在找不存在相互word中的字母进行交换，检查交换之和两个总和是否相等；
//时间复杂度：O(26∗26+m+n) 
//空间复杂度：O(1)
        public bool IsItPossible(string word1, string word2)
        {
            Dictionary<char, int> word1Freq = new Dictionary<char, int>();
            Dictionary<char, int> word2Freq = new Dictionary<char, int>();

            foreach (char c in word1)
            {
                word1Freq.TryAdd(c, 0);
                word1Freq[c]++;
            }
            foreach (char c in word2)
            {
                word2Freq.TryAdd(c, 0);
                word2Freq[c]++;
            }

            int word1UniqueCharsCount = word1Freq.Count;
            int word2UniqueCharsCount = word2Freq.Count;
            foreach (var kv1 in word1Freq)
            {
                foreach (var kv2 in word2Freq)
                {
                    int word1UniqueCharsCountCurrent = word1UniqueCharsCount;
                    int word2UniqueCharsCountCurrent = word2UniqueCharsCount;

                    if (kv1.Key != kv2.Key)
                    {
                        if (kv1.Value == 1)
                            word1UniqueCharsCountCurrent--;
                        if (kv2.Value == 1)
                            word2UniqueCharsCountCurrent--;

                        if (!word2Freq.ContainsKey(kv1.Key))
                            word2UniqueCharsCountCurrent++;
                        if (!word1Freq.ContainsKey(kv2.Key))
                            word1UniqueCharsCountCurrent++;
                    }

                    if (word1UniqueCharsCountCurrent == word2UniqueCharsCountCurrent)
                        return true;
                }
            }
            return false;
        }