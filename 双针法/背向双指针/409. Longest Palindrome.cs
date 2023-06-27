//409. Longest Palindrome ez: 给定一个由大小写字母组成的字符串 s，找到构成最长回文串的长度
//思路：哈希表,首先遍历字符串 s，统计每个字符出现的次数，并将其存储在哈希表中。然后遍历哈希表，计算出现次数为偶数的字符个数，这些字符可以全部使用在构成回文串中。同时，如果存在出现次数为奇数的字符，可以选择其中一个作为回文串的中心字符，因此还需要判断是否存在出现次数为奇数的字符。如果存在，将其计数减一，将其余的字符个数加入到回文串的长度中。最后，如果存在至少一个出现次数为奇数的字符，将回文串的长度加一。
        public int LongestPalindrome(string s)
        {
            Dictionary<char, int> counts = new Dictionary<char, int>();
            int length = 0;

            foreach (char c in s)
            {
                if (counts.ContainsKey(c))
                    counts[c]++;
                else
                    counts[c] = 1;
            }

            bool hasOddCount = false;

            foreach (int count in counts.Values)
            {
                if (count % 2 == 0)
                    length += count;
                else
                {
                    length += count - 1;
                    hasOddCount = true;
                }
            }

            if (hasOddCount)
                length++;

            return length;
        }