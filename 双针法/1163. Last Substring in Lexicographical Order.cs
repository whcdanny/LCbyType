//Leetcode 1163. Last Substring in Lexicographical Order hard
//题意：给定一个字符串 s，要求返回字符串中字典序最大的子串。
//思路：双指针，maxIndex 为字符串最后一个字符的索引。
//从字符串最后一个字符开始往前遍历，对于当前遍历到的字符 chars[currIndex]：
//如果 chars[currIndex] 大于 chars[maxIndex]，则更新 maxIndex 为 currIndex。
//如果 chars[currIndex] 等于 chars[maxIndex]，则需要在当前字符与 maxIndex 后面的字符中继续比较，找到字典序最大的子串。
//初始化两个指针 i 和 j 分别指向 currIndex + 1 和 maxIndex + 1。
//在循环中，比较 chars[i] 和 chars[j]，直到两者不相等或者其中一个指针达到边界。
//如果 i 到达 maxIndex 或者 j 到达字符串尾部，或者 chars[i] > chars[j]，则更新 maxIndex 为 currIndex。
//返回从 maxIndex 到字符串尾部的子串。
//注：说白了找最后一个substring是按照字母升序，第一个可以不是升序
//时间复杂度： O(n)，其中 n 为字符串的长度
//空间复杂度：O(1)

        public string LastSubstring(string s)
        {
            int maxIndex = s.Length - 1;
            char[] chars = s.ToCharArray();
            for (int currIndex = s.Length - 1; currIndex >= 0; currIndex--)
            {
                if (chars[currIndex] > chars[maxIndex])
                    maxIndex = currIndex;

                else if (chars[currIndex] == chars[maxIndex])
                {
                    int i = currIndex + 1;
                    int j = maxIndex + 1;


                    while (i < maxIndex && j < s.Length && chars[i] == chars[j])
                    {
                        i++;
                        j++;
                    }

                    if (i == maxIndex || j == s.Length || chars[i] > chars[j])
                        maxIndex = currIndex;
                }
            }

            return s.Substring(maxIndex);
        }