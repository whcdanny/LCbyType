//Leetcode 3722. Lexicographically Smallest String After Reverse med
//题意：给一个s，在k的位置反转，可以反转前k个也可以反转后k个，使结果是Lexicographically Smallest
//Lexicographically Smallest：意思就是两个string A B，a[0]字母要比b[0]小，如果a[0]==b[0]就a的长度小于b的长度
//思路：string+逻辑思维+双针法。先找到最小字符在s中，用于后面的ReversePrefix和ReverseSuffix
//情况一：全反转 (k = n)无论是前缀还是后缀反转 k=n，结果都是整个字符串反转
//情况二：前缀反转 只有当 s[k-1] 是最小字符时，反转后的字符串才可能更小
//情况三：后缀反转除非 s[0] 本身就是最小字符，否则这种反转通常没有竞争力。
//时间复杂度:  O(n*m)，n是字符串长度，m是满足minChar条件的候选k的数量。在最差情况下（全 'a'）O(n^2)
//空间复杂度： O(n)
        public string LexSmallest(string s)//fix
        {
            int n = s.Length;
            if (n <= 1) return s;

            // 默认结果设为原字符串 (对应 k=1 的情况)
            string best = s;

            // 1. 找到字符串中的最小字符
            char minChar = 'z';
            foreach (char c in s)
            {
                if (c < minChar) 
                    minChar = c;
            }

            // 2. 情况一：全反转 (k = n)
            // 无论是前缀还是后缀反转 k=n，结果都是整个字符串反转
            char[] allArr = s.ToCharArray();
            Array.Reverse(allArr);
            string reversedAll = new string(allArr);
            if (string.CompareOrdinal(reversedAll, best) < 0)
            {
                best = reversedAll;
            }

            // 3. 情况二：前缀反转 (枚举 k)
            // 只有当 s[k-1] 是最小字符时，反转后的字符串才可能更小
            for (int k = 1; k < n; k++)
            {
                if (s[k - 1] == minChar)
                {
                    string temp = ReversePrefix_LexSmallest(s, k);
                    if (string.CompareOrdinal(temp, best) < 0)
                    {
                        best = temp;
                    }
                }
            }

            // 4. 情况三：后缀反转 (k < n)
            // 只要 k < n，后缀反转后的字符串开头依然是 s[0]。
            // 除非 s[0] 本身就是最小字符，否则这种反转通常没有竞争力。
            // 为了保险，如果 s[0] == minChar，我们可以尝试所有后缀反转。
            if (s[0] == minChar)
            {
                for (int k = 1; k < n; k++)
                {
                    string temp = ReverseSuffix_LexSmallest(s, k);
                    if (string.CompareOrdinal(temp, best) < 0)
                    {
                        best = temp;
                    }
                }
            }

            return best;
        }

        // 辅助函数：反转前 k 个字符
        private string ReversePrefix_LexSmallest(string s, int k)
        {
            char[] arr = s.ToCharArray();
            int left = 0, right = k - 1;
            while (left < right)
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
                left++; 
                right--;
            }
            return new string(arr);
        }

        // 辅助函数：反转后 k 个字符
        private string ReverseSuffix_LexSmallest(string s, int k)
        {
            char[] arr = s.ToCharArray();
            int n = s.Length;
            int left = n - k, right = n - 1;
            while (left < right)
            {
                (arr[left], arr[right]) = (arr[right], arr[left]);
                left++; 
                right--;
            }
            return new string(arr);
        }