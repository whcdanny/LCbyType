//Leetcode 30. Substring with Concatenation of All Words hard
//题意：题目中文解释：
//给定一个字符串 s 和一个字符串数组 words。words 中所有字符串的长度相同。
//一个“连接字符串”是指包含 words 中所有字符串（以任意顺序排列）的一个字符串。
//例如：
//如果 words = ["ab", "cd", "ef"]，那么以下字符串是“连接字符串”：
//"abcdef", "abefcd", "cdabef", "cdefab", "efabcd", "efcdab"
//"acdbef" 不是“连接字符串”，因为它不是 words 中所有字符串的某种排列的连接。
//你需要返回所有这些“连接字符串”在字符串 s 中的起始索引的数组。返回结果可以按任意顺序排列。
//思路：滑窗+dictionary，先用Dictionary map 把words里出现每个word的个数求和
//然后因为每个word的长度固定，其实我们只需要在s[0 - wordLength]就可以了，因为后面会重复计算，
//wordLength是3，第一个不行，第二个不行，第三个不行，第四个不行的时候，其实在第一个不行的时候[0-3]的下一个是[4-7]
//所以总的外部循环只需要[0 - wordLength]
//然后在内部我们滑窗先确定left 和 right同向，和建立一个内部的dictionary currMap用于计算出现的个数
//然后right+wordLength；
//找出s中对应的词，然后查看map中是否有相同的，然后更新currMap
//如果一个word的词超出了map的个数，说明两点
//1.符合条件了，2 更新left
//1的话就看此时count是否和words的总个数一样，如果一样，说明words全在当前[left,right]区间中，res添加left
//2的话，我们需要left+wordLength，再来继续循环；
//时间复杂度:  O(n × k) k 个单词
//空间复杂度： O(k)
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            if (string.IsNullOrEmpty(s) || words == null || words.Length == 0)
            {
                return result;
            }

            var map = new Dictionary<string, int>();
            foreach(var word in words)
            {
                if (!map.ContainsKey(word))
                {
                    map[word] = 0;
                }
                map[word]++;
            }
            int wordLength = words[0].Length;
            int wordCount = words.Length;
            for (int i = 0; i < wordLength; i++)
            {
                int left = i, right = i;
                var currMap = new Dictionary<string, int>();
                int count = 0;

                while (right + wordLength <= s.Length)
                {
                    // 取出当前窗口的单词
                    string word = s.Substring(right, wordLength);
                    right += wordLength;

                    if (map.ContainsKey(word))
                    {
                        if (!currMap.ContainsKey(word))
                        {
                            currMap[word] = 0;
                        }
                        currMap[word]++;
                        count++;

                        // 如果当前单词出现次数超过预期，调整左指针
                        while (currMap[word] > map[word])
                        {
                            string leftWord = s.Substring(left, wordLength);
                            currMap[leftWord]--;
                            count--;
                            left += wordLength;
                        }

                        // 如果窗口大小正好等于 totalLength，记录结果
                        if (count == wordCount)
                        {
                            result.Add(left);
                        }
                    }
                    else
                    {
                        // 如果当前单词不在 words 中，重置窗口
                        currMap.Clear();
                        count = 0;
                        left = right;
                    }
                }

            }

            return result;
        }