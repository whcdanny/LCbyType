//Leetcode 345. Reverse Vowels of a String ez
//题意：要求翻转字符串中的元音字母
//思路：双指针，将字符串转换为字符数组，因为字符串是不可变的，而字符数组可以方便地交换元素。
//定义一个 HashSet 存储元音字母，方便判断一个字符是否为元音字母。
//使用两个指针 i 和 j 分别指向字符串的头部和尾部。
//在循环中，分别找到字符串头部和尾部的元音字母，然后交换它们。
//循环直到 i 不再小于 j。
//时间复杂度：O(n)，其中 n 是字符串的长度
//空间复杂度：O(1)
        public string ReverseVowels(string s)
        {
            char[] chars = s.ToCharArray();
            HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                while (i < j && !vowels.Contains(chars[i]))
                {
                    i++;
                }
                while (i < j && !vowels.Contains(chars[j]))
                {
                    j--;
                }

                if (i < j)
                {
                    char temp = chars[i];
                    chars[i] = chars[j];
                    chars[j] = temp;
                    i++;
                    j--;
                }
            }

            return new string(chars);
        }