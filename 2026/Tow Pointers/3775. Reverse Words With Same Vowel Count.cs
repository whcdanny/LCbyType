//Leetcode 3775. Reverse Words With Same Vowel Count med
//题意：给一个string，然后根据第一个词里出现的元音个数，如果后面单词出现的元音个数与第一个单词一样，就反转这个单词，不一样就不变。
//Vowels are 'a', 'e', 'i', 'o', and 'u'.
//思路：双针法（在反转word的时候用到），先找到第一个word的元音，然后一次找到后面元音个数与第一个一样的，然后反转
//时间复杂度:  O(n) 分割字符串 (Split): 遍历一次全量字符，耗时 $O(n)$。计算元音 (GetVowelsCount): 每个单词的每个字符都会被检查一次。所有单词长度之和等于 $n$，因此总耗时 $O(n)$。反转单词 (ReverseString): 只有符合条件的单词会被反转，且每个字符只被交换一次。最坏情况下（所有单词都需要反转），总耗时 $O(n)$。拼接字符串 (string.Join): 再次遍历所有单词及其字符进行拼接，耗时 $O(n)$。综上所述： $O(n) + O(n) + O(n) + O(n) = O(n)$。
//空间复杂度： O(n) 单词数组 (words): Split 方法会创建一个字符串数组。在 C# 中，字符串是不可变的，这些拆分出来的子字符串总共占用 $O(n)$ 的空间。字符数组 (chars): 在 ReverseString 方法中，我们为当前处理的单词创建了一个 char[]。在任何给定时刻，这个数组的大小不会超过 $n$，且随方法结束而释放，但由于我们在遍历中产生新字符串，整体空间消耗仍为 $O(n)$。最终结果: string.Join 或 StringBuilder 会构建一个长度为 $n$ 的新字符串。综上所述： 空间消耗与输入字符串的长度成正比，即 $O(n)$。
        public string ReverseWords(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            string[] words = s.Split(" ");
            int firstWordVowelsCount = getVovelsCount(words[0]);            
            for(int i = 1; i < words.Length; i++)
            {
                if (getVovelsCount(words[i]) == firstWordVowelsCount)
                {
                    words[i] = reverseString(words[i]);//fix
                }
            }
            return string.Join(" ", words);//fix
        }

        private string reverseString(string word)
        {
            char[] chars = word.ToCharArray();
            int start = 0;
            int end = chars.Length - 1;//fix
            while (start < end)
            {
                char temp = chars[start];
                chars[start] = chars[end];
                chars[end] = temp;
                start++;
                end--;
            }
            return new string(chars);//fix
        }

        public int getVovelsCount(string word)
        {
            int vowelsCount = 0;
            foreach (char c in word)//fix
            {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')//if ("aeiou".Contains(c))
                {
                    vowelsCount++;
                }
            }
            return vowelsCount;
        }