//Leetcode 1750. Minimum Length of String After Deleting Similar Ends med
//题意：给定一个字符串 s，其中只包含字符 'a'、'b' 和 'c'。你可以对字符串应用以下算法任意次数：
//选择一个非空前缀，该前缀中的所有字符都相等。
//选择一个非空后缀，该后缀中的所有字符都相等。
//前缀和后缀不能在任何索引处交叉。
//前缀和后缀中的字符必须相同。
//删除前缀和后缀。
//返回执行上述操作任意次数后的字符串 s 的最小长度（可能为零）。       
//思路：双指针从字符串的两端开始，分别找到最长的相同字符前缀和后缀，然后删除这个前缀和后缀。重复这个过程，直到无法找到相同字符前缀和后缀为止。最后返回剩余字符串的长度。
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinimumLength(string s)
        {
            int left = 0, right = s.Length - 1;

            while (left < right && s[left] == s[right])
            {
                char target = s[left];
                while (left <= right && s[left] == target)
                {
                    left++;
                }
                while (left <= right && s[right] == target)
                {
                    right--;
                }
            }

            return right - left + 1;
        }