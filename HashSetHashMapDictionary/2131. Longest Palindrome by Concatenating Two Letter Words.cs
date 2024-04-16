//Leetcode 2131. Longest Palindrome by Concatenating Two Letter Words med
//题意：给定一个字符串数组 words，每个单词由两个小写英文字母组成。
//从 words 中选择一些元素，按任意顺序连接它们，以创建最长可能的回文字符串。每个元素最多可以选择一次。
//返回你可以创建的最长回文字符串的长度。如果无法创建任何回文字符串，则返回 0。
//思路：hashtable 用dictionary来存每个word的出现个数，然后如果word和reverse的word在dictionary中，那么就长度+4；
//注：如果本身就算一个回文，那么就最后+2；            
//时间复杂度：O(n)
//空间复杂度：O(n)
        public int LongestPalindrome(string[] words)
        {
            var length = 0;
            var isValidPalindrome = false;
            var map = new Dictionary<string, int>();

            foreach (var word in words)
                map[word] = map.GetValueOrDefault(word, 0) + 1;

            foreach (var word in words)
            {
                if (map[word] > 0)
                {
                    map[word]--;
                    var str = word[1] + "" + word[0];
                    if (map.ContainsKey(str) && map[str] > 0)
                    {
                        length += 4;
                        map[str]--;
                    }
                    else if (word == str)
                        isValidPalindrome = true;
                }
            }

            return isValidPalindrome ? length + 2 : length;
        }