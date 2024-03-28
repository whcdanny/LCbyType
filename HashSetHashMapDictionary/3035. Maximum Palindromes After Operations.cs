//Leetcode 3035. Maximum Palindromes After Operations med
//题意：给定一个长度为n的字符串数组words，每个字符串都是由小写字母组成的。
//可以执行以下操作任意次数（包括零次）：
//选择整数i、j、x和y，使得0 <= i, j<n，0 <= x<words[i].length，0 <= y<words[j].length，并交换字符words[i][x]和words[j][y]。
//返回执行一些操作后words能包含的最大回文字符串的数量。
//思路：hashtable, 计算出每个字母出现的个数，因为要成对，所以再把每个字母出现的总个数除以2找出能凑出对少相同字母的对儿；
//然后给每个word排序，从小到大；然后如果排完序的word长度小于pairs就证明可以组成一个回文字符串；      
//时间复杂度：O(m*n) ; n = words.Length, m = words[i].Length
//空间复杂度：O(n)
        public int MaxPalindromesAfterOperations(string[] words)
        {
            int res = 0;
            int pairs = 0;
            int[] c = new int[26];
            List<string> list = new List<string>();

            foreach (var s in words)
            {
                list.Add(s);
                foreach (var x in s)
                    c[x - 'a']++;
            }

            for (int i = 0; i < 26; i++)
                pairs += c[i] / 2;

            list.Sort((a, b) => a.Length.CompareTo(b.Length));

            for (int i = 0; i < list.Count(); i++)
            {
                if (pairs >= list[i].Length / 2)
                {
                    pairs -= list[i].Length / 2;
                    res++;
                }
            }

            return res;
        }