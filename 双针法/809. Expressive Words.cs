//Leetcode 809. Expressive Words med
//题意：题目描述了一种字符串的扩展规则。有时候人们通过重复相邻字母来表示额外的情感。例如：
//"hello" -> "heeellooo"
//"hi" -> "hiiii"
//在这些字符串中，比如 "heeellooo"，我们有一组相邻的字母都是相同的："h"，"eee"，"ll"，"ooo"。
//给定一个字符串 s 和一个查询字符串数组 words。一个查询字符串是“可伸展的”（stretchy），如果可以通过以下扩展操作的任意次数使其等于 s：
//选择一个由字符 c 组成的组，并添加一些字符 c 到该组，使得该组的大小为三个或更多。
//例如，从 "hello" 开始，我们可以对组 "o" 进行扩展，得到 "hellooo"，但我们不能得到 "helloo"，因为组 "oo" 的大小小于三。
//此外，我们还可以进行另一次扩展，比如 "ll" -> "lllll"，得到 "helllllooo"。
//如果 s = "helllllooo"，那么查询字符串 "hello" 就是可伸展的，因为通过这两次扩展操作：query = "hello" -> "hellooo" -> "helllllooo" = s。
//要求返回可伸展的查询字符串的数量。
//思路：双指针，遍历查询字符串数组 words，对每个查询字符串调用 IsStretchy 方法判断是否可伸展。
//在 IsStretchy 方法中，使用两个指针 i 和 j 分别指向字符串 s 和查询字符串 word。
//在循环中，比较 s[i] 和 word[j]，如果相同，分别计算 s 和 word 中相邻字符的连续数量。
//根据题目规定的扩展规则，判断是否满足条件。
//更新指针位置，继续循环，直到其中一个字符串遍历完成。
//如果两个字符串都遍历完成，且满足条件，返回 true，否则返回 false。
//时间复杂度：O(N * M)，其中 N 是查询字符串数组的长度，M 是字符串的最大长度
//空间复杂度：O(1)
        public int ExpressiveWords(string s, string[] words)
        {
            int count = 0;

            foreach (string word in words)
            {
                if (IsStretchy(s, word))
                {
                    count++;
                }
            }

            return count;
        }
        private bool IsStretchy(string s, string word)
        {
            int i = 0, j = 0;

            while (i < s.Length && j < word.Length)
            {
                if (s[i] == word[j])
                {
                    int countS = CountConsecutive(s, i);
                    int countWord = CountConsecutive(word, j);

                    if (countS < 3 && countS != countWord || countS >= 3 && countS < countWord)
                    {
                        return false;
                    }

                    i += countS;
                    j += countWord;
                }
                else
                {
                    return false;
                }
            }

            return i == s.Length && j == word.Length;
        }

        private int CountConsecutive(string str, int start)
        {
            int end = start;

            while (end < str.Length && str[end] == str[start])
            {
                end++;
            }

            return end - start;
        }