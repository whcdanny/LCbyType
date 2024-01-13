//Leetcode 2938. Separate Black and White Balls med
//题意：给定一个字符串 s，其中字符 '1' 代表黑色球，字符 '0' 代表白色球。每一步，你可以选择两个相邻的球进行交换。要求返回将所有黑色球移到右边，所有白色球移到左边所需的最小步数。
//思路：左右针，i为白，j为黑，然后先找到左边第一个黑球和右边第一个白球，然后交换的是j-i因为每一次只能换一个位置，然后依此；
//时间复杂度: O(n)，其中 n 为字符串长度。遍历字符串一次，每次操作花费常数时间。
//空间复杂度：O(1)
        public long MinimumSteps(string s)
        {
            long res = 0;
            int i = 0, j = s.Length - 1;

            while (i < j)
            {
                while (i < s.Length && s[i] == '0') i++;
                while (j >= 0 && s[j] == '1') j--;

                if (i < j && s[i] == '1' && s[j] == '0')
                {
                    res += j - i;
                    i++; j--;
                }
            }

            return res;
        }
        public long MinimumSteps1(string s)
        {
            long res = 0;
            int i = 0, j = s.Length - 1;

            var sb = new StringBuilder(s);

            while (j > i)
            {
                while (j >= 0 && sb[j] == '1') j--;
                while (i < sb.Length && sb[i] == '0') i++;

                if (i >= j) break;

                if (sb[i] == '1' && sb[j] == '0')
                {
                    sb[i] = '0';
                    sb[j] = '1';
                    res += j - i;
                    i++; j--;
                }
            }

            return res;
        }