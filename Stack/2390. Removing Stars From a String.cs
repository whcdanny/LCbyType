//Leetcode 2390. Removing Stars From a String med
//题意：给定一个字符串s，其中包含星号*。
//在一个操作中，你可以：
//选择字符串s中的一个星号。
//移除其左侧最近的非星号字符，以及移除星号本身。
//返回移除所有星号后的字符串。
//注意：
//输入数据保证每次操作都是可行的。
//结果字符串将始终是唯一的。
//思路：Stack; 用stack来存字母；如果遇到*，stack就pop一个
//最后得到的再反转一下；
//时间复杂度：O(n)，其中n为字符串s的长度，因为需要遍历整个字符串。
//空间复杂度：O(n)，最坏情况下，栈的大小为字符串s中星号的数量。    
        public string RemoveStars(string s)
        {
            var charStack = new Stack<char>();
            foreach (char c in s)
            {
                if (c == '*')
                {
                    charStack.Pop();
                }
                else
                {
                    charStack.Push(c);
                }
            }
            return new string(charStack.Reverse().ToArray());
        }