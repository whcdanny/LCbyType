//Leetcode 1147. Longest Chunked Palindrome Decomposition hard
//题意：给定一个字符串 text，要求将其分割成若干个子字符串（subtext1, subtext2, ..., subtextk），满足以下条件：
//subtexti 是一个非空字符串。
//所有子字符串的拼接应该等于原始字符串（即，subtext1 + subtext2 + ... + subtextk == text）。
//对于所有合法的 i（1 <= i <= k），都应该满足 subtexti == subtextk - i + 1。
//要求返回满足条件的子字符串的最大数量 k。
//思路：双指针，开头和结尾分别取相等长度的前缀和后缀，然后比较它们是否相等。如果相等，说明找到了一个符合条件的子字符串，将答案加2。然后，将字符串中已经处理的部分截掉，继续检查新的字符串。
//时间复杂度： O(n)，其中 n 为字符串的长度
//空间复杂度：O(1)
        public int LongestDecomposition(string text)
        {
            int answer = 1;
            int n = text.Length;

            for (int idx = 1; idx <= n / 2; idx++)
            {
                string prefix = text.Substring(0, idx);
                string suffix = text.Substring(n - idx);

                if (prefix == suffix)
                {
                    answer += 2;
                    text = text.Substring(idx, n - 2 * idx);
                    idx = 0;
                    n = text.Length;
                    if (string.IsNullOrWhiteSpace(text))
                    {
                        answer--;
                    }
                }
            }

            return answer;
        }