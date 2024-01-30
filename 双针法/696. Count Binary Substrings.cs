//Leetcode 696. Count Binary Substrings ez
//题意：给定一个二进制字符串 s，要求返回具有相同数量的 0 和 1，并且所有 0 和所有 1 在这些子字符串中都是连续分组的非空子字符串数量。
//思路：双指针，两个变量 prevCount 和 currCount 分别表示上一个数字连续分组的数量和当前数字连续分组的数量，初始化 currCount 为 1。
//从字符串的第二个字符开始遍历，比较当前字符和前一个字符：
//如果当前数字与前一个数字相同，增加当前数字连续分组的数量 currCount。
//如果当前数字与前一个数字不同，更新上一个数字连续分组的数量 prevCount 为当前数字连续分组的数量 currCount，并重置 currCount 为 1。
//在遍历过程中，如果上一个数字连续分组的数量大于等于当前数字连续分组的数量，说明可以构成有效的子字符串，将计数器 count 增加。
//时间复杂度：O(n)，其中 n 是字符串的长度
//空间复杂度：O(1)
        public int CountBinarySubstrings(string s)
        {
            int count = 0;
            int prevCount = 0;  // 记录上一个数字连续分组的数量
            int currCount = 1;  // 记录当前数字连续分组的数量

            for (int i = 1; i < s.Length; i++)
            {
                // 如果当前数字与前一个数字相同，增加当前数字连续分组的数量
                if (s[i] == s[i - 1])
                {
                    currCount++;
                }
                else
                {
                    // 否则，当前数字与前一个数字不同，更新上一个数字连续分组的数量为当前数字连续分组的数量
                    prevCount = currCount;
                    currCount = 1;
                }

                // 如果上一个数字连续分组的数量大于等于当前数字连续分组的数量，说明可以构成有效的子字符串
                if (prevCount >= currCount)
                {
                    count++;
                }
            }

            return count;
        }