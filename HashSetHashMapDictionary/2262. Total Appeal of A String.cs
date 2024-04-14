//Leetcode 2262. Total Appeal of A String hard
//题意：字符串的吸引力是字符串中找到的不同字符的数量。
//例如，"abbca"的吸引力是3，因为它有3个不同的字符：'a'，'b'和'c'。
//给定一个字符串 s，返回其所有子串的总吸引力。
//子串是字符串中的连续字符序列。
//思路：hashtable 
//如果同一个字符串里有多个A出现，那么为了避免重复计数，我们约定，该字符串里关于A贡献的appeal只是由最左边的A给出。那么对于位置a处的字母A而言，假设它之前最近的一个字母A位于b，如下图
//X X X A X X [A] X X X
//      j      i      n-1 n
//则确定由位置a上的A字符贡献appeal的substring，其左边界可以在“b右边”到“a左边”之间游动，其右边界可以在“a右边”到“最后一个字符右边”之间游动。所以组合的方案数是(i-j)*(n-i).
//综上，依次遍历所有的字符串nums[i]，找到该字符能贡献appeal的字符串的左右边界范围，计算组合数目。
//时间复杂度：O(n)
//空间复杂度：O(1)
        
        public long AppealSum(string s)
        {
            int n = s.Length;
            int[] lastPosition = new int[26];
            Array.Fill(lastPosition, -1);

            long ret = 0;
            for (int i = 0; i < n; i++)
            {
                int j = lastPosition[s[i] - 'a'];
                ret += (i - j) * (n - i);
                lastPosition[s[i] - 'a'] = i;
            }

            return ret;
        }