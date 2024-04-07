//Leetcode 2516. Take K of Each Character From Left and Right  med
//题意：给定一个字符串 s，由字符 'a'、'b' 和 'c' 构成，以及一个非负整数 k。每分钟，你可以从字符串 s 的左端或右端取一个字符。
//返回至少需要多少分钟，你才能取得至少 k 个每个字符，如果无法取得 k 个每个字符，则返回 -1。
//思路：hashtable, sliding window, 先把s中的abc的出现频率找出，然后是否满足k
//然后滑窗，我们只要外部abc个数要满足大或等于k，这样，滑窗以外的的个数就算被移走的时间，
//这样找的最小满足的；       
//时间复杂度：O(n)
//空间复杂度：O(1)
        public int TakeCharacters(string s, int k)
        {
            int n = s.Length;
            //freq of a, b, c
            int[] freq = new int[3];
            foreach (char c in s)
            {
                freq[c - 'a']++;
            }

            if (freq[0] < k || freq[1] < k || freq[2] < k)
                return -1;

            int result = n;

            int left = 0;
            for (int right = 0; right < n;)
            {
                freq[s[right] - 'a']--;
                right++;
                while ((freq[0] < k || freq[1] < k || freq[2] < k) && left < right)
                {
                    freq[s[left] - 'a']++;
                    left++;
                }
                result = Math.Min(result, n - (right - left));
            }
            return result;
        }
