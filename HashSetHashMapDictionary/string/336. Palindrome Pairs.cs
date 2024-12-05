//Leetcode 336. Palindrome Pairs hard
//题意：给定一个唯一字符串数组 words，寻找所有回文对。回文对满足以下条件：
//0≤i, j<words.length
//i≠j
//字符串 words[i] + words[j] 是一个回文字符串。
//要求返回所有满足条件的索引对
//(i, j)，且算法的时间复杂度要求为
//O(所有字符串长度的总和)。
//思路：用Dictionary来存每个word的reverse
//然后根据每次word，然后将word切割成 [i,j][j,len] 然后是否右其中一部分在Dictionary
//因为"lls""sssll"，所以对word进行切割
//切割左部分是回文，检查右部分反转是否存在，IsPalindrome(left) && wordMap.ContainsKey(right) && wordMap[right] != i
//result.Add(new List<int> { wordMap[right], i });
//右部分是回文，检查左部分反转是否存在,j != len && IsPalindrome(right) && wordMap.ContainsKey(left) && wordMap[left] != i
//result.Add(new List<int> { i, wordMap[left] });
//时间复杂度:  总O(n⋅m^2):O(n⋅m)n是单词数,m是单词平均长度。每个单词m个分割点，每次检查是否回文O(m)
//空间复杂度： O(n⋅m)
        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var result = new List<IList<int>>();
            var wordMap = new Dictionary<string, int>();

            // 构建反转哈希表
            for (int i = 0; i < words.Length; i++)
            {
                wordMap[Reverse_PalindromePairs(words[i])] = i;
            }

            // 遍历每个单词
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int len = word.Length;

                // 尝试所有可能的分割点
                for (int j = 0; j <= len; j++)
                {
                    string left = word.Substring(0, j);
                    string right = word.Substring(j);

                    // 左部分是回文，检查右部分反转是否存在
                    if (IsPalindrome_PalindromePairs(left) && wordMap.ContainsKey(right) && wordMap[right] != i)
                    {
                        result.Add(new List<int> { wordMap[right], i });
                    }

                    // 右部分是回文，检查左部分反转是否存在
                    // 额外判断 j != len 是为了避免重复情况
                    if (j != len && IsPalindrome_PalindromePairs(right) && wordMap.ContainsKey(left) && wordMap[left] != i)
                    {
                        result.Add(new List<int> { i, wordMap[left] });
                    }
                }
            }

            return result;
        }
        // 判断是否为回文
        private bool IsPalindrome_PalindromePairs(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s[left++] != s[right--]) return false;
            }
            return true;
        }

        // 反转字符串
        private string Reverse_PalindromePairs(string s)
        {
            char[] chars = s.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }