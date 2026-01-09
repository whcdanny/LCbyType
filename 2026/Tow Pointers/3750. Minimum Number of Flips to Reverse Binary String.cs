/Leetcode 3750. Minimum Number of Flips to Reverse Binary String ez
//题意：给一个数字n，转换成binary s, 然后再反转这个s，比较这两个二进制有几个位置是不一样的数字。
//思路：双针法，先得到binary s，这里不用反转，之间left从头，right从尾部，然后一旦不同res+2就好了，因为反转就是折叠所以重复两次就好；
//时间复杂度: O(log n) Convert.ToString(n, 2) O(log n)。ToCharArray()O(log n)。while 循环：L/2，即O(log n)
//空间复杂度：O(log n)
        public int MinimumFlips(int n)
        {
            int res = 0;
            char[] sChars = Convert.ToString(n, 2).ToCharArray();
            int left = 0;
            int right = sChars.Length - 1;
            while (left < right)
            {
                if (sChars[left] != sChars[right])
                    res+=2;
                left++;
                right--;
            }
            return res;
        }