//Leetcode 409. Longest Palindrome ez
//题意：包含大小写字母的字符串，我们可以通过重新排列字符的顺序，使其变成一个回文串。求解可以构成的最长回文串的长度。
//思路：哈希表,首先遍历字符串 s，统计每个字符出现的次数，并将其存储在哈希表中。然后遍历哈希表，计算出现次数为偶数的字符个数，这些字符可以全部使用在构成回文串中。同时，如果存在出现次数为奇数的字符，可以选择其中一个作为回文串的中心字符，因此还需要判断是否存在出现次数为奇数的字符。如果存在，将其计数减一，将其余的字符个数加入到回文串的长度中。最后，如果存在至少一个出现次数为奇数的字符，将回文串的长度加一。
//时间复杂度:  n 是字符串的长度, 时间复杂度是 O(n)。
//空间复杂度： O(1)  
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
		
		 public int LongestPalindrome_2p(string s)
        {
            int[] counts = new int[128]; // 用数组作为哈希表存储字符出现的次数
            int left = 0, right = s.Length - 1;
            int length = 0;

            // 统计字符出现的次数
            foreach (char c in s)
            {
                counts[c]++;
            }

            while (left <= right)
            {
                if (s[left] == s[right])
                {
                    length += 2;
                    left++;
                    right--;
                }
                else
                {
                    // 判断哪个字符出现的次数更多，将对应的指针向另一个指针移动
                    if (counts[s[left]] > counts[s[right]])
                    {
                        length++;
                        left++;
                    }
                    else
                    {
                        length++;
                        right--;
                    }
                }
            }

            if (left == right)
            {
                length++; // 如果剩余一个字符，则将其加入回文串
            }

            return length;