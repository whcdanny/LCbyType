//Leetcode 2062. Count Vowel Substrings of a String ez
//题意：给定一个字符串 word，要求计算其中只包含所有五个元音字母（'a', 'e', 'i', 'o', 'u'）的子串的数量。
//思路：hashtable hashset来存每个寻找的区间内连续的元音字母；
//j为右边界，i为初始位置；
//只要是连续的元音，然后就j++，如果此时hashset刚好是5个，那么就是所有都在里面，满足条件+1；
//如果不是连续，那么就更新j=++i；
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int CountVowelSubstrings(string word)
        {
            int count = 0;
            HashSet<char> vowels = new HashSet<char>();
            int i = 0;
            int j = 0;

            while (j < word.Length)
            {
                char letter = word[j];

                if (!IsVowel(letter))
                {
                    vowels.Clear();
                    j = ++i;
                }
                else
                {

                    vowels.Add(letter);

                    if (vowels.Count == 5)
                    {
                        count++;
                    }

                    if (j == word.Length - 1)
                    {
                        vowels.Clear();
                        j = ++i;
                    }
                    else
                    {
                        j++;
                    }
                }
            }

            return count;
        }

        private bool IsVowel(char c)
        {
            return
                c == 'a' ||
                c == 'e' ||
                c == 'i' ||
                c == 'o' ||
                c == 'u';
        }