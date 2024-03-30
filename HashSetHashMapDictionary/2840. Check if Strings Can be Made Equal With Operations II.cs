//Leetcode 2840. Check if Strings Can be Made Equal With Operations II med
//题意：给定两个长度为 n 的字符串 s1 和 s2，包含小写英文字母。可以对任意一个字符串应用以下操作：
//选择任意两个索引 i 和 j，其中 i<j 且索引之间的距离为偶数，然后交换字符串中这两个索引处的字符。
//要求判断是否能通过应用上述操作，使得字符串 s1 和 s2 相等
//思路：hashtable 只要把s1和s2奇数位置和偶数位置的每个字母总和进行比较，
//如果s1和s2奇数位置上，s1遇到字母+1，s2遇到字母-1；如果最终26字母都是0，说明s1的奇数位置我肯定可以保证选装之和于s2奇数位置上的所有字母都相同
//同理偶数位也一样；
//时间复杂度：O(n)
//空间复杂度：O(n)
        public bool CheckStrings(string s1, string s2)
        {
            int[] frequencyLettersAtEvenIndexes = new int[26];
            FillFrequency(0, s1, s2, frequencyLettersAtEvenIndexes);

            int[] frequencyLettersAtOddIndexes = new int[26];
            FillFrequency(1, s1, s2, frequencyLettersAtOddIndexes);

            return LettersAreSwappable(frequencyLettersAtEvenIndexes) && LettersAreSwappable(frequencyLettersAtOddIndexes);
        }


        private void FillFrequency(int startIndex, string s1, string s2, int[] frequencyLetters)
        {
            for (int i = startIndex; i < s1.Length; i += 2)
            {
                ++frequencyLetters[s1[i] - 'a'];
                --frequencyLetters[s2[i] - 'a'];
            }
        }

        private bool LettersAreSwappable(int[] frequencyLetters)
        {
            foreach (int frequency in frequencyLetters)
            {
                if (frequency != 0)
                {
                    return false;
                }
            }
            return true;
        }