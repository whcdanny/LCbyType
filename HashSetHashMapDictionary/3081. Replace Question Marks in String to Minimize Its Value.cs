//Leetcode 3081. Replace Question Marks in String to Minimize Its Value med
//题意：给定一个字符串s，其中s[i]要么是小写英文字母，要么是'?'。
//对于一个只包含小写英文字母的字符串t，定义函数cost(i)表示在索引i之前（包括i）出现的与t[i]相等的字符的数量。
//字符串t的值是所有索引i的cost(i)之和。现在要求将s中所有的'?'替换为小写英文字母，使得s的值最小。如果有多个替换方案使得值最小，则返回字典序最小的方案。
//思路：hashtable，先把所有字母出现的个数算出来；
//然后找出每个s上的char的？找出每个位置当前的最小出现频率的字母和要替换位置的个数；
//然和再扫一遍s，把？改成replace的字母；
//时间复杂度：O(n)。
//空间复杂度：O(n)
        public string MinimizeStringValue(string s)
        {
            var letters = new int[26];
            var replacers = new int[26];

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '?') letters[s[i] - 'a']++;
            }

            var str = s.ToCharArray();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '?') continue;

                var minFreq = int.MaxValue;
                var minIndex = 0;

                for (int j = 0; j < letters.Length; j++)
                {
                    if (letters[j] < minFreq)
                    {
                        minFreq = letters[j];
                        minIndex = j;
                    }
                }

                letters[minIndex]++;
                replacers[minIndex]++;
            }

            for (int i = 0, j = 0; i < str.Length; i++)
            {
                if (str[i] != '?') continue;

                while (replacers[j] == 0) j++;
                str[i] = (char)(j + 'a');
                replacers[j]--;
            }

            return new string(str);
        }