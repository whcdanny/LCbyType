//Leetcode 2716. Minimize String Length ez
//题意：题目要求我们对给定的字符串s进行操作，操作规则是选择字符串中的一个字符，然后删除其左右两侧最近的相同字符，直到无法继续操作为止，求经过操作后字符串的最小长度。
//思路：hashtable, 转成hashset
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int MinimizedStringLength(string s)
        {
            return s.ToHashSet().Count;
        }