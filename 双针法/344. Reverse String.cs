//Leetcode 344. Reverse String ez
//题意：翻转字符串
//思路：双指针，两个指针 left 和 right 分别指向字符串的头部和尾部。
//在循环中，交换 s[left] 和 s[right] 的值。
//循环直到 left 不再小于 right。
//字符数组 s 本身被修改，无需返回值。
//时间复杂度：O(n)，其中 n 是字符串的长度
//空间复杂度：O(1)
        public void ReverseString(char[] s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }