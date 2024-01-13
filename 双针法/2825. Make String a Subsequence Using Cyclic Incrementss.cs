//Leetcode 2825. Make String a Subsequence Using Cyclic Incrementss med
//题意：给定两个字符串 str1 和 str2。
//在一个操作中，你可以选择 str1 中的一些索引，对每个索引 i，在 str1[i] 上进行循环递增。也就是说，'a' 变成 'b'，'b' 变成 'c'，以此类推，'z' 变成 'a'。
//如果通过最多一次操作，可以使 str2 成为 str1 的子序列，则返回 true；否则返回 false。
//注意：子序列是通过删除一些（可能为空）字符而形成的新字符串，而不会破坏剩余字符的相对位置。
//思路：左右针，两个指针 i 和 j，分别指向 str1 和 str2 的起始位置
//注：代码处理字符转换的三种情况：精确匹配、与递增的 ASCII 值匹配以及与递减的 ASCII 值匹配
//时间复杂度: O(min(n, m))
//空间复杂度：O(1)
        public bool CanMakeSubsequence(string str1, string str2)
        {
            int i = 0; 
            int j = 0; 
            int n = str1.Length; 
            int m = str2.Length; 
            while (i < n && j < m)
            { 
                if (str1[i] == str2[j] || str1[i] + 1 == str2[j] || str1[i] - 25 == str2[j])
                {  
                    j++; 
                }
                i++; 
            }
            return j == m; // return true if j is equal to m else return false
        }
